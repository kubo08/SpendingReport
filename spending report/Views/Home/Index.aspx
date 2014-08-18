<%@ Page Language="C#" MasterPageFile="~/Views/Shared/SpendingMaster.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Spending report
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    

        <%= Html.Label("Vitajte na tejto super stranke") %>

</asp:Content>
