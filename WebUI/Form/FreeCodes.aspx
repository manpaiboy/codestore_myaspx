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
                
                <li class="list-group-item showtogg"><SPAN class="labelinfo">你的水平:</SPAN>  <span class="label">菜鸟</span> <span class="label">进阶</span>  <span class="label">高手</span> <span class="label">研究</span></li>
                <li class="list-group-item showtogg"><SPAN class="labelinfo">&nbsp;&nbsp;&nbsp;&nbsp;数据库:</SPAN>  <span class="label label-danger">SQL2012</span> <span class="label">SQL2008R2</span>  <span class="label label-danger">SQL2008</span> <span class="label">SQL2005</span> <span class="label label-warning">SQL2000</span>  <span class="label label-success">Access</span>  <span class="label label-danger">MySql</span>  <span class="label label-success">SQLite</span>  <span class="label label-danger">Oracle</span>  <span class="label label-success">XML</span>  <span class="label">其他</span>  <span class="label label-default">无数据库</span></li>
                <li class="list-group-item showtogg" id="speli"><SPAN class="labelinfo">源码类型:</SPAN>
                     <div> <span class="label label-default">企业网站</span>  <span class="label label-default">新闻文章</span>  <span class="label label-default">博客空间</span>  <span class="label label-default">影音娱乐</span>  <span class="label label-default">上传下载</span>  <span class="label label-default">留言本类</span>  <span class="label label-default">投票调查</span>  <span class="label label-default">聊天计数</span>  <span class="label label-default">尚未分类</span>  <span class="label label-default">电子商务</span>  <span class="label label-default">控件应用</span>  <span class="label label-default">新知实践</span>  <span class="label label-default">商务办公</span> </div><div> <span class="label label-default">会员交友</span>  <span class="label label-default">论坛社区</span>  <span class="label label-default">学教实践</span>  <span class="label label-default">企业办公</span> <span class="label label-default">网络应用</span>  <span class="label label-default">开发辅助</span>  <span class="label label-default">仓储物流</span>  <span class="label label-default">游戏娱乐</span>  <span class="label label-default">酒店餐饮</span>  <span class="label label-default">门户综合</span>  <span class="label label-default">行业软件</span>  <span class="label label-default">系统工具</span>  <span class="label label-default">实验作品</span> <span class="label label-default">其他类别</span> </div>
                </li>
                  <li class="list-group-item toggli">
                      <span id="togg">收缩</span>
                  </li>
                     <script>
                         $("#togg").click(function () {
                             var curtoggval=$("#togg").html();
                             if 
                               (curtoggval == "收缩") {
                                 $(".showtogg").css("display", "none");
                                 $("#togg").html("展开");
                             }
                             else {
                                 $(".showtogg").css("display", "block");
                                 $("#togg").html("收缩");
                             }
                         });
                     </script>
              </ul>
            </div>
        <div id="list">
           <div id="navsort">
               <span class="badge badge-primary   ">用户好评↑</span>
               <span class="badge badge-primary  ">更新时间↓</span>
               <span class="badge badge-primary  ">下载量↓</span>
<%--               <button type="button" class="btn btn-info btn-block btnw" data-toggle="tooltip" data-placement="left" title="" data-original-title="Tooltip on left"></button>
                <button type="button" class="btn btn-info btn-block btnw" data-toggle="tooltip" data-placement="left" title="" data-original-title="Tooltip on left"></button>
                <button type="button" class="btn btn-info btn-block btnw" data-toggle="tooltip" data-placement="left" title="" data-original-title="Tooltip on left"></button>--%>
           </div>
                <asp:Repeater ID="RepeaterCodeLists" runat="server" DataSourceID="SqlDataSource1" >
                    <ItemTemplate>
                        <div class="listcontent">
                        <img src="../Upfiles/CodeThumbnail/codea.jpg" />
                        <br />
                        <strong>企业ERP</strong>
                        <small>一款简单的erp系统</small>
                        <br />
                        下载次数：92
                            </div>
                    </ItemTemplate>
                </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:commyaspxdbConnectionString %>" SelectCommand="SELECT * FROM [my_fileinfo]"></asp:SqlDataSource>
        <div class="col-md-12 " id="page">
                <ul class="pagination">
                  <li class="active"><a href="#">PREV</a></li>
                  <li><a href="#">1</a></li>
                  <li class="active"><a href="#">2</a></li>
                  <li><a href="#">3</a></li>
                  <li><a href="#">4</a></li>
                  <li class="disabled"><a href="#">5</a></li>
                  <li class="active"><a href="#">NEXT</a></li>
                </ul>
              </div>
        </div>
        </div>
</asp:Content>
