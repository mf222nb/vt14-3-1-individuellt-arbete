<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="MovieDetails.aspx.cs" Inherits="Projekt.Pages.MovieDetails" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- Alla felmeddelanden och rättmeddelanden visas här --%>
    <asp:ValidationSummary CssClass="error" runat="server" />
    <asp:ValidationSummary CssClass="error" runat="server" ValidationGroup="Edit" />

    <asp:FormView ID="MovieFormView" runat="server" ItemType="Projekt.Model.Movie" DataKeyNames="MovieID"
        DefaultMode="ReadOnly" RenderOuterTable="false" SelectMethod="MovieFormView_GetItem" DeleteMethod="MovieFormView_DeleteItem"
        UpdateMethod="MovieFormView_UpdateItem">
        <%-- Visar information om 1 film --%>
        <ItemTemplate>
            <div>
                <label for="Titel">Titel</label>
            </div>
            <div class="text">
                <%#: Item.Titel %>
            </div>
            <div>
                <label for="Length">Längd i min</label>
            </div>
            <div class="text">
                <%# Item.Length %>
            </div>
            <div class="buttons">
                <asp:LinkButton ID="DeleteLinkButton" CssClass="LinkButton" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick="return confirm('Är du säker att du vill ta bort filmen')"></asp:LinkButton>
                <asp:LinkButton ID="EditLinkButton" CssClass="LinkButton" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false"></asp:LinkButton>
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
                            <th>
                                Skådespelare
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
                            <asp:LinkButton ID="DeleteLinkButton" CssClass="LinkButton" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick="return confirm('Är du säker att du vill ta bort rollen')"></asp:LinkButton>
                            <asp:LinkButton ID="EditLinkButton" CssClass="LinkButton" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false"></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>
                                Roller saknas
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <%-- Redigering av rollen --%>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="Character" runat="server" Text='<%# BindItem.Character %>' ValidationGroup="Edit" Columns="40" MaxLength="40" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ActorDropDownList" runat="server" ItemType="Projekt.Model.Actor" DataTextField="Name"
                                DataValueField="ActorID" SelectMethod="ActorDropDownList_GetData" SelectedValue='<%# BindItem.ActorID %>'>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" CssClass="LinkButton" runat="server" CommandName="Update" Text="Spara" ValidationGroup="Edit"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" CssClass="LinkButton" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false"></asp:LinkButton>
                        </td>
                    </tr>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Ett rollnamn måste fyllas i" ControlToValidate="Character" Display="None" Text="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="Character" runat="server" Text='<%# BindItem.Character %>' MaxLength="40" Columns="40"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="ActorDropDownList" runat="server" ItemType="Projekt.Model.Actor" DataTextField="Name"
                                DataValueField="ActorID" SelectMethod="ActorDropDownList_GetData" SelectedValue='<%# BindItem.ActorID %>'>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:LinkButton ID="InsertLinkButton" CssClass="LinkButton" runat="server" CommandName="Insert" Text="Lägg till"></asp:LinkButton>
                            <asp:LinkButton ID="CancelLinkButton" CssClass="LinkButton" runat="server" CommandName="Cancel" Text="Rensa"></asp:LinkButton>
                        </td>
                    </tr>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Ett rollnamn måste fyllas i" ControlToValidate="Character" Display="None" Text="*"></asp:RequiredFieldValidator>
                </InsertItemTemplate>
            </asp:ListView>
        </ItemTemplate>
        <%-- Redigering av filmen --%>
        <EditItemTemplate>
            <div>
                <label for="Titel">Titel</label>
            </div>
            <div>
                <asp:TextBox ID="Titel" runat="server" Text='<%# BindItem.Titel %>' ValidationGroup="Edit" MaxLength="40" Columns="40" />
            </div>
            <div>
                <label for="Length">Längd i min</label>
            </div>
            <div>
                <asp:TextBox ID="Length" runat="server" Text='<%# BindItem.Length %>' ValidationGroup="Edit" Columns="3"></asp:TextBox>
            </div>
            <div class="buttons">
                <asp:LinkButton ID="LinkButton1" CssClass="LinkButton" runat="server" CommandName="Update" Text="Spara" ValidationGroup="Edit"></asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" CssClass="LinkButton" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false"></asp:LinkButton>
            </div>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="En titel måste fyllas i" ControlToValidate="Titel" Display="None" Text="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="En längd måste anges" Display="None" ControlToValidate="Length" Text="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
