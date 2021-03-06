<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="StudentManage.aspx.cs" Inherits="StudentInfo.StudentManage" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="am-u-sm-12 am-u-md-12 am-u-lg-12">
            <div class="widget am-cf">
                <div class="widget-head am-cf">
                    <div class="widget-title am-fl">
                        用户信息</div>
                    <div class="widget-function am-fr">
                        <a href="javascript:;" class="am-icon-cog"></a>
                    </div>
                </div>
                <div class="widget-body am-fr">
                    <div class="am-form tpl-form-border-form tpl-form-border-br">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="98%" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" DataKeyNames="Id">
                            <Columns>
                                <asp:BoundField DataField="StudentId"  HeaderText="学号" />
                                <asp:BoundField DataField="StudentName" HeaderText="姓名" />
                                <asp:BoundField DataField="StudentSex" HeaderText="性别" />
                                <asp:BoundField DataField="StudentNation" HeaderText="民族" />
                                <asp:BoundField DataField="StudentTelephone" DataFormatString="电话" 
                                    HeaderText="电话" />
                                <asp:BoundField DataField="StudentQQ" HeaderText="QQ" />
                                <asp:BoundField DataField="StudentClass" HeaderText="班级" />
                                <asp:BoundField DataField="StudentAddress" HeaderText="宿舍" />
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
