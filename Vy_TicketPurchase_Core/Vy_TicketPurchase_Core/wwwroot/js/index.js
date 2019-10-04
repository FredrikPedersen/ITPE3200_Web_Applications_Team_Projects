//Initialize variables that will be used in the script
var from = document.querySelector('#from');
var to = document.querySelector('#to');
var errMsg = document.querySelector('#test-err');
var fromInput = from.value;
var btnInput = document.querySelector('#btn-submit');
console.log(fromInput);

//Add an event listener to the submitt button
btnInput.addEventListener('click', checkInput);

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