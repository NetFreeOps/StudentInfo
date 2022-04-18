<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CourseSelect.aspx.cs" Inherits="StudentInfo.CourseSelect" %>
<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="am-u-sm-12 am-u-md-12 am-u-lg-12">
            <div class="widget am-cf">
                <div class="widget-head am-cf">
                    <div class="widget-title am-fl">
                        选课操作</div>
                    <div class="widget-function am-fr">
                        <a href="javascript:;" class="am-icon-cog"></a>
                    </div>
                </div>
                <div class="widget-body am-fr">
                    <div class="am-form tpl-form-border-form tpl-form-border-br">
                        <table style="width: 480px; margin-bottom:35px;">
                            <tr>
                                <td style=" width:200px;">
                                    可选课程
                                    <asp:ListBox ID="ListBox1" runat="server" Height="300px" 
                                        SelectionMode="Multiple"></asp:ListBox>
                                </td>
                                <td style="text-align:center; vertical-align:middle; width:60px;">
                                    <asp:Button ID="Button2" runat="server" Text="选定》》" ToolTip="选择" 
                                        onclick="Button2_Click" ForeColor="Black" />
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Button ID="Button3" runat="server" Text="退选《《" ToolTip="撤销" 
                                        onclick="Button3_Click" ForeColor="Black" />
                                </td>
                                <td style=" width:200px;">
                                    已选课程
                                    <asp:ListBox ID="ListBox2" runat="server" Height="300px" 
                                        SelectionMode="Multiple"></asp:ListBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="am-form-group">
                        <div class="am-u-sm-9 am-u-sm-push-3">
                            <asp:Button ID="btnSubmit" runat="server" Text="提交" class="am-btn am-btn-primary tpl-btn-bg-color-success "
                                OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>