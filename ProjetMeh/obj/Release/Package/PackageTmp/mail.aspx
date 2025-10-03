<%@ Page EnableSessionState="ReadOnly" ViewStateMode="Disabled" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mail.aspx.cs" Inherits="ProjetMeh.mail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/Script1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dialogue">
        <p><label id="lblconfirmregion"></label></p>
    </div>

    <div class="row" style="width:100%">
        <div class="col-sm-3">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Envoi E-mail</h3>
                </div>
                <div class="panel-body">
                    <asp:Label ID="lblexp" runat="server">Expediteur :</asp:Label><br />
                    <asp:TextBox ID="txtexp" runat="server" CssClass="form-control"></asp:TextBox><br />
                    <asp:Label ID="lblmdp" runat="server">Mot de passe :</asp:Label><br />
                    <asp:TextBox runat="server" ID="txtmdp" TextMode="Password" CssClass="form-control"></asp:TextBox><br />
                    <asp:Label ID="lblhost" runat="server">Host :</asp:Label><br />
                    <!--
                    <asp:TextBox ID="txthost" runat="server" CssClass="form-control"></asp:TextBox><br />
                    -->
                    <input type="text" id="txth" class="form-control" name="txth" list="listehost" />
                    <datalist id="listehost">
                        <option value="smtp.gmail.com">smtp.gmail.com</option>
                        <option value="stmp.live.com">smtp.live.com</option>
                        <option value="smtp.moov.com">smtp.moov.mg</option>
                        <option value="smtp.wanadoo.fr">smtp.wanadoo.fr</option>
                        <option value="mail.yahoo.com">mail.yahoo.com</option>
                    </datalist>
                    <br />
                    <asp:Label ID="lbldestinataire" runat="server">Destinataire :</asp:Label><br />
                    <input  class="form-control" type="text" id="txtdestinataire" name="txtdestinataire" list="datalist" /><br />
                    <div id="sntdiv"></div>                 
                    <input type="button" class="btn btn-success" value="Ajouter plus de destinataire" id="add" /><br />
                    <asp:Label ID="lblobjet" runat="server">Objet :</asp:Label><br />
                    <asp:TextBox CssClass="form-control" ID="txtobjet" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lbltexte" runat="server">Texte :</asp:Label><br />
                    <asp:TextBox CssClass="form-control" ID="txttexte" runat="server" TextMode="MultiLine"></asp:TextBox><br />
                    <asp:Button ID="btenvoi" runat="server" Text="Envoyer" OnClick="btenvoi_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
      </div>

    <div id="dialog" class="web_dialog">
        <table style="width: 100%; border: 0px">
            <tr>
                <td class="web_dialog_title" colspan="4">Rechercher</td>                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button runat="server" ID="Button1" Text="OK" CausesValidation="False" OnClick="Button1_Click"/>
                </td>
            </tr>
        </table>
     </div>
</asp:Content>
