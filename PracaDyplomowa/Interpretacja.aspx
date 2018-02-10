<%@ Page Title="Interpretacja" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Interpretacja.aspx.cs" Inherits="PracaDyplomowa.Interpretacja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    	
    
    <div class="jumbotron">
        <h1 style="text-align:center">Interpretacja komunikatów ASA</h1>
                <asp:Table ID="Table1" runat="server" Width="100%" class="table tablesorter">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell onclick="sortTable(0)" style="text-align:center"><a href="#">Czas wystąpienia</a></asp:TableHeaderCell>
                        <asp:TableHeaderCell onclick="sortTable(1)" style="text-align:center"><a href="#">ID</a></asp:TableHeaderCell>
                        <asp:TableHeaderCell style="text-align:center">Opis</asp:TableHeaderCell>
                        <asp:TableHeaderCell style="text-align:center">Zalecane rozwiązanie</asp:TableHeaderCell>
                        <asp:TableHeaderCell style="text-align:center">Hiperłącza</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
        


        <script type="text/javascript">
            function sortTable(n) {
                var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
                table = document.getElementById("MainContent_Table1");
                switching = true;
                // Set the sorting direction to ascending:
                dir = "asc";
                /* Make a loop that will continue until
                no switching has been done: */
                while (switching) {
                    // Start by saying: no switching is done:
                    switching = false;
                    rows = table.getElementsByTagName("TR");
                    /* Loop through all table rows (except the
                    first, which contains table headers): */
                    for (i = 1; i < (rows.length - 1); i++) {
                        // Start by saying there should be no switching:
                        shouldSwitch = false;
                        /* Get the two elements you want to compare,
                        one from current row and one from the next: */
                        x = rows[i].getElementsByTagName("TD")[n];
                        y = rows[i + 1].getElementsByTagName("TD")[n];
                        /* Check if the two rows should switch place,
                        based on the direction, asc or desc: */
                        if (dir == "asc") {
                            if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                                // If so, mark as a switch and break the loop:
                                shouldSwitch = true;
                                break;
                            }
                        } else if (dir == "desc") {
                            if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                                // If so, mark as a switch and break the loop:
                                shouldSwitch = true;
                                break;
                            }
                        }
                    }
                    if (shouldSwitch) {
                        /* If a switch has been marked, make the switch
                        and mark that a switch has been done: */
                        rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                        switching = true;
                        // Each time a switch is done, increase this count by 1:
                        switchcount++;
                    } else {
                        /* If no switching has been done AND the direction is "asc",
                        set the direction to "desc" and run the while loop again. */
                        if (switchcount == 0 && dir == "asc") {
                            dir = "desc";
                            switching = true;
                        }
                    }
                }
            }
</script>

    </div>
</asp:Content>
