<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/UI/SiteUI.Master" AutoEventWireup="true" CodeBehind="FreeCodes.aspx.cs" Inherits="WebUI.Form.FreeCodes" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
               <script>
                   $(function () {
                       $("#bannertable tr td:eq(2)").css("background-color", "#3bafda");
                   });
               </script>
<link href="../Css/codelist.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Css/PlugIn/css/imagehover.min.css" rel="stylesheet" />
    <div id="topNav">当前位置：首页 > 源码列表</div>
  
    <div id="content">
    <div class="panel panel-default">
              <div class="panel-heading">您已选择:</div>
           <%--   <div class="panel-body">
      
              </div>--%>
              <ul class="list-group">
                  <li class="list-group-item fitlan"><SPAN class="labelinfo">开发语言:</SPAN>  <span class="label label-info">C#</span> <span class="label label-info">VB.NET</span>  </li>
                <li class="list-group-item fittype"><SPAN class="labelinfo">源码类型:</SPAN>  <span class="label label-primary">WebForm</span> <span class="label label-primary">WinForm</span>  <span class="label label-primary">WinPhone</span>  </li>
                <li class="list-group-item fitlis"><SPAN class="labelinfo">授权类型:</SPAN>  <span class="label label-success">免费</span> <span class="label label-warning">共享</span>  <span class="label label-danger">商业</span> </li>
                
                <li class="list-group-item fityourlever showtogg"><SPAN class="labelinfo">你的水平:</SPAN>  <span class="label">菜鸟</span> <span class="label">进阶</span>  <span class="label">高手</span> <span class="label">研究</span></li>
                <li class="list-group-item fitdevtool showtogg"><SPAN class="labelinfo">开发工具:</SPAN> <span class="label label-success">VS2015</span> <span class="label label-danger">VS2013</span> <span class="label label-success">VS2012</span> <span class="label label-success">VS2011</span> <span class="label label-danger">VS2010</span> <span class="label label-danger">VS2008</span> <span class="label label-success">VS2005</span> <span class="label label-success">VS2003</span> <span class="label label-success">WinPhone SDK</span> <span class="label label-success">其他</span> </li>
                  <li class="list-group-item fitdbtype showtogg"><SPAN class="labelinfo">&nbsp;&nbsp;&nbsp;&nbsp;数据库:</SPAN>  <span class="label label-danger">SQL2012</span> <span class="label">SQL2008R2</span>  <span class="label label-danger">SQL2008</span> <span class="label">SQL2005</span> <span class="label label-warning">SQL2000</span>  <span class="label label-success">Access</span>  <span class="label label-danger">MySql</span>  <span class="label label-success">SQLite</span>  <span class="label label-danger">Oracle</span>  <span class="label label-success">XML</span>  <span class="label">其他</span>  <span class="label label-default">无数据库</span></li>
                <li class="list-group-item fitclasstype showtogg" id="speli"><SPAN class="labelinfo">源码类别:</SPAN>
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
                   <script>
                       $("li .label").click(function () {
                           //if ($(this).hasClass("label")) {
                           var curhtml = $(this).html();
                           //alert(curhtml);
                           /* <div class="checkbox">
                               <div class="icheckbox_flat checked" style="position: relative;"><input type="checkbox" id="flat-checkbox-2" checked="" style="position: absolute; top: -20%; left: -20%; display: block; width: 140%; height: 140%; margin: 0px; padding: 0px; border: 0px; opacity: 0; background: rgb(255, 255, 255);"><ins class="iCheck-helper" style="position: absolute; top: -20%; left: -20%; display: block; width: 140%; height: 140%; margin: 0px; padding: 0px; border: 0px; opacity: 0; background: rgb(255, 255, 255);"></ins></div>
                               <label for="flat-checkbox-2" class="">checked</label>
                             </div>*/
                           var addhtml = "<div class=\"checkbox\"><div class=\"icheckbox_flat checked\" style=\"position: relative;\"><input type=\"checkbox\" id=\"flat-checkbox-2\" style=\"position: absolute; top: -20%; left: -20%; display: block; width: 140%; height: 140%; margin: 0px; padding: 0px; border: 0px; opacity: 0; background: rgb(255, 255, 255);\"><ins class=\"iCheck-helper\" style=\"position: absolute; top: -20%; left: -20%; display: block; width: 140%; height: 140%; margin: 0px; padding: 0px; border: 0px; opacity: 0; background: rgb(255, 255, 255);\"></ins></div><label for=\"flat-checkbox-2\">" + curhtml + "</label></div>"
                           var addhtml2 = "<div class=\"alert-success alert-dismissable\" style=\"width:150px;height:20px;\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">×</button>"+curhtml+"</div>";
                           var addhtml3 = "<span class=\"tag\">" + curhtml + "<button type=\"button\" class=\"close\">×</button></span>";
                           //获取父元素class
                           var curspanpar = $(this).parent();
                           if ($(curspanpar).is("div")) { curspanpar = $(curspanpar).parent(); }
                           var parclassname = $(curspanpar).attr("class");
                           parclassname = parclassname.split(" ")[1];
                     
                           var addhtml4 = "<span class=\"label addspan " + parclassname + "\" onclick=\"hide(this)\">" + curhtml + "  ×" + "</span>";
                           //alert($(".panel-heading").html());
                           var html = $(".panel-heading").html().toString();
                            
                           //alert(html);
                           //$(".panel-heading").html($(".panel-heading").html() + addhtml4);
                           if (html.indexOf(curhtml)<=0) {
                               if (!$(".panel-heading span").hasClass(parclassname)) {
                                   $(".panel-heading").html($(".panel-heading").html() + addhtml4);
                               }
                                   
                           }
                           //}
                       });

                       //$("[class='label addspan']").click(function () {
                       //    //alert("d");
                       //    //$(““);
                       //    $(this).html($(this).html()+"w");
                       //});
                       $(document).ready(function () {
                           $(".addspan").on("click", function () {
                               alert("s");
                               $(this).hide();
                           });
                       });
                       function hide(obj)
                       {
                           $(obj).remove();
                       }
    
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
                <asp:Repeater ID="RepeaterCodeLists" runat="server" OnItemDataBound="RepeaterCodeLists_ItemDataBound"  >
                    <ItemTemplate>
                        	<div class="spbq">
		<div class="biankuang biankuang_1"></div>
		<div class="biankuang biankuang_2"></div>
		<div class="biankuang biankuang_3"></div>
		<div class="biankuang biankuang_4"></div>
                        <%--<figure class="imghvr-reveal-up">--%>
                        <div class="listcontent">
                        <img src="<%#Eval("filefirimg")%>" width="195" height="200" />
                        <br />
                        <strong><%#Eval("filename")%> </strong>
                              <%-- <figcaption>
                                Hover Content
                               </figcaption>--%>
                        <%--<small>一款简单的erp系统</small>--%>
                        <br />
                        下载次数：<%#Eval("filedownnum")%><br /><%--    <a href="<%#Eval("linkurl")%>"></a>--%>
                              <br />
                       <%#Eval("tagname")%>
                        </div>
                            <%--</figure>--%>
                              	<div class="text_gobuy">
			<br/>
                              
			<p><%#Eval("usermsg")%></p>
			<br/>
		</div>
	</div>
                    </ItemTemplate>
                </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:commyaspxdbConnectionString %>" SelectCommand="SELECT a.*,b.tagname as tagname FROM [my_fileinfo] as a left join [my_tag] as b on a.fileid=b.fileinfoid ORDER BY [addtime] DESC"></asp:SqlDataSource>
        <div class="col-md-12 " id="page">
               <%-- <ul class="pagination">
                  <li class="active gray"><a href="#">上一页</a></li>
                  <li><a href="#">1</a></li>
                  <li class="active gray"><a href="#">2</a></li>
                  <li><a href="#">3</a></li>
                  <li><a href="#">4</a></li>
                  <li class="disabled"><a href="#">5</a></li>
                  <li class="active gray"><a href="#">下一页</a></li>
                </ul>--%>
            <ul class="pagination">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  CssClass="pagination"   PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active"
                                          NumericButtonCount="6"
                                          UrlPaging="true"
                                          NumericButtonTextFormatString="{0}"

                                          FirstPageText="首页"
                                          LastPageText="末页" 
                                          NextPageText="下页" 
                                          PrevPageText="上页" 
                                          Font-Names="Arial"
                                          BackColor="#F8B500"
                                          AlwaysShow="true"
                                          ShowInputBox="Always"
                                          SubmitButtonText="跳转"
                                          SubmitButtonStyle="botton"
                                          OnPageChanged="AspNetPager1_PageChanged"
                                          PageSize="15"  >
                    </webdiyer:AspNetPager>
            </ul>
        </div>
            <script>
                //$('.listcontent').mouseenter(function() {
                //    $(this).css("background-color", "whitesmoke");
                //});
                //$('.listcontent').mouseleave(function () {
                //    $(this).css("background-color", "white");
                //});
            </script>
            <script type="text/javascript">
                //边框效果--移入
                function biankuang(obj) {
                    $(obj).find('.biankuang_1').stop(true).animate({
                        height: '305px'
                    }, 300)
                    $(obj).find('.biankuang_2').stop(true).delay(300).animate({
                        width: '360px'
                    }, 300)
                    $(obj).find('.biankuang_3').stop(true).animate({
                        height: '305px'
                    }, 300)
                    $(obj).find('.biankuang_4').stop(true).delay(300).animate({
                        width: '360px'
                    }, 300)
                }
                //边框效果--移出
                function biankuang1(obj) {

                    $(obj).find('.biankuang_1').stop(true).delay(100).animate({
                        height: '0px'
                    }, 100)
                    $(obj).find('.biankuang_2').stop(true).animate({
                        width: '0px'
                    }, 100)
                    $(obj).find('.biankuang_3').stop(true).delay(100).animate({
                        height: '0px'
                    }, 100)
                    $(obj).find('.biankuang_4').stop(true).animate({
                        width: '0px'
                    }, 100)
                }
                //触发
                $('.spbq').hover(
                    function () {
                        var obj = $(this);
                        $(obj).find('.text_gobuy').addClass('text_gobuy_show');
                        $(obj).find('.listcontent').css("background-color", "#f2f2f2");
                        $(obj).find('.search_y').animate({ left: '150', opacity: 1 }, 300);
                        biankuang(obj);
                    },
                    function () {
                        var obj = $(this);
                        $(obj).find('.text_gobuy').removeClass('text_gobuy_show');
                        $(obj).find('.listcontent').css("background-color", "white");
                        $(obj).find('.search_y').animate({ left: '100', opacity: 0 }, 300);
                        biankuang1(obj);
                    }
                );
</script>
        </div>
        </div>
</asp:Content>
