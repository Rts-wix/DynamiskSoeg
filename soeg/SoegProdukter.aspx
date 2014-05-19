<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SoegProdukter.aspx.cs" Inherits="SoegProdukter" %>

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
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">CategoryName</td>
                <td>
                    <asp:TextBox ID="TextBoxCategoryName" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">ProductName</td>
                <td>
                    <asp:TextBox ID="TextBoxProductName" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">QuantityPerUnit</td>
                <td>
                    <asp:TextBox ID="TextBoxQtyPerUnit_min" runat="server" Width="48px"></asp:TextBox>
                    -<asp:TextBox ID="TextBoxQtyPerUnit_max" runat="server" Width="48px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">UnitsInStock</td>
                <td>
                    <asp:TextBox ID="TextBoxStockPerUnit_min" runat="server" Width="48px"></asp:TextBox>
                    -<asp:TextBox ID="TextBoxStockPerUnit_max" runat="server" Width="48px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Discontinued</td>
                <td>Yes:<asp:CheckBox ID="CheckBox_Discontinued" runat="server"  />No:<asp:CheckBox ID="CheckBox_NotDiscontinued" runat="server" /></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="ButtonSoeg" runat="server" Text="Søg" OnClick="ButtonSoeg_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="GridViewProducts" runat="server" AutoGenerateColumns="False" 
            EmptyDataText="There are no data records to display.">
            <Columns>
                <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" SortExpression="CategoryName" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock" />
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
            </Columns>
        </asp:GridView>
        
    <div>
    
    </div>
    </form>
</body>
</html>
