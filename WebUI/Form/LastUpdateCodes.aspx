<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/UI/SiteUI.Master" AutoEventWireup="true" CodeBehind="LastUpdateCodes.aspx.cs" Inherits="WebUI.Form.LastUpdateCodes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
               <script>
                   $(function () {
                       $("#bannertable tr td:eq(4)").css("background-color", "#3bafda");
                   });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
