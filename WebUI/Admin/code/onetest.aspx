<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="onetest.aspx.cs" Inherits="WebUI.Admin.code.onetest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../xheditor-1.2.2/jquery/jquery-1.4.4.min.js"></script>
    <script src="../../xheditor-1.2.2/xheditor-1.2.2.min.js"></script>
    <script src="../../xheditor-1.2.2/xheditor_lang/zh-cn.js"></script>
    <script>
        $(function () {
            $('#preview').xheditor({ tools: 'mini', skin: 'nostyle' });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="section"><textarea id="preview" name="preview" rows="8" cols="120"></textarea></div>           
    </div>
    </form>
</body>
</html>
