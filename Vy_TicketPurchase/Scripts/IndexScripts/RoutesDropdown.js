$(function () {

    //Get a list of all available routes from the controller and fill them into a dropdown-list
    $.ajax({
        url: '/Vy/GetAllRoutes/',
        type: 'GET',
        dataType: 'json',
        success: function(jsRoute) {
            FillDropdown(jsRoute);
        },
        error: function() {
            alert("Something went wrong when trying to load Routes from the database") //TODO find a better way to handle this
        }
    });
    
    //Whenever the selected item in the routes dropdown is changed, get and display info about selected route
    $("#routes").change(function () {
        var id = $(this).val();
        $.ajax({
            url: '/Vy/GetRouteInfo/' + id,
            type: 'GET',
            dataType: 'json',
            success: function (route) {
                ShowInfo(route);
            },
            error: function () {
                alert("Something went wrong when trying to load Routes from the database");
            }
        });
    });
    
/*  THIS IS NOT FINISHED.   
    $("#travelNowBtn").click(function () {
        var test = $('routes').find('option:selected');
        alert(test);
    })
}); */

//Iterates through all jsRoute-objects and puts their Routenames in as options in  a dropdown
function FillDropdown(jsRoutes) {
    var outString = "";
    for (var i in jsRoutes) {
        outString += "<option value='" + jsRoutes[i].Id + "'>" + jsRoutes[i].RouteName+"</option>";
    }
    $("#routes").append(outString);
}

//Formats info from passed route and displays it in the view
function ShowInfo(route) {
    var outString = "Travel time: " + route.TravelTimeMinutes + "m. Price: "
        + route.Price + "NOK";
    $("#showInfo").html(outString);
}