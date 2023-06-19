<%@ Page Title="" Language="C#" MasterPageFile="~/View/MainView.Master" AutoEventWireup="true" CodeBehind="MyCart.aspx.cs" Inherits="KpopZstation.View.MyCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Shopping Cart</h2>
        <div class="row">
            <div class="table-responsive">
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Album Picture</th>
                            <th scope="col">Album Name</th>
                            <th scope="col">Quantity</th>
                            <th scope="col">Price</th>
                            <th scope="col">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <!-- Cart Item Loop -->
                        <asp:Repeater ID="rptCart" runat="server" OnItemCommand="rptCart_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Image ID="imgArtist" alt="Album Picture" class="img-thumbnail" runat="server" ImageUrl='<%# "~/Assets/Albums/" + Eval("Album.AlbumImage") %>' />
                                    <td><%# Eval("Album.AlbumName") %></td>
                                    <td><%# Eval("qty") %></td>
                                    <td><%# Eval("Album.AlbumPrice") %></td>
                                    <td>
                                        <asp:LinkButton ID="lbRemove" class="btn btn-danger btn-remove" runat="server" CommandName="Remove" CommandArgument='<%# Eval("AlbumID") %>'>Remove</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <!-- End Cart Item Loop -->
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <asp:Button ID="btnCheckout" class="btn btn-primary" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
            </div>
        </div>
    </div>
</asp:Content>
