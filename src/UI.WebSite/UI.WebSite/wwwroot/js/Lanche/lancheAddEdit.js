document.getElementById("DataCadastro").readOnly = true;
document.getElementById("DataCadastro").style.color = "#c0c0c0";

document.getElementById("Preco").readOnly = true;
document.getElementById("Preco").style.color = "#c0c0c0";

function AddIngrediente(idIngrediente, nomeIngrediente) {

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
    }
    else if (StringHeVazia(theForm.DataCadastro.value)) {
        alert("Campo login esta vazio");
        return;
    }
    else if (StringHeVazia(theForm.Nome.value)) {
        alert("Campo Nome esta vazio");
        return;
    }
    else if (StringHeVazia(theForm.Preco.value)) {
        alert("Preço vazio");
        return;
    }
    else {

        let ingredientes = [];

        for (var i = 0; i < arrayIdsIngredientes.length; i++) {

            let idIngrediente = arrayIdsIngredientes[i];
            let qtd = Number($("#qtdIngrediente_" + idIngrediente).text());

            if (qtd > 0) {
                ingredientes.push({ "IdIngrediente": idIngrediente, "NomeIngrediente": "NaoImporta", "QtdIngrediente": qtd });
            }
        }

        if (ingredientes.length == 0) {
            alert("Lanche deve ter ao menos um ingrediente");
            return;
        }

        var lancheJson = {
            'Id': theForm.Id.value,
            'DataCadastro': theForm.DataCadastro.value,
            'Nome': theForm.Nome.value,
            'Preco': theForm.Preco.value,
            'Ingredientes': ingredientes
        };

        var token = $('input[name="__RequestVerificationToken"]').val();

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
                $("#Preco").val(response.preco);
                alert("O lanche ficou R$" + response.preco);
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