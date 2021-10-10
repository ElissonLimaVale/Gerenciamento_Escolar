var Senha = {};

$(document).ready(() => { 
    Senha = {
        Isvalid: true,
        Value: $("#Senha").val()
    };
});

const Metodos = {
    ValidarPassWord: () => {
        var senha = $("#AterarSenha");
        var confirmar = $("#ConfirmarSenha");
        if (senha.val() != confirmar.val()) {
            var textSenha = $(senha.parent().parent().children()[2]);
            var textConfirm = $(confirmar.parent().parent().children()[2]);
            textSenha.text("As Senhas Não Conincidem!");
            textConfirm.text("As Senhas Não Conincidem!");
        } else {
            var textSenha = $(senha.parent().parent().children()[2]);
            var textConfirm = $(confirmar.parent().parent().children()[2]);
            textSenha.text("");
            textConfirm.text("");
        }
        $("#Senha").val(senha.val());
    }
};