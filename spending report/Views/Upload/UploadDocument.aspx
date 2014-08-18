<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<spending_report.Models.BankAccountPayments>" %>
<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="Microsoft.Ajax.Utilities" %>
<%@ Import Namespace="PagedList.Mvc" %>
<%@ Import Namespace="spending_report.L10n" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Imported Transactions
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.Label(BankPaymentsL10n.Bank) %>    
    <%= Model.Account.Bank.Name %><br />
    <%= Html.Label(BankPaymentsL10n.BankAccountID) %>    
    <%= Model.Account.Bank.Account.AccountID %><br />
    <%= Html.Label(BankPaymentsL10n.From) %>    
    <%= Model.From %><br />
    <%= Html.Label(BankPaymentsL10n.To) %>    
    <%= Model.To %><br />
        <table >
            <tr>
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
                    foreach (var item in Model.Account.Payments)
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
        <%= Html.PagedListPager(Model.Transactions, 
        page => Url.Action("Upload", new RouteValueDictionary(){
            {"Page", page}
            }),
            PagedListRenderOptions.ClassicPlusFirstAndLast) %>
</asp:Content>