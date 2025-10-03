<%@ Page EnableSessionState="ReadOnly" ViewStateMode="Disabled" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addprojet.aspx.cs" Inherits="ProjetMeh.addprojet" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" EnableViewState="false"> 
    <link href="Styles/table.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/Script.js"></script>
    <script src="Scripts/table.js"></script>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" EnableViewState="false">
    <asp:SqlDataSource EnableViewState="false" ID="dsentite" runat="server" ConnectionString="<%$ ConnectionStrings:Projet %>" ProviderName="<%$ ConnectionStrings:Projet.ProviderName %>" SelectCommand="SELECT IdEntite, LibEntite FROM Entites"></asp:SqlDataSource>
    

    
    
    <div id="lblerreur" runat="server" enableviewstate="false"></div>
    <div id="dialogue">
        <p><label id="lblconfirmregion" enableviewstate="false"></label></p>
    </div>
    
    <div id="dial" class="web_dialog">
        <table style="width: 100%; border: 0px">
            <tr>
                <td class="web_dialog_title" colspan="4">Message</td>                
            </tr>
            <tr>
                <td>
                    <label>Voulez-vous vraiment supprimers?</label><br />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button runat="server" ID="Button2" Text="Supprimer" CausesValidation="False" OnClick="Button2_Click" enableviewstate="false"/>
                    <asp:Button runat="server" ID="Button3" Text="Annuler" CausesValidation="false" OnClick="Button3_Click" enableviewstate="false" />
                </td>
            </tr>
        </table>
     </div>


    <div id="dialog" class="web_dialog">
        <table style="width: 100%; border: 0px">
            <tr>
                <td class="web_dialog_title" colspan="4">Message</td>                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblmsg" runat="server" enableviewstate="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button enableviewstate="false" runat="server" ID="Button1" Text="OK" CausesValidation="False" OnClick="Button1_Click"/>
                </td>
            </tr>
        </table>
     </div>
    <!--
    <input type="button" value="Liste Projet" class="btn btn-primary" id="btliste" />&nbsp;&nbsp;&nbsp;
    <input type="button" value="Rechercher Projet" class="btn btn-primary" id="btrecherche" />&nbsp;&nbsp;&nbsp;
    -->
    <asp:Button EnableViewState="false" CssClass="btn btn-primary" ID="Button4" runat="server" Text="Liste Projet" OnClick="Button4_Click" />
    <asp:Button EnableViewState="false" CssClass="btn btn-primary" ID="Button5" runat="server" Text="Rechercher Projet" OnClick="Button5_Click" />
    <%
        if(Session["role"].ToString().Trim().ToUpper()=="ADMINISTRATEUR"
            || Session["role"].ToString().Trim().ToUpper()=="SUPER UTILISATEUR"
            || Session["role"].ToString().Trim().ToUpper()=="SUPERVISEUR"){
         %>
    <!--<input type="button" value="Ajouter Projet" class="btn btn-primary" id="btadd" />-->
    <asp:Button EnableViewState="false" CssClass="btn btn-primary" ID="bt_add" runat="server" Text="Ajouter Projet" OnClick="bt_add_Click" />
    <%
    } %>
        
    <div id="liste">       
        <asp:Panel ID="pan" runat="server" EnableViewState="false"></asp:Panel>
        <!--<asp:PlaceHolder ID="place" runat="server" EnableViewState="false"></asp:PlaceHolder>-->
    </div>
    <br />
    <asp:Panel ID="panelp" runat="server" Visible="false" EnableViewState="false">
    <div id="recherche">
        <h1>Recherche</h1>
        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3>Resultat Recherche</h3>
                    </div>
                    <div class="panel-body">
                        <div id="resultatrecherche" runat="server" enableviewstate="false"></div>
                    </div>
                </div>
            </div>
        </div>        
        <div class="row">
            <div class="col-sm-3">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Description du projet</h3>
                </div>
                <div class="panel-body">
                    Numéro :<br />
                    <asp:TextBox EnableViewState="false" ID="rchnum"  CssClass="form-control" runat="server"></asp:TextBox><br />
                    Titre :<br />
                    <asp:TextBox EnableViewState="false" ID="rchtitre"  CssClass="form-control" runat="server"></asp:TextBox><br />
                    Type :<br />
                    <asp:TextBox EnableViewState="false" ID="rchtype"  CssClass="form-control" runat="server"></asp:TextBox><br />
                    Capacite :<br />
                    <asp:TextBox EnableViewState="false" ID="rchcapacite"  CssClass="form-control" runat="server"></asp:TextBox><br />
                    Promoteur :<br />
                    <asp:TextBox EnableViewState="false" ID="rchpromoteur"  CssClass="form-control" runat="server"></asp:TextBox><br />
                    Source :<br />
                    <asp:TextBox EnableViewState="false" ID="rchsource"  CssClass="form-control" runat="server"></asp:TextBox><br />
                    Région :<br />
                    <asp:TextBox ID="rchregion" EnableViewState="false"  CssClass="form-control" runat="server"></asp:TextBox><br />
                    District :<br />                    
                    <asp:TextBox ID="rchdistrict" EnableViewState="false"  CssClass="form-control" runat="server"></asp:TextBox><br />
                </div>

            </div>
         
        </div>
        <div class="col-sm-3">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Etat d'avancement</h3>
                </div>
                <div class="panel-body">
                    Etapes :<br />
                    <asp:TextBox EnableViewState="false" ID="rchetape"  CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    Début :<br /> <input type="text" id="rcdebut" name="rcdebut"  class="form-control"/><br />
                    Fin : <br /><input type="text" id="rcfin" name="rcfin"  class="form-control"/><br />
                    Contrainte :<br />
                    <asp:TextBox EnableViewState="false" ID="rchcontrainte"  CssClass="form-control" runat="server"></asp:TextBox><br />                    
                    Solution :<br />
                    <asp:TextBox EnableViewState="false" ID="rchsolution"  CssClass="form-control" runat="server"></asp:TextBox><br />
                    Observations :<br />
                    <asp:TextBox EnableViewState="false" ID="rchobs"  CssClass="form-control" runat="server"></asp:TextBox><br />
                    Etat :<br />
                    <asp:TextBox EnableViewState="false" ID="rchetat"  CssClass="form-control" runat="server"></asp:TextBox><br />
                    Urgence :<br />
                    <asp:TextBox EnableViewState="false" ID="rchurgence"  CssClass="form-control" runat="server"></asp:TextBox><br />

                </div>
            </div> 
        </div>
        <div class="col-sm-3">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Entite Responsable</h3>
                </div>
                <div class="panel-body">
                    Entite :<br />
                    <asp:TextBox EnableViewState="false" ID="rchentite"  CssClass="form-control" runat="server"></asp:TextBox><br />                    
                    Direction :<br />
                    <asp:TextBox EnableViewState="false" ID="rchdir"  CssClass="form-control" runat="server"></asp:TextBox><br />

                    service :<br />
                    <asp:TextBox EnableViewState="false" ID="rchser"  CssClass="form-control" runat="server"></asp:TextBox><br />
                    Nom :<br />
                    <asp:TextBox EnableViewState="false" ID="rchnom"  CssClass="form-control" runat="server"></asp:TextBox><br />
                    Prénom :<br />
                    <asp:TextBox EnableViewState="false" ID="rchprenom"  CssClass="form-control" runat="server"></asp:TextBox><br />
                    E-mail :<br />
                    <asp:TextBox EnableViewState="false" ID="rchmail"  CssClass="form-control" runat="server"></asp:TextBox><br />
                    Téléphone :<br />
                    <asp:TextBox EnableViewState="false" ID="rchtel"  CssClass="form-control" runat="server"></asp:TextBox><br />


                    <asp:Button EnableViewState="false" ID="rechercher" CssClass="btn btn-success" runat="server" Text="Rechercher" CausesValidation="false" OnClick="rechercher_Click" />
                </div>
            </div>
        </div>
        </div>
    </div>
        </asp:Panel>
    <br />
    <asp:Panel ID="paneladd" runat="server" Visible="false">
    <div id="add">
        <h1>Nouveau Projet</h1>
        <div class="row" style="width:100%">
        <div class="col-sm-4">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Description Du Projet</h3>
                </div>
                <div class="panel-body">
                    Titre du Projet : <br />
                    <asp:TextBox EnableViewState="false" CssClass="form-control" ID="txttitre" runat="server"></asp:TextBox><br />
                   
                    Type : <br />
                    <asp:TextBox EnableViewState="false" CssClass="form-control" ID="txttype" runat="server"></asp:TextBox><br />
                    Source : <br />
                    <asp:TextBox EnableViewState="false" CssClass="form-control" ID="txtsource" runat="server"></asp:TextBox><br />
                    Resumé : <br />
                    <asp:TextBox EnableViewState="false" CssClass="form-control" ID="txtcapacite" runat="server"></asp:TextBox><br />
                    Promoteur : <br />
                    <asp:TextBox EnableViewState="false" CssClass="form-control" ID="txtpromoteur" runat="server"></asp:TextBox><br />
                    Région :  <br />
                    <input class="form-control" type="text" id="txtregion" name="txtregion" /><br />
                    <div id="listeregion"></div>
                    <input type="button" id="btregion" class="btn btn-success" value="Ajouter plus de région" /><br />
                     <label  for="txtdistrict">District :</label> <br />
                    <input  class="form-control" type="text" id="txtdistrict" name="txtdistrict" /><br />
                    <div id="listedistrict"></div>
                    <input type="button" id="btdistrict" class="btn btn-success" value="Ajouter plus de district" />
                </div>
            </div>
          
        </div>    
    <div class="col-sm-4">
        <div class="panel panel-primary">
             <div class="panel-heading">
                  <h3 class="panel-title">Etat d'avancement</h3>
             </div>
             <div class="panel-body">
                    Etapes :<br />
                    <textarea class="form-control" id="txtetapes" name="txtetapes"></textarea><br />
                    Date début : <br />
                    <input  class="form-control" type="text" id="txtdebut" name="txtdebut" /><br />
                    Date fin :<br />
                    <input  class="form-control" type="text" id="txtfin" name="txtfin" /><br />
                    Situation actuelle :<br />
                    <textarea  class="form-control" id="txtsituation" name="txtsituation"></textarea><br />
                    Contrainte :<br />
                    <textarea  class="form-control"  id="txtcontrainte" name="txtcontrainte"></textarea><br />
                    Solution :<br />
                    <textarea  class="form-control"  id="txtsolution" name="txtsolution"></textarea><br />
                    Observations :<br />
                    <textarea  class="form-control"  id="txtobs" name="txtobs"></textarea><br />
                    Etat:<br />
                    <input  class="form-control" type="text" id="ddletat" name="ddletat"/>
                        <br />
                    Niveau d'urgence :<br />
                    <select  class="form-control" id="ddlurgence" name="ddlurgence">
                        <option>En Retard</option>
                        <option>Normal</option>
                        <option>Urgent</option>
                        <option>Très Urgent</option>
                    </select>                  
                </div>
            </div>            
            <div id="listeEtat"></div>                                  
            <input type="button" value="Ajouter plus d'Etat" class="btn btn-success" id="btEtat" /> 
        </div>
        <div class="col-sm-4">
                        <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Responsable</h3>
                </div>
                <div class="panel-body">
                    Entite :<br />
                    <asp:DropDownList  EnableViewState="false"  CssClass="form-control" ID="ddlentite" runat="server" DataSourceID="dsentite" DataTextField="libentite" DataValueField="identite"></asp:DropDownList><br />
                    Direction :<br />
                    <asp:TextBox EnableViewState="false"  CssClass="form-control" ID="txtdirection" runat="server"></asp:TextBox><br />
                    Service :<br />
                    <asp:TextBox EnableViewState="false"  CssClass="form-control" ID="txtservice" runat="server"></asp:TextBox><br />
                    Nom de l'agent : <br />
                    <asp:TextBox EnableViewState="false"  CssClass="form-control" ID="txtnom" runat="server"></asp:TextBox><br />
                    Prénom de l'agent : <br />
                    <asp:TextBox EnableViewState="false"  CssClass="form-control" ID="txtprenom" runat="server"></asp:TextBox><br />                
                    Téléphone :<br />
                    <asp:TextBox EnableViewState="false" CssClass="form-control" ID="txttel" runat="server"></asp:TextBox><br />
                    E-mail:<br />
                    <asp:TextBox EnableViewState="false"  CssClass="form-control" ID="txtmail" runat="server"></asp:TextBox><br />
                </div>
            </div>
        </div>

    </div>
        <asp:Button EnableViewState="false" runat="server" ID="btajouter" Text="Enregistrer Projet" CssClass="btn btn-primary" OnClick="btajouter_Click"/>
        
    </div>
        </asp:Panel>
</asp:Content>
