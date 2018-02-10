<%@ Page Title="Konsola" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Konsola.aspx.cs" Inherits="PracaDyplomowa.Konsola" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>

    <div class="jumbotron">
        <div class="row">

            <div class="col">
                <div class="form-group">
                    <asp:UpdatePanel runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Button1" />
                        </Triggers>
                        <ContentTemplate>
                            <textarea id="textarea" style="width: 100%; background-color: white;" type="text" class="form-control" runat="server" rows="20" disabled></textarea></ContentTemplate>
                    </asp:UpdatePanel>   
                </div>
                <label for="TextBoxIp">Wprowadź komdendę:</label>
                <div class="form-group input-group">
                    <span class="input-group-addon" id="basic-addon1">ciscoasa#</span>
                    <asp:TextBox ID="TextBoxKomenda" type="text" class="form-control" runat="server" aria-describedby="basic-addon1" ToolTip="show interface ip brief"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button ID="Button1" class="btn btn-primary" type="button" OnClick="BtnLogin_Click" runat="server" Text="Wykonaj!"></asp:Button>
                    </span>
                </div>
                
            </div>
        </div>
     </div>
</asp:Content>
