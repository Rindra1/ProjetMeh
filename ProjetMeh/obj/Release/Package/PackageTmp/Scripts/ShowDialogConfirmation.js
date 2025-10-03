$(document).ready(function () {
    $("#btnShowSimple").click(function (e) {
        ShowDialogConfirmation(false);
        e.preventDefault();
    });

    $("#btnShowModal").click(function (e) {
        ShowDialogConfirmation(true);
        e.preventDefault();
    });

    $("#btnClose").click(function (e) {
        HideDialogConfirmation();
        e.preventDefault();
    });

    $("#btnSubmit").click(function (e) {
        var brand = $("#brands input:radio:checked").val();
        $("#output").html("<b>Your favorite mobile brand: </b>" + brand);
        HideDialogConfirmation();
        e.preventDefault();
    });
});

function ShowDialogConfirmation(modal) {
    $("#overlay").show();
    $("#dialog").fadeIn(300);

    if (modal) {
        $("#overlay").unbind("click");
    }
    else {
        $("#overlay").click(function (e) {
            HideDialogConfirmation();
        });
    }
}

function HideDialogConfirmation() {
    $("#overlay").hide();
    $("#dialog").fadeOut(300);
}