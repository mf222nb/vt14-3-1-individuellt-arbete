<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ActorList.aspx.cs" Inherits="Projekt.Pages.ActorList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ValidationSummary CssClass="error" runat="server" ValidationGroup="Edit" ShowModelStateErrors="false"/>
    <asp:ValidationSummary CssClass="error" runat="server" />

    <h2>
        Skådespelare
    </h2>
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
        <%-- De skådespelare som finns i databasen listas här --%>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Item.FirstName %>
                </td>
                <td>
                    <%# Item.LastName %>
                </td>
                <td>
                    <%# Item.Born.ToString("yyyy-MM-dd") %>
                </td>
                <td>
                    <asp:LinkButton ID="DeleteLinkButton" CssClass="LinkButton" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick="return confirm('Är du säker att du vill ta bort skådespelaren, alla roller som skådespelarn är med i kommer också att tas bort')"></asp:LinkButton>
                    <asp:LinkButton ID="EditLinkButton" CssClass="LinkButton" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <%-- Om det inte finns några skådespelare så visas detta --%>
        <EmptyDataTemplate>
            <p>
                Skådespelare saknas
            </p>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>' MaxLength="20" Columns="20" />
                </td>
                <td>
                    <asp:TextBox ID="LastName" runat="server" Text='<%# BindItem.LastName %>' MaxLength="25" Columns="25" />
                </td>
                <td>
                    <asp:TextBox ID="Born" runat="server" Text='<%# BindItem.Born %>' MaxLength="10" Columns="10" />
                </td>
                <td>
                    <asp:LinkButton ID="InsertLinkButton" CssClass="LinkButton" runat="server" CommandName="Insert" Text="Lägg till"></asp:LinkButton>
                    <asp:LinkButton ID="CancelLinkButton" CssClass="LinkButton" runat="server" CommandName="Cancel" Text="Rensa"></asp:LinkButton>
                </td>
            </tr>
            <%-- Validering så att man inte kan skicka tomma fält och så att man måste ange ett korrekt datum för att spara --%>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Ett förnamn måste fyllas i" ControlToValidate="FirstName" Display="None" Text="*"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Ett efternamn måste fyllas i" ControlToValidate="LastName" Display="None" Text="*"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Ett födelsedatum måste fyllas i" ControlToValidate="Born" Display="None" Text="*"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ErrorMessage="Ett korrekt födelsedatum måste anges" ValidationExpression="^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$" Display="None" Text="*" ControlToValidate="Born"></asp:RegularExpressionValidator>
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
                    <asp:TextBox ID="Born" runat="server" Text='<%# Bind("Born", "{0:yyyy-MM-dd}") %>' ValidationGroup="Edit" />
                </td>
                <td>
                    <asp:LinkButton ID="UpdateLinkButton" CssClass="LinkButton" runat="server" CommandName="Update" Text="Spara" ValidationGroup="Edit"></asp:LinkButton>
                    <asp:LinkButton ID="CancelLinkButton" CssClass="LinkButton" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false"></asp:LinkButton>
                </td>
            </tr>
            <<%-- Validering så att man inte kan skicka tomma fält och så att man måste ange ett korrekt datum för att spara --%>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Ett förnamn måste fyllas i" ControlToValidate="FirstName" Display="None" Text="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Ett efternamn måste fyllas i" ControlToValidate="LastName" Display="None" Text="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Ett födelsedatum måste fyllas i" ControlToValidate="Born" Display="None" Text="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator runat="server" ErrorMessage="Ett korrekt födelsedatum måste anges" ControlToValidate="Born" ValidationGroup="Edit" ValidationExpression="^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$" Display="None" Text="*"></asp:RegularExpressionValidator>
        </EditItemTemplate>
    </asp:ListView>
    <asp:DataPager ID="DataPager1" runat="server" PageSize="5" PagedControlID="ActorListView">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="False" ShowFirstPageButton="True" />
                <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                <asp:NextPreviousPagerField ButtonType="Link" ShowPreviousPageButton="False" ShowLastPageButton="True" />
            </Fields>
        </asp:DataPager>
</asp:Content>
