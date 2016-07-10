<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebUI.login" %>

<%@ Register Src="~/Component/Head.ascx" TagPrefix="uc1" TagName="Head" %>

<uc1:Head runat="server" ID="Head" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理员登录入口</title>
    <link href="Css/login.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.2.3.js"></script>
    <script src="Scripts/layer/layer.js"></script>
    <script>
        $(document).ready(function () {
            //$("#ImageCheck").click();
            // return;
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
       <div id="login">
          
           <div class="messpan">管理员登录 - MyAspx.Com</div>
           <hr style="width:70%;float:left;margin-left:60px;" />
        
 <div class="col-md-6 textdiv">
     <ul>
     <li><img src="Images/admin/login-user-logo.png" style="width:42px;height:42px" /></li>
               <li> <input type="text" autocomplete="on"  class="form-control minwidthtext" runat="server" placeholder="管理员用户名" id="user"></li>
       <%--  <li><span class="errormes">*必填</span></li>--%>
              </ul></div>
   
        <div class="col-md-6 textdiv">
            <ul>
<li><img src="Images/admin/login-user-pwd.png" style="width:42px;height:42px"  /></li>
               <li><input type="password" autocomplete="on"  class="form-control minwidthtext" runat="server" placeholder="密码" id="pwd"></li> 
              </ul></div> 
              <%-- <div class="yzm">--%>
                   
                   <div class="col-md-6 textdiv">     
                       <ul>          
                     <li>  验证码&nbsp<a href="javascript:changeCode()"><asp:Image Runat="server"  ID="ImageCheck" ImageUrl="~/Form/ValidateCode.aspx"></asp:Image></a>
                         <script type="text/javascript">
function changeCode() {
    document.getElementById('ImageCheck').src = document.getElementById('ImageCheck').src + '?';
          }
</script>

                     </li> 
               <li> <input type="text" autocomplete="on"  class="form-control minwidthtext yzminput" runat="server" placeholder="验证码" id="yzm">
                   <input type="hidden" id="yzmhiddle" runat="server"  />
               </li> 
             </ul>    </div> 

               <%--</div>--%>   
             
           
          <div class="col-md-6 textdiv">
              <asp:Button ID="yzmbtnhiddle" runat="server" Text="验证码验证按钮 " Visible="false" OnClick="yzmbtnhiddle_Click" />
            <%--<button type="button" class="btn btn-block minwidthbutton" id="loginid" runat="server" onClick="loginClick"  >管理员登录</button>--%>
              <asp:Button ID="loginid" runat="server" Text="管理员登录"  class="btn btn-block minwidthbutton" OnClick="loginClick" />
               </div>
               <div class="col-md-6">
                <div class="popover left">
                  <div class="arrow"></div>
                  <h3 class="popover-title">Popover left</h3>
                  <div class="popover-content">
                    <p>Sed posuere consectetur est at lobortis. Aenean eu leo quam. Pellentesque ornare sem lacinia quam venenatis vestibulum.</p>
                  </div>
                </div>
              </div>
   
 
       </div>
  
    </form>
    <script>
        function checktext() {
            if($("#yzm").val() =="")
            {
                layer.alert('验证码不可以为空！');
                return "f";
            }
            if ($("#user").val() == "") {
                layer.alert('用户名不可以为空！');
                return "f";
            }
            if ($("#pwd").val() == "") {
                layer.alert('密码不可以为空！');
                return "f";
            }
            return "s";
        }


        $(function () {
            $("#loginid").click(function () {
                var geta = checktext();
                if (geta == "f")
                {
                    return false;
                }
                //document.getElementById("<%# yzmbtnhiddle.ClientID%>").onclick();
                var userstr = $("#user").val();
                var pwdstr = $("#pwd").val();
                var yzmstr = $("#yzmhiddle").val();
                var yzm = $("#yzm").val();
                return ;
                //if (yzm != yzmstr)
                //{
                //    layer.alert("验证码错误！");
                //    return;
                //}
                $.ajax({
                    //要用post方式   
                    type: "Post",
                    //方法所在页面和方法名   
                    url: "login.aspx/LoginAdmin",
                    data: JSON.stringify({ user: userstr, pwd: pwdstr}),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                           //返回的数据用data.d获取内容   
                        var aaaa = data.d;
                        if (data.d == "验证码不对！") {
                            layer.alert(data.d);
                        }
                        if (data.d == "admin/index.aspx") {
                        window.location.href(data.d);
                        }
                        if (data.d == "用户名密码不对！") {
                            layer.alert(data.d);
                        }
            
                    },
                    error: function (err) {
                        layer.alert(err);
                    }
                });

                //禁用按钮的提交   
                return false;
            });
        });
    </script>
</body>
</html>
