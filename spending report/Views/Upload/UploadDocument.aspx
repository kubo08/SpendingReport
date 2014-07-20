<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<XMLParser.Data.Bank>" %>
<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="Microsoft.Ajax.Utilities" %>
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
        <%= Html.Label("Počet spracovaných transakcií: ") %>
        <%= ViewData["count"] %>
        
        
        
        <table >
            <tr>
                <td>
                    <%# BankPaymentsL10n.Amount %>
                </td>
                <td>
                    <%# BankPaymentsL10n.BankAccount %>
                </td>
                <td>
                    <%# BankPaymentsL10n.TransactionType %>
                </td>
                <td>
                    <%# BankPaymentsL10n.TransactionPurpose %>
                </td>
                <td>
                    <%# BankPaymentsL10n.Currency %>
                </td>
                <td>
                    <%# BankPaymentsL10n.Description %>
                </td>
            </tr>
        <tr>
            
            <%
                foreach (var item in Model.Payments)
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
    </body>
</html>
