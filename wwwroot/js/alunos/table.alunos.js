﻿$(document).ready(() => {
    $.ajax({
        method: "Get",
        url: "/Alunos/ListarTodos",
    }).done((data) => {
        tablealunos.setData(data);
    }).fail();
});

var columns = [
    {title: "id", field: "id", visible: false },
    {title: "Nome", field: "nome" },
    {title: "CPF", field: "cpf" },
    {title: "Nome da Mãe", field: "nomeDaMae" },
    { title: "Nome do Pai", field: "nomeDoPai" },
    { title: "Ações", field: "", formatter: ButtonTable, width: 140 }
];

var tablealunos = new Tabulator("#table-alunos", {
    data: [],
    height: "400px",
    layout: "fitColumns",
    columns: columns,
    pagination: "local",
    paginationSize: 10,
    paginationSizeSelector: [20, 30, 40, 50],
    placeholder: "Nenhum Aluno Encontrado!",
    dataLoaded: AddFunctionButtons,
    langs: pt_br
});

function ButtonTable() {
    return `
        <div class="btn-group">
            <button class="btn btn-xs btn-default editar" title="Editar Aluno">
                <i class="fa fa-pencil"></i>
            </button>
            <button class="btn btn-xs btn-default visualizar" title="Visualizar Notas do Aluno">
                <i class="fa fa-graduation-cap"></i>
            </button>
            <button class="btn btn-xs btn-default excluir" title="Excluir Aluno">
                <i class="fa fa-trash"></i>
            </button>
        </div>
    `;
}

// Adiciona os códigos javascript para as ações dos botões depois que carrega o html da tabela
function AddFunctionButtons() {

    $(".editar").click((e) => {
        var row = $(e.currentTarget).parent().parent().parent();
        var id = row.children()[0].innerText;
        window.location.href = "/Alunos/Editar/" + id;
    });

    $(".visualizar").click((e) => {
        var row = $(e.currentTarget).parent().parent().parent();
        var id = row.children()[0].innerText;
        window.location.href = "/Alunos/InformacoesPeriodo/" + id;
    });

    $(".excluir").click((e) => {
        var row = $(e.currentTarget).parent().parent().parent();
        var id = row.children()[0].innerText;
        bootbox.confirm({ 
            title: "Tem Certeza?",
            message: "Deseja excluir esse aluno permanentemente? Esta ação é irrevercivel deseja continuar?"
        }, () => {
            window.location.href = "/Alunos/Deletar/" + id;
        });
    });
}