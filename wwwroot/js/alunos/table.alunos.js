$(document).ready(() => {
    $.ajax({
        method: "Get",
        url: "../Alunos/ListarTodos",
    }).done((data) => {
        tablealunos.setData(data);
    }).fail();
});

var columns = [
    {title: "Nome", field: "nome" },
    {title: "CPF", field: "CPF" },
    {title: "Nome da Mãe", field: "nomeDaMae" },
    { title: "Nome do Pai", field: "nomeDoPai" },
    { title: "Ações", field: "", formatter: ButtonTable }
];

var tablealunos = new Tabulator("#table-alunos", {
    data: [],
    height: "450px",
    layout: "fitColumns",
    columns: columns,
    paginationSize: 10,
    paginationSizeSelector: [20, 30, 40, 50],
    placeholder: "Nenhum Aluno Encontrado!"
});

function ButtonTable() {
    return `
        <div class="btn-group">
            <button class="btn btn-default excluir">
                <i class="glyphicon glyphicon-trash"></i>
            </button>
            <button class="btn btn-default Editar">
                <i class="glyphicon glyphicon-trash"></i>
            </button>
        </div>
    `;
}