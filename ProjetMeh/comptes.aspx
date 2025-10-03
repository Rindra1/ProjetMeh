<%@ Page EnableSessionState="True" ViewStateMode="Disabled" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="comptes.aspx.cs" Inherits="ProjetMeh.comptes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="panel" runat="server"></asp:Panel>
    <div class="row"  style="margin-left:auto;margin-right:auto">
            <div class="col-sm-4" >
                <div class="panel panel-primary">
                    <div class="panel panel-heading">
                        <h3 class="panel-title">Modifier Pseudo et Mot de Passe</h3>
                    </div>
                    <div class="panel panel-body">
                    <label>Pseudo :</label>
                    <br /><asp:TextBox ID="txtpseudo" CssClass="form-control" runat="server"></asp:TextBox><br />
                        <label>Mot de Passe :</label>
                    <br /><asp:TextBox ID="txtmdp" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox><br />
                        <label>Confirmer Mot de Passe  :</label>
                    <br /><asp:TextBox ID="txtconfirm" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox><br />

                    <asp:Button ID="bt_ok" runat="server" CssClass="btn btn-primary" Text="Enregistrer" OnClick="bt_ok_Click" />&nbsp;&nbsp;
                    </div>
                </div>                
            </div>
        </div>
        
        <div id="dialog" class="web_dialog">
        <table style="width: 100%; border: 0px">
            <tr>
                <td class="web_dialog_title" colspan="4">Message</td>                
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
