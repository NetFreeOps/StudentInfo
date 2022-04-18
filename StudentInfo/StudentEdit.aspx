<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="StudentEdit.aspx.cs" Inherits="StudentInfo.StudentEdit" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="am-u-sm-12 am-u-md-12 am-u-lg-12">
        <div class="widget am-cf">
            <div class="widget-head am-cf">
                <div class="widget-title am-fl">
                    学生新增</div>
                <div class="widget-function am-fr">
                    <a href="javascript:;" class="am-icon-cog"></a>
                </div>
            </div>
            <div class="widget-body am-fr">
                <div class="am-form tpl-form-line-form">
                <div class="am-form-group">
                    <label for="user-name" class="am-u-sm-3 am-form-label">
                        学号 <span class="tpl-form-line-small-title">StudentId</span></label>
                    <div class="am-u-sm-9">
                        <input type="text" class="tpl-form-input" id="stuid" placeholder="请输入学号" runat="server"/>
                    </div>
                </div>
                 <div class="am-form-group">
                    <label for="user-name" class="am-u-sm-3 am-form-label">
                        密码 <span class="tpl-form-line-small-title">StudentPasswort</span></label>
                    <div class="am-u-sm-9">
                        <input type="password" class="tpl-form-input" id="pwd" placeholder="请输入密码" runat="server"/>
                    </div>
                </div>
                <div class="am-form-group">
                    <label class="am-u-sm-3 am-form-label">
                        姓名 <span class="tpl-form-line-small-title">StudentName</span></label>
                    <div class="am-u-sm-9">
                        <input type="text" id="name" placeholder="请输入学生姓名" runat="server"/>
                    </div>
                </div>
                
               <div class="am-form-group">
                                    <label for="user-name" class="am-u-sm-3 am-form-label">
                                        图片： <span class="tpl-form-line-small-title">Image</span></label>
                                    <div class="am-u-sm-9">
                                        <asp:FileUpload ID="Fileimg" runat="server"  class="tpl-form-input" placeholder="请插入图" runat="server"/>
                                    </div>
                                </div>
                
                 <div class="am-form-group">
                    <label for="user-phone" class="am-u-sm-3 am-form-label">
                        性别 <span class="tpl-form-line-small-title"> Sex </span></label>
                    <div class="am-u-sm-9">
                        <select data-am-selected="{searchBox: 1}" id="sex" style="display: none;" runat="server">
                            <option value="男">男</option>
                            <option value="女">女</option>
                        </select>
                    </div>
                </div>
                <div class="am-form-group">
                    <label class="am-u-sm-3 am-form-label">
                        民族 <span class="tpl-form-line-small-title">Nation</span></label>
                    <div class="am-u-sm-9">
                        <input id="nation" type="text" placeholder="请输入民族" runat="server"/>
                    </div>
                </div>
                
                 <div class="am-form-group">
                    <label class="am-u-sm-3 am-form-label">
                        电话 <span class="tpl-form-line-small-title">StudentTelephone</span></label>
                    <div class="am-u-sm-9">
                        <input id="telephone" type="text" placeholder="请输入联系电话" runat="server"/>
                    </div>
                </div>
                 <div class="am-form-group">
                    <label class="am-u-sm-3 am-form-label">
                        QQ <span class="tpl-form-line-small-title">QQ</span></label>
                    <div class="am-u-sm-9">
                        <input id="qq" type="text" placeholder="请输入QQ" runat="server"/>
                    </div>
                </div>
                
                 <div class="am-form-group">
                    <label for="user-phone" class="am-u-sm-3 am-form-label">
                        班级 <span class="tpl-form-line-small-title"> StudentClass </span></label>
                    <div class="am-u-sm-9">
                        <select data-am-selected="{searchBox: 1}" id="StudentClass" style="display: none;" runat="server">
                            <option value="18-1">18-1</option>
                            <option value="18-2">18-2</option>
                        </select>
                    </div>
                </div>
                
                 <div class="am-form-group">
                    <label class="am-u-sm-3 am-form-label">
                        宿舍 <span class="tpl-form-line-small-title">Dormitory</span></label>
                    <div class="am-u-sm-9">
                        <input id="dormitory" type="text" placeholder="请输入宿舍" runat="server"/>
                    </div>
                </div>
                 <div class="am-form-group">
                    <label class="am-u-sm-3 am-form-label">
                        住址 <span class="tpl-form-line-small-title">Address</span></label>
                    <div class="am-u-sm-9">
                        <input id="address" type="text" placeholder="请输入住址" runat="server"/>
                    </div>
                </div>
                <div class="am-form-group">
                    <div class="am-u-sm-9 am-u-sm-push-3">
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" class="am-btn am-btn-primary tpl-btn-bg-color-success " onclick="btnSubmit_Click" />                    </div>
                </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
