$(document).ready(function () {
    $('.confirmaDelete').click(function () {
        let url = $(this).attr('data-url');
        console.log(url);
        bootbox.confirm({ title: "Tem certeza que deseja excluir o(s) item(s)?", message: "Esta ação é irreverssível!" }, () => {
            window.location.href = "/"+url;
        });
        return false;
    });


    //$("#empresaDefault").change(() => {
    //    sessionStorage.setItem("empresaDefault", $("#empresaDefault option:selected").val());
    //});

    //verificaEmpresaDefault();
});

//function verificaEmpresaDefault() {
//    let empresaDefault = sessionStorage.getItem("empresaDefault");
//    if (empresaDefault != null && empresaDefault != 'null' && empresaDefault != undefined) {
//        $("#empresaDefault").val(empresaDefault);
//    }
//}


