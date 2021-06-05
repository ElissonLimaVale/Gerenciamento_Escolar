$(document).ready(function () {
    $('.confirmaDelete').click(function () {
        let url = $(this).attr('data-url');
        $('#dialog_confirma').dialog({
            autoOpen: false,
            open: function (event, ui) {
                $(".ui-dialog-titlebar-close").remove();
            },
            width: 600,
            resizable: false,
            modal: true,
            title: "Tem Certeza ?",
            buttons: [{
                html: "<i class='fa fa-trash-o'></i>&nbsp; Sim, Excluir",
                "class": "btn btn-danger",
                click: function () {
                    window.location.href = url;
                    $(this).dialog("close");
                }
            }, {
                html: "<i class='fa fa-times'></i>&nbsp; Cancelar",
                "class": "btn btn-default",
                click: function () {
                    $(this).dialog("close");
                }
            }]
        }).dialog('open');
        return false;
    });


    $("#empresaDefault").change(() => {
        sessionStorage.setItem("empresaDefault", $("#empresaDefault option:selected").val());
    });

    verificaEmpresaDefault();
});

function verificaEmpresaDefault() {
    let empresaDefault = sessionStorage.getItem("empresaDefault");
    if (empresaDefault != null && empresaDefault != 'null' && empresaDefault != undefined) {
        $("#empresaDefault").val(empresaDefault);
    }
}


