var time1 = document.querySelector('#1');
var time2 = document.querySelector('#2');
var time3 = document.querySelector('#3');
var time4 = document.querySelector('#4');

function setTimeFrom(event) {
    var oldonload = window.onload;
    if (typeof window.onload != 'function') {
        window.onload = func;
    } else {
        window.onload = function () {
            if (oldonload) {
                oldonload();
            }
            event();
        }
    }
}

addLoadEvent(function () {
    document.getElementById('lbltipAddedComment').innerHTML = 'your tip has been submitted!';
});
}