$(document).ready(function () {
    
    $("#btnShowSimple").click(function (e) {
        ShowDialog1(false);
        e.preventDefault();
    });

    $("#btnShowModal").click(function (e) {
        ShowDialog1(true);
        e.preventDefault();
    });

    $("#btnClose").click(function (e) {
        HideDialog1();
        e.preventDefault();
    });

    $("#btnSubmit").click(function (e) {
        var brand = $("#brands input:radio:checked").val();
        $("#output").html("<b>Your favorite mobile brand: </b>" + brand);
        HideDialog1();
        e.preventDefault();
    });
});


function ShowDialog1(modal) {
    $("#overlay").show();
    $("#dial").fadeIn(300);

    if (modal) {
        $("#overlay").unbind("click");
    }
    else {
        $("#overlay").click(function (e) {
            HideDialog1();
        });
    }
}

function HideDialog1() {
    $("#overlay").hide();
    $("#dial").fadeOut(300);
}