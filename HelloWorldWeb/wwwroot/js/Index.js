$(document).ready(function () {

    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();

        // Remember string interpolation
        $("#teamList").append(`<li>${newcomerName}</li>`);

        $("#nameField").val("");
    })
});