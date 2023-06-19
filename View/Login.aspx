<%@ Page Title="" Language="C#" MasterPageFile="~/View/MainView.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KpopZstation.View.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <h2>Login</h2>
        <div class="alert alert-danger mt-4" id="alert" runat="server" style="display: none;">
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" Text="Email" AssociatedControlID="tbEmail"></asp:Label>
            <asp:TextBox ID="tbEmail" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblPassword" runat="server" Text="Password" AssociatedControlID="tbPassword"></asp:Label>
            <asp:TextBox ID="tbPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="form-group form-check">
            <asp:CheckBox ID="cbRemember" runat="server" />
            <asp:Label ID="Label1" class="form-check-label" runat="server" Text="Remember Me" AssociatedControlID="cbRemember"></asp:Label>
        </div>
        <asp:Button ID="btnLogin" class="btn btn-primary" runat="server" Text="Submit" OnClick="btnLogin_Click" />
    </div>
</asp:Content>
