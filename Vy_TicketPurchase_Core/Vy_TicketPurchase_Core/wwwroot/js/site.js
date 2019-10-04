// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var from = document.querySelector('#from');

    $(document).ready(function () {
        $(".toautocomplete").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/Vy/AutocompleteTo",
                    type: "POST",
                    datatype: "json",
                    data: { input: request.term, id: from.value },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item, value: item };
                        }))

                    }
                })
            },
        });
        
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
