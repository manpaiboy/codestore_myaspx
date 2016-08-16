<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/UI/AdminUiBase.Master" AutoEventWireup="true" CodeBehind="codesadd.aspx.cs" Inherits="WebUI.Admin.code.codesadd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/Admin/Code/CodeAdd.css" rel="stylesheet" />
    <script src="../../ACE/assets/js/jquery-2.0.3.min.js"></script>
    <script src="../../ACE/assets/js/ace-extra.min.js"></script>
    <link href="../../ACE/assets/css/select2.css" rel="stylesheet" />
    <script src="../../ACE/assets/js/jquery.validate.min.js"></script>
    <script src="../../ACE/assets/js/select2.min.js"></script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    	 
	<div class="widget-body">
												<div class="widget-main">
													<div id="fuelux-wizard" class="row-fluid" data-target="#step-container">
														<ul class="wizard-steps">
															<li data-target="#step1" class="active">
																<span class="step">1</span>
																<span class="title">选择源码类型</span>
															</li>

															<li data-target="#step2">
																<span class="step">2</span>
																<span class="title">填写基本信息</span>
															</li>

															<li data-target="#step3">
																<span class="step">3</span>
																<span class="title">上传文件</span>
															</li>

															<li data-target="#step4">
																<span class="step">4</span>
																<span class="title">上传截图</span>
															</li>

                                                            	<li data-target="#step5">
																<span class="step">5</span>
																<span class="title">填写详细信息</span>
															</li>
                                                             	<li data-target="#step6">
																<span class="step">6</span>
																<span class="title">提交完成</span>
															</li>
														</ul>
													</div>

													<hr />
													<div class="step-content row-fluid position-relative" id="step-container">
														<div class="step-pane active" id="step1">
															<h3 class="lighter block green"> </h3>

															 
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
                                                         <div id="upfile" class="row-fluid wizard-actions" >
														<button class="btn btn-success btn-next" >
												 
															下一步
														</button>

											 
													</div>
													<div id="upfile" class="row-fluid wizard-actions" style="display:none;">
														<button class="btn btn-success btn-next" >
												 
															提交
														</button>

														<button class="btn btn-prev" data-last="Finish ">
															重置
															 
														</button>
													</div>
												</div><!-- /widget-main -->
											</div>
    </div></div>
            <script type="text/javascript">
               
		    </script>
</asp:Content>
