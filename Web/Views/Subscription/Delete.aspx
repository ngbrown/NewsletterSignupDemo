<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Web.Model.Subscription>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Unsubscribe
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Unsubscribe</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.AntiForgeryToken() %>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Enter Info</legend>

            <div class="editor-label">
                E-Mail
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.EMail) %>
                <%= Html.ValidationMessageFor(model => model.EMail) %>
            </div>
            
            <p>
                <input type="submit" value="Delete" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>
