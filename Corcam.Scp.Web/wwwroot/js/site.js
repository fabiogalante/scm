// Write your Javascript code.

var app = {};


$(function () {
    app.dataTable();
    app.Inicia();
    app.IncluirPaciente();
    app.mask();
    app.Editar();

});


app.SalvarEditar = function () {


    $('#editarPaciente').click(function (e) {

        console.log('editar');

        e.preventDefault();

        var id = $("#Id").val();
        var nome = $("#NomeCompleto").val();
        var cpf = $("#Cpf").val();
        var sexo = $("#Sexo option:selected").val();
        var nascimento = $("#DataNascimento").val();
        var peso = $("#Peso").val();
        var altura = $("#Altura").val();

        $.ajax({
            url: '/Home/Editar/")',
            data: { id: id, cpf: cpf, nome: nome, sexo: sexo, dataNascimento: nascimento, peso: peso, altura: altura },
            dataType: "json",
            type: "post",
            success: function (data) {
                return toastr.success(data.mensagem, "Corcam");
            },
            complete: function () {
               
            },
            error: function (data) {
                $('#editarModal').modal('hide');
                return toastr.success(data.mensagem, "Corcam");

            }
        });

        return true;
    });
}
    
app.Editar = function() {


    $(".edit-btn").click(function (e) {

        e.preventDefault();

        var div = $('#editarPacienteDiv');

        var id = $(this).data('id');

        var url = '/Home/ObterPacientePorId/';

        $.get(url, { id: id }, function (data) {
            div.html('');
            div.append(data);
            app.SalvarEditar();
            app.mask();
            $('#editarModal').modal('show');

        });

       


    });


    

    

  
}


app.mask = function () {

    $('#dataNascimento').mask('00/00/0000');
    $('#cpf').mask('000.000.000-00', { reverse: true });
    $('#peso').mask('0,00', { reverse: true });
    $('#altura').mask('0,00', { reverse: true });
   

}

app.Inicia = function () {

    console.log('scp');


    $(".paciente-btn").click(function (e) {
        e.preventDefault();
        $('#incluirModal').modal('show');
    });

  

    $(".edit-btn").click(function (e) {
        e.preventDefault();
        $('#editarModal').modal('show');
    });


    $(".delete-btn").on("click", function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var nome = $(this).data("nome");
        $('#deleteModal').modal('show');
        $("#deleteModal .modal-body input[type=hidden]").val(id);
        $("#deleteModal .modal-body span").text(nome);
    });


   


    $("#deleteModal .modal-footer button").click(function (e) {

        e.preventDefault();

        //var id = $(".modal-body input[type=hidden]").val();

        var id = $("#id").val();

        console.log(id);

        $.ajax({
            url: '/Home/Excluir/")',
            data: { id: id },
            dataType: "json",
            type: "post",
            success: function (data) {

                $('#deleteModal').modal('hide');

                toastr.success(data.mensagem, "Corcam");

                var linha = $("#pacientesTable tbody #" + id);
                $(linha).animate({ opacity: 0.0 }, 400, function () {
                    $(linha).remove();
                });
            },
            complete: function () {

            }
        });
    });


}

app.dataTable = function () {

    $('#pacientesTable').dataTable({
        "pagingType": "full_numbers",

        "order": [],
        "columnDefs": [
            { "targets": 'no-sort', "orderable": false }],


        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ do _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });


}

app.IncluirPaciente = function () {


    $("#salvarPaciente").click(function (e) {

        e.preventDefault();
        if ($('#cpf').val() === '')
            return toastr.success('Digite o cpf', "Corcam");

        if ($('#nomeCompleto').val() === '')
            return toastr.success('Digite o nome', "Corcam");


        $.ajax({
            url: '/Home/Incluir/")',
            data: $("form").serialize(),
            dataType: "json",
            type: "post",
            success: function (data) {
                return  toastr.success(data.mensagem, "Corcam");
            },
            complete: function () {
                windows.localtion.reload();
            },
            error: function (data) {
                $('#incluirModal').modal('hide');
                return toastr.success(data.mensagem, "Corcam");
               
            }
        });

        return true;
    });
}
