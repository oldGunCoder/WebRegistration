<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationsList.aspx.cs" Inherits="WebRegistration.RegistrationsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            LIST OF REGISTRANTS</div>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="WebRegistration2" DataTextField="Name" DataValueField="Name">
            </asp:DropDownList>
            <asp:SqlDataSource ID="WebRegistration2" runat="server" ConnectionString="<%$ ConnectionStrings:WebRegistrationDBConnectionString %>" SelectCommand="SELECT [Name] FROM [Registration]"></asp:SqlDataSource>
       
    </form>
</body>
</html>
