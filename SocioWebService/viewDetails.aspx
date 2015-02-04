<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="viewDetails.aspx.vb" Inherits="SocioWebService.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sociodbConnectionString %>" SelectCommand="SELECT [MobileNo], [Email], [DistanceFromStore], [Latitude], [Longitude], [LogFlag], [LoginDateTime] FROM [AttendanceDetails]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" SortExpression="MobileNo" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="DistanceFromStore" HeaderText="DistanceFromStore" SortExpression="DistanceFromStore" />
                <asp:BoundField DataField="Latitude" HeaderText="Latitude" SortExpression="Latitude" />
                <asp:BoundField DataField="Longitude" HeaderText="Longitude" SortExpression="Longitude" />
                <asp:CheckBoxField DataField="LogFlag" HeaderText="LogFlag" SortExpression="LogFlag" />
                <asp:BoundField DataField="LoginDateTime" HeaderText="LoginDateTime" SortExpression="LoginDateTime" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        Mark more attendance in the application and refresh this page to see the entries.<a href="addEmployee.aspx"> Click here 
            </a>to add a new employee.</div>
    </form>
</body>
</html>
