using System;
using System.Linq;
using Corcam.Scp.Dominio.Entidades;
using Corcam.Scp.Dominio.Enum;
using Corcam.Scp.Dominio.ObjetosValor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Corcam.Scp.Domain.Testes
{
    [TestClass]
    public class PacienteTestes
    {
        [TestMethod]
        [TestCategory("Documento - Novo paciente")]
        public void DadosUmCpfInvalidoDeveRetornarUmaNotificacao()
        {
            var documento = new Documento("82915738412");
            Assert.IsFalse(documento.IsValid());
        }

        [TestMethod]
        [TestCategory("Documento - Novo paciente")]
        public void DadosUmCpfValidNaoDeveRetornarUmaNotificacao()
        {
            var documento = new Documento("82915738408");
            Assert.IsTrue(documento.IsValid());
        }


        [TestMethod]
        [TestCategory("Dados - Novo paciente")]
        public void DadosDataNascimentoPensoInvalidoRetornarDuasNotificacoes()
        {

            var dados = new Dados(Sexo.Feminino, new DateTime(2017, 2, 26), 0, 1.83m);
            Assert.AreEqual(2 ,dados.Notifications.Count);
        }


        [TestMethod]
        [TestCategory("Paciente - Novo paciente")]
        public void DadoUmPacienteComDadosValidoRetornartrue()
        {
            var documento = new Documento("82915738408");
            var nome = new Nome("Isabella", "Fonseca Galante");
            var dados = new Dados(Sexo.Feminino, new DateTime(1965, 6, 22), 64, 1.62m);


            var paciente = new Paciente(documento, nome, dados);


            Assert.IsTrue(paciente.IsValid());
        }

        [TestMethod]
        [TestCategory("Paciente - Novo paciente")]
        public void DadoUmPacienteComIdadeMenorQueDozeAnosApresentarMensagemErro()
        {
            var documento = new Documento("82915738408");
            var nome = new Nome("Isabella", "Fonseca Galante");
            var dados = new Dados(Sexo.Feminino, new DateTime(2014, 6, 22), 64, 1.62m);
            var paciente = new Paciente(documento, nome, dados);


            //var mensagem = paciente.Notifications.Where(f => f.Message)

            Assert.AreEqual("Idade inválida", paciente.Notifications.FirstOrDefault());
        }
    }
}
