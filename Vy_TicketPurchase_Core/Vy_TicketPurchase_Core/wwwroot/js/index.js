var from = document.querySelector('#from');
var to = document.querySelector('#to');
var errMsg = document.querySelector('#test-err');
var fromInput = from.value;
var btnInput = document.querySelector('#btn-submit');
console.log(fromInput);

btnInput.addEventListener('click', checkInput);

function checkInput(e) {
    var fromInput = from.value;
    var toInput = to.value;
    if(fromInput === toInput) {
        e.preventDefault();
        errMsg.classList.add('error');
        errMsg.innerHTML = "Du har valgt samme fra og til stasjon"
    }
}