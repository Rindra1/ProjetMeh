<%@ Page EnableSessionState="ReadOnly" ViewStateMode="Disabled" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="ProjetMeh.update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/Script3.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <div id="etape"></div>
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
    <asp:Button ID="bt_update" runat="server" Text="Modifier" OnClick="bt_update_Click" CssClass="btn btn-primary" />
    
</asp:Content>
