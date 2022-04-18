<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="StudentInfo.UserAdd" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="am-u-sm-12 am-u-md-12 am-u-lg-12">
        <div class="widget am-cf">
            <div class="widget-head am-cf">
                <div class="widget-title am-fl">
                    用户新增</div>
                <div class="widget-function am-fr">
                    <a href="javascript:;" class="am-icon-cog"></a>
                </div>
            </div>
            <div class="widget-body am-fr">
                <div class="am-form tpl-form-line-form">
                <div class="am-form-group">
                    <label for="user-name" class="am-u-sm-3 am-form-label">
                        用户名 <span class="tpl-form-line-small-title">UserName</span></label>
                    <div class="am-u-sm-9">
                        <input type="text" class="tpl-form-input" id="username" placeholder="请输入用户名" runat="server"/>
                        <small>请填写8个以上字符。</small>
                    </div>
                </div>
                 <div class="am-form-group">
                    <label for="user-name" class="am-u-sm-3 am-form-label">
                        密码 <span class="tpl-form-line-small-title">UserPasswort</span></label>
                    <div class="am-u-sm-9">
                        <input type="password" class="tpl-form-input" id="userpwd" placeholder="请输入密码" runat="server"/>
                        <small>请填写8个以上字符。</small>
                    </div>
                </div>
               
                <div class="am-form-group">
                    <label for="user-phone" class="am-u-sm-3 am-form-label">
                        类型 <span class="tpl-form-line-small-title">Role</span></label>
                    <div class="am-u-sm-9">
                        <select data-am-selected="{searchBox: 1}" id="role" style="display: none;" runat="server">
                            <option value="管理员">管理员</option>
                            <option value="教师">教师</option>
                        </select>
                    </div>
                </div>
                <div class="am-form-group">
                    <label class="am-u-sm-3 am-form-label">
                        姓名 <span class="tpl-form-line-small-title">TrueName</span></label>
                    <div class="am-u-sm-9">
                        <input type="text" id="truename" placeholder="请输入真实姓名" runat="server">
                    </div>
                </div>
                 <div class="am-form-group">
                    <label class="am-u-sm-3 am-form-label">
                        电话 <span class="tpl-form-line-small-title">LinkTelephone</span></label>
                    <div class="am-u-sm-9">
                        <input id="linktelephone" type="text" placeholder="请输入联系电话" runat="server">
                    </div>
                </div>
              
                <div class="am-form-group">
                    <div class="am-u-sm-9 am-u-sm-push-3">
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" 
                            class="am-btn am-btn-primary tpl-btn-bg-color-success " 
                            onclick="btnSubmit_Click" />
                       
                    </div>
                </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
