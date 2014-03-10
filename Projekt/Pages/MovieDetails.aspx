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
            <%--Listar rollerna som tillhör filmen --%>
            <asp:ListView ID="ActorListView" runat="server" ItemType="Projekt.Model.StarringActor" DataKeyNames="StarringID, MovieID, ActorID"
                SelectMethod="ActorListView_GetData" UpdateMethod="ActorListView_UpdateItem" InsertMethod="ActorListView_InsertItem" DeleteMethod="ActorListView_DeleteItem" InsertItemPosition="LastItem">
                <LayoutTemplate>
                    <h2>Roller
                    </h2>
                    <table>
                        <tr>
                            <th>Roller
                            </th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Item.Character %>
                        </td>
                        <td>
                            <%# Item.ActorName %>
                        </td>
                        <td>
                            <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandName="Delete" Text="Ta bort" OnClientClick="return confirm('Är du säker att du vill ta bort rollen')"></asp:LinkButton>
                            <asp:LinkButton ID="EditLinkButton" runat="server" CommandName="Edit" Text="Redigera"></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="Character" runat="server" Text='<%# BindItem.Character %>' />
                        </td>
                        <td>
                            <asp:DropDownList ID="ActorDropDownList" runat="server" ItemType="Projekt.Model.Actor" DataTextField="Name"
                                DataValueField="ActorID" SelectMethod="ActorDropDownList_GetData" SelectedValue='<%# BindItem.ActorID %>'>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Spara"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Avbryt"></asp:LinkButton>
                        </td>
                    </tr>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="Character" runat="server" Text='<%# BindItem.Character %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="ActorDropDownList" runat="server" ItemType="Projekt.Model.Actor" DataTextField="Name"
                                DataValueField="ActorID" SelectMethod="ActorDropDownList_GetData" SelectedValue='<%# BindItem.ActorID %>'>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:LinkButton ID="InsertLinkButton" runat="server" CommandName="Insert" Text="Lägg till"></asp:LinkButton>
                            <asp:LinkButton ID="CancelLinkButton" runat="server" CommandName="Cancel" Text="Rensa"></asp:LinkButton>
                        </td>
                    </tr>
                </InsertItemTemplate>
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
