<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" Inherits="StudentInfo.NewsEdit" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <script type="text/javascript" charset="utf-8" src="ueditor/ueditor.config.js"></script>

    <script type="text/javascript" charset="utf-8" src="ueditor/ueditor.all.js"></script>

    <link rel="stylesheet" type="text/css" href="ueditor/themes/default/css/ueditor.css" />
    <div class="row">
        <div class="am-u-sm-12 am-u-md-12 am-u-lg-12">
            <div class="widget am-cf">
                <div class="widget-head am-cf">
                    <div class="widget-title am-fl">
                        新闻信息</div>
                    <div class="widget-function am-fr">
                        <a href="javascript:;" class="am-icon-cog"></a>
                    </div>
                </div>
                <div class="widget-body am-fr">
                    <div class="am-form tpl-form-border-form tpl-form-border-br">
                        <div class="am-form-group">
                            <label for="user-name" class="am-u-sm-3 am-form-label">
                                标题 <span class="tpl-form-line-small-title">IdCard</span></label>
                            <div class="am-u-sm-9">
                                <input type="text" class="tpl-form-input" id="title" placeholder="请输入新闻标题" runat="server"/>
                                <small>必须是字母、数字和下划线</small>
                            </div>
                        </div>
                         <div class="am-form-group">
                            <label for="user-name" class="am-u-sm-3 am-form-label">
                                作者 <span class="tpl-form-line-small-title">Auther</span></label>
                            <div class="am-u-sm-9">
                                <input type="text" class="tpl-form-input" id="auther" placeholder="请输入作者"
                                    runat="server"/>
                                
                            </div>
                        </div>
                        <div class="am-form-group">
                            <label for="user-name" class="am-u-sm-3 am-form-label">
                                内容 <span class="tpl-form-line-small-title">Content</span></label>
                            <div class="am-u-sm-9">
                                <div id="txteditor" style="height: 500px; width:800px">
                                </div>
                                <asp:HiddenField ID="content" runat="server" />

                                <script type="text/javascript">
                                    var temp = document.getElementById("<%=content.ClientID %>").value;
                                    var ue = new baidu.editor.ui.Editor();
                                    ue.render("txteditor");   //这里填写要改变为编辑器的控件id 
                                    ue.ready(function () { ue.setContent(temp); })
                                </script>

                                <script type="text/javascript">
                                    function getContent() {
                                        var temp = UE.getEditor('txteditor').getContent();
                                        // alert(temp); 
                                        document.getElementById("<%=content.ClientID %>").value = temp;
                                    }
                                </script>

                            </div>
                        </div>
                    </div>
                    <div class="am-form-group">
                        <div class="am-u-sm-9 am-u-sm-push-3">
                            <asp:Button ID="Button1" runat="server" Text="提交" OnClientClick="getContent();" class="am-btn am-btn-primary tpl-btn-bg-color-success "
                                OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
