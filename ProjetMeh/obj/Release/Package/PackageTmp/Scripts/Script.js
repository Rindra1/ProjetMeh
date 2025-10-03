function Obtenirparam(sVar) {
    return unescape(window.location.search.replace(new RegExp("^(?:.*[&\\?]" + escape(sVar).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
}
$(document).ready(function () {


    $('#testTable').slimtable();

    JQ('#rcdebut').datepicker({
        dateFormat: "dd/mm/yy"
    });

    JQ('#rcfin').datepicker({
        dateFormat: "dd/mm/yy"
    });

    $('#btliste').click(function (e) {
        e.preventDefault();
        if ($('#liste').is(':hidden')) {
            $('#liste').slideDown('slow');
            
        } else {
            $('#liste').slideUp('slow');
        }
    });
    $('#btrecherche').click(function (e) {
        e.preventDefault();
        if ($('#panrecherche').is(':hidden')) {
            $('#panrecherche').slideDown('slow');
        } else {
            $('#recherche').slideUp('slow');
        }
    });
    $('#btadd').click(function (e) {
        e.preventDefault();
        if ($('#add').is(':hidden')) {
            $('#add').slideDown('slow');
        } else {
            $('#add').slideUp('slow');
        }
    });
    JQ('#drag').draggable();
    JQ('#txtdebut').datepicker({
        dateFormat: "dd-mm-yy"
    });
    JQ('#txtfin').datepicker({
        dateFormat: "dd-mm-yy"
    });
    $('#btregion').live('click', function () {
        var sntDiv = $('#listeregion');
        var i = $('#listeregion p').size() + 1;
        $('<p><input  class="form-control" type="text" name="txtregion" id="txtregion' + i + '" /></label><input type="button" id="effacerregion" value="Effacer"  class="btn btn-danger"/></p>').appendTo(sntDiv);
    });
    $('#effacerregion').live('click', function () {
        var i = $('#listeregion p').size();
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
    $('#btdistrict').live('click', function () {
        var sntDiv = $('#listedistrict');
        var i = $('#listedistrict p').size() + 1;
        $('<p><input  class="form-control" type="text" name="txtdistrict" id="txtdistrict' + i + '" /></label><input type="button" id="effacerdistrict" value="Effacer"  class="btn btn-danger"/></p>').appendTo(sntDiv);
    });
    $('#effacerdistrict').live('click', function () {
        var i = $('#listedistrict p').size();
        var parent = $(this).parent('p');
        $('#lblconfirmregion').text("Voulez vous vraiment supprimer District?");
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
    $('#btEtat').live('click', function () {
        var sntDiv = $('#listeEtat');
        var i = $('#listeEtat panel').size() + 1;
        $('<panel><div class="panel panel-primary"><div class="panel-heading">Etat d\'avancement ' + i + '</div>' +
            '<div class="panel-body">' +
            'Etapes :<br/>' +
            '<textarea  class="form-control" id="txtetapes' + i + '" name="txtetapes"/><br/>' +
            'Date début :<br/><input required="required"  class="form-control" type="text" id="txtdebut' + i + '" name="txtdebut"/><br/>' +
            'Date fin :<br/><input  required="required"  class="form-control" type="text" id="txtfin' + i + '" name="txtfin"/><br/>' +
            'Situation Actuelle :<br/><textarea  class="form-control" id="txtsituation' + i + '" name="txtsituation"/><br/>' +
            'Contrainte :<br/><textarea  class="form-control" id="txtcontrainte' + i + '" name="txtcontrainte"/><br/>' +
            'Solution :<br/><textarea  class="form-control" id="txtsolution' + i + '" name="txtsolution"/><br/>' +
            'Obsérvation :<br/><textarea  class="form-control" id="txtobs' + i + '" name="txtobs"/><br/>' +
            'Etat:<br/><input type="text"  class="form-control" id="ddletat' + i + '" name="ddletat"><br/>' +
            'Urgences :<br/><select  class="form-control" id="ddlurgence' + i + '" name="ddlurgence">' +
            '<option>En retard</option>' +
            '<option>Normal</option>' +
            '<option>Urgent</option>' +
            '<option>Très Urgent</option>' +
            '</select>' +
            '</div></div></label><input type="button" id="effacerEtat" value="Effacer"  class="btn btn-danger"/></panel>').appendTo(sntDiv);
        JQ('#txtdebut' + i).datepicker({
            dateFormat: 'dd-mm-yy'
        });
        JQ('#txtfin' + i).datepicker({
            dateFormat: 'dd-mm-yy'
        });
    });
    $('#effacerEtat').live('click', function () {
        var i = $('#listeEtat panel').size();
        var parent = $(this).parent('panel');
        $('#lblconfirmregion').text("Voulez vous vraiment supprimer l'Etat d\'avancement?");
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
    
});