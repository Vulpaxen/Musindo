<%@ Page Title="" Language="C#" MasterPageFile="~/View/MainView.Master" AutoEventWireup="true" CodeBehind="UpdateAlbum.aspx.cs" Inherits="KpopZstation.View.UpdateAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1>Update Album</h1>
        <div class="alert alert-danger mt-4" id="alert" runat="server" style="display: none;">
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAlbName" class="form-label" runat="server" Text="Album Name"></asp:Label>
            <asp:TextBox ID="tbAlbName" class="form-control" runat="server" placeholder="Enter album name"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAlbDesc" class="form-label" runat="server" Text="Album Description"></asp:Label>
            <asp:TextBox ID="tbAlbDesc" class="form-control" runat="server" placeholder="Enter album description"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAlbPrice" class="form-label" runat="server" Text="Album Price"></asp:Label>
            <asp:TextBox ID="tbAlbPrice" class="form-control" runat="server" placeholder="Enter album price"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAlbStock" class="form-label" runat="server" Text="Album Stock"></asp:Label>
            <asp:TextBox ID="tbAlbStock" class="form-control" runat="server" placeholder="Enter album stock"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblImage" class="form-label" runat="server" Text="Album Image"></asp:Label>
            <asp:FileUpload ID="upImage" class="form-control" runat="server" />
        </div>
        <div>
            <asp:Button ID="btnUpdateAlbum" class="btn btn-primary" runat="server" Text="Update Album" OnClick="btnUpdateAlbum_Click" />
        </div>
    </div>
</asp:Content>
