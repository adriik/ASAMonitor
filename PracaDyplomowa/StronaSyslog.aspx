<%@ Page Async="true" Title="Syslog" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StronaSyslog.aspx.cs" Inherits="PracaDyplomowa.StronaSyslog" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %> Cisco ASA</h2>
    

    

     <script type="text/javascript">
           // It is important to place this JavaScript code after ScriptManager1
           var xPos, yPos;
           var prm = Sys.WebForms.PageRequestManager.getInstance();

           function BeginRequestHandler(sender, args) {
               if ($get('<%=textarea.ClientID%>') != null) {
              // Get X and Y positions of scrollbar before the partial postback
              xPos = $get('<%=textarea.ClientID%>').scrollLeft;
              yPos = $get('<%=textarea.ClientID%>').scrollTop;

            }
         }

         function EndRequestHandler(sender, args) {
             if ($get('<%=textarea.ClientID%>') != null) {
               // Set X and Y positions back to the scrollbar
               // after partial postback
               $get('<%=textarea.ClientID%>').scrollLeft = xPos;
               $get('<%=textarea.ClientID%>').scrollTop = $get('<%=textarea.ClientID%>').scrollHeight;
             }
         }

         prm.add_beginRequest(BeginRequestHandler);
         prm.add_endRequest(EndRequestHandler);
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        <ContentTemplate>

            <div class="container-fluid">

                    <div class="form-group">
                        <textarea id="textarea" style="width: 100%" type="text" class="form-control"  runat="server" Rows="20" disabled></textarea>   
                    </div>

            </div>
            <asp:Timer ID="Timer1" Interval="1000" OnTick="Timer1_Tick" runat="server"></asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>

    </script>
</asp:Content>
