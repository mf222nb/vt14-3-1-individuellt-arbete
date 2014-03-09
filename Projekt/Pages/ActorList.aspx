<%@ Page Title="Skådespelare" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ActorList.aspx.cs" Inherits="Projekt.Pages.ActorList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandName="Delete" Text="Ta bort" OnClientClick="return confirm('Är du säker att du vill ta bort skådespelaren')"></asp:LinkButton>
                    <asp:LinkButton ID="EditLinkButton" runat="server" CommandName="Edit" Text="Redigera"></asp:LinkButton>
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
                    <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>' />
                </td>
                <td>
                    <asp:TextBox ID="LastName" runat="server" Text='<%# BindItem.LastName %>' />
                </td>
                <td>
                    <asp:TextBox ID="Born" runat="server" Text='<%# BindItem.Born %>' />
                </td>
                <td>
                    <asp:LinkButton ID="InsertLinkButton" runat="server" CommandName="Insert" Text="Lägg till"></asp:LinkButton>
                    <asp:LinkButton ID="CancelLinkButton" runat="server" CommandName="Cancel" Text="Rensa"></asp:LinkButton>
                </td>
            </tr>
        </InsertItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# BindItem.FirstName %>' />
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# BindItem.LastName %>' />
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# BindItem.Born %>' />
                </td>
                <td>
                    <asp:LinkButton ID="UpdateLinkButton" runat="server" CommandName="Update" Text="Spara"></asp:LinkButton>
                    <asp:LinkButton ID="CancelLinkButton" runat="server" CommandName="Cancel" Text="Avbryt"></asp:LinkButton>
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
