<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="Projekt.Pages.MovieList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="MovieListView" runat="server" ItemType="Projekt.Model.Movie"
        SelectMethod="MovieListView_GetData"
        DataKeyNames="MovieID">
        <LayoutTemplate>
            <table>
                <tr>
                    <th>Titel
                    </th>
                    <th>Längd i min
                    </th>
                </tr>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("MovieDetails", new { id = Item.MovieID})%>' Text='<%# Item.Titel %>'></asp:HyperLink>
                </td>
                <td>
                    <%# Item.Length %>
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <p>
                Filmer saknas
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
