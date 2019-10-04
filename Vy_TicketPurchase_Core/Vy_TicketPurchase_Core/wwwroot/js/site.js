// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Initialise variable that will be used in the script
var from = document.querySelector('#from');
    //Calls autocoplete function for the "To" textboxt in Index View
    $(document).ready(function () {
        $(".toautocomplete").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/Vy/AutocompleteTo",
                    type: "POST",
                    datatype: "json",
                    data: { input: request.term, fromStation: from.value },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item, value: item };
                        }))

                    }
                })
            },
        });
        //Calls autocomplete function for the "From" textboxt in Index View
        $(".autocomplete").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/Vy/Autocomplete",
                    type: "POST",
                    datatype: "json",
                    data: { input: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item, value: item };
                        }))

                    }
                })
            },
        });
    })
