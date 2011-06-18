<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MyMDB.Models.Entities.Film>" %>

<div class="item">
<h3><%: Model.Title %></h3>
<h4>Director: <%: Model.Director %></h4>
<h4>Genre:<%: Model.Genre %></h4>
<h4>Release date: <%: Model.ReleaseDate %></h4>
<h4>Rating: <%: Model.Rating %></h4>
</div>

