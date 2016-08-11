<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/UI/SiteUI.Master" AutoEventWireup="true" CodeBehind="FreeCodes.aspx.cs" Inherits="WebUI.Form.FreeCodes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
               <script>
                   $(function () {
                       $("#bannertable tr td:eq(2)").css("background-color", "#3bafda");
                   });
    </script>
<link href="../Css/codelist.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="topNav">当前位置：首页 > 源码列表</div>
    <div id="content">
    <div class="panel panel-default">
              <div class="panel-heading">您已选择:</div>
              <div class="panel-body">
               <SPAN class="labelinfo">开发语言:</SPAN>  <span class="label label-info">C#</span> <span class="label label-info">VB.NET</span>  
              </div>
              <ul class="list-group">
                <li class="list-group-item"><SPAN class="labelinfo">源码类型:</SPAN>  <span class="label label-primary">WebForm</span> <span class="label label-primary">WinForm</span>  <span class="label label-primary">WinPhone</span>  </li>
                <li class="list-group-item"><SPAN class="labelinfo">授权类型:</SPAN>  <span class="label label-success">免费</span> <span class="label label-warning">共享</span>  <span class="label label-danger">商业</span> </li>
                <li class="list-group-item"><SPAN class="labelinfo">你的水平:</SPAN>  <span class="label">菜鸟</span> <span class="label">进阶</span>  <span class="label">高手</span> <span class="label">研究</span></li>
                <li class="list-group-item"><SPAN class="labelinfo">&nbsp;&nbsp;&nbsp;&nbsp;数据库:</SPAN>  <span class="label label-danger">SQL2012</span> <span class="label">SQL2008R2</span>  <span class="label label-danger">SQL2008</span> <span class="label">SQL2005</span> <span class="label label-warning">SQL2000</span>  <span class="label label-success">Access</span>  <span class="label label-danger">MySql</span>  <span class="label label-success">SQLite</span>  <span class="label label-danger">Oracle</span>  <span class="label label-success">XML</span>  <span class="label">其他</span>  <span class="label label-default">无数据库</span></li>
                <li class="list-group-item"><SPAN class="labelinfo">源码类型:</SPAN>
                     <p> <span class="label label-default">企业网站</span>  <span class="label label-default">新闻文章</span>  <span class="label label-default">博客空间</span>  <span class="label label-default">影音娱乐</span>  <span class="label label-default">上传下载</span>  <span class="label label-default">留言本类</span>  <span class="label label-default">投票调查</span>  <span class="label label-default">聊天计数</span>  <span class="label label-default">尚未分类</span>  <span class="label label-default">电子商务</span>  <span class="label label-default">控件应用</span>  <span class="label label-default">新知实践</span>  <span class="label label-default">商务办公</span> <span class="label label-default">会员交友</span>  <span class="label label-default">论坛社区</span>  <span class="label label-default">学教实践</span>  <span class="label label-default">企业办公</span>  <span class="label label-default">网络应用</span>  <span class="label label-default">开发辅助</span>  <span class="label label-default">仓储物流</span>  <span class="label label-default">游戏娱乐</span>  <span class="label label-default">酒店餐饮</span>  <span class="label label-default">门户综合</span>  <span class="label label-default">行业软件</span>  <span class="label label-default">系统工具</span>  <span class="label label-default">实验作品</span>  <span class="label label-default">其他类别</span></p>
                </li>
              </ul>
            </div>s
        </div>
</asp:Content>
