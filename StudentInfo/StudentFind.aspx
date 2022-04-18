<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="StudentFind.aspx.cs" Inherits="StudentInfo.StudentFind" EnableEventValidation="false" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="content">
    <div class="row">
        <div class="am-u-sm-12 am-u-md-12 am-u-lg-12">
            <div class="widget am-cf">
                <div class="widget-head am-cf">
                    <div class="widget-title am-fl">
                        学生信息</div>
                    <div class="widget-function am-fr">
                        <a href="javascript:;" class="am-icon-cog"></a>
                    </div>
                </div>
                <div class="widget-body am-fr">
                    <div>
                        班级：<asp:DropDownList ID="DropDownList1" runat="server" Style="color: Black;">
                            <asp:ListItem>全部</asp:ListItem>
                            <asp:ListItem>18-1</asp:ListItem>
                            <asp:ListItem>18-2</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        姓名：<asp:TextBox ID="TextBox1" runat="server" Style="color: Black;"></asp:TextBox><br />
                        性别：<asp:DropDownList ID="DropDownList2" runat="server" Style="color: Black;">
                            <asp:ListItem>全部</asp:ListItem>
                            <asp:ListItem>男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="am-btn am-btn-primary tpl-btn-bg-color-success "
                            Style="margin-top: 10px;" OnClick="btnSearch_Click" />
                    </div>
                    <div class="am-form tpl-form-border-form tpl-form-border-br">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="98%"
                            OnRowCommand="GridView1_RowCommand" DataKeyNames="Id" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="studentId" HeaderText="学号" />
                                <asp:BoundField DataField="studentName" HeaderText="姓名" />
                                <asp:BoundField DataField="studentSex" HeaderText="性别" />
                                <asp:BoundField DataField="studentClass" HeaderText="班级" />
                                <asp:BoundField DataField="studentAddress" HeaderText="籍贯" />
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbE" runat="server" CommandName="ComE">编辑</asp:LinkButton>||
                                        <asp:LinkButton ID="lbD" runat="server" CommandName="ComD" OnClientClick="return confirm('确定要删除吗?');">删除</asp:LinkButton>
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