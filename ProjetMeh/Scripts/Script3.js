$(document).ready(function () {
    var id = Obtenirparam("id");
    $.ajax({
        type: "POST",
        dataType: "json",
        data: "{id:" + id + "}",
        url: "update.aspx/GetProjet",
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
    $.ajax({
        type: "POST",
        dataType: "json",
        data: "{id:" + id + "}",
        url: "update.aspx/GetEtat",
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            var table = "";
            var nbr = 1;
            $.each(result.d, function (key, resultat) {
                table += "<div class='row'><div class='panel panel-primary'>";
                table += "<div class='panel-heading'><h3 class='panel-title'>Etapes " + nbr + "</h3></div>";
                table += "<div class='panel-body'>";
                table += "<input type='hidden' id='id_" + nbr + "' value='" + resultat.IdEtape + "' name='id'/><br/>"
                if (resultat.LibEtape != "")
                    table += "<label style='color:blue'> Etape :</label><br/><textarea  class='form-control' id='txtetape_'" + nbr + " name='txtetape'>" + resultat.LibEtape + "</textarea><br/>";
                else
                    table += "<label style='color:blue'> Etape :</label><br/><textarea class='form-control' id='txtetape_'" + nbr + " name='txtetape'></textarea><br/>";
                table += "<label style='color:blue'>Debut :</label><br/><input class='form-control' type='text' id='txtdebut_" + nbr + "' name='txtdebut' value='" + resultat.Debut + "'   /><br/>";
                table += "<label style='color:blue'>Fin :</label><br/><input class='form-control' type='text' id='txtfin_" + nbr + "' name='txtfin' value='" + resultat.Fin + "' /><br/>";
                if (resultat.Situation != "")
                    table += "<label style='color:blue'>Situation :</label><br/><textarea id='txtsituation_" + nbr + "' name='txtsituation'  class='form-control' >" + resultat.Situation + "</textarea><br/>";
                else
                    table += "<label style='color:blue'>Situation :</label><br/><textarea class='form-control' id='txtsituation_" + nbr + "' name='txtsituation' ></textarea><br/>";
                table += "<label style='color:blue'>Contrainte :</label><br/><textarea class='form-control' id='txtcontrainte_" + nbr + "' name='txtcontrainte' >" + resultat.Contrainte + "</textarea><br/>";
                table += "<label style='color:blue'>Solution :</label><br/><textarea class='form-control' id='txtsolution_" + nbr + "' name='txtsolution'> " + resultat.Solution + "</textarea><br/>";
                table += "<label style='color:blue'>Observation :</label><br/><textarea class='form-control' id='txtobs_" + nbr + "' name='txtobs'>" + resultat.Obs + "</textarea><br/>";
                table += "<label style='color:blue'>Etat :</label><br/><textarea class='form-control' id='txtetat_" + nbr + "' name='txtetat'  value='" + resultat.Etat + "'/><br/>";
                table += "<select id='ddlurgence_" + nbr + "' name='ddlurgence' class='form-control'>";
                table += "<option value='En Retard'>En Retard</option>";
                table += "<option value='Normal'>Normal</option>";
                table += "<option value='Urgent'>Urgent</option>";
                table += "<option value='Très Urgent'>Très Urgent</option>";
                table += "</select>";
                table += "</div></div></div>";
                JQ('#txtdebut_' + nbr).datepicker({
                    dateFormat: "dd-mm-yy"
                });
                JQ('#txtfin_' + nbr).datepicker({
                    dateFormat: "dd-mm-yy"
                });
                nbr++;
            });
            $('#etape').append(table);
        },
        error: function (result) {
        }
    });
    $('#add').live('click', function () {
        var sntdiv = $('#sntdiv');
        var i = $('#sntdiv p').size() + 1;
        $('<p><input type="text" id="txtdestinataire' + i + '" list="datalist" name="txtdestinataire"/></label><input type="button" id="bteffacer" value="Effacer"/></p>').appendTo(sntdiv);
    });
    $('#bteffacer').live('click', function () {
        var i = $('#sntdiv p').size();
        var parent = $(this).parent('p');
        $('#lblconfirmregion').text("Voulez vous vraiment supprimer destinataire?");
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