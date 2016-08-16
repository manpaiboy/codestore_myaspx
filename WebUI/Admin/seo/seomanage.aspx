<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seomanage.aspx.cs" Inherits="WebUI.Admin.seo.seomanage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

</head>
<body class="easyui-layout">
    <div>
    	<div region="center" title="Seo管理">
            <table id="seoManageGrid" fit="true">

            </table>
		</div>
		
	<div id="dialogAddSeo" icon="icon-add" title="添加新的seo信息" style=" display:none;">
        <div style=" width:500px; height:400px; font-size:12px; color:Black;">
            <table style=" width:500px; height:400px; margin-left:20px; margin-top:15px;">
                <tr>
                    <td valign="middle" style=" width:100px; text-align:right;">网站标题：</td>
                    <td valign="middle" style=" width:370px"><input id="siteTitle" type="text" style=" width:350px"/></td>
                </tr>
                <tr>
                    <td valign="middle" style=" text-align:right;">网站关键字：</td>
                    <td valign="middle" style=" width:370px"><input id="siteKeywords" type="text" style=" width:350px"/></td>
                </tr>
                  <tr>
                    <td valign="middle" style=" text-align:right;">网站描述：</td>
                    <td valign="middle" style=" width:370px"><input id="siteDescription" type="text" style=" width:350px"/></td>
                </tr>
                  <tr>
                    <td valign="middle" style=" text-align:right;">标记：</td>
                    <td valign="middle" style=" width:370px"><textarea id="siteRemark" rows="4" cols="10" style=" width:350px;"></textarea></td>
                </tr>
            </table>
        </div>
    </div>
    </div>
     <script type="text/javascript">
         //角色ID 全局变量
         
         $(function () {
             $('#seoManageGrid').datagrid({
                 //title: 'SEO记录管理',
                 //iconCls: 'icon-save',
                 collapsible: false,
                 width: "auto", //自動寬度
                 height: "450PX",  //固定高度
                 singleSelect: true,
                 remoteSort: false,
                 sortName: 'siteid',
                 sortOrder: 'siteaddtime',
                 nowrap: true,
                 fitColumns: true,  
                 loadMsg: '正在加载数据...',
                 method:'POST',
                 url: '../service/seo.ashx',
                 frozenColumns: [[
                     { field: 'ck', checkbox: true }
                 ]],
                 columns: [[
                     { field: 'siteid', title: 'SEOid', width: 80, sortable: true },
                     { field: 'sitetitle', title: '标题', width: 100, sortable: true },
                     { field: 'sitekeywords', title: '关键字', width: 100 },
                     { field: 'sitedescription', title: '网站描述', width: 100 },
                     { field: 'sitewriter', title: '修改人', width: 100 },
                     { field: 'siteremark', title: '修改标记', width: 100 },
                     { field: 'siteaddtime', title: '记录时间', width: 100 }
                 ]],
                 pagination: true,
                 
                 rownumbers: true,
                 toolbar:
                 [
                     {
                         id: 'btnAdd',
                         text: '添加SEO',
                         iconCls: 'icon-add',
                         handler: function () {
                             $("#siteTitle").val("");
                             $("#siteKeywords").val("");
                             $("#siteDescription").val("");
                             $("#siteRemark").val("");
                             addSeoDialog();
                         }
                     },
                     '-',
                     {
                         id: 'btnDelete',
                         text: '删除SEO记录',
                         disabled: true,
                         iconCls: 'icon-remove',
                         handler: function () {
                         }
                     }
                 ],
                 onLoadSuccess: function () {
                     //$("#seoManageGrid").datagrid('reload');
     ;
                 },
                 onClickRow: function (rowIndex, rowData) {
                    
                 }
             });
         });

         //添加角色对话框
         function addSeoDialog() {
             $("#dialogAddSeo").show();
             $("#dialogAddSeo").attr("title", "添加Seo信息");

             $("#dialogAddSeo").dialog({
                 width: 600,
                 height: 500,
                 draggable: true,
                 resizable: false,
                 modal: true,
                 buttons:
                     [
                         {
                             text: '提交',
                             iconCls: 'icon-ok',
                             handler: function () {
                                 var sitetitle= $("#siteTitle").val();
                                 var sitekeywords = $("#siteKeywords").val();
                                 var sitedescription = $("#siteDescription").val();
                                 var siteremark = $("#siteRemark").val();
                                 $.ajax({
                                     //要用post方式   
                                     type: "Post",
                                     //方法所在页面和方法名   
                                     url: "seomanage.aspx/AddSeoInfo",
                                     data: JSON.stringify({ sitetitle: sitetitle, sitekeywords: sitekeywords, sitedescription: sitedescription, siteremark: siteremark }),
                                     contentType: "application/json; charset=utf-8",
                                     dataType: "json",
                                     success: function (data) {
                                         //返回的数据用data.d获取内容   
                                         var aaaa = data.d;
                                         if (data.d == "scuess") {
                                             layer.alert(data.d);
                                         }
                                         if (data.d == "fail") {
                                             layer.alert(data.d);
                                         }

                                     },
                                     error: function (err) {
                                         layer.alert(err);
                                     }
                                 });

                                 //禁用按钮的提交   
                                 return false;
                             }
                         },
                         {
                             text: '取消',
                             handler: function () {
                                 $('#dialogAddSeo').dialog('close');
                             }
                         }
                     ]
             });
         }
     </script>
     <script src="../../Scripts/layer/layer.js"></script>
</body>
</html>
