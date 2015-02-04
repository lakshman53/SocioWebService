<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="addEmployee.aspx.vb" Inherits="SocioWebService.addEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sociodbConnectionString %>" SelectCommand="SELECT [EmpId], [Email], [MobileNo], [StoreId] FROM [Employee]"></asp:SqlDataSource>
    
    </div>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1">
            <EditItemTemplate>
                EmpId:
                <asp:DynamicControl ID="EmpIdDynamicControl" runat="server" DataField="EmpId" Mode="Edit" />
                <br />
                Email:
                <asp:DynamicControl ID="EmailDynamicControl" runat="server" DataField="Email" Mode="Edit" />
                <br />
                MobileNo:
                <asp:DynamicControl ID="MobileNoDynamicControl" runat="server" DataField="MobileNo" Mode="Edit" />
                <br />
                StoreId:
                <asp:DynamicControl ID="StoreIdDynamicControl" runat="server" DataField="StoreId" Mode="Edit" />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" ValidationGroup="Insert" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                EmpId:
                <asp:DynamicControl ID="EmpIdDynamicControl" runat="server" DataField="EmpId" Mode="Insert" ValidationGroup="Insert" />
                <br />
                Email:
                <asp:DynamicControl ID="EmailDynamicControl" runat="server" DataField="Email" Mode="Insert" ValidationGroup="Insert" />
                <br />
                MobileNo:
                <asp:DynamicControl ID="MobileNoDynamicControl" runat="server" DataField="MobileNo" Mode="Insert" ValidationGroup="Insert" />
                <br />
                StoreId:
                <asp:DynamicControl ID="StoreIdDynamicControl" runat="server" DataField="StoreId" Mode="Insert" ValidationGroup="Insert" />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" ValidationGroup="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                EmpId:
                <asp:DynamicControl ID="EmpIdDynamicControl" runat="server" DataField="EmpId" Mode="ReadOnly" />
                <br />
                Email:
                <asp:DynamicControl ID="EmailDynamicControl" runat="server" DataField="Email" Mode="ReadOnly" />
                <br />
                MobileNo:
                <asp:DynamicControl ID="MobileNoDynamicControl" runat="server" DataField="MobileNo" Mode="ReadOnly" />
                <br />
                StoreId:
                <asp:DynamicControl ID="StoreIdDynamicControl" runat="server" DataField="StoreId" Mode="ReadOnly" />
                <br />

            </ItemTemplate>
        </asp:FormView>
        <br />
        <br />
        Please enter 1 as storeid</form>
</body>
</html>
