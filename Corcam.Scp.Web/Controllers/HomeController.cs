﻿using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using Corcam.Scp.Dominio.Entidades;
using Corcam.Scp.Dominio.Enum;
using Corcam.Scp.Dominio.ObjetosValor;
using Corcam.Scp.Dominio.Repositorio;
using Corcam.Scp.Infra.Transacoes;
using Corcam.Scp.Web.Model;
using Microsoft.AspNetCore.Mvc;

namespace Corcam.Scp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPacienteRepositorio _repositorio;
        public HomeController(IUow uow, IPacienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        
        public PartialViewResult ObterPacientePorId(Guid id)
        {
            var paciente = _repositorio.Obter(id);

            var dto = new PacienteDto
            {
                Cpf = paciente.Documento.Numero,
                Id = paciente.Id,
                Peso = paciente.Dados.Peso,
                DataNascimento = paciente.Dados.DataNascimento,
                Altura = paciente.Dados.Altura,
                NomeCompleto = $"{paciente.Nome.PrimeiroNome}  {paciente.Nome.SobreNome}"
        };

            return PartialView("_Editar", dto);
        }

        public IActionResult Index()
        {

            var pacientes = _repositorio.ObterPacientesTodos();
            return View(pacientes);
        }

        [HttpPost]
        public JsonResult Incluir(PacienteDto dto)
        {
            object obj = null;
            var erro = string.Empty;

            if (dto.NomeCompleto != null)
            {
                var nomeCompleto = dto.NomeCompleto.Split(' ');
                if (nomeCompleto.Length > 0)
                {
                    var nome = nomeCompleto[0];
                    if (nomeCompleto.Length > 2)
                    {
                        var sobreNome = nomeCompleto[2];

                        var paciente = new Paciente(
                            new Documento(dto.Cpf.Replace(".", "").Replace("-", "")),
                            new Nome(nome.ToUpper(), sobreNome.ToUpper()),
                            new Dados((Sexo) dto.Sexo, dto.DataNascimento, dto.Peso, dto.Altura));


                        try
                        {
                            if (paciente.IsValid())
                            {
                                _repositorio.SalvarPaciente(paciente);
                                _repositorio.Salvar();
                            }
                            else
                            {
                                foreach (var mensagem in paciente.Notifications)
                                    erro += $"{mensagem.Message}";

                                obj = new {Mensagem = erro};
                                return Json(obj);
                            }


                            obj = new {Mensagem = "Paciente cadastrado com sucesso!"};
                        }

                        catch (DbUpdateException ex)
                        {
                            if (ex.InnerException != null)
                            {
                                var innerException = ex.InnerException.InnerException as SqlException;
                                if (innerException != null &&
                                    (innerException.Number == 2627 || innerException.Number == 2601))
                                {
                                    obj = new {Mensagem = "Cpf já cadastrado!"};
                                }
                                else
                                {
                                    throw;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            obj =  new { Mensagem = ex.Message};
                        }
                    }
               
                }
               
            }
            else
                obj = new { Mensagem = "Digite o nome!" };


            return Json(obj);
        }

        [HttpPost]
        public JsonResult Excluir(Guid id)
        {
             _repositorio.Excluir(id);
            _repositorio.Salvar();

            object obj = new { Mensagem = "Paciente excluído com sucesso!" };

            return Json(obj);
        }

        [HttpPost]
        public  JsonResult Editar(string id, string cpf, string nome, string sexo, string dataNascimento, decimal peso,
            decimal altura)
        {

            object obj = null;
            var erro = string.Empty;

            Enum.TryParse(sexo, out Sexo sexoEnum);

            var nomeCompleto = nome.Split(' ');
            if (nomeCompleto.Length > 0)
            {
                var primeiroNome = nomeCompleto[0];

                if (nomeCompleto.Length > 2)
                {
                    var sobreNome = nomeCompleto[2];

                    var paciente = new Paciente(
                        new Documento(cpf),
                        new Nome(primeiroNome, sobreNome),
                        new Dados(sexoEnum,
                            Convert.ToDateTime(dataNascimento),
                            Convert.ToDecimal(peso),
                            Convert.ToDecimal(altura)));

                   

                    try
                    {
                        if (paciente.IsValid())
                            _repositorio.Atualizar(paciente);

                        obj = new {Mensagem = "Paciente alterado com sucesso!"};
                    }
                    catch (Exception ex)
                    {
                        obj = new { Mensagem = ex.Message };
                          
                    }

                }
            }

            return Json(obj);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
