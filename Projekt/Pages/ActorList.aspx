<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ActorList.aspx.cs" Inherits="Projekt.Pages.ActorList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Edit" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" />

    <h2>
        Skådespelare
    </h2>
    <%-- Listview för att visa alla skådespelare som finns i databasen --%>
    <asp:ListView ID="ActorListView" runat="server" ItemType="Projekt.Model.Actor" SelectMethod="ActorListView_GetData" UpdateMethod="ActorListView_UpdateItem" DeleteMethod="ActorListView_DeleteItem"
        InsertMethod="ActorListView_InsertItem" InsertItemPosition="FirstItem"
        DataKeyNames="ActorID">
        <LayoutTemplate>
            <table>
                <tr>
                    <th>Förnamn
                    </th>
                    <th>Efternamn
                    </th>
                    <th>Födelsedatum
                    </th>
                </tr>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Item.FirstName %>
                </td>
                <td>
                    <%# Item.LastName %>
                </td>
                <td>
                    <%# Item.Born %>
                </td>
                <td>
                    <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick="return confirm('Är du säker att du vill ta bort skådespelaren')"></asp:LinkButton>
                    <asp:LinkButton ID="EditLinkButton" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <p>
                Skådespelare saknas
            </p>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>' MaxLength="20" />
                </td>
                <td>
                    <asp:TextBox ID="LastName" runat="server" Text='<%# BindItem.LastName %>' MaxLength="25" />
                </td>
                <td>
                    <asp:TextBox ID="Born" runat="server" Text='<%# BindItem.Born %>' MaxLength="10" />
                </td>
                <td>
                    <asp:LinkButton ID="InsertLinkButton" runat="server" CommandName="Insert" Text="Lägg till"></asp:LinkButton>
                    <asp:LinkButton ID="CancelLinkButton" runat="server" CommandName="Cancel" Text="Rensa"></asp:LinkButton>
                </td>
            </tr>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Ett förnamn måste fyllas i" ControlToValidate="FirstName" Display="None" Text="*"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Ett efternamn måste fyllas i" ControlToValidate="LastName" Display="None" Text="*"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Ett födelsedatum måste fyllas i" ControlToValidate="Born" Display="None" Text="*"></asp:RequiredFieldValidator>
        </InsertItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>' ValidationGroup="Edit" />
                </td>
                <td>
                    <asp:TextBox ID="LastName" runat="server" Text='<%# BindItem.LastName %>' ValidationGroup="Edit" />
                </td>
                <td>
                    <asp:TextBox ID="Born" runat="server" Text='<%# BindItem.Born %>' ValidationGroup="Edit" />
                </td>
                <td>
                    <asp:LinkButton ID="UpdateLinkButton" runat="server" CommandName="Update" Text="Spara" ValidationGroup="Edit"></asp:LinkButton>
                    <asp:LinkButton ID="CancelLinkButton" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false"></asp:LinkButton>
                </td>
            </tr>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Ett förnamn måste fyllas i" ControlToValidate="FirstName" Display="None" Text="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Ett efternamn måste fyllas i" ControlToValidate="LastName" Display="None" Text="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Ett födelsedatum måste fyllas i" ControlToValidate="Born" Display="None" Text="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
