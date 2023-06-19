<%@ Page Title="" Language="C#" MasterPageFile="~/View/MainView.Master" AutoEventWireup="true" CodeBehind="ArtistDetail.aspx.cs" Inherits="KpopZstation.View.ArtistDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .artist-image {
            width: 100%;
            max-height: 300px;
            object-fit: cover;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <!-- Artist Information -->
        <asp:Image ID="imgArtist" class="card-img-top artist-image" alt="Artist Image" runat="server" />
        <div class="card-body">
            <h5 class="card-title">Artist Name: <%= CurrArt.ArtistName %></h5>
            <!-- Display Artist Details-->

            <!-- Albums Section -->
            <h5 class="mt-4 mb-2">Albums</h5>
            <div class="row">
                <asp:Repeater ID="rptAlbum" runat="server" OnItemCommand="rptAlbum_ItemCommand">
                    <ItemTemplate>
                        <!-- Album Card -->
                        <div class="col-md-4 mb-4">
                            <asp:HyperLink ID="hl" NavigateUrl='<%# "~/View/AlbumDetail.aspx?alb_id=" + Eval("AlbumID") %>' runat="server">
                                <div class="card">
                                    <asp:Image ID="imgAlbum" class="card-img-top" alt="Album Image" runat="server" ImageUrl='<%# "~/Assets/Albums/" + Eval("AlbumImage") %>' />
                                    <div class="card-header">
                                        <h5 class="card-title"><%# Eval("AlbumName") %></h5>
                                    </div>
                                    <div class="card-body">
                                        <p>Description: <%# Eval("AlbumDescription") %></p>
                                        <p>Price: <%# Eval("AlbumPrice") %></p>
                                    </div>
                                    <% if (customer.CustomerRole.Equals("admin"))
                                        { %>
                                    <div class="card-footer">
                                        <asp:LinkButton ID="lbUpdate" class="btn btn-info mt-2 me-2" runat="server" CommandName="update" CommandArgument='<%# Eval("AlbumID") %>'>Update</asp:LinkButton>
                                        <asp:LinkButton ID="lbDelete" class="btn btn-danger mt-2" runat="server" CommandName="delete" CommandArgument='<%# Eval("AlbumID") %>'>Delete</asp:LinkButton>
                                    </div>
                                    <% } %>
                                </div>
                            </asp:HyperLink>
                        </div>
                        <!-- End of Album Card -->
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <!-- End of Albums Section -->

            <% if (customer.CustomerRole.Equals("admin"))
                { %>
            <!-- Insert Album Button -->
            <asp:Button ID="btnInsertAlbum" class="btn btn-success" runat="server" Text="Insert Album" OnClick="btnInsertAlbum_Click" />
            <% } %>
        </div>
    </div>
</asp:Content>
