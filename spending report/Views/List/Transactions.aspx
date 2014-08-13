<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<spending_report.Models.BankPayments>" MasterPageFile="~/Views/Shared/SpendingMaster.Master" %>
<%@ Import Namespace="PagedList.Mvc" %>
<%@ Import Namespace="spending_report.L10n" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= BankPaymentsL10n.TransactionList %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table >
            <tr>
                <td>
                    <%= Html.Label(BankPaymentsL10n.Bank) %>
                </td>
                <td>
                    <%=  Html.Label(BankPaymentsL10n.Amount) %>
                </td>
                <td>
                    <%= Html.Label(BankPaymentsL10n.BankAccountID) %>
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
                    foreach (var item in Model.Transactions)
                    {
                    %>
                <td>
                    <%--<%= item. %>--%>
                </td>
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
        <%= Html.PagedListPager(Model.Transactions, 
        page => Url.Action("Transactions", new RouteValueDictionary(){
            {"Page", page}
            }),
            PagedListRenderOptions.ClassicPlusFirstAndLast) %>
    </asp:Content>