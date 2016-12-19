﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebUI.Admin.index" %>

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
        $("li").mouseover(function () {
            $(this).addCss("hoverbg");
        });
        $("li").mouseover(function () {
            $(this).css("background-color", "gray");
        });
    </script>
    <style>
        .easyui-accordion ul li{margin-bottom:10px;cursor:pointer;}
        .easyui-accordion ul li a:hover{color:red;}
        .hoverbg{background-color:gray;}
    </style>
    	<!-- basic styles -->
		<link href="../ACE/assets/css/bootstrap.min.css" rel="stylesheet" />
		<link rel="stylesheet" href="../ACE/assets/css/font-awesome.min.css" />
 
		<!--[if IE 7]>
		  <link rel="stylesheet" href="../ACE/assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

		<!-- page specific plugin styles -->

		<!-- fonts -->

		<%--<link rel="stylesheet" href="http://fonts.useso.com/css?family=Open+Sans:400,300" />--%>

		<!-- ace styles -->

		<link rel="stylesheet" href="../ACE/assets/css/ace.min.css" />
		<link rel="stylesheet" href="../ACE/assets/css/ace-rtl.min.css" />
		<link rel="stylesheet" href="../ACE/assets/css/ace-skins.min.css" />

		<!--[if lte IE 8]>
		  <link rel="stylesheet" href="../ACE/assets/css/ace-ie.min.css" />
		<![endif]-->

		<!-- inline styles related to this page -->

		<!-- ace settings handler -->

		<script src="../ACE/assets/js/ace-extra.min.js"></script>

		<!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

		<!--[if lt IE 9]>
		<script src="../ACE/assets/js/html5shiv.js"></script>
		<script src="../ACE/assets/js/respond.min.js"></script>
		<![endif]-->
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
                    <li onclick="loadFrame('seo/seomanage.aspx')">支付配置</li>
                    <li onclick="loadFrame('seo/seomanage.aspx')">网站功能配置</li>
                </ul>
		    </div>
		    <div title="业务管理">
			    <ul id="workManageTree">
                    <li onclick="loadFrame('seo/seomanage.aspx')">订单管理</li>
                </ul>
		    </div>
		    <div title="源码管理">
			    <ul id="dailyManageTree">
                    <li onclick="loadFrame('code/codesmanage.aspx')">源码列表</li>
                    <li onclick="loadFrame('code/codesadd.aspx')">添加</li>
                </ul>
		    </div>
		    <div title="会员管理">
			    <ul id="otherTree">
                    <li onclick="loadFrame('seo/seomanage.aspx')">会员管理</li>
                </ul>
		    </div>
	    </div>
    </div>
    <div region="center"  >
 
                <iframe id="contentPage" width="100%" height="100%" frameborder="0" marginheight="0" marginwidth = "0" style="height:100%;background-color:white;"></iframe>
		 
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
