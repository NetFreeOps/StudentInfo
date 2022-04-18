<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CourseAdd.aspx.cs" Inherits="StudentInfo.CourseAdd" %>
<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="am-u-sm-12 am-u-md-12 am-u-lg-12">
            <div class="widget am-cf">
                <div class="widget-head am-cf">
                    <div class="widget-title am-fl">
                        课程信息</div>
                    <div class="widget-function am-fr">
                        <a href="javascript:;" class="am-icon-cog"></a>
                    </div>
                </div>
                <div class="widget-body am-fr">
                    <div class="am-form tpl-form-border-form tpl-form-border-br">
                        <div class="am-form-group">
                            <label for="user-name" class="am-u-sm-3 am-form-label">
                               课程编号<span class="tpl-form-line-small-title">CourseId</span></label>
                            <div class="am-u-sm-9">
                                <input type="text" class="tpl-form-input" id="course_id" placeholder="请输入课程编号" runat="server">
                                <small>必须是字母、数字和下划线</small>
                            </div>
                        </div>
                        <div class="am-form-group">
                            <label for="user-name" class="am-u-sm-3 am-form-label">
                               课程名称<span class="tpl-form-line-small-title">CourseName</span></label>
                            <div class="am-u-sm-9">
                                <input type="text" class="tpl-form-input" id="course_name" placeholder="请输入课程名程"
                                    runat="server">
                                <small>必须是字母、数字和下划线。</small>
                            </div>
                        </div>
                        <div class="am-form-group">
                            <label for="user-name" class="am-u-sm-3 am-form-label">
                               任课教师 <span class="tpl-form-line-small-title">CourseTeacher</span></label>
                            <div class="am-u-sm-9">
                                <input type="text" class="tpl-form-input" id="course_teacher" placeholder="请输入任课教师姓名"
                                    runat="server">
                                <small>必须是字母、数字和下划线</small>
                            </div>
                        </div>
                        <div class="am-form-group">
                            <label for="user-name" class="am-u-sm-3 am-form-label">
                               限定人数 <span class="tpl-form-line-small-title">CourseNum</span></label>
                            <div class="am-u-sm-9">
                                <input type="text" class="tpl-form-input" id="course_number" placeholder="请输入选修的人数上限"
                                    runat="server">
                                <small>必须为数字</small>
                            </div>
                        </div>
                        <div class="am-form-group">
                            <label for="user-name" class="am-u-sm-3 am-form-label">
                               课程信息 <span class="tpl-form-line-small-title">CourseInfo</span></label>
                            <div class="am-u-sm-9">
                                <textarea runat="server" class="" rows="10" id="course_info" placeholder="请输入课程内容"></textarea>
                                <small>必须是字母、数字和下划线</small>
                            </div>
                        </div>
                    </div>
                    <div class="am-form-group">
                        <div class="am-u-sm-9 am-u-sm-push-3">
                            <asp:Button ID="btnSubmit" runat="server" Text="提交" 
                                class="am-btn am-btn-primary tpl-btn-bg-color-success " 
                                OnClick="btnSubmit_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>