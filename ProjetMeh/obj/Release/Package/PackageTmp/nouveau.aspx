<%@ Page EnableSessionState="False" ViewStateMode="Disabled" Language="C#" AutoEventWireup="true" CodeBehind="nouveau.aspx.cs" Inherits="ProjetMeh.nouveau" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>-MEH</title>
    <link rel="icon" href="Images/saina.png" />
    <link href="Styles/theme.css" rel="stylesheet" />
    <link href="Styles/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/ie10-viewport-bug-workaround.css" rel="stylesheet" />
    <link href="Styles/signin.css" rel="stylesheet" />
    <link href="Styles/popup.css" rel="stylesheet" />

    <script src="Scripts/jquery-ui-1.12.1.custom/external/jquery/jquery.js"></script>
    <script src="Scripts/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <nav class="navbar navbar-inverse navbar-fixed-top">
    <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
            <a class="navbar-brand" href="#">
                <img class="img-responsive" src="../Images/saina.png" style="float:left;" width="50" height="25" alt="saina" />
            </a>
          <a class="navbar-brand" href="#">MEH</a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
          
        </div><!--/.nav-collapse -->
      </div>
    </nav>
    
        <div class="row"  style="margin-left:auto;margin-right:auto">
            <div class="col-sm-4" >
                <div class="panel panel-primary">
                    <div class="panel panel-heading">
                        <h3 class="panel-title">Nouveau Compte</h3>
                    </div>

                    <div class="panel panel-body">
                <label style="color:red">*</label> Champ obligatoire<br />
                <label style="color:green">*</label> Champ invalid<br />
                <label style="color:blue">*</label> Champ identique<br />
           
            <asp:Label ID="lblentite" runat="server" Text="Entite :"></asp:Label><br />
            <asp:DropDownList ID="ddlentite" runat="server" CssClass="form-control">
                <asp:ListItem>MEH</asp:ListItem>
                <asp:ListItem>ADER</asp:ListItem>
                <asp:ListItem>JIRAMA</asp:ListItem>
                <asp:ListItem>OMH</asp:ListItem>
                <asp:ListItem>ORE</asp:ListItem>
            </asp:DropDownList>
            <br />
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

            <asp:Button ID="bt_ok" runat="server" CssClass="btn btn-primary" Text="Enregistrer" OnClick="bt_ok_Click" />&nbsp;&nbsp;
            <asp:Button ID="bt_annuler" CssClass="btn btn-primary" runat="server" Text="Annuler" CausesValidation="False" OnClick="bt_annuler_Click" />
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
    </form>
</body>
</html>
