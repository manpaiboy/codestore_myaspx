<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebUI.Admin.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MyAspx.Com - 管理后台</title>
    <script>
        //加载页面
        function loadFrame(url) {
            $("#contentPage").attr("src", url);
        }
    </script>
</head>
<body class="easyui-layout">
<%--    <noscript>
        <div style="position: absolute; z-index: 100000; height: 2046px; top: 0px; left: 0px;
            width: 100%; background: white; text-align: center;">
            <img src="images/noscript.gif" alt='抱歉，请开启脚本支持！' />
        </div>
    </noscript>--%>
    <div region="north" border="false" style="height:70px;background:#3D3C7A">
        <h2 style=" padding:20px 0 0 20px; color:#fff;">[后台管理] MyAspx.Com - 专业.Net源码专家！</h2>
       
    </div>
    <div region="west" split="true" title="管理工具" style="width:200px;padding:0px;">
        <div class="easyui-accordion" fit="true" >
		    <div title="系统管理">
                <ul id="sysManageTree">
                    <li onclick="loadFrame('seo/seomanage.aspx')">网站SEO</li>
                </ul>
		    </div>
		    <div title="业务管理">
			    <ul id="workManageTree">
                </ul>
		    </div>
		    <div title="日常管理">
			    <ul id="dailyManageTree">
                </ul>
		    </div>
		    <div title="其他事项">
			    <ul id="otherTree">
                </ul>
		    </div>
	    </div>
    </div>
    <div region="center"  >
		<div class="easyui-tabs" fit="true" border="false">
			<div title="主页" style="padding:0px;overflow:hidden;"> 
                <iframe id="contentPage" width="100%" height="100%" frameborder="0" marginheight="0" marginwidth = "0"></iframe>
			</div>
		</div>
    </div>
    <div region="south" style="height:30px;"></div>
    
    <div id="treeMenu" class="easyui-menu" style="width:120px;">
		<div onclick="append()" iconCls="icon-reload">刷新</div>
		<div class="menu-sep"></div>
		<div onclick="expand()">展开</div>
		<div onclick="collapse()">收缩</div>
	</div>
</body>
</html>
