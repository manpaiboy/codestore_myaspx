<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/UI/AdminUiBase.Master" AutoEventWireup="true" CodeBehind="codesadd.aspx.cs" Inherits="WebUI.Admin.code.codesadd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <script src="../../ACE/assets/js/jquery-2.0.3.min.js"></script>
    <script src="../../ACE/assets/js/ace-extra.min.js"></script>
    <link href="../../ACE/assets/css/select2.css" rel="stylesheet" />
    <script src="../../ACE/assets/js/jquery.validate.min.js"></script>
    <script src="../../ACE/assets/js/select2.min.js"></script>
    <link href="../../Css/Admin/Code/CodeAdd.css" rel="stylesheet" />
    <script src="../../Scripts/ajaxfileupload.js"></script>
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

                                                                 <span>选择文件：</span><input id="txt_filePath" type="text" readonly="readonly"/>
                                                                 <span class="file"><input id="txtCodeUpRar" name="txtCodeUpRar" type="file"/>浏览</span>
                                                               <%-- <input type="file" value=""  id="txtCodeUpRar" /> --%>
                                                                <label class="errtooptip" id="e4"></label>
                                                              
                                                                <script>
                                                                    $(function () {
                                                                        //选择文件
                                                                        $(".file").on("change", "input[type='file']", function () {
                                                                            var filePath = $(this).val();
                                                                            //alert(filePath); return;
                                                                            //设置上传文件类型
                                                                            if (filePath.indexOf("rar") != -1 || filePath.indexOf("zip") != -1) {
                                                                                //上传文件
                                                                                $.ajaxFileUpload({
                                                                                    url: '../service/FileHandler.ashx',
                                                                                    secureuri: false,
                                                                                    fileElementId: 'txtCodeUpRar',
                                                                                    dataType: 'json',
                                                                                    success: function (data, status) {
                                                                                        //获取上传文件路径
                                                                                        $("#txt_filePath").val(data.filenewname);
                                                                                        alert("文件上传成功！");
                                                                                    },
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
                                                        	</div>
                                                        <!-- /widget-main --> 

                                                         <div id="upfilenext" class="row-fluid wizard-actions" >
													<%--	<button class="btn btn-success btn-next" id="btnnextsetp" >
												 
															下一步
														</button>--%>
                                                             <input type="button" class="btn btn-success btn-next" id="btnnextsetp" value="下一步" />
                                                        <script>
                                                            $("#btnnextsetp").click(function () {
                                                                if ($("#txtCodeName").val() == "") { $("#e1").html("源码名称不能为空"); return; }
                                                                if (parseInt($("#txtCodePayNub").val()) <= 10) { $("#e2").html("积分或者金币不能低于10"); return; }
                                                                $("#e1").html(""); $("#e2").html("");
                                                                $("#dstep2").addClass("active");
                                                                $("#step2").addClass("active");
                                                                $("#step1").removeClass("active");
                                                                //$("#step2").addClass("active");
                                                            });
                                                        </script>
											 
													</div>
													<div id="upfile" class="row-fluid wizard-actions" style="display:none;">
														<button class="btn btn-success btn-next" >
												 
															提交
														</button>

														<button class="btn btn-prev" data-last="Finish ">
															重置
															 
														</button>
													</div>
											</div>
    </div></div>
            <script type="text/javascript">
               
		    </script>
</asp:Content>
