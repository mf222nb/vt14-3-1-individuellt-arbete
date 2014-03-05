<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="Projekt.Pages.MovieList" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="MovieListView" runat="server">
        <LayoutTemplate>
            <table>
                <tr>
                    <th>

                    </th>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>
