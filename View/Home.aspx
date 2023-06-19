<%@ Page Title="" Language="C#" MasterPageFile="~/View/MainView.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KpopZstation.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="mt-4">Musindo Artists</h1>

        <% if (customer != null && customer.CustomerRole.Equals("admin"))
            { %>
        <!-- Admin Actions -->
        <div class="mt-4">
            <asp:Button ID="btnInsertArtist" class="btn btn-success" runat="server" Text="Insert Artist" OnClick="btnInsertArtist_Click" />
        </div>
        <% } %>

        <!-- Artist Cards -->
        <div class="row mt-4">
            <asp:Repeater ID="rptArtists" runat="server" OnItemCommand="rptArtists_ItemCommand">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <asp:HyperLink ID="hl" NavigateUrl='<%# "~/View/ArtistDetail.aspx?art_id=" + Eval("ArtistID") %>' runat="server">
                            <div class="card">
                                <asp:Image ID="imgArtist" class="card-img-top" alt="Artist Image" runat="server" ImageUrl='<%# "~/Assets/Artists/" + Eval("ArtistImage") %>' />
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("ArtistName") %></h5>
                                    <% if (customer != null && customer.CustomerRole.Equals("admin"))
                                        { %>
                                    <div>
                                        <asp:LinkButton ID="lbUpdate" class="btn btn-info mt-2 me-2" runat="server" CommandName="update" CommandArgument='<%# Eval("ArtistID") %>'>Update</asp:LinkButton>
                                        <asp:LinkButton ID="lbDelete" class="btn btn-danger mt-2" runat="server" CommandName="delete" CommandArgument='<%# Eval("ArtistID") %>'>Delete</asp:LinkButton>
                                    </div>
                                    <% } %>
                                </div>
                            </div>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
