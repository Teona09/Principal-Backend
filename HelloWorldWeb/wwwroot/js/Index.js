$(document).ready(function () {

    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();
        var length = $("#teamMembers").children().length;
        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: {
                "name": newcomerName
            },
            success: (result) => {
                console.log(result);
                $("#teamList").append(
                    `<li>
                <span class="memberName" member-id=${result}>
                        ${newcomerName}
                    </span >
                <span class="delete fa fa-remove" onclick="deleteMember(${result})">
                    </span>
                <span class="edit fa fa-pencil">
                    </span>
                </li>`);
                $("#nameField").val("");
                document.getElementById("createButton").disabled = true;
            },
            error: function (err) {
                console.log(err);
            }
        })

    });

    $("#clearButton").click(function ClearFields() {
        document.getElementById("nameField").value = "";
        document.getElementById("createButton").disabled = true;
    });

    $("#editClassmate").on("click", "#submit", function () {
        console.log('submit changes to server');
        const id = $('#editClassmate').attr('member-id');
        console.log(id);
        const newName = $('#classmateName').val();
        $.ajax({
            url: "/Home/UpdateMemberName",
            method: "POST",
            data: {
                memberId: id,
                name: newName
            },
            success: function (result) {
                location.reload();
            }
        })
    })

    $("#editClassmate").on("click", "#cancel", function () {
        console.log('cancel changes');
    })

    $("#teamList").on("click", ".edit", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('member-id');
        var currentName = targetMemberTag.find(".memberName").text();
        $('#editClassmate').attr("member-id", id);
        $('#classmateName').val(currentName);
        $('#editClassmate').modal('show');
        })
});

function deleteMember(index) {

    $.ajax({
        url: "/Home/RemoveMember",
        method: "DELETE",
        data: {
            memberIndex: index
        },
        success: function (result) {
            location.reload();
        }
    })
}

(function () {
    $('#nameField').on('change textInput input', function () {
        var inputVal = this.value;
        if (inputVal != "") {
            document.getElementById("createButton").disabled = false;
        } else {
            document.getElementById("createButton").disabled = true;
        }
    });
}());