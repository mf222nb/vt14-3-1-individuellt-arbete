<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Projekt.Pages.Shared.Error" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Fel
    </h2>
    <p class="text">
        Något gick fel
    </p>
    <asp:HyperLink ID="HyperLink1" CssClass="LinkButton" runat="server" NavigateUrl='<%$ RouteUrl:routename=Default %>'>Tillbaka till startsidan</asp:HyperLink>
</asp:Content>
