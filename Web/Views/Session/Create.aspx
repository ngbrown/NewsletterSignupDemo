<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Web.Model.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Login
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2>Login</h2>
    </div>
    <div class="column span-8 bpad-36">
        <% using (Html.BeginForm()) { %>
            <%= Html.AntiForgeryToken() %>
            <p>
                <label>Login</label><br />
                <%= Html.TextBox("UserName") %>
            </p>
            <p>
                <label>Password</label><br />
                <%= Html.Password("Password") %>
            </p>
            <p>
                <button class="button positive" type="submit">
                    <img alt="" src="/Public/css/blueprint/plugins/buttons/icons/tick.png" />
                    Login
                </button>
            </p>
        <% } %>

    </div>

</asp:Content>
