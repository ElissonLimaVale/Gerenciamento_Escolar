$(document).ready(() => {
    $(".mascara-cpf").mask("999.999.999-99");
    $(".mascara-cnpj").mask("99.999.999/9999-99");
    $(".mascara-cep").mask("99.999-999");
    $(".mascara-celular").mask("(99) 99999-9999");
    $(".mascara-telefone").mask("(99) 9999-9999?9");
    $(".mascara-conta").mask("99999999-9");
    $(".mascara-agencia").mask("9999");
    $(".mascara-data").mask("99/99/9999");
    $(".mascara-money").maskMoney({
        prefix: '',
        allowNegative: false,
        thousands: '.',
        decimal: ',',
        affixesStay: false
    });
});

function ValidateJson(jsonparams, acceptnull) {
    var response = true;
    for (var item in jsonparams) {
        if (!acceptnull.includes(item) && !!!jsonparams[item]) {
            response = false;
        }
    }
    return response;
}



