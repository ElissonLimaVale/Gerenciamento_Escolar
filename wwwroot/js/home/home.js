$(document).ready(() => {
    var columns = [
        { title: "Nome", field: "nome" },
        { title: "Email", field: "email" },
        { title: "CPF", field: "cpf" },
        { title: "Nome do Pai", field: "pai" },
        { title: "Nome da Mãe", field: "mae" }
    ];
    var data = [{
        nome: "Elisson",
        email: "elissonlima@gail.com",
        cpf: "08267092307",
        pai: "Lesson Conta do Vale",
        mae: "Raimunda Ferreira Lima"
    }];

    var table = new Tabulator("#table-alunos", {
        data: [],
        layout: "fitColumns",
        columns: columns,
        responsiveLayout: "collapse",
        langs: pt_br,
        placeholder: "Nenhum Aluno encontrado!",
        height: "400px",
        pagination: "local",
        paginationSize: 10,
        paginationSizeSelector: [10, 20, 30]
    });
});
