<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="NewsShow.aspx.cs" Inherits="StudentInfo.NewsShow" %>
<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
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
                            Width="98%"  DataKeyNames="Id" >
                            <Columns>
                                <asp:BoundField DataField="Title" HeaderText="标题" />
                                <asp:BoundField DataField="Author" HeaderText="作者" />
                                 <asp:BoundField DataField="Content" HeaderText="内容" />
                                <asp:BoundField DataField="ReleaseTime" HeaderText="时间" />
                            </Columns>
                            <RowStyle Height="30px" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>