<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Web.Model.Subscription>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Subscribe</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.AntiForgeryToken() %>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Enter Info</legend>

            <div class="editor-label">
                First name
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.FirstName) %>
                <%= Html.ValidationMessageFor(model => model.FirstName) %>
            </div>
            
            <div class="editor-label">
                Last Name
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LastName) %>
                <%= Html.ValidationMessageFor(model => model.LastName) %>
            </div>
            
            <div class="editor-label">
                E-Mail
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.EMail) %>
                <%= Html.ValidationMessageFor(model => model.EMail) %>
            </div>
            
            <p>
                <button type="submit" class="button positive">
                    <img src="/Public/css/blueprint/plugins/buttons/icons/tick.png" alt=""/>Create
                </button>
            </p>
        </fieldset>

    <% } %>

</asp:Content>

