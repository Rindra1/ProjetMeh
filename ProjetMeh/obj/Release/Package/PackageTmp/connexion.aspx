<%@ Page EnableSessionState="True" EnableViewState="false" Language="C#" AutoEventWireup="true" CodeBehind="connexion.aspx.cs" Inherits="ProjetMeh.connexion" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>-MEH</title>
    <link href="Styles/theme.css" rel="stylesheet" />
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Styles/ie10-viewport-bug-workaround.css" rel="stylesheet" />
    <link href="Styles/signin.css" rel="stylesheet" />

    <style type="text/css">
        
    </style>

</head>
<body>
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
          <a class="navbar-brand" href="#"><p id="titre">MEH</p></a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
          
        </div><!--/.nav-collapse -->
      </div>
    </nav>
    <form enableviewstate="false" id="form1" runat="server" autocomplete="off" class="form-signin">
    
        
    <div id="lblerreur" runat="server"></div>
    <h2 class="form-signin-heading">Connexion</h2>
        <label for="txtpseudo" class="sr-only">Pseudo</label>
        <input type="text" id="txtpseudo" name="txtpseudo" class="form-control" placeholder="Pseudo" required="required"/>
        <label for="txtmdp" class="sr-only">Password</label>
        <input type="password" id="txtmdp" name="txtmdp" class="form-control" placeholder="Mot de passe" required="required"/>
        <div class="checkbox">
          <label>
            <asp:CheckBox ID="chk" runat="server" Text="Se Souvenir" EnableViewState="false" /> 
          </label>
        </div>
        <asp:Button ID="btconnexion" runat="server" Text="Se Connecter" CssClass="btn btn-lg btn-primary btn-block" OnClick="btconnexion_Click" EnableViewState="false" />
        <asp:LinkButton ID="lnknouveau" runat="server" Text="Nouveau Compte" OnClick="lnknouveau_Click"  CssClass="btn btn-lg btn-success btn-block" EnableViewState="false"></asp:LinkButton> 
        
    </form> 
</body>
</html>
