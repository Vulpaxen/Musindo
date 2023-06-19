<%@ Page Title="" Language="C#" MasterPageFile="~/View/MainView.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="KpopZstation.View.UpdateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <h2>Update Profile</h2>
        <div class="alert alert-danger mt-4" id="alert" runat="server" style="display: none;">
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="lblName" runat="server" Text="Name" AssociatedControlID="tbName"></asp:Label>
            <asp:TextBox ID="tbName" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" Text="Email" AssociatedControlID="tbEmail"></asp:Label>
            <asp:TextBox ID="tbEmail" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblGender" runat="server" Text="Gender" AssociatedControlID="ddlGender"></asp:Label>
            <asp:RadioButtonList ID="ddlGender" runat="server" RepeatDirection="Horizontal" Width="100%">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAddress" runat="server" Text="Address" AssociatedControlID="tbAddress"></asp:Label>
            <asp:TextBox ID="tbAddress" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblPassword" runat="server" Text="Password" AssociatedControlID="tbPassword"></asp:Label>
            <asp:TextBox ID="tbPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="Delete Account" OnClick="btnDelete_Click" />
        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" Text="Submit" OnClick="btnUpdate_Click" />
    </div>
</asp:Content>
