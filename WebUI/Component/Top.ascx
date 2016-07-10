<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Top.ascx.cs" Inherits="WebUI.Component.Top" %>
<link href="../Css/Mix/Top.css" rel="stylesheet" />
<style type="text/css">
<!--
.STYLE1 {font-size: 12px}
.togblue{
    background-color:#3bafda;
    cursor:pointer;
}
-->
</style>
<script src="../Scripts/jquery-2.2.3.js"></script>
<%--<script src="../Scripts/jquery-2.2.3.intellisense.js"></script>--%>
<center>
<table width="1005" border="0" cellpadding="0" cellspacing="0">
 
  <tr style="height:30px">
    <td width="152"  valign="top" class="telphone">电话</td>
    <td width="24" valign="top" class="topgray">│</td>
    <td width="191" valign="top" class="weibo">微博 @MyAspx </td>
    <td width="392">&nbsp;</td>
    <td width="265" valign="middle">登陆信息和帮助</td>
  </tr>
  
</table>
<table width="1005" border="0" cellpadding="0" cellspacing="0">
 </table>
<table width="1005" border="0" cellpadding="0" cellspacing="0">
 
  <tr style="width:100%">
    <td width="259" height="85" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
 
      <tr>
        <td width="21" rowspan="3">&nbsp;</td>
        
        </tr>
      <tr>
        <td width="196" height="74" valign="top">MyAspx的logo</td>
        <td width="42">&nbsp;</td>
      </tr>
      <tr>
    
        </tr>
      
    </table>    </td>
    <td width="299" valign="middle"><table width="100%" border="0" cellpadding="0" cellspacing="0">
   
      <tr>
        <td width="17" rowspan="3">&nbsp;</td>
        
          </tr>
      <tr>
        <td width="62" height="32" valign="top" class="toptag">常用</td>
        
        <td width="54" valign="top" class="taggray STYLE1">免费</td>
        <td width="50" valign="top" class="topgray STYLE1">热销</td>
        <td width="46" valign="top" class="taggray STYLE1">推荐</td>
        <td width="57" valign="top" class="topgray STYLE1">建站</td>
      </tr>
      <tr>
        <td height="29" valign="top" class="toptag">热点</td>
       
        <td valign="top" class="topgray STYLE1">商业</td>
        <td valign="top" class="topgray STYLE1">共享版</td>
        <td valign="top" class="topgray STYLE1">MVC</td>
        <td valign="top" class="topgray STYLE1">毕设</td>
      </tr>
      </table></td>
    <td width="251" valign="middle"><table width="100%" border="0" cellpadding="0" cellspacing="0">
 
      <tr>
        <td width="10" rowspan="5">&nbsp;</td>
        
          </tr>
      <tr>
        <td width="62" height="30" valign="top" class="toptag">会员</td>
     
        <td width="45" valign="top" class="topgray STYLE1">充值</td>
        <td colspan="3" valign="top" class="topgray STYLE1">赚钱</td>
        <td width="53" valign="top" class="topgray STYLE1">分享</td>
        <td width="9">&nbsp;</td>
        <td width="12">&nbsp;</td>
      </tr>
      <tr>
      
        </tr>
      <tr>
        <td height="30" valign="top" class="toptag">论坛</td>
      
        <td colspan="2" valign="top" class="topgray STYLE1">技术交流</td>
        
        
        <td width="12">&nbsp;</td>
        <td colspan="3" valign="top" class="topgray STYLE1">源码讨论</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
 
        </tr>
    </table></td>
    <td width="215" valign="middle"><table width="100%" border="0" cellpadding="0" cellspacing="0">
    
      <tr>
        <td width="12" rowspan="4">&nbsp;</td>
       
        </tr>
      <tr>
        <td width="51" height="28" valign="top" class="toptag">Demo</td>
        
        <td colspan="2" valign="top" class="topgray STYLE1">在线演示</td>
        <td width="37">&nbsp;</td>
        </tr>
      <tr>
        
        </tr>
      <tr>
        <td height="27" valign="top" class="toptag">活动</td>

        <td width="67" valign="top" class="topgray STYLE1">采购源码</td>
        <td colspan="2" valign="top" class="topgray STYLE1">吐槽得分</td>
        </tr>
      </table>
    </td>
  </tr>
</table>

</center>
<table style="background-color:#e8e8f0"  width="100%" height="35px" border="0" cellpadding="0" cellspacing="0" id="bannertable">
 
  <tr><td width="164" height="35px">&nbsp;

</td>
    <td width="82" valign="top" class="banar" onclick="window.open('../index.aspx','_self')">首页</td>
    <td width="131" valign="top" class="banar" onclick="window.open('../Form/FreeCodes.aspx','_self')">免费源码</td>
    <td width="128" valign="top" class="banar" onclick="window.open('../Form/ShareCodes.aspx','_self')">共享源码</td>
    <td width="116" valign="top" class="banar" onclick="window.open('../Form/LastUpdateCodes.aspx','_self')">最近更新</td>
    <td width="111" valign="top" class="banar" onclick="window.open('../Form/BusinessCodes.aspx','_self')">商业精品</td>
    <td width="106" valign="top" class="banar" onclick="window.open('../Form/#','_self')">源码出售</td>
    <td width="131" valign="top" class="banar" onclick="window.open('../Form/#','_self')">源码点评</td>
    <td width="113" valign="top" class="banar" onclick="window.open('../Form/#','_self')">下载排行</td>
    <td width="106" valign="top" class="banarUp">源码上传↑</td>
    <td width="163">&nbsp;</td>
</tr></table>
<script>
    $(function () {
        //cursor: pointer;
        $("#bannertable tr td").css("cursor", "pointer");
        $("#bannertable tr td").click(function () {
            if ($(this).hasClass("banar")) {
                $(this).toggleClass("togblue").siblings().removeClass("togblue");
            }
        });
        /*
        $("#bannertable tr td").mouseover(function () {
            if ($(this).hasClass("banar")) {
               // $(this).animate({background:"#3bafda"});
                $(this).toggleClass("togblue").siblings().removeClass("togblue");
            }
        });

        $("#bannertable tr td").mouseout(function () {
            if ($(this).hasClass("banar")) {
                $(this).toggleClass("togblue").siblings().removeClass("togblue");
            }
        });
        */
    })
</script>
