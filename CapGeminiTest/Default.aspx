﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CapGeminiTest.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="Add.aspx">Add new customer</a>
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
        <asp:GridView ID="customersGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" />
                <asp:BoundField DataField="Telephone" HeaderText="Telephone" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:TemplateField HeaderText="Option">
                    <ItemTemplate>
                        <asp:LinkButton ID="DeleteButton" runat="server" OnClick="DeleteButton_Click" OnClientClick="return confirm('Are you sure?')">Delete</asp:LinkButton> | <a href="Edit.aspx?CustomerId=<%# Eval("CustomerId") %>">Edit</a>
                        &nbsp;<asp:HiddenField ID="HiddenFieldCustomerId" runat="server" Value='<%# Eval("CustomerId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CustomerId" Visible="False" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
