<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="Projekt.Pages.MovieList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Listar alla filmer från databasen --%>
    <asp:ListView ID="MovieListView" runat="server" ItemType="Projekt.Model.Movie"
        SelectMethod="MovieListView_GetData"
        DataKeyNames="MovieID">
        <LayoutTemplate>
            <table>
                <tr>
                    <th>Titel
                    </th>
                    <th class="small">Längd i min
                    </th>
                </tr>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <%-- Tar dig till den filmen som du trycker på --%>
                <td class="tableWidth">
                    <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("MovieDetails", new { id = Item.MovieID})%>' Text='<%# Item.Titel %>'></asp:HyperLink>
                </td>
                <td>
                    <%# Item.Length %>
                </td>
            </tr>
        </ItemTemplate>
        <%-- Om filmer saknas så visas detta --%>
        <EmptyDataTemplate>
            <p>
                Filmer saknas
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
    <asp:DataPager ID="DataPager1" runat="server" PageSize="20" PagedControlID="MovieListView">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="False" ShowFirstPageButton="True" />
                <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                <asp:NextPreviousPagerField ButtonType="Link" ShowPreviousPageButton="False" ShowLastPageButton="True" />
            </Fields>
        </asp:DataPager>
</asp:Content>
