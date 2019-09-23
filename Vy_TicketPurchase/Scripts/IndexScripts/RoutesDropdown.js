$.ajax({
    url: '/Vy/GetAllRoutes',
    type: 'GET',
    dataType: 'json',
    success: function(jsRoute) {
        ShowDropdown(jsRoute);
    },
    error: function() {
        alert("Something something handle this later") //TODO Handle this later
    }
});

function ShowDropdown(jsRoutes) {
    var outString = "";
    for (var i in jsRoutes) {
        outString += "<option value='" + jsRoutes[i].id + "'>" + jsRoutes[i].routeName+"</option>";
    }
    $("#routes").append(outString);
}