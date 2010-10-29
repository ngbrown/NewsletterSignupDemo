<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Register for our awesome newsletter!</h2>
    <div class="container">
        To receive our newsletter of helpful content: <br />
        <a href="/Subscription/Create" class="button positive">
            <img src="/Public/css/blueprint/plugins/buttons/icons/tick.png" alt=""/>Register
        </a>
    </div>
    <div class="container">
        Maybe you are already receiving our newsletter, and no longer wish to:<br />
        <a href="/Subscription/Delete" class="button negative">
            <img src="/Public/css/blueprint/plugins/buttons/icons/cross.png" alt=""/>Unregister
        </a>
    </div>
</asp:Content>
