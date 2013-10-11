<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="X3Store.Web.Credentials.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPH" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPH" runat="server">
    <div>
        Email: <asp:TextBox runat="server" ID="UserEmail" />
    </div>
    <div>
        <asp:Button runat="server" Text="Сохранить изменения" ID="Save"/>
    </div>
</asp:Content>
