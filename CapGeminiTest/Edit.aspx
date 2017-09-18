<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CapGeminiTest.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
        }
        .auto-style2 {
            width: 260px;
            height: 31px;
        }
        .auto-style3 {
            height: 31px;
        }
        .auto-style4 {
            width: 260px;
            height: 33px;
        }
        .auto-style5 {
            height: 33px;
        }
        .auto-style6 {
            width: 260px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style1" colspan="2">
                    <asp:Label ID="LabelMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Name</td>
                <td>
                    <asp:TextBox ID="TextBoxName" runat="server" MaxLength="50" Width="330px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Surname</td>
                <td>
                    <asp:TextBox ID="TextBoxSurname" runat="server" MaxLength="50" Width="330px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Telephone</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxTelephone" runat="server" MaxLength="15" Width="330px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Address</td>
                <td>
                    <asp:TextBox ID="TextBoxAddress" runat="server" MaxLength="50" Width="330px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Postal Code</td>
                <td>
                    <asp:TextBox ID="TextBoxCode" runat="server" MaxLength="10" Width="330px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">City</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxCity" runat="server" MaxLength="50" Width="330px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td>
                    <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Save" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
