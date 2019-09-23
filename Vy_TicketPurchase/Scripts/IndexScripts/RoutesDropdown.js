$.ajax({
    url: '/Vy/GetAllRoutes',
    type: 'GET',
    dataType: 'json',
    success: function(jsRoute) {
        ShowDropdown(jsRoute);
    },
    error: function() {
        alert("Something went wrong when trying to load Routes from the database") //TODO find a better way to handle this
    }
});

function ShowDropdown(jsRoutes) {
    var outString = "";
    for (var i in jsRoutes) {
        outString += "<option value='" + jsRoutes[i].Id + "'>" + jsRoutes[i].RouteName+"</option>";
    }
    $("#routes").append(outString);
}