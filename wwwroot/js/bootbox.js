var bootbox = {};

$(document).ready(() => {
    bootbox = {
        alert: (msg) => {
            $.smallBox({
                title: "Informações",
                content: msg,
                color: "#5384AF",
                timeout: 5000,
                icon: "fa fa-bell"
            });
        },
        success: (msg) => {
            $.smallBox({
                title: "Mensagem",
                content: "<i class='fa fa-clock-o'></i> <i>" + msg + "</i>",
                color: "#659265",
                iconSmall: "fa fa-check fa-2x fadeInRight animated",
                timeout: 4000
            });
        },
        error: (msg) => {
            $.smallBox({
                title: "Erro",
                content: "<i class='fa fa-clock-o'></i> <i>" + msg + "</i>",
                color: "#C46A69",
                iconSmall: "fa fa-times fa-2x fadeInRight animated",
                timeout: 4000
            });
        },
        confirm: (object, method) => {
            $.SmartMessageBox({
                title: object.title,
                content: object.message,
                buttons: '[Cancelar][Continuar]'
            }, function (ButtonPressed) {
                if (ButtonPressed === "Continuar") {
                    method();
                }
            });
        },
        notific_error: (msg) => {
            $.bigBox({
                title: "Notificação de erro:",
                content: msg,
                color: "#C46A69",
                icon: "fa fa-warning shake animated",
                //number: "1",
                timeout: 6000
            });
        },
        notific_alert: (msg) => {
            $.bigBox({
                title: "Notificação de informação:",
                content: msg,
                color: "#3276B1",
                timeout: 8000,
                icon: "fa fa-bell swing animated",
                //number: "2"
            });
        },
        notific_warning: (msg) => {
            $.bigBox({
                title: "Notificação de aviso!",
                content: msg,
                color: "#C79121",
                timeout: 8000,
                icon: "fa fa-shield fadeInLeft animated",
                //number: "3"
            });
        },
        notific_success: (msg) => {
            $.bigBox({
                title: "Notificação de sucesso!",
                content: msg,
                color: "#739E73",
                timeout: 8000,
                icon: "fa fa-check",
                //number: "4"
            }, function () {
                closedthis();
            });
        },
        dialogValue: (object, method) => {
            var response = 
            $.SmartMessageBox({
                title: object.title,
                content: object.message,
                buttons: "[Cancelar][Continuar]",
                input: "text",
                value: "",
                placeholder: "Digite o valor socilidato"
            }, function (ButtonPress, Value) {
                if (ButtonPress == "Cancel") {
                    return 0;
                }
                method(Value);
            });
            return response;
        }
    };

});





