<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CourseManage.aspx.cs" Inherits="StudentInfo.CourseManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
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
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            Width="98%" onrowcommand="GridView1_RowCommand" DataKeyNames="Id" 
                            onrowdatabound="GridView1_RowDataBound" 
                            onrowediting="GridView1_RowEditing">
                            <Columns>
                                <asp:BoundField DataField="CourseId" HeaderText="课程编号" />
                                <asp:BoundField DataField="CourseName" HeaderText="课程名称" />
                                <asp:BoundField DataField="CourseTeacher" HeaderText="任课老师" />
                                <asp:BoundField DataField="CourseInfo" HeaderText="课程介绍" />
                                <asp:BoundField DataField="CourseStudentNum" HeaderText="允许选课人数" />
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbE" runat="server" CommandName="comE">编辑</asp:LinkButton>||
                                        <asp:LinkButton ID="lbD" runat="server" CommandName="comD" OnClientClick="return confirm('确定要删除吗?');">删除</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle Height="30px" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
