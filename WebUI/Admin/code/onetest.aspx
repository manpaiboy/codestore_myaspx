<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="onetest.aspx.cs" Inherits="WebUI.Admin.code.onetest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../xheditor-1.2.2/jquery/jquery-1.4.4.min.js"></script>
    <script src="../../xheditor-1.2.2/xheditor-1.2.2.min.js"></script>
    <script src="../../xheditor-1.2.2/xheditor_lang/zh-cn.js"></script>
    <script>
        function pageInit() {

        }

        $(document).ready(function () {
            $('#preview').xheditor({ tools: 'simple', skin: 'nostyle', upImgUrl: "../service/up.aspx", upImgExt: "jpg,jpeg,gif,png", width: '700', height: '195' });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" method="post">
    <div>
    <textarea id="preview" name="preview" rows="8" cols="120" runat="server"></textarea>          
    </div>
    </form>
</body>
</html>
