<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Projekt.Pages.Create" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ValidationSummary Class="error" runat="server" />

    <%-- Formulär för att lägga till en film --%>
    <asp:FormView ID="CreateFormView" runat="server" ItemType="Projekt.Model.Movie" InsertMethod="CreateFormView_InsertItem"
        DataKeyNames="MovieID" DefaultMode="Insert">
        <InsertItemTemplate>
            <div>
                <label for="Titel">Titel</label>
            </div>
            <div>
                <asp:TextBox ID="Titel" runat="server" Text='<%# BindItem.Titel %>' MaxLength="40" Columns="40"></asp:TextBox>
            </div>
            <div>
                <label for="Length">Längd i min</label>
            </div>
            <div>
                <asp:TextBox ID="Length" runat="server" Text='<%# BindItem.Length %>' Columns="3"></asp:TextBox>
            </div>
            <%-- Knappar för att spara och rensa fälten --%>
            <div class="buttons">
                <asp:LinkButton ID="InsertLinkButton" CssClass="LinkButton" runat="server" CommandName="Insert" Text="Lägg till"></asp:LinkButton>
                <asp:LinkButton ID="CancelLinkButton" CssClass="LinkButton" runat="server" CommandName="Cancel" Text="Rensa"></asp:LinkButton>
            </div>
            <%-- Validering så att man inte kan skicka in tomma fält --%>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="En titel måste fyllas i" ControlToValidate="Titel" Display="None" Text="*"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="En längd måste anges" ControlToValidate="Length" Display="None" Text="*"></asp:RequiredFieldValidator>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
