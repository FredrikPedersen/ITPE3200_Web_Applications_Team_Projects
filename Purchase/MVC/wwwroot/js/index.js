//Initialize variables that will be used in the script
var from = document.querySelector('#from');
var to = document.querySelector('#to');
var errMsg = document.querySelector('#same-station-err');
var btnInput = document.querySelector('#btn-submit');
var hiddenDiv = document.querySelector('#hidden-div');
var hideButton = document.querySelector('#hide-div');

//Eventlisteners
btnInput.addEventListener('click', checkInput);
from.addEventListener('click', showElements);
to.addEventListener('click', showElements);
hideButton.addEventListener('click', hideDiv);

//Checks input in from and to text boxes and stops the submit process if the contents are equal
function checkInput(event) {
    if (from.value === to.value) {
        event.preventDefault();
        errMsg.classList.add('error');
        errMsg.innerHTML = "Du må velge to forskjellige stasjoner!";
    }
}

function showElements() {
    hiddenDiv.classList.remove('hidden');
    hideButton.classList.remove('hidden');
}

function hideDiv() {
    hiddenDiv.classList.add('hidden');
    hideButton.classList.add('hidden');
}

$(function () {
    $.ajax({
        url: '/Vy/GetPassengerTypes',
        type: 'GET',
        dataType: 'json',
        success: function (jsPassengerTypes) {
            showDropDown(jsPassengerTypes);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
});

function showDropDown(jsPassengerTypes) {
    var output = "";
    for (var i in jsPassengerTypes) {
        console.log(jsPassengerTypes[i].type);
        output += "<option value='" + jsPassengerTypes[i].id + "'>" + jsPassengerTypes[i].type + "</option>";
    }
    $("#drop").append(output);
}

