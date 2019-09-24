//Get a list of all available routes from the controller and fill them into a dropdown-list
$.ajax({
    url: '/Vy/GetAllRoutes',
    type: 'GET',
    dataType: 'json',
    success: function(jsRoute) {
        FillDropdown(jsRoute);
    },
    error: function() {
        alert("Something went wrong when trying to load Routes from the database") //TODO find a better way to handle this
    }
});

//Iterates through all jsRoute-objects and puts their Routenames in as options in  a dropdown
function FillDropdown(jsRoutes) {
    var outString = "";
    for (var i in jsRoutes) {
        outString += "<option value='" + jsRoutes[i].Id + "'>" + jsRoutes[i].RouteName+"</option>";
    }
    $("#routes").append(outString);
}