<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SoegKunder.aspx.cs" Inherits="SoegKunder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">ComapanyName</td>
                <td>
                    <asp:TextBox ID="TextBoxCompanyName" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">ContactName</td>
                <td>
                    <asp:DropDownList ID="DropDownListContactName" runat="server" DataSourceID="SqlDataSourceContactName" DataTextField="ContactName" DataValueField="ContactName" AppendDataBoundItems="True">
                        <asp:ListItem Selected="True" Value="">Vælg en Kontakt</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceContactName" runat="server" ConnectionString="<%$ ConnectionStrings:NW1ConnectionString1 %>" 
                        SelectCommand="SELECT DISTINCT [ContactName] FROM [Customers]"></asp:SqlDataSource>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Country</td>
                <td>
                    <asp:CheckBoxList ID="CheckBoxListCountries" runat="server" DataSourceID="SqlDataSourceCountries" DataTextField="Country" DataValueField="Country" RepeatColumns="3">
                    </asp:CheckBoxList>
                    <asp:SqlDataSource ID="SqlDataSourceCountries" runat="server" ConnectionString="<%$ ConnectionStrings:NW1ConnectionString1 %>" SelectCommand="SELECT DISTINCT [Country] FROM [Customers]"></asp:SqlDataSource>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="ButtonSoeg" runat="server" OnClick="ButtonSoeg_Click" Text="Søg" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
    
        <asp:GridView ID="GridViewKunder" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerID" EmptyDataText="There are no data records to display.">
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" SortExpression="CustomerID" />
                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
                <asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" SortExpression="ContactTitle" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
