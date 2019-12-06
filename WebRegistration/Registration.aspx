<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebRegistration.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style {
            margin-left: 49px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            REGISTRATION PAGE</div>
        <p>
            Full  Name:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtName" runat="server" Width="349px"></asp:TextBox>
        </p>
        <p>
            Username:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUsername" runat="server" Width="265px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please enter a Username" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="245px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter a Password" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            Confirm Password:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="219px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Re-enter password" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Passwords don't match" ForeColor="Red"></asp:CompareValidator>
        </p>
        <p>
            Gender:&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem Selected="True" Value="0">Select...</asp:ListItem>
                <asp:ListItem Value="1">Male</asp:ListItem>
                <asp:ListItem Value="2">Female</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            Age:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAge" runat="server" Width="33px"></asp:TextBox>
        </p>
        <p>
            Street Number:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtStreetNumber" runat="server"></asp:TextBox>
        </p>
        <p>
            Street Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtStreetName" runat="server"></asp:TextBox>
        </p>
        <p>
            City:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
        </p>
        <p>
            PostalCode:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TxtPostalCode" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="128px" />
            <asp:Label ID="lblResultMessage" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
