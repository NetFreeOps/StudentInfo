<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="StuImport.aspx.cs" Inherits="StudentInfo.StuImport" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="am-u-sm-12 am-u-md-12 am-u-lg-12">
            <div class="widget am-cf">
                <div class="widget-head am-cf">
                    <div class="widget-title am-fl">
                        导入学生信息</div>
                    <div class="widget-function am-fr">
                        <a href="javascript:;" class="am-icon-cog"></a>
                    </div>
                </div>
                <div class="widget-body am-fr">
                    <div class="am-form tpl-form-border-form tpl-form-border-br">
                        <asp:Literal ID="ltshow" runat="server"></asp:Literal>
                        <div class="am-form-group">
                            <label for="user-name" class="am-u-sm-3 am-form-label">
                                选择文件<span class="tpl-form-line-small-title"></span><br /></label>
                            <div class="am-u-sm-9">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="am-form-group">
                        <div class="am-u-sm-9 am-u-sm-push-3">
                            <asp:Button ID="Button1" runat="server" Text="确认导入" class="am-btn am-btn-primary tpl-btn-bg-color-success " OnClick="Button1_Click"/>
                            <br />
                            <br />
                        </div>
                    </div>
                    <div class="am-form-group">
                        <div class="am-u-sm-9 am-u-sm-push-3">
                            <asp:Button ID="Button2" runat="server" Text="导出数据" class="am-btn am-btn-primary tpl-btn-bg-color-success " OnClick="Button2_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
