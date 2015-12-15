<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<spending_report.ViewModels.TransactionsListModel>" MasterPageFile="~/Views/Shared/SpendingMaster.Master" %>
<%@ Import Namespace="PagedList.Mvc" %>
<%@ Import Namespace="spending_report.L10n" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= BankPaymentsL10n.TransactionList %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <% Scripts.Render("~/Scripts/jquery-ui-1.8.24.min.js"); %>
<script>
    $(function () {
        $("#accordion").accordion({
            header: "tr.transaction"
        });
    });
</script>

    <div id="accordion">
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
                <td>
                    <%= Html.Label(BankPaymentsL10n.Name) %>
                </td>
                <td>
                    <%= Html.Label(BankPaymentsL10n.DatePosted) %>
                </td>
                <td>
                    <%= Html.Label(BankPaymentsL10n.DateAvailable) %>
                </td>
                <td>
                    <%= Html.Label(BankPaymentsL10n.SpecificSymbol) %>
                </td>
                <td>
                    <%= Html.Label(BankPaymentsL10n.VariableSymbol) %>
                </td>
                <td>
                    <%= Html.Label(BankPaymentsL10n.ConstantSymbol) %>
                </td>
            </tr>
            <tr class="transaction">
                <%
                    foreach (var item in Model.TransactionsList)
                    {
                    %>
                <td>
                    <%= item.BankAccount.BankName %>
                </td>
                <td>
                    <%= item.TransacionAmount.Amount %>
                </td>
                <td>a
                    <%= item.BankAccount.AccountNumber %>        
                </td>
                <td>
                    <%= item.TransacionAmount.TransactionType %>
                </td>
                <td>
                    <%--<%= item.Purpose %>--%>
                </td>
                <td>
                    <%= item.TransacionAmount.Currency %>
                </td>
                <td>
                    <%= item.Name %>
                </td>
                <td>
                    <%= item.Description %>
                </td>
                <td>
                    <%= item.DatePosted %>
                </td>
                <td>
                    <%= item.DateAvailable %>
                </td>
                <td>
                    <%= item.SpecificSymbol %>
                </td>
                <td>
                    <%= item.VariableSymbol %>
                </td>
                <td>
                    <%= item.ConstantSymbol %>
                </td>
            </tr>
            <% } ;%>
        </table>
        </div>
        <%= Html.PagedListPager(Model.TransactionsList, 
                page => Url.Action("TransactionsPaging", new RouteValueDictionary(){
                {"Page", page}
                }),
                PagedListRenderOptions.ClassicPlusFirstAndLast) %>
    </asp:Content>