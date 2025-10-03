<%@ Page EnableSessionState="ReadOnly" ViewStateMode="Disabled" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ajout.aspx.cs" Inherits="ProjetMeh.ajout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="width:100%">
        <div class="col-sm-4">
            <div class="panel panel-primary">
                <div class="panel panel-heading">
                <h3 class="panel-title">Ajout Comptes</h3>
            </div>
            <div class="panel panel-body">
                <asp:Label ID="Label9" runat="server" Text="Roles :"></asp:Label><br />
                <asp:DropDownList ID="ddlrole" runat="server" CssClass="form-control">
                    <asp:ListItem Value="1" Text="Administrateur">Administrateur</asp:ListItem>
                    <asp:ListItem Value="2" Text="Superviseur">Superviseur</asp:ListItem>
                    <asp:ListItem Value="3" Text="Utilisateur">Utilisateur</asp:ListItem>
                    <asp:ListItem Value="4" Text="Simple Utilisateur">Simple Utilisateur</asp:ListItem>                    
                </asp:DropDownList><br />
                <asp:Label ID="Label10" runat="server" Text="Entites :"></asp:Label><br />
                <asp:DropDownList ID="ddlentite" runat="server" DataSourceID="dsentite" DataTextField="libentite" DataValueField="identite" CssClass="form-control"></asp:DropDownList><br />
                <asp:Label ID="lblfonction" runat="server" Text="Direction :"></asp:Label><br />
            <asp:TextBox ID="txtfonction" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtfonction" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>            
            <br />

            <asp:Label ID="Label1" runat="server" Text="Service :"></asp:Label><br />
            <asp:TextBox ID="txtservice" runat="server" CssClass="form-control"></asp:TextBox><br />

            <asp:Label ID="Label2" runat="server" Text="Nom :"></asp:Label><br />
            <asp:TextBox ID="txtnom" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtnom"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Prénom :"></asp:Label><br />
            <asp:TextBox ID="txtprenom" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtprenom"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label4" runat="server" Text="E-mail :"></asp:Label><br />
            <asp:TextBox ID="txtmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtmail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^(([\w]+)@([\w]+)\.([\w]+)|([\w]+)\.([\w]+)@([\w]+)\.([\w]+)|([\w]+)@([\w]+)\.([\w]+)\.([\w]+))$" runat="server" ErrorMessage="*" ForeColor="Green" ControlToValidate="txtmail"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Telephone :"></asp:Label><br />
            <asp:TextBox ID="txttel" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txttel"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ForeColor="Green" ControlToValidate="txttel" ValidationExpression="^((\+)([0-9]{10,15})|[0-9]{10,15})$"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Pseudo :"></asp:Label><br />
            <asp:TextBox ID="txtpseudo" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtpseudo"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Mot de passe :"></asp:Label><br />
            <asp:TextBox ID="txtmdp" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtmdp" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ForeColor="Blue" ControlToCompare="txtconfirm" ControlToValidate="txtmdp"></asp:CompareValidator>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Confirmer Mot de passe :"></asp:Label><br />
            <asp:TextBox ID="txtconfirm" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="txtconfirm" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" ForeColor="Blue" ControlToCompare="txtconfirm" ControlToValidate="txtmdp"></asp:CompareValidator>
            
            <br />
            <asp:Button ID="bt_ok" runat="server" Text="Enregistrer" OnClick="bt_ok_Click" CssClass="btn btn-primary" />&nbsp;&nbsp;
            <asp:Button ID="bt_annuler" runat="server" Text="Annuler" CausesValidation="False" OnClick="bt_annuler_Click" CssClass="btn btn-primary" />
            </div>
            </div>
        </div>

        <div id="panel" runat="server"></div>

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

    <asp:SqlDataSource ID="dsentite" runat="server" ConnectionString="<%$ ConnectionStrings:Projet %>" ProviderName="<%$ ConnectionStrings:Projet.ProviderName %>" SelectCommand="SELECT IdEntite, LibEntite FROM Entites"></asp:SqlDataSource>

</asp:Content>
