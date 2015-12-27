<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<SpendingReport.Models.BankAccountImportedPayments>" MasterPageFile="~/Views/Shared/SpendingMaster.Master" %>
<%@ Import Namespace="PagedList.Mvc" %>
<%@ Import Namespace="SpendingReport.L10n" %>
<%@ Import Namespace="parser.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Imported Transactions
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm("Filter", "Upload", FormMethod.Post)) %>
        <%
       { %>
        <%= Html.Label(BankPaymentsL10n.Bank) %>    
        <%= Model.Account.Bank.Name %><br />
        <%= Html.Label(BankPaymentsL10n.BankAccountID) %>    
        <%= Model.Account.AccountID %><br />
        <%= Html.Label(BankPaymentsL10n.From) %>    
        <%= Model.From %><br />
        <%= Html.Label(BankPaymentsL10n.To) %>    
        <%= Model.To %><br />
        <%= Html.LabelFor(l=>l.OnlyImported)%>
        <%= Html.CheckBoxFor(c=>c.OnlyImported, new {onClick = "this.form.submit();"}) %>
            <table >
                <tr>
                    <td>
                        <%= Html.Label(BankPaymentsL10n.Amount) %>
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
                        <%= Html.Label(BankPaymentsL10n.IsImported) %>
                    </td>
                </tr>
                <tr>
                    <%
                        foreach (ImportedPayment item in Model.Transactions)
                        {
                    %>
                    <td>
                        <%= item.TransactionAmount.Amount %>
                    </td>
                    <td>
                        <%= item.BankAccount.AccountID %>        
                    </td>
                    <td>
                        <%= item.TransactionAmount.Type %>
                    </td>
                    <td>
                        <%= item.Purpose %>
                    </td>
                    <td>
                        <%= item.TransactionAmount.Currency %>
                    </td>
                    <td>
                        <%= item.Description %>
                    </td>
                    <td>
                        <%= item.Imported %> 
                    </td>
                </tr>
                <% }
                    ; %>
            </table>
            <%= Html.PagedListPager(Model.Transactions,
                    page => Url.Action("Upload", new RouteValueDictionary()
                    {
                        {"Page", page}
                    }),
                    PagedListRenderOptions.ClassicPlusFirstAndLast) %>
    <% } %>
</asp:Content>