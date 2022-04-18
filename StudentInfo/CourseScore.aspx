<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CourseScore.aspx.cs" Inherits="StudentInfo.CourseScore" %>
<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="am-u-sm-12 am-u-md-12 am-u-lg-12">
            <div class="widget am-cf">
                <div class="widget-head am-cf">
                    <div class="widget-title am-fl">
                        录入成绩</div>
                    <div class="widget-function am-fr">
                        选择科目<asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" 
                            Style="color: Black; background-color: White;" 
                            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="widget-body am-fr">
                    <div class="am-form tpl-form-border-form tpl-form-border-br">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="98%"
                            DataKeyNames="Id">
                            <Columns>
                                <asp:BoundField DataField="StudentId" HeaderText="学号" />
                                <asp:BoundField DataField="StudetnName" HeaderText="姓名" />
                                <asp:BoundField DataField="CourseName" HeaderText="课程" />
                                <asp:TemplateField HeaderText="成绩">
                                    <ItemTemplate>
                                        <asp:TextBox ID="tb1" runat="server" Width="60px" Style="text-align: right; background-color: White; color:Black;"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle Height="30px" />
                        </asp:GridView>
                    </div>
                    <div class="am-form-group" style="margin-top: 15px;">
                        
                        <div class="am-u-sm-9 am-u-sm-push-3">
                            <asp:Button ID="Button2" runat="server" Text="添加" class="am-btn am-btn-primary tpl-btn-bg-color-success "
                                OnClick="Button2_Click" />
                            <asp:Button ID="Button1" runat="server" Text="提交" class="am-btn am-btn-primary tpl-btn-bg-color-success "
                                OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>