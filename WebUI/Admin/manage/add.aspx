<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="WebUI.Admin.manage.add" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Src="~/Component/Head.ascx" TagPrefix="uc1" TagName="Head" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <uc1:Head runat="server" ID="Head" />
   <%-- <script src="../../Scripts/jquery-2.2.3.js"></script>
    <script src="../../Scripts/layer/layer.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 <div class="col-md-6">
                <input type="text" class="form-control" placeholder="管理员用户名" id="user" runat="server" />
              </div>
        <div class="col-md-6">
                <input type="text" class="form-control" placeholder="密码" id="pwd" runat="server" />
              </div>
          <div class="col-md-3">
            <button type="button" class="btn btn-block"  onclick="verity()" >增加</button>
            <%--<Button  ID="addadminid" runat="server" Text="" OnClick="AddAdmin" style="display:none" />--%>
            <button id="addadminid" value="" runat="server" onserverclick="AddAdmin" style="display:none" ></button>
          </div>
          <script>
              function _addadmin()
              {
                 
              }
              function verity()
              {
                  var mesgerr = "";
                  if($("#user").val()=="")
                  {
                      mesgerr+="填写用户名不能为空！";
                  }
                  if ($("#pwd").val() == "") {
                      mesgerr += "<BR>";
                      mesgerr+="填写密码不能为空！";
                  }
                  if(mesgerr.length>0)
                  {
                      layer.alert(mesgerr);
                      return;
                  }
                  document.getElementById("addadminid").click();
              }
          </script>
    </div>
    </form>
</body>
</html>
