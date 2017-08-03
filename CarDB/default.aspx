<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CarDB.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Car Mileage Web APP</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Car Mileage Web APP</h2>
        <div>

            <asp:DataList ID="CarList" runat="server" DataKeyField="CarID" OnItemCommand="CarList_ItemCommand">
                <ItemTemplate>
                    CarID:
                <asp:Label ID="CarIDLabel" runat="server" Text='<%# Eval("CarID") %>' />
                    <br />
                    Car:
                <asp:Label ID="CarLabel" runat="server" Text='<%# Eval("Car") %>' />
                    <br />
                    Manufact:
                <asp:Label ID="ManufactLabel" runat="server" Text='<%# Eval("Manufact") %>' />
                    <br />
                    MPG:
                <asp:Label ID="MPGLabel" runat="server" Text='<%# Eval("MPG") %>' />
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument="CarID" CommandName="Delete">Delete This Car</asp:LinkButton>
                    <br />
                </ItemTemplate>
                <SeparatorTemplate>
                    <hr />
                </SeparatorTemplate>
            </asp:DataList>
            <br />

        </div>

        <hr />

        <div>
            <h4>Add a new car</h4>
            <p>Car Make:
                <asp:TextBox ID="CarMake" runat="server"></asp:TextBox></p>
            <p>Manafacure:
                <asp:TextBox ID="Manafacture" runat="server"></asp:TextBox></p>
            <p>MPG:
                <asp:TextBox ID="MPG" runat="server" MaxLength="3"></asp:TextBox></p>
            <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add" />
            <br />
        </div>
    </form>
    <h4>(C)Sunny WU 2017</h4>
</body>
</html>
