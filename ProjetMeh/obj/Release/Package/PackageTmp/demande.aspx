<%@ Page EnableSessionState="True" ViewStateMode="Disabled" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="demande.aspx.cs" Inherits="ProjetMeh.demande" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblerreur" runat="server" EnableViewState="false"></asp:Label>
    <asp:DropDownList ID="ddlentite" runat="server" AutoPostBack="true">
       <asp:ListItem>Administrateur</asp:ListItem>
       <asp:ListItem>Superviseur</asp:ListItem>
       <asp:ListItem>Super Utilisateur</asp:ListItem>
       <asp:ListItem>Utilisateur</asp:ListItem>
   </asp:DropDownList>
    <div id="panel" runat="server"></div>

    <div id="dialog" class="web_dialog">
        <table style="width: 100%; border: 0px">
            <tr>
                <td class="web_dialog_title" colspan="4">Rechercher</td>                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblmsg" runat="server" EnableViewState="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button EnableViewState="false" runat="server" ID="Button1" Text="OK" CausesValidation="False" OnClick="Button1_Click"/>
                </td>
            </tr>
        </table>
     </div>
</asp:Content>
