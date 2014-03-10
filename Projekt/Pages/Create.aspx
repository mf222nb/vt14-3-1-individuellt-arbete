<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Projekt.Pages.Create" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="CreateFormView" runat="server" ItemType="Projekt.Model.Movie" InsertMethod="CreateFormView_InsertItem" 
        DataKeyNames="MovieID" DefaultMode="Insert">
        <InsertItemTemplate>
            <div>
                <label for="Titel">Titel</label>
            </div>
            <div>
                <asp:TextBox ID="Titel" runat="server" Text='<%# BindItem.Titel %>'></asp:TextBox>
            </div>
            <div>
                <label for="Length">Längd i min</label>
            </div>
            <div>
                <asp:TextBox ID="Length" runat="server" Text='<%# BindItem.Length %>'></asp:TextBox>
            </div>
            <div>
                <asp:LinkButton ID="InsertLinkButton" runat="server" CommandName="Insert" Text="Lägg till"></asp:LinkButton>
                <asp:LinkButton ID="CancelLinkButton" runat="server" CommandName="Cancel" Text="Rensa"></asp:LinkButton>
            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
