

var methods = {
    timeout: null,
    search: (filtro) => {
        $.ajax({
            method: "Get",
            url: "/Professores/Buscar",
            data: {
                filtro: filtro
            }
        }).done((data) => {
            LoadHide();
            tableprofessor.setData(data);
        }).fail(() => {
            LoadHide();
            bootbox.error("Ops, ocorreu um erro inesperado ao tentar listar Professores, por favor atualize a página!");
        });
    }
};

var columns = [
    { title: "id", field: "id", visible: false },
    { title: "Nome", field: "nome" },
    { title: "Email", field: "email" },
    { title: "Telefone", field: "telefone" },
    { title: "Disciplina", field: "desciplina" },
    { title: "Endereco", field: "endereco.rua" },
    { title: "Ações", field: "", formatter: ButtonTable, width: 140 }
];

var tableprofessores = new Tabulator("#table-professor", {
    height: "420px",
    layout: "fitColumns",
    columns: columns,
    pagination: "local",
    ajaxURL: "/Professores/ListarTodos",
    paginationSize: 12,
    paginationSizeSelector: [20, 30, 40, 50],
    placeholder: "Nenhum Professor Encontrado!",
    dataLoaded: AddFunctionButtons,
    locale: true,
    langs: pt_br
});

function ButtonTable() {
    return `
        <div class="btn-group">
            <button class="btn btn-xs btn-default editar" title="Editar Professor">
                <i class="fa fa-pencil"></i>
            </button>
            <button class="btn btn-xs btn-default visualizar" title="Visualizar Professor">
                <i class="fa fa-graduation-cap"></i>
            </button>
            <button class="btn btn-xs btn-default excluir" title="Excluir Professor">
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
        window.location.href = "/Professor/Editar/" + id;
    });

    $(".visualizar").click((e) => {
        var row = $(e.currentTarget).parent().parent().parent();
        var id = row.children()[0].innerText;
        window.location.href = "/Professor/InformacoesPeriodo/" + id;
    });

    $(".excluir").click((e) => {
        var row = $(e.currentTarget).parent().parent().parent();
        var id = row.children()[0].innerText;
        bootbox.confirm({
            title: "Tem Certeza?",
            message: "Deseja excluir esse Professor permanentemente? Esta ação é irrevercivel deseja continuar?"
        }, () => {
            window.location.href = "/Professor/Deletar/" + id;
        });
    });
}

$("#search").keyup(() => {
    LoadShow();
    clearTimeout(methods.timeout);
    methods.timeout = setTimeout(function () { methods.search($("#search").val()) }, 380);
});