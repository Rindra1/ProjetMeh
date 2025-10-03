$(document).ready(function () {

    $.ajax({
        type: "POST",
        data: "",
        url: "mail.aspx/GetCorrespondant",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (resultat) {
            $('#sntdiv').append(resultat.d);
        },
        error: function (data, value) {
        }
    });

    $('#add').live('click', function () {
        var sntdiv = $('#sntdiv');
        var i = $('#sntdiv p').size() + 1;
        $('<p><input type="text" id="txtdestinataire' + i + '" list="datalist" name="txtdestinataire" class="form-control"/></label><input type="button" class="btn btn-danger" id="bteffacer" value="Effacer"/></p>').appendTo(sntdiv);
    });

    $('#bteffacer').live('click', function () {

        var i = $('#sntdiv p').size();
        var parent = $(this).parent('p');
        $('#lblconfirmregion').text("Voulez vous vraiment supprimer la région?");

        JQ('#dialogue').dialog({
            autoOpen: true,
            modal: true,
            buttons: [
                {
                    text: "OK",
                    click: function () {
                        if (i > 0) {
                            parent.remove();
                            i--;
                        }
                        JQ(this).dialog("close");
                        $('#lblconfirmregion').text('');

                    }
                },
                {
                    text: "Cancel",
                    click: function () {
                        JQ(this).dialog("close");
                        $('#lblconfirmregion').text('');

                    }
                }
            ]

        });
    });
})