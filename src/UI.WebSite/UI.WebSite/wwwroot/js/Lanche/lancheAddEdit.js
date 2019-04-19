document.getElementById("DataCadastro").readOnly = true;
document.getElementById("DataCadastro").style.color = "#c0c0c0";

function AddIngrediente(idIngrediente, nomeIngrediente) {

    alert(arrayIngredientes);

    let qtd = Number($("#qtdIngrediente_" + idIngrediente).text());

    if (qtd < 10)
        qtd++;
    else
        alert("o maximo é 10 " + nomeIngrediente + "s");

    $("#qtdIngrediente_" + idIngrediente).text(qtd);
}

function RemoveIngrediente(idIngrediente, nomeIngrediente) {
    let qtd = Number($("#qtdIngrediente_" + idIngrediente).text());

    if (qtd > 0)
        qtd--;
    else
        alert(nomeIngrediente + " no minimo Zero");

    $("#qtdIngrediente_" + idIngrediente).text(qtd);
}

function validateForm(theForm) {

    if (StringHeVazia(theForm.Id.value)) {
        alert("Id esta vazio");
        return;
    } else if (StringHeVazia(theForm.DataCadastro.value)) {
        alert("Campo login esta vazio");
        return;
    } else if (StringHeVazia(theForm.Nome.value)) {
        alert("Campo Nome esta vazio");
        return;
    } else if (StringHeVazia(theForm.Preco.value)) {
        alert("Preço vazio");
        return;
    } else {

        /*
        public int IdIngrediente { get; set; }
        public string NomeIngrediente { get; set; }
        public int QtdIngrediente { get; set; }
        */

        let ingredientes = [
            { "IdIngrediente": 1, "NomeIngrediente": "NaoImporta", "QtdIngrediente": 3 },
            { "IdIngrediente": 2, "NomeIngrediente": "NaoImporta", "QtdIngrediente": 4 },
            { "IdIngrediente": 3, "NomeIngrediente": "NaoImporta", "QtdIngrediente": 5 },
        ];

        var lancheJson = {
            'Id': theForm.Id.value,
            'DataCadastro': theForm.DataCadastro.value,
            'Nome': theForm.Nome.value,
            'Preco': theForm.Preco.value,
            'Ingredientes': ingredientes
        };

        var token = $('input[name="__RequestVerificationToken"]').val();
        //var _token = theForm.__RequestVerificationToken.value;

        $.ajax({
            type: 'POST',
            url: '/Lanches/Edit/' + theForm.Id.value,
            dataType: 'JSON',
            async: true,
            data: {
                __RequestVerificationToken: token,
                id: theForm.Id.value,
                lanche: lancheJson
            },
            success: function (response) {
                console.log(response);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR.responseText.split("'"));
                console.log(errorThrown.message);
                console.log(textStatus);
            }
        });
    }
}

function StringHeVazia(texto) {
    return false;
}