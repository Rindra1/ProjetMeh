<%@ Page EnableSessionState="ReadOnly"  ViewStateMode="Disabled" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="impression.aspx.cs" Inherits="ProjetMeh.impression" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a class="btn btn-success" href="#" onclick="javascript:window.print()" id="impression">Imprimer</a>
    <asp:Label ID="lblimp" runat="server" EnableViewState="false"></asp:Label>
</asp:Content>
