<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs"  Inherits="WebUI.index" %>
<%@ Register Src="~/Component/Top.ascx" TagPrefix="uc1" TagName="Top" %>
<%@ Register Src="~/Component/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>
<%@ Register Src="~/Component/Head.ascx" TagPrefix="uc1" TagName="Head" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=WebUI.App_Code.GlobalDictionary.basePageTitle %></title>
    <link href="Css/Base.css" rel="stylesheet" />
    <uc1:Head runat="server" ID="Head" />
               <script>
                   $(function () {
                       $("#bannertable tr td:eq(1)").css("background-color", "#3bafda");
                   });
    </script>
</head>
<body>

    <uc1:Top runat="server" ID="Top" />
    <form id="form1" runat="server">
    <div>
    <div id="topsearch">
     <div id="topsearch_tip">
     <div class="col_left2">
                        <a href="/CodeList/0!0!0!0!0!0!0!0!0!0i3" title="免费版源码下载排行">免费版</a><span>|</span>
                        <a href="/CodeList/0!0!0!0!0!0!0!0!0!1i3" title="共享版源码下载排行">共享版</a><span>|</span>
                        <a href="/CodeList/0!0!0!0!0!0!0!0!0!2i3" title="商业版源码下载排行">商业版</a>
         <br style="height:5px;" />
                        <p class="fl">每天都有热心网友上传源码，经51Aspx编辑精心整理后与大家分享...</p>
     </div>
     </div>
     <div id="topsearch_main">

         <div class="input-group">
                      <input type="text" class="form-control" autocomplete="off">
                      <div class="input-group-btn">
                        <button type="button" class="btn btn-primary" tabindex="-1">全站搜索</button>
                        <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" tabindex="-1">
                          <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu">
                          <li><a href="#">winform</a></li>
                          <li><a href="#">webform</a></li>
                          <li><a href="#">winphone</a></li>
                          <li class="divider"></li>
                          <li><a href="#">vb</a></li>
                        </ul>
                      </div>
                    </div>
         <div style="margin-top:5px;"><span class="topbold12">热门搜索：</span> crm 进销存 net 办公 mvc wcf 三层 毕设 OA 多层 erp</div>
     </div>
    </div>
    <div id="topad">
        ad

    </div>
        <div id="mainbody" >
            <div id="leftbanner">
            <!--    <div class="panel"  style="min-width:325px;height:345px;>
              <div class="tabbable tabs-left clearfix">
                <div id="myTabContent" class="tab-content">
                  <div class="tab-pane fade active in" id="home2" style="height:270px">
                    <p>餐饮教育体育
旅游医疗汽车
物流酒店租车
婚庆视频机构
培训贸易鲜花 </p>
                  </div>
                  <div class="tab-pane fade" id="profile2" style="height:270px">
                    <p>淘宝客家具商城
贸易物流珠宝饰品
影音娱乐建材五金
超市外贸
化妆品宠物</p>
                  </div>
              <div class="tab-pane fade" id="profile3" style="height:270px">
                    <p>MVCEF
WPFWP8
Windows8SilverLight
WebFormWinForm
WCFWPF</p>
                  </div>
              <div class="tab-pane fade" id="profile4" style="height:270px">
                    <p>OA流程管理
ERP文档管理
CRM考勤管理
HR资产管理
财务软件项目管理</p>
                  </div>
              <div class="tab-pane fade" id="profile5" style="height:270px">
                    <p>WP8WP7
图片浏览游戏
日历天气
订餐词典
新闻校园课程</p>
                  </div>
              <div class="tab-pane fade" id="profile6" style="height:270px">
                    <p>商城CMS
短信邮件管理软件
返利自动化
商务办公OA
开发框架二维码</p>
                  </div>
              <div class="tab-pane fade" id="profile7" style="height:270px">
                    <p>MVC专题淘宝客专题
WPF专题毕业设计专题
CRM专题博客空间专题
权限管理专题CMS专题
进销存专题WP专题</p>
                  </div>     

                </div>
                <ul id="myTab2" class="nav nav-tabs nav-justified">
                  <li class="active"><a href="#home2" data-toggle="tab">行业</a></li>
                  <li class="libgcolor" ><a href="#profile2" data-toggle="tab">电商</a></li>
             <li class="libgcolor" ><a href="#profile3" data-toggle="tab">技术</a></li>
                      <li  class="libgcolor" ><a href="#profile4" data-toggle="tab">通用</a></li>
                      <li  class="libgcolor" ><a href="#profile5" data-toggle="tab">手机</a></li>
                      <li  class="libgcolor" ><a href="#profile6" data-toggle="tab">商业</a></li>
                      <li  class="libgcolor" ><a href="#profile7" data-toggle="tab">专题</a></li>
                </ul>
              </div>
            </div> -->
                <div class="panel">
              <div class="tabbable tabs-left clearfix">
                <ul id="myTab1" class="nav nav-tabs">
                  <li class="active"><a href="#home3" data-toggle="tab">行业划分</a></li>
                  <li class="libgcolor"><a href="#profile3" data-toggle="tab">电商系统</a></li>
                  <li class="libgcolor"><a href="#myTabDrop3" data-toggle="tab">开发技术</a></li>
                     <li class="libgcolor"><a href="#myTabDrop3" data-toggle="tab">通用软件</a></li>
                     <li class="libgcolor"> <a href="#myTabDrop3" data-toggle="tab">手机应用</a></li>
                     <li class="libgcolor"><a href="#myTabDrop3" data-toggle="tab">商业精品</a></li>
                     <li class="libgcolor"><a href="#myTabDrop3" data-toggle="tab">小编专题</a></li>
                </ul>
                <div id="myTabContent" class="tab-content">
                  <div class="tab-pane fade active in" id="home3">
                   <div class="infoCon" id="rowtab3" style="display: block;">
                    <p><a href="/Search/%E9%A4%90%E9%A5%AE" target="_blank">餐饮</a><a href="/Search/%E6%95%99%E8%82%B2" target="_blank">教育</a><a href="/Search/%E4%BD%93%E8%82%B2" target="_blank">体育</a></p>
                    <p><a href="/Search/%E6%97%85%E6%B8%B8" target="_blank">旅游</a><a href="/Search/%E5%8C%BB%E7%96%97" target="_blank">医疗</a><a href="/Search/%E6%B1%BD%E8%BD%A6" target="_blank">汽车</a></p>
                    <p><a href="/CodeList/21!0!0!0!0!0!0!0!2!-1i0" target="_blank">物流</a><a href="/Search/%E9%85%92%E5%BA%97" target="_blank">酒店</a><a href="/Search/%E7%A7%9F%E8%BD%A6" target="_blank">租车</a></p>
                    <p><a href="/Search/%E5%A9%9A%E5%BA%86" target="_blank">婚庆</a><a href="/Search/%E8%A7%86%E9%A2%91" target="_blank">视频</a><a href="/Search/%E6%9C%BA%E6%9E%84" target="_blank">机构</a></p>
                    <p><a href="/Search/%E5%9F%B9%E8%AE%AD" target="_blank">培训</a><a href="/Search/%E8%B4%B8%E6%98%93" target="_blank">贸易</a><a href="/Search/%E9%B2%9C%E8%8A%B1" target="_blank">鲜花</a></p>
                    <h4 class="green">源码排行</h4>
                    	<ul>
          <li><a href="/code/ImageUpload" target="_blank" title="图片上传(水印、缩略图、远程保存)源码">图片上传(水印、缩略图、远程保存)源码</a></li>
          <li><a href="/code/FlashUploadWeb" target="_blank" title="通用上传源码（功能强大，界面美观）">通用上传源码（功能强大，界面美观）</a></li>
          <li><a href="/code/WebFileManagerFox" target="_blank" title="精美的WEB在线文件管理（狐狸修改版）源码">精美的WEB在线文件管理（狐狸修改版）源码</a></li>
          <li><a href="/code/ThreeLayerMusic" target="_blank" title="三层音乐网站源码">三层音乐网站源码</a></li>
          <li><a href="/code/XMLVideo" target="_blank" title="视频XML播放源码">视频XML播放源码</a></li>
	</ul>

                </div>
                  </div>
                  <div class="tab-pane fade" id="profile3">
                    <p>Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid. Exercitation +1 labore velit, blog sartorial PBR leggings next level wes anderson artisan four loko farm-to-table craft beer twee.  </p>
                  </div>
                  <div class="tab-pane fade" id="myTabDrop3">
                    <p>Etsy mixtape wayfarers, ethical wes anderson tofu before they sold out mcsweeney's organic lomo retro fanny pack lo-fi farm-to-table readymade. Messenger bag gentrify pitchfork tattooed craft beer, iphone...</p>
                  </div>
                </div>
              </div>
            </div>
            </div>
            <div id="toptab1">
              <div class="panel">
              <ul id="myTab1" class="nav nav-tabs nav-justified">
                <li class="active"><a href="#home1" data-toggle="tab">最近更新</a></li>
                <li><a href="#profile1" data-toggle="tab">免费版</a></li>
                      <li><a href="#profile1" data-toggle="tab">共享版</a></li>
                       <li><a href="#profile1" data-toggle="tab">商业版</a></li>

              </ul>
              <div id="myTabContent" class="tab-content">
                <div class="tab-pane fade active in" id="home1">
                  <p>Raw denim you probably haven't heard of them jean shorts Austin. Nesciunt tofu stumptown aliqua, retro synth master cleanse. Mustache cliche tempor, williamsburg carles vegan helvetica.</p>
                </div>
                <div class="tab-pane fade" id="profile1">
                  <p>Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid. Exercitation +1 labore velit, blog sartorial PBR leggings next level wes anderson artisan four loko farm-to-table craft beer twee.  </p>
                </div>
                <div class="tab-pane fade" id="dropdown1-1">
                  <p>Etsy mixtape wayfarers, ethical wes anderson tofu before they sold out mcsweeney's organic lomo retro fanny pack lo-fi farm-to-table readymade. Messenger bag gentrify pitchfork tattooed craft beer, iphone...</p>
                </div>
                <div class="tab-pane fade" id="dropdown1-2">
                  <p>Trust fund seitan letterpress, keytar raw denim keffiyeh etsy art party before they sold out master cleanse gluten-free squid scenester freegan cosby sweater. Fanny pack portland seitan DIY, art party locavore wolf cliche ... </p>
                </div>
              </div>
            </div>
            </div>
              <div id="topright1">
              <div class="panel">

                  sdfsd
              </div>
              </div>
        </div>
    </div>
    </form>
    <uc1:Footer runat="server" ID="Footer" />
</body>
</html>
