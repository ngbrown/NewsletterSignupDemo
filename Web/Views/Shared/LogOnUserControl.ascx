<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Hi <b><%= Html.Encode(Page.User.Identity.Name) %></b>!
        [ <form id="fLougout" name="fLogout" action="<%=Url.Action("delete","session") %>" method="post" style="display:inline">
                    <%=Html.AntiForgeryToken() %>
                    <a href="" onclick="fLogout.submit();return false;" >Logout</a></form> ]
<%
    }
    else {
%> 
        [ <%= Html.ActionLink("Log On", "create", "Session") %> ]
<%
    }
%>
