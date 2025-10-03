$(document).ready(function () {
    JQ('#txtdebut').datepicker({
        dateFormat: "dd-mm-yy"
    });
    JQ('#txtfin').datepicker({
        dateFormat: "dd-mm-yy"
    });
    var id = Obtenirparam("id");
    $.ajax({
        type: "POST",
        dataType: "json",
        data: "{id:" + id + "}",
        url: "addetape.aspx/GetProjet",
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            var table = "";
            $.each(result.d, function (key, resultat) {
                table += "<label style='color:blue'> Titre :</label><br/>" + resultat.Titre + "<br/>";
                table += "<label style='color:blue'>Promoteur :</label><br/>" + resultat.Promoteur + "<br/>";
                table += "<label style='color:blue'>Source :</label><br/>" + resultat.Source + "<br/>";
                table += "<label style='color:blue'>Type :</label><br/>" + resultat.Type + "<br/>";
                table += "<label style='color:blue'>Capacite :</label><br/>" + resultat.Capacite + "<br/>";
            });
            table += "</div></div>";
            $('#description').append(table);
        },
        error: function (result) {
        }
    });
    $('#btEtataddetape').live('click', function () {
        var sntDiv = $('#listeEtat');
        var i = $('#listeEtat panel').size() + 1;
        $('<panel><div class="panel panel-primary"><div class="panel-heading">Etat d\'avancement ' + i + '</div>' +
            '<div class="panel-body">' +
            'Etapes :<br/>' +
            '<textarea  class="form-control" id="txtetapes' + i + '" name="txtetapes"/><br/>' +
            'Date début :<br/><input  class="form-control" type="date" id="txtdebut' + i + '" name="txtdebut"/><br/>' +
            'Date fin :<br/><input  class="form-control" type="date" id="txtfin' + i + '" name="txtfin"/><br/>' +
            'Situation Actuelle :<br/><textarea  class="form-control" id="txtsituation' + i + '" name="txtsituation"/><br/>' +
            'Contrainte :<br/><textarea  class="form-control" id="txtcontrainte' + i + '" name="txtcontrainte"/><br/>' +
            'Solution :<br/><textarea  class="form-control" id="txtsolution' + i + '" name="txtsolution"/><br/>' +
            'Obsérvation :<br/><textarea  class="form-control" id="txtobs' + i + '" name="txtobs"/><br/>' +
            'Etat:<br/><input  class="form-control" type="text" id="ddletat' + i + '" name="ddletat"><br/>' +
            'Urgences :<br/><select  class="form-control" id="ddlurgence' + i + '" name="ddlurgence">' +
            '<option>En retard</option>' +
            '<option>Normal</option>' +
            '<option>Urgent</option>' +
            '<option>Très Urgent</option>' +
            '</select>' +
            '</div></div></label><input type="button" id="effacerEtataddetape" value="Effacer"/></panel>').appendTo(sntDiv);
        JQ('#txtdebut' + i).datepicker({
            dateFormat: 'dd-mm-yy'
        });
        JQ('#txtfin' + i).datepicker({
            dateFormat: 'dd-mm-yy'
        });
    });
    $('#effacerEtataddetape').live('click', function () {
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
})

function Obtenirparam(sVar) {
    return unescape(window.location.search.replace(new RegExp("^(?:.*[&\\?]" + escape(sVar).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
}