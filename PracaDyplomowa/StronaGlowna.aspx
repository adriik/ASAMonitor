<%@ Page Title="Strona Główna" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StronaGlowna.aspx.cs" Inherits="PracaDyplomowa._StronaGlowna" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 style="text-align:center">Podstawowe informacje</h1>


        <div class="row">
            <div class="col-sm-6">
                <asp:UpdatePanel runat="server" ID="UpdatePanel">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer" EventName="Tick"/>
                    </Triggers>
                    <ContentTemplate>
                        <p>
                            <asp:Label ID="Label1" runat="server" Text="Urządzenie jest uruchmione od:"></asp:Label></p>
                        <p>
                            <asp:Label ID="Label2" runat="server" Text="Wersja systemu:"></asp:Label></p>
                        <p>
                            <asp:Label ID="Label3" runat="server" Text="Tryb firewalla:"></asp:Label></p>
                        <p>
                            <asp:Label ID="LabelGodzina" runat="server" Text="Czas:"></asp:Label></p>
                        <asp:Timer ID="Timer" Interval="10000" OnTick="Timer_Tick" runat="server"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-sm-6">
                <div class="table-responsive">
                    <asp:Table ID="Table1" runat="server" Width="100%" class="table table-hover">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>Interfejsy</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Adres IP</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Maska podsieci</asp:TableHeaderCell>
                            <asp:TableHeaderCell>MTU</asp:TableHeaderCell>
                            <asp:TableHeaderCell>CCL</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
            </div>
        </div>
     </div>

</asp:Content>
