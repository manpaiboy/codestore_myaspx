<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/UI/AdminUiBase.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="codesadd.aspx.cs" Inherits="WebUI.Admin.code.codesadd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
   <%-- <script src="../../Scripts/jquery-2.2.3.js"></script>--%>
    <script src="../../xheditor-1.2.2/xheditor-1.2.2.min.js"></script>
    <script src="../../xheditor-1.2.2/xheditor_lang/zh-cn.js"></script>
    <script src="../../Scripts/ajaxfileupload.js"></script>
    <script src="../../ACE/assets/js/ace-extra.min.js"></script>
    <link href="../../ACE/assets/css/select2.css" rel="stylesheet" />
    <script src="../../ACE/assets/js/jquery.validate.min.js"></script>
    <script src="../../ACE/assets/js/select2.min.js"></script>
    <link href="../../Css/Admin/Code/CodeAdd.css" rel="stylesheet" />
    <script src="../../ACE/assets/js/bootstrap-wysiwyg.min.js"></script>
    <script src="../../ACE/assets/js/jquery.hotkeys.min.js"></script>
    <script>
        function pageInit() {

        }

        $(document).ready(function () {
            var editer =  $('#preview').xheditor({ tools: 'simple', skin: 'nostyle', upImgUrl: "../service/up.aspx", upImgExt: "jpg,jpeg,gif,png", width: '700', height: '195' });
                       });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="widget-body">
												<div class="widget-main">
													<div id="fuelux-wizard" class="row-fluid" data-target="#step-container">
														<ul class="wizard-steps">
														<%--	<li data-target="#step1" class="active" id="dstep1">
																<span class="step">1</span>
																<span class="title">选择源码类型</span>
															</li>--%>

															<li data-target="#step1" class="active" id="dstep1">
																<span class="step">1</span>
																<span class="title">填写基本信息</span>
															</li>

															<li data-target="#step2"  id="dstep2">
																<span class="step">2</span>
																<span class="title">上传文件</span>
															</li>

															<li data-target="#step3"  id="dstep3">
																<span class="step">3</span>
																<span class="title">上传截图</span>
															</li>

                                                            	<li data-target="#step4"  id="dstep4">
																<span class="step">4</span>
																<span class="title">填写详细信息</span>
															</li>
                                                             	<li data-target="#step5"  id="dstep5">
																<span class="step">5</span>
																<span class="title">提交完成</span>
															</li> 
														</ul>
													</div>

													<hr />
													<div class="step-content row-fluid position-relative" id="step-container">
														<div class="step-pane active" id="step1">
															<%--<h3 class="lighter block green"> </h3>

															 
																<div class="form-group has-warning">
																	<label for="codename" class="col-xs-12 col-sm-3 control-label">源码名称：</label>

																	<div class="col-xs-12 col-sm-5">
																		<span class="block input-icon input-icon-right">
												 
                                                                            <input type="text" id="codename" class="form-control"  />
																			<i class="icon-leaf"></i>
																		</span>
																	</div>
																	<div class="help-block col-xs-12 col-sm-reset inline">
																	 
																	</div>
																</div>

																<div class="form-group has-error">
																	<label for="inputError" class="col-xs-12 col-sm-3 col-md-3 control-label">源码类别：</label>

																	<div class="col-xs-12 col-sm-5">
																		<span class="block input-icon input-icon-right">
																		       <input type="text" id="codetype" class="form-control"  />
																			<i class="icon-remove-sign"></i>
																		</span>
																	</div>
																	<div class="help-block col-xs-12 col-sm-reset inline">  </div>
																</div>

																 

													<hr />
                                                        --%>
                                                           <span> 源码名称：<input type="text" id="txtCodeName" /> <label class="errtooptip" id="e1"></label> </span>
                                                           <span> 授权类别： 
                                                               <input type="radio" name="radSaleType" value="免费版" id="radFree" checked="checked" /><label for="radFree">免费版</label>
                                                               <input type="radio" name="radSaleType" value="积分" id="radScore" /><label for="radScore">积分</label>
                                          
                                                               <input type="radio" name="radSaleType" value="商业版" id="radPay" /><label for="radPay">商业版</label>
                                                                                    <script>
                                                                                        $("#radScore").click(function () {
                                                                                            $(".hidecodepaynub").css("display", "block");
                                                                                            $(".hidecodepayunit").html("积分");
                                                                                        });

                                                                                        $("#radFree").click(function () {
                                                                                            $(".hidecodepaynub").css("display", "none");

                                                                                        });

                                                                                        $("#radPay").click(function () {
                                                                                            $(".hidecodepayunit").html("金币");
                                                                                            $(".hidecodepaynub").css("display", "block");


                                                                                        });
                                                               </script>
                                                               <%--<input id="Radio1" type="radio" />--%>
                                                           </span>
                                                            <span style="display:none;" class="hidecodepaynub">源码售价: <input type="text" value="0" style="width:80px;" id="txtCodePayNub" /><span class="hidecodepayunit">积分</span> <label class="errtooptip" id="e2"></label></span>
                                                            <span style="vertical-align:top;">
                                                                <input id="ccboxAgree" type="checkbox" value="同意" checked="checked" /><label for="ccboxAgree">同意</label>
                                                                <a>商业资源交易规则</a>
                                                            </span>
												</div>
                                                        
                                                        	<div class="step-pane" id="step2">
                                                                  <span> 
                                                               <input type="radio" name="upType" value="上传源码包" id="radUpCodeRar" /><label for="radUpCodeRar">上传源码包</label>
                                                               <input type="radio" name="upType" value="添加源码下载地址" id="radUpCodeUrl" checked="checked" /><label for="radUpCodeUrl">添加源码下载地址</label>
                                         
                                                                                    <script>
                                                                                        $("#radUpCodeRar").click(function () {
                                                                                            $(".hidecodeuprar").css("display", "block");
                                                                                            $(".hidecodeupurl").css("display", "none");
                                                                                        });

                                                                                        $("#radUpCodeUrl").click(function () {
                                                                                            $(".hidecodeupurl").css("display", "block");
                                                                                            $(".hidecodeuprar").css("display", "none");
                                                                                        });

                                                               </script>
                                                               <%--<input id="Radio1" type="radio" />--%>
                                                           </span>
                                                            <span style="display:block;" class="hidecodeupurl">请输入源码下载地址: <input type="text" value=""  id="txtCodeUpUrl" /> <label class="errtooptip" id="e3"></label></span>
                                                            <span style="display:none;" class="hidecodeuprar">

                                                                 <span>选择文件：</span><input id="txt_filePath" style="width:auto; text-align:left;" type="text" readonly="readonly"/>
                                                                 <span class="file"><input id="txtCodeUpRar" name="txtCodeUpRar" type="file"/>浏览</span>
                                                               <%-- <input type="file" value=""  id="txtCodeUpRar" /> --%>
                                                                <label class="errtooptip" id="e4"></label>
                                                                
                                                                <script>
                                                                    $(function () {
                                                                        var img = $("#progressImgage");
                                                                        var mask = $("#maskOfProgressImage");
                                                                        //选择文件
                                                                        $(".file").on("change", "input[type='file']", function () {
                                                                            var filePath = $(this).val();
                                                                            //var formdata = new FormData();
                                                                            var formData = new FormData($("#form1")[0]);
                                                                            //alert(filePath); return;
                                                                            //设置上传文件类型
                                                                            if (filePath.indexOf("rar") != -1 || filePath.indexOf("zip") != -1) {
                                                                                //上传源码文件
                                                                                $.ajax({
                                                                                    url: '../service/FileHandler.ashx',
                                                                                    type: 'POST',
                                                                                    data: formData,
                                                                                    async: true,
                                                                                    cache: false,
                                                                                    contentType: false,
                                                                                    processData: false,
                                                                                    beforeSend: function () {
                                                                                        img.show()
                                                                                            .css({
                                                                                            "position": "fixed",
                                                                                            "top": "30%",
                                                                                            "left": "45%",
                                                                                            "margin-top": function () { return -1 * img.height() / 2; },
                                                                                            "margin-left": function () { return -1 * img.width() / 2; }
                                                                                            })
                                                                                        ;
                                                                                        mask.show().css("opacity", "0.1");
                                                                                    },
                                                                                    success: function (data) {
                                                                                        //获取上传文件路径
                                                                                        $("#txt_filePath").val(data);
                                                                                        alert("文件上传成功！" );
                                                                                    },
                                                                                    complete:function(){ 
                                                                                        img.hide(); 
                                                                                        mask.hide(); 

                                                                                    } ,
                                                                                    error: function (data, status, e) {
                                                                                        alert(e);
                                                                                    }
                                                                                });
                                                                            } else {
                                                                                alert("请选择正确的文件格式！");
                                                                                //清空上传路径
                                                                                $("#txt_filePath").val("");
                                                                                return false;
                                                                            }
                                                                        });
                                                                    })
                                                                </script>
                                                            </span>
                                                                <img id="progressImgage" class="progress" style="display:none;width:100px;height:100px;" alt="" src="../../Images/globals/loading.gif" /> 
                                                                <div id="maskOfProgressImage" class="mask" style="display:none"></div> 
                                                        	</div>
                                                        <div class="step-pane" id="step3">
                                                           <%-- <span class="btnupimgs" style="margin-left:35%;margin:0 auto;"><input type="button" id="btnUpImgs" value="上传截图" />--%>
                                                            <span class="uppic"><input id="btnUpImgs" name="btnUpImgs" type="file"/>上传截图</span>
                                                            <div class="upimgspanel"></div>
                                                            <%--</span>--%>
                                                           
                                                        </div>

                                                         <div class="step-pane" id="step4">
                                     
                <p>
                    <label for="CodeTypeId" class="title label4">源码类型：</label>
                    <select id="CodeTypeId" name="CodeTypeId" data-val-required="The 源码类型 field is required." data-val-number="The field 源码类型 must be a number." data-val="true">
                        <option value="0" selected="selected">==请选择==</option>
                        <option value="1">WebForm</option>
                        <option value="2">WinForm</option>
                        <option value="3">WinPhone</option>
                    </select>
                </p>
                <p>
                    <label for="DevelopToolId" class="title label4">开发工具：</label>
                    <select id="DevelopToolId" name="DevelopToolId" data-val-required="The 开发工具 field is required." data-val-number="The field 开发工具 must be a number." data-val="true">
                        <option value="0" selected="selected">==请选择==</option>
                        <option value="16">VS2015</option>
                        <option value="15">VS2013</option>
                        <option value="13">VS2012</option>
                        <option value="5">VS2011</option>
                        <option value="4">VS2010</option>
                        <option value="3">VS2008</option>
                        <option value="2">VS2005</option>
                        <option value="1">VS2003</option>
                        <option value="8">WinPhone SDK</option>
                        <option value="10">其他</option>
                    </select>
                </p>
                <p>
                    <label for="LanguageId" class="title label4">开发语言：</label>
                    <select id="LanguageId" name="LanguageId" data-val-required="The 开发语言 field is required." data-val-number="The field 开发语言 must be a number." data-val="true">
                        <option value="0" selected="selected">==请选择==</option>
                        <option value="1">C#</option>
                        <option value="2">VB.net</option>
                    </select>
                </p>
                <p>
                    <label for="DatabaseId" class="title  label5">数据库类型：</label>
                    <select id="DatabaseId" name="DatabaseId" data-val-required="The 数据库类型 field is required." data-val-number="The field 数据库类型 must be a number." data-val="true">
                        <option value="0" selected="selected">==请选择==</option>
                        <option value="19">SQL2014</option>
                        <option value="14">SQL2012</option>
                        <option value="7">SQL2008R2</option>
                        <option value="6">SQL2008</option>
                        <option value="5">SQL2005</option>
                        <option value="4">SQL2000</option>
                        <option value="3">Access</option>
                        <option value="8">MySql</option>
                        <option value="2">SQLite</option>
                        <option value="16">SqlCE</option>
                        <option value="9">Oracle</option>
                        <option value="1">XML</option>
                        <option value="18">其他</option>
                        <option value="15">无数据库</option>
                    </select>
                </p>
                <p>
                    <label for="FrameworkId" class="title label4">框架版本：</label>
                    <select id="FrameworkId" name="FrameworkId" data-val-required="The 框架版本 field is required." data-val-number="The field 框架版本 must be a number." data-val="true">
                        <option value="0" selected="selected">==请选择==</option>
                        <option value="2">V2.0</option>
                        <option value="6">V4.5</option>
                        <option value="5">V4.0</option>
                        <option value="4">V3.5</option>
                        <option value="1">V1.1</option>
                        <option value="3">V3.0</option>
                        <option value="7">其它</option>
                    </select>
                </p>
                <p>
                    <label for="Tags" class="title  label2">标签：</label>
                    <input id="Tags" type="text" name="Tags" class="box" />
                </p>
                <p>
                    <label for="LinkUrl" class="title label4">相关链接：</label>
                    <input id="LinkUrl" type="text" name="LinkUrl" class="box" />
                </p>
                <p>
                    <label for="Author" class="title label4">源码作者：</label>
                    <input id="Author" type="text" value='<%#Session["myaspxadminuser"] %>' name="Author" class="box" />
                </p>
                
                <p>
                    <label for="Contract" class="title label4">联系方式：</label>
                    <input id="Contract" type="text" value=" " name="Contract" class="box" />
                </p>
                <p class="tMar10">
                    <label for="UserMsg" class="title label5">给编辑留言：</label>
                    <textarea id="UserMsg" style="vertical-align:top;width:600px;height:105px;" rows="2" name="UserMsg" cols="20"></textarea>
                </p>
        
                    <label for="DescriptionString" class="title label4">源码描述：</label>
                  
        <%--            <div class="wysiwyg-toolbar btn-toolbar center wysiwyg-style2"> <div class="btn-group">  <a class="btn btn-sm  dropdown-toggle" data-toggle="dropdown" title="" data-original-title="Font"><i class="icon-font"></i><i class="icon-angle-down icon-on-right"></i></a>  <ul class="dropdown-menu dropdown-light"> <li><a data-edit="fontName Arial" style="font-family:'Arial'">Arial</a></li>  <li><a data-edit="fontName Courier" style="font-family:'Courier'">Courier</a></li>  <li><a data-edit="fontName Comic Sans MS" style="font-family:'Comic Sans MS'">Comic Sans MS</a></li>  <li><a data-edit="fontName Helvetica" style="font-family:'Helvetica'">Helvetica</a></li>  <li><a data-edit="fontName Open Sans" style="font-family:'Open Sans'">Open Sans</a></li>  <li><a data-edit="fontName Tahoma" style="font-family:'Tahoma'">Tahoma</a></li>  <li><a data-edit="fontName Verdana" style="font-family:'Verdana'">Verdana</a></li>  </ul> </div> <div class="btn-group">  <a class="btn btn-sm  dropdown-toggle" data-toggle="dropdown" title="" data-original-title="Font Size"><i class="icon-text-height"></i>&nbsp;<i class="icon-angle-down icon-on-right"></i></a>  <ul class="dropdown-menu dropdown-light">  <li><a data-edit="fontSize 1"><font size="1">Small</font></a></li>  <li><a data-edit="fontSize 3"><font size="3">Normal</font></a></li>  <li><a data-edit="fontSize 5"><font size="5">Huge</font></a></li>  </ul>  </div> <div class="btn-group">  <a class="btn btn-sm btn-info" data-edit="bold" title="" data-original-title="Bold (Ctrl/Cmd+B)"><i class="icon-bold"></i></a>  <a class="btn btn-sm btn-info" data-edit="italic" title="" data-original-title="Italic (Ctrl/Cmd+I)"><i class="icon-italic"></i></a>  <a class="btn btn-sm btn-info" data-edit="strikethrough" title="" data-original-title="Strikethrough"><i class="icon-strikethrough"></i></a>  <a class="btn btn-sm btn-info" data-edit="underline" title="" data-original-title="Underline"><i class="icon-underline"></i></a>  </div> <div class="btn-group">  <a class="btn btn-sm btn-success" data-edit="insertunorderedlist" title="" data-original-title="Bullet list"><i class="icon-list-ul"></i></a>  <a class="btn btn-sm btn-success" data-edit="insertorderedlist" title="" data-original-title="Number list"><i class="icon-list-ol"></i></a>  <a class="btn btn-sm btn-purple" data-edit="outdent" title="" data-original-title="Reduce indent (Shift+Tab)"><i class="icon-indent-left"></i></a>  <a class="btn btn-sm btn-purple" data-edit="indent" title="" data-original-title="Indent (Tab)"><i class="icon-indent-right"></i></a>  </div> <div class="btn-group">  <a class="btn btn-sm btn-primary" data-edit="justifyleft" title="" data-original-title="Align Left (Ctrl/Cmd+L)"><i class="icon-align-left"></i></a>  <a class="btn btn-sm btn-primary active" data-edit="justifycenter" title="" data-original-title="Center (Ctrl/Cmd+E)"><i class="icon-align-center"></i></a>  <a class="btn btn-sm btn-primary" data-edit="justifyright" title="" data-original-title="Align Right (Ctrl/Cmd+R)"><i class="icon-align-right"></i></a>  <a class="btn btn-sm btn-inverse" data-edit="justifyfull" title="" data-original-title="Justify (Ctrl/Cmd+J)"><i class="icon-align-justify"></i></a>  </div> <div class="btn-group">  <div class="inline position-relative"> <a class="btn btn-sm btn-pink dropdown-toggle" data-toggle="dropdown" title="" data-original-title="Hyperlink"><i class="icon-link"></i></a>  <div class="dropdown-menu dropdown-caret pull-right">							<div class="input-group">								<input class="form-control" placeholder="URL" type="text" data-edit="createLink">								<span class="input-group-btn">									<button class="btn btn-sm btn-primary" type="button">Add</button>								</span>							</div>						</div> </div> <a class="btn btn-sm btn-pink" data-edit="unlink" title="" data-original-title="Remove Hyperlink"><i class="icon-unlink"></i></a>  </div> <div class="btn-group">  <div class="inline position-relative"> <a class="btn btn-sm btn-success dropdown-toggle" data-toggle="dropdown" title="" data-original-title="Insert picture"><i class="icon-picture"></i></a>  <div class="dropdown-menu dropdown-caret pull-right">							<div class="input-group">								<input class="form-control" placeholder="Image URL" type="text" data-edit="insertImage">								<span class="input-group-btn">									<button class="btn btn-sm btn-primary" type="button">Insert</button>								</span>							</div><div class="space-2"></div>							 <div class="center">								<button class="btn btn-sm btn-success wysiwyg-choose-file" type="button"><i class="icon-file"></i> Choose Image …</button>								<input type="file" data-edit="insertImage">							  </div> </div> </div> </div> <div class="btn-group">  <select class="hide wysiwyg_colorpicker" title="Change Color" style="display: none;">  <option value="#ac725e">#ac725e</option>  <option value="#d06b64">#d06b64</option>  <option value="#f83a22">#f83a22</option>  <option value="#fa573c">#fa573c</option>  <option value="#ff7537">#ff7537</option>  <option value="#ffad46">#ffad46</option>  <option value="#42d692">#42d692</option>  <option value="#16a765">#16a765</option>  <option value="#7bd148">#7bd148</option>  <option value="#b3dc6c">#b3dc6c</option>  <option value="#fbe983">#fbe983</option>  <option value="#fad165">#fad165</option>  <option value="#92e1c0">#92e1c0</option>  <option value="#9fe1e7">#9fe1e7</option>  <option value="#9fc6e7">#9fc6e7</option>  <option value="#4986e7">#4986e7</option>  <option value="#9a9cff">#9a9cff</option>  <option value="#b99aff">#b99aff</option>  <option value="#c2c2c2">#c2c2c2</option>  <option value="#cabdbf">#cabdbf</option>  <option value="#cca6ac">#cca6ac</option>  <option value="#f691b2">#f691b2</option>  <option value="#cd74e6">#cd74e6</option>  <option value="#a47ae2">#a47ae2</option>  <option value="#444444">#444444</option>  </select><div class="dropdown dropdown-colorpicker"><a data-toggle="dropdown" class="dropdown-toggle" href="#"><span class="btn-colorpicker" style="background-color:#ac725e" data-original-title="" title=""></span></a><ul class="dropdown-menu dropdown-caret pull-right"><li><a class="colorpick-btn selected" href="#" style="background-color:#ac725e;" data-color="#ac725e"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#d06b64;" data-color="#d06b64"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#f83a22;" data-color="#f83a22"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#fa573c;" data-color="#fa573c"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#ff7537;" data-color="#ff7537"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#ffad46;" data-color="#ffad46"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#42d692;" data-color="#42d692"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#16a765;" data-color="#16a765"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#7bd148;" data-color="#7bd148"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#b3dc6c;" data-color="#b3dc6c"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#fbe983;" data-color="#fbe983"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#fad165;" data-color="#fad165"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#92e1c0;" data-color="#92e1c0"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#9fe1e7;" data-color="#9fe1e7"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#9fc6e7;" data-color="#9fc6e7"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#4986e7;" data-color="#4986e7"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#9a9cff;" data-color="#9a9cff"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#b99aff;" data-color="#b99aff"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#c2c2c2;" data-color="#c2c2c2"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#cabdbf;" data-color="#cabdbf"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#cca6ac;" data-color="#cca6ac"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#f691b2;" data-color="#f691b2"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#cd74e6;" data-color="#cd74e6"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#a47ae2;" data-color="#a47ae2"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#444444;" data-color="#444444"></a></li></ul></div>  <input style="display:none;" disabled="" class="hide" type="text" data-edit="foreColor">  </div> <div class="btn-group">  <a class="btn btn-sm btn-grey" data-edit="undo" title="" data-original-title="Undo (Ctrl/Cmd+Z)"><i class="icon-undo"></i></a>  <a class="btn btn-sm btn-grey" data-edit="redo" title="" data-original-title="Redo (Ctrl/Cmd+Y)"><i class="icon-repeat"></i></a>  </div> </div>
                    <div class="wysiwyg-editor" id="editor1" contenteditable="true"></div>
                    <script>
                        $('#editor1').ace_wysiwyg({
                            toolbar:
                            [
                                'font',
                                null,
                                'fontSize',
                                null,
                                { name: 'bold', className: 'btn-info' },
                                { name: 'italic', className: 'btn-info' },
                                { name: 'strikethrough', className: 'btn-info' },
                                { name: 'underline', className: 'btn-info' },
                                null,
                                { name: 'insertunorderedlist', className: 'btn-success' },
                                { name: 'insertorderedlist', className: 'btn-success' },
                                { name: 'outdent', className: 'btn-purple' },
                                { name: 'indent', className: 'btn-purple' },
                                null,
                                { name: 'justifyleft', className: 'btn-primary' },
                                { name: 'justifycenter', className: 'btn-primary' },
                                { name: 'justifyright', className: 'btn-primary' },
                                { name: 'justifyfull', className: 'btn-inverse' },
                                null,
                                { name: 'createLink', className: 'btn-pink' },
                                { name: 'unlink', className: 'btn-pink' },
                                null,
                                { name: 'insertImage', className: 'btn-success' },
                                null,
                                'foreColor',
                                null,
                                { name: 'undo', className: 'btn-grey' },
                                { name: 'redo', className: 'btn-grey' }
                            ],
                            'wysiwyg': {
                                fileUploadError: showErrorAlert
                            }
                        }).prev().addClass('wysiwyg-style2');
                    </script>--%>
                     <p><textarea id="preview" name="preview" rows="8" cols="120"></textarea></p>
                     <%--<p><span><input type="button" value="编辑器源码" id="previewHtml" /></span>

                         <script>
                             $("#previewHtml").click(function () {
                                 alert($("#preview").val());
                             });
                         </script>
                     </p>--%>
                     <p><span class="err-red-out"></span></p>
                                                        </div>
                                                         <div class="step-pane" id="step5">
                                                             <span class="suc-info-mes">
                                                                 继续点击下面按钮提交。
                                                             </span>
                                                             </div>
                                                        <!-- /widget-main --> 

                                                         <div id="upfilenext" class="row-fluid wizard-actions" >
													<%--	<button class="btn btn-success btn-next" id="btnnextsetp" >
												 
															下一步
														</button>--%>
                                                             <input type="button" class="btn btn-success btn-next" id="btnnextsetp" value="下一步" />
                                                        <script>
                                                            $("#btnnextsetp").click(function () {
                                                                //step1
                                                                if ($("#txtCodeName").val() == "") { $("#e1").html("源码名称不能为空"); return; }
                                                                if (!$("#radFree").is(":checked")){
                                                                    if (parseInt($("#txtCodePayNub").val()) < 10) { $("#e2").html("积分或者金币不能低于10"); return; }
                                                                }
                                                                $("#e1").html(""); $("#e2").html("");
                                                                //step2
                                                                $("#dstep2").addClass("active");
                                                                $("#step2").addClass("active");
                                                                $("#step1").removeClass("active");
                                                                //$("#step2").addClass("active");
                                                                //step3
                                                                if ($("#txt_filePath").val().indexOf('/') <= 0
                                                                    //||
                                                                    //$("#txtCodeUpUrl").val().indexOf('/') <= 0
                                                                    )
                                                                {
                                                                    //alert("请上传源码或者填写源码路径");
                                                                    return;
                                                                }
                                                                $("#dstep3").addClass("active");
                                                                $("#step1").removeClass("active");
                                                                $("#step2").removeClass("active");
                                                                $("#step3").addClass("active");

                                                                //step4
                                                                if ($(".upimgspanel").html().indexOf('/') <= 0
                                                                  ) {
                                                                    return;
                                                                }
                                                                $("#dstep4").addClass("active");
                                                                $("#step1").removeClass("active");
                                                                $("#step2").removeClass("active");
                                                                $("#step3").removeClass("active");
                                                                $("#step4").addClass("active");

                                                                //step5 
                                                                var mesindex = -1;
                                                                if ($("#CodeTypeId").val().indexOf('请选择') > 0
                                                                     || $("#DevelopToolId").val().indexOf('请选择') > 0
                                                                     || $("#LanguageId").val().indexOf('请选择') > 0
                                                                     || $("#LanguageId").val().indexOf('请选择') > 0
                                                                     || $("#DatabaseId").val().indexOf('请选择') > 0
                                                                     || $("#FrameworkId").val().indexOf('请选择') > 0
                                                                     || $("#Contract").val() == ""
                                                                     || $("#preview").val() == ""
                                                                    ) {
                                                                    $(".err-red-out").html("*资料请填写完整，除了 【标签】，【相关链接】，【源码作者】可以不填，其他都是必填项。");
                                                                    $(".err-red-out").css("display", "block");
                                                                    return;
                                                                }
                                                                $(".err-red-out").html("");
                                                                $(".err-red-out").css("display", "none");
                                                                $("#dstep5").addClass("active");
                                                                $("#step1").removeClass("active");
                                                                $("#step2").removeClass("active");
                                                                $("#step3").removeClass("active");
                                                                $("#step4").removeClass("active");
                                                                $("#step5").addClass("active");
                                                                //显示提交按钮
                                                                $("#upfile").css("display", "block");
                                                                $("#btnnextsetp").css("display", "none");
                                                            });
                                                        </script>
											 
													</div>
													<div id="upfile" class="row-fluid wizard-actions" style="display:none;">
														<button class="btn btn-success btn-next" id="submitSendCode" >
												 
															提交
														</button>

														<button class="btn btn-prev" data-last="Finish ">
															放弃
															 
														</button>
                                                        <script>
                                                            $("#submitSendCode").click(function () {
                                                                //获取上传源码的相关信息
                                                                var codedata = {
                                                                    name: $("#txtCodeName").val(),
                                                                    paynub: $("#txtCodePayNub").val(),
                                                                    codeserverurl: $("#txt_filePath").val(),
                                                                    codepics: $(".upimgspanel").html(),
                                                                    //5
                                                                    CodeType: $("#CodeTypeId").val(),
                                                                    DevelopTool: $("#DevelopToolId").val(),
                                                                    Language: $("#LanguageId").val(),
                                                                    Database: $("#DatabaseId").val(),
                                                                    Framework: $("#FrameworkId").val(),
                                                                    Tags: $("#Tags").val(),
                                                                    LinkUrl: $("#LinkUrl").val(),
                                                                    Author: $("#Author").val(),
                                                                    Contract: $("#Contract").val(),
                                                                    UserMsg: $("#UserMsg").val(),
                                                                    preview: $("#preview").val()

                                                                };
                                                                $.ajax({
                                                                    url: '../../Services/Core/SendCodeInfoHandler.ashx',
                                                                    type: 'POST',
                                                                    //data: ,
                                                                    data: {
                                                                        "name": codedata.name, "paynub": codedata.paynub, "codeserverurl": codedata.codeserverurl, "codepics": codedata.codepics, "codetype": codedata.CodeType,
                                                                        "developtool": codedata.DevelopTool, "language": codedata.Language, "database": codedata.Database, "framework": codedata.Framework, "tags": codedata.Tags,
                                                                        "linkurl": codedata.LinkUrl, "author": codedata.Author, "contract": codedata.Contract, "usermsg": codedata.UserMsg, "preview": codedata.preview

                                                                        //"codedata":JSON.stringify(codedata)
                                                                    },
                                                                    dataType: "json",
                                                                    async: false,
                                                                    cache: false,
                                                                    //contentType: false,
                                                                    //processData: false,
                                                                    success: function (data) {
                                                                        //$(".upimgspanel").html($(".upimgspanel").html() + "<br>" + data);
                                                                    },
                                                                    error: function (data, status, e) {
                                                                        alert(e);
                                                                    }
                                                                });
                                                            });
                                                        </script>
													</div>
											</div>
            </div></div>
            <script type="text/javascript">
                $(".uppic").on("change", "input[type='file']", function () {
                    var filePath = $(this).val();
                    var formData = new FormData($("#form1")[0]);
                    //设置上传文件类型
                    if (filePath.indexOf("jpg") != -1 || filePath.indexOf("png") != -1 || filePath.indexOf("bmp") != -1 || filePath.indexOf("jpge") != -1) {
                        //上传源码文件
                        $.ajax({
                            url: '../service/PicHandler.ashx',
                            type: 'POST',
                            data: formData,
                            async: false,
                            cache: false,
                            contentType: false,
                            processData: false,
                            success: function (data) {
                                $(".upimgspanel").html(  $(".upimgspanel").html()+"<br>"+data);
                            },
                            error: function (data, status, e) {
                                alert(e);
                            }
                        });
                    } else {
                        alert("请选择正确的文件格式！");
                        $(".upimgspanel").html("");
                        return false;
                    }
                });
		    </script>
</asp:Content>
