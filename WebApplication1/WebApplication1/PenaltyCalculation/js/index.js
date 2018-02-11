function Start() {
    ajax('GetCountries.aspx', fillCountry);

    document.getElementById('calculate-button').onclick = function () {
        var c = document.querySelector('input[name="checkOutDate"]').value;
        var r = document.querySelector('input[name="returnDate"]').value;

        var elem = document.getElementById("countries");
        var countryCode = elem.options[elem.selectedIndex].value;

        ajax('CalculatePenalty.aspx?checkOutDate=' + c + '&returnDate=' + r + '&countryCode=' + countryCode, calculate);
    }
}

function calculate(getData) {
    document.getElementById("business-day").innerHTML = getData.BusinessDay;
    document.getElementById("penalty").innerHTML = getData.Total;
    document.getElementById("currency").innerHTML = getData.Currency;
}

function fillCountry(data) {
    var html = '';
    data.forEach(function (v, k) {
        html += '<option value="' + v.Id + '">' + v.Name + '</option>';
    });

    document.getElementById('countries').innerHTML = html;
}

function ajax(url, callback) {
    var xmlhttp = new XMLHttpRequest();

    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == XMLHttpRequest.DONE && xmlhttp.status == 200) {
            var getData = JSON.parse(xmlhttp.responseText);
            callback(getData);
        }
    };

    xmlhttp.open('GET', url, true);
    xmlhttp.send();
}


document.addEventListener("DOMContentLoaded", function (event) {
    Start();
});