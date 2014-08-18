<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/SpendingMaster.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Spending report
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    

        <% using (Html.BeginForm("Upload", "Upload", FormMethod.Post, new { enctype = "multipart/form-data" })) %>
        <% { %>
            <input type="file" name="FileUpload" />
            <input type="submit" name="Submit" id="Submit" value="Upload" />
        <% } %>
</asp:Content>
