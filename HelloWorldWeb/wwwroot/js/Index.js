$(document).ready(function () {

    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();

        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: {
               "name": newcomerName
            },
            success: (result) => {
                console.log(result);
                $("#teamList").append(`<li>${newcomerName}</li>`);
                $("#nameField").val("");
            },
            error: function (err) {
                console.log(err);
            }
        })


    })
});