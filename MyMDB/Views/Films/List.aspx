<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MyMDB.Views.Models.FilmsListViewModel>" %>
<%@ Import Namespace="MyMDB.Models.Entities" %>
<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
	List | Films
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="color:Fuchsia">Suck on THIS List</h1>
    <% foreach (var film in Model.Films) {  %>
       <% Html.RenderPartial("FilmSummary", film); %>
    <% } %>

    <div class="pager">
        <%: Html.PageLinks(Model.PagingInfo, x => Url.Action("List", new {page = x})) %>
    </div>
</asp:Content>
