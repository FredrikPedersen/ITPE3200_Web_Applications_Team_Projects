//Initialize variables that will be used in the script
var from = document.querySelector('#from');
var to = document.querySelector('#to');
var errMsg = document.querySelector('#test-err');
var fromInput = from.value;
var btnInput = document.querySelector('#btn-submit');
var hiddenDiv = document.querySelector('#hidden-div');
var hideButton = document.querySelector('#hide-div');
console.log(fromInput);

//Add an event listener to the submitt button
btnInput.addEventListener('click', checkInput);

from.addEventListener('click', showElements);
to.addEventListener('click', showElements);
hideButton.addEventListener('click', hideDiv);

//Checks input in from and to text boxes and stops the submittion procces if the contents are equal
function checkInput(e) {
    var fromInput = from.value;
    var toInput = to.value;
    if(fromInput === toInput) {
        e.preventDefault();
        errMsg.classList.add('error');
        errMsg.innerHTML = "Du må velge to forskjellige stasjoner!"
    }
}    
    
function showElements() {
    console.log("click");
    hiddenDiv.classList.remove('hidden');
    hideButton.classList.remove('hidden');
}
    
function hideDiv() {
    hiddenDiv.classList.add('hidden');
    hideButton.classList.add('hidden');
    }
