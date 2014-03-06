<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="MovieDetails.aspx.cs" Inherits="Projekt.Pages.MovieDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="MovieFormView" runat="server" ItemType="Projekt.Model.Movie" DataKeyNames="MovieID"
        DefaultMode="ReadOnly" RenderOuterTable="false" SelectMethod="MovieFormView_GetItem" DeleteMethod="MovieFormView_DeleteItem"
        UpdateMethod="MovieFormView_UpdateItem">
        <ItemTemplate>
            <div>
                <label for="Titel">Titel</label>
            </div>
            <div>
                <%#: Item.Titel %>
            </div>
            <div>
                <label for="Length">Längd i min</label>
            </div>
            <div>
                <%# Item.Length %>
            </div>
            <div>
                <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandName="Delete" Text="Ta bort" OnClientClick="return confirm('Är du säker att du vill ta bort filmen')"></asp:LinkButton>
                <asp:LinkButton ID="EditLinkButton" runat="server" CommandName="Edit" Text="Redigera"></asp:LinkButton>
            </div>
            <asp:ListView ID="ActorListView" runat="server" ItemType="Projekt.Model.Actor" DataKeyNames="ActorID"
                SelectMethod="ActorListView_GetData" UpdateMethod="ActorListView_UpdateItem">
                <LayoutTemplate>
                    <h2>Skådespelare
                    </h2>
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
                            <asp:LinkButton ID="EditLinkButton" runat="server" CommandName="Edit" Text="Redigera"></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
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
                            <asp:LinkButton runat="server" CommandName="Update" Text="Spara"></asp:LinkButton>
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt"></asp:LinkButton>
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
        </ItemTemplate>
        <EditItemTemplate>
            <div>
                <label for="Titel">Titel</label>
            </div>
            <div>
                <asp:TextBox ID="Titel" runat="server" Text='<%# BindItem.Titel %>' />
            </div>
            <div>
                <label for="Length">Längd i min</label>
            </div>
            <div>
                <asp:TextBox ID="Length" runat="server" Text='<%# BindItem.Length %>'></asp:TextBox>
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Spara"></asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Avbryt"></asp:LinkButton>
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
