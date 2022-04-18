<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="NewsManage.aspx.cs" Inherits="StudentInfo.NewsManage" EnableEventValidation="false" %>
<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="am-u-sm-12 am-u-md-12 am-u-lg-12">
            <div class="widget am-cf">
                <div class="widget-head am-cf">
                    <div class="widget-title am-fl">
                        公告信息</div>
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
                                <asp:BoundField DataField="Title" HeaderText="标题" />
                                <asp:BoundField DataField="Author" HeaderText="作者" />
                                 <asp:BoundField DataField="Content" HeaderText="内容" />
                                <asp:BoundField DataField="ReleaseTime" HeaderText="时间" />
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