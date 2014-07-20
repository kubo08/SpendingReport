<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Spending report</title>
    </head>
    <body>
        <% using (Html.BeginForm("Upload", "Upload", FormMethod.Post, new { enctype = "multipart/form-data" })) %>
        <% { %>
            <input type="file" name="FileUpload" />
            <input type="submit" name="Submit" id="Submit" value="Upload" />
        <% } %>
    </body>
</html>
