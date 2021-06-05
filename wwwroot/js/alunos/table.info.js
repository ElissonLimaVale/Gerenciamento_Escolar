$(document).ready(() => {
    $.ajax({
        method: "Get",
        url: "/Alunos/ListarTodos",
    }).done((data) => {
        tableinfo.setData(data);
    }).fail();
});

var columns = [
    { title: "id", field: "id", visible: false },
    { title: "Nome", field: "nome" },
    { title: "CPF", field: "cpf" },
    { title: "Nome da Mãe", field: "nomeDaMae" },
    { title: "Nome do Pai", field: "nomeDoPai" },
    { title: "Ações", field: "", formatter: ButtonTable, width: 140 }
];

var tableinfo = new Tabulator("#table-info", {
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
            <button class="btn btn-xs btn-default editar" title="Editar Avaliação">
                <i class="fa fa-pencil"></i>
            </button>
            <button class="btn btn-xs btn-default excluir" title="Excluir Avaliação">
                <i class="fa fa-trash"></i>
            </button>
        </div>
    `;
}

function AddFunctionButtons() {

    $(".editar").click((e) => {
        var row = $(e.currentTarget).parent().parent().parent();
        var id = row.children()[0].innerText;
        window.location.href = "/Alunos/Editar/" + id;
    });

    $(".excluir").click((e) => {
        var row = $(e.currentTarget).parent().parent().parent();
        var id = row.children()[0].innerText;
        bootbox.confirm({
            title: "Te Certeza?",
            message: "Deseja excluir esse aluno permanentemente? Esta ação é irrevercivel deseja continuar?"
        }, () => {
            window.location.href = "/Alunos/Deletar/" + id;
        });
    });
}

$("#baixar").click(() => {
    bootbox.dialogValue({
        title: "Baixar PDF",
        message: "Digite o nome do para o arquivo"
    }, (data) => {
        tableinfo.download("pdf", (data + ".pdf"),{
            orientation: "portrait",
            title: "Informações do Período do Aluno"
        });
    });
});