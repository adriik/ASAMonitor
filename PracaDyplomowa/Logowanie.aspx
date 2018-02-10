<%@ Page Title="Logowanie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logowanie.aspx.cs" Inherits="PracaDyplomowa.Logowanie" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
    
    <div class="jumbotron"> 
            <h1 style="text-align:center">Zaloguj się do Cisco ASA</h1>
        <div class="container-fluid">
            <div class="row">

                <div class="col text-center">
                    <label for="TextBoxIp">Adres IP:</label>
                    <div class="form-group input-group">
                        <span class="input-group-addon" id="basic-addon1">https://</span>
                        <asp:TextBox ID="TextBoxIp" type="text" class="form-control" runat="server" aria-describedby="basic-addon1" ToolTip="10.0.0.2"></asp:TextBox>  
                    </div>
                    <div class="form-group">
                        <label for="TextBoxName">Nazwa użytkownika:</label>
                        <asp:TextBox ID="TextBoxName" type="text" class="form-control" runat="server" MinLength="3" MaxLength="60" ToolTip="cisco"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidatorUsername" CssClass="help-block" runat="server" ErrorMessage="Musisz podać nazwę użytkownika" ControlToValidate="TextBoxName"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="TextBoxPassword">Hasło:</label>
                        <asp:TextBox ID="TextBoxPassword" type="password" class="form-control" runat="server" MinLength="3" MaxLength="127" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidatorPassword" CssClass="help-block" runat="server" ErrorMessage="Musisz podać hasło" ControlToValidate="TextBoxPassword"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Button ID="ButtonZaloguj" runat="server" Text="Zaloguj" class="btn btn-primary btn-lg" OnClick="btnLogin_Click" Style="text-align:center"/>

                </div>
             </div>
            <br />
            <div class="row">

                <div class="col text-center">
                    <asp:CustomValidator ID="ValidatorBlad" runat="server" CssClass="alert alert-danger" ErrorMessage="Podany adres nie odpowiada"></asp:CustomValidator>
                </div>
            </div>
            <div class="row">
                <div class="col text-center">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="alert alert-danger" runat="server" ErrorMessage="Niepoprawny format adresu IP" ControlToValidate="TextBoxIP" ValidationExpression="^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="col text-center">
                    <asp:RequiredFieldValidator ID="ValidatorAddress" runat="server" CssClass="alert alert-danger" ErrorMessage="Musisz wpisać adres urządzenia" ControlToValidate="TextBoxIp"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div>

            <script type="text/javascript">
            function extendedValidatorUpdateDisplay(obj) {
                // Appelle la méthode originale
                if (typeof originalValidatorUpdateDisplay === "function") {
                    originalValidatorUpdateDisplay(obj);
                }
                // Récupère l'état du control (valide ou invalide) 
                // et ajoute ou enlève la classe has-error
                var control = document.getElementById(obj.controltovalidate);
                if (control) {
                    var isValid = true;
                    for (var i = 0; i < control.Validators.length; i += 1) {
                        if (!control.Validators[i].isvalid) {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid) {
                        $(control).closest(".form-group").removeClass("has-error");
                    } else {
                        $(control).closest(".form-group").addClass("has-error");
                    }
                }
            }
            // Remplace la méthode ValidatorUpdateDisplay
            var originalValidatorUpdateDisplay = window.ValidatorUpdateDisplay;
            window.ValidatorUpdateDisplay = extendedValidatorUpdateDisplay;
        </script>
</asp:Content>
