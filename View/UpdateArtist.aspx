<%@ Page Title="" Language="C#" MasterPageFile="~/View/MainView.Master" AutoEventWireup="true" CodeBehind="UpdateArtist.aspx.cs" Inherits="KpopZstation.View.UpdateArtist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1>Update Artist</h1>
        <div class="alert alert-danger mt-4" id="alert" runat="server" style="display: none;">
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="lblArtName" class="form-label" runat="server" Text="Artist Name"></asp:Label>
            <asp:TextBox ID="tbArtName" class="form-control" runat="server" placeholder="Enter artist name"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblImage" class="form-label" runat="server" Text="Artist Image"></asp:Label>
            <asp:FileUpload ID="upImage" class="form-control" runat="server" />
        </div>
        <div>
            <asp:Button ID="btnUpdateArtist" class="btn btn-primary" runat="server" Text="Update Artist" OnClick="btnUpdateArtist_Click" />
        </div>
    </div>
</asp:Content>
