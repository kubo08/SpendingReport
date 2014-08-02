<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<spending_report.Models.BankPayments>" %>
<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="Microsoft.Ajax.Utilities" %>
<%@ Import Namespace="PagedList.Mvc" %>
<%@ Import Namespace="spending_report.L10n" %>
<%@ Import Namespace="spending_report.Support" %>
<%@ Import Namespace="XMLParser.Data" %>
<%@ Import namespace="System.Collections.Generic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Title</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <meta name="description" content="The description of my page" />
</head>
    <body>
<%--        <%= Html.Label("Počet spracovaných transakcií: ") %>
        <%= ViewData["count"] %>--%>
        
        
        
        <table >
            <tr>
                <td>
                    <%=  Html.Label(BankPaymentsL10n.Amount) %>
                </td>
                <td>
                    <%= Html.Label(BankPaymentsL10n.BankAccount) %>
                </td>
                <td>
                    <%= Html.Label(BankPaymentsL10n.TransactionType) %>
                </td>
                <td>
                    <%= Html.Label(BankPaymentsL10n.TransactionPurpose) %>
                </td>
                <td>
                    <%= Html.Label(BankPaymentsL10n.Currency) %>
                </td>
                <td>
                    <%= Html.Label(BankPaymentsL10n.Description) %>
                </td>
            </tr>
            <tr>
                <%
                    foreach (var item in Model.Bank.Payments)
                    {
                    %>
                <td>
                    <%= item.TransactionAmount.Amount %>
                </td>
                <td>
                    <%= item.BankAccount.AccountID %>        
                </td>
                <td>
                    <%= item.PaymentType %>
                </td>
                <td>
                    <%= item.Purpose%>
                </td>
                <td>
                    <%= item.TransactionAmount.Currency %>
                </td>
                <td>
                    <%= item.Description %>
                </td>
            </tr>
            <% } ;%>
        </table>
        Page <%# Model.pager.CurrentPageIndex %>
    </body>
</html>
