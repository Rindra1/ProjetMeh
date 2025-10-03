<%@ Page EnableSessionState="ReadOnly" ViewStateMode="Disabled" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addetape.aspx.cs" Inherits="ProjetMeh.addetape" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" EnableViewState="false">
    <script src="Scripts/Script2.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" EnableViewState="false" runat="server">
    <div id="lblerreur" runat="server" enableviewstate="false"></div>

            <div id="dialog" class="web_dialog">
        <table style="width: 100%; border: 0px">
            <tr>
                <td class="web_dialog_title" colspan="4">Message</td>                
            </tr>
            <tr>
                <td>
                    <asp:Label EnableViewState="false" ID="lblmsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button EnableViewState="false" runat="server" ID="Button1" Text="OK" CausesValidation="False" OnClick="Button1_Click"/>
                </td>
            </tr>
        </table>
     </div>
    
    <div id="dialogue">
        <p><label id="lblconfirmregion"></label></p>
    </div>
    <div class="row" style="width:auto">
        <div class="col-sm-4">
            <div class="panel panel-primary">
                <div class="panel panel-heading">
                    <h3 class="panel-title">Description du Projet</h3>
                </div>
                <div class="panel panel-body">                    
                    <div id="description"></div>
                </div>
            </div>
        </div>
        <div class="col-sm-4">
        <div class="panel panel-primary">
             <div class="panel-heading">
                  <h3 class="panel-title">Etat d'avancement</h3>
             </div>
             <div class="panel-body">
                    <label for="txtetapes">Etapes :</label><br />
                    <textarea class="form-control" id="txtetapes" name="txtetapes"></textarea><br />
                    Date début : <br />
                    <input  class="form-control" type="text" id="txtdebut" name="txtdebut" /><br />
                    Date fin :<br />
                    <input  class="form-control" type="text" id="txtfin" name="txtfin" /><br />
                    Situation actuelle :<br />
                    <textarea  class="form-control" id="txtsituation" name="txtsituation"></textarea><br />
                    Contrainte :<br />
                    <textarea   class="form-control" id="txtcontrainte" name="txtcontrainte"></textarea><br />
                    Solution :<br />
                    <textarea   class="form-control" id="txtsolution" name="txtsolution"></textarea><br />
                    Obsérvation :<br />
                    <textarea   class="form-control" id="txtobs" name="txtobs"></textarea><br />
                    Etat:<br />
                    <input type="text" class="form-control" id="ddletat" name="ddletat"/>
                        <br />
                    Niveau d'urgence :<br />
                    <select id="ddlurgence"   class="form-control" name="ddlurgence">
                        <option>En Retard</option>
                        <option>Normal</option>
                        <option>Urgent</option>
                        <option>Très Urgent</option>
                    </select>                  
                </div>
            </div>            
            <div id="listeEtat"></div>                                  
            <input type="button" value="Ajouter plus d'Etat" class="btn btn-success" id="btEtataddetape" /> 
        </div>
        <div class="col-sm-4">
            <div class="panel panel-primary">
                <div class="panel panel-heading">
                    <h3 class="panel-title">Entite Résponsable</h3>
                </div>
                <div class="panel panel-body">                    
                    <div id="entite" runat="server"></div>
                </div>
            </div>
        </div>
     
    </div>
        <asp:Button EnableViewState="false" ID="bt_add" runat="server" CssClass="btn btn-primary"  Text="Enregistrer Etapes" OnClick="bt_add_Click" />
    

</asp:Content>
