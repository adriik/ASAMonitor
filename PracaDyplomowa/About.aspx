<%@ Page Title="O stronie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PracaDyplomowa.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
    <div class="panel-group" id="accordion">
  <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
        Strona główna</a>
      </h4>
    </div>
    <div id="collapse1" class="panel-collapse collapse in">
      <div class="panel-body">Strona przedstawiająca podstawowe informacje o konfiguracji Cisco ASA. Informuje nas o stanie wszystkich interfejsów występujących, w urządzeniu.
          Dodatkowo możemy się dowiedzieć czy dany interfejs jest typu Cluster Control Link (CCL).
      </div>
    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">
        Konsola</a>
      </h4>
    </div>
    <div id="collapse2" class="panel-collapse collapse">
      <div class="panel-body">Strona umożliwiająca interakcję z konsolą urządzenia. Dostępna jest historia wpisanych komend. 
          W tym oknie możemy budować potok komend stosując znak "|".</div>
    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">
        Syslog</a>
      </h4>
    </div>
    <div id="collapse3" class="panel-collapse collapse">
      <div class="panel-body">Strona przedstawiająca wszystkie komunikaty wysłane przez ASA od momentu wystartowania aplikacji. Panel jest automatycznie uzupełniany o nowe komunikaty.</div>
    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#collapse4">
        Interpretacja</a>
      </h4>
    </div>
    <div id="collapse4" class="panel-collapse collapse">
      <div class="panel-body">Strona przedstawiająca interpretację komunikatów odebranych od ASA. Daje nam możliwość zapoznania się z opisem oraz proponowanym rozwiązaniem danego komunikatu.</div>
    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#collapse5">
        Klaster</a>
      </h4>
    </div>
    <div id="collapse5" class="panel-collapse collapse">
      <div class="panel-body">Strona przedstawiająca stan klastra - jeżeli jest aktywowany. Przedstawia komunikaty odnoszące się do pracy klastra. Umożliwia nam również wygenerować raport do pliku tekstowego.</div>
    </div>
  </div>



</div>
        </div>

</asp:Content>
