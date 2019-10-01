// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    $(document).ready(function () {
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
