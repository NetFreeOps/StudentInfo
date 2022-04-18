<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StudentInfo.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <title>Amaze UI Admin index Examples</title>
    <meta name="description" content="这是一个 index 页面"/>
    <meta name="keywords" content="index"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="renderer" content="webkit"/>
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link rel="icon" type="image/png" href="assets/i/favicon.png"/>
    <link rel="apple-touch-icon-precomposed" href="assets/i/app-icon72x72@2x.png"/>
    <meta name="apple-mobile-web-app-title" content="Amaze UI" />
    <link rel="stylesheet" href="assets/css/amazeui.min.css" />
    <link rel="stylesheet" href="assets/css/amazeui.datatables.min.css" />
    <link rel="stylesheet" href="assets/css/app.css"/>
    <script src="assets/js/jquery.min.js"></script>
</head>
<body data-type="login">
    <script src="assets/js/theme.js"></script>
    <div class="am-g tpl-g">
        <!-- 风格切换 -->
        <div class="tpl-skiner">
            <div class="tpl-skiner-toggle am-icon-cog">
            </div>
            <div class="tpl-skiner-content">
                <div class="tpl-skiner-content-title">
                    选择主题
                </div>
                <div class="tpl-skiner-content-bar">
                    <span class="skiner-color skiner-white" data-color="theme-white"></span>
                    <span class="skiner-color skiner-black" data-color="theme-black"></span>
                </div>
            </div>
        </div>
        <div class="tpl-login">
            <div class="tpl-login-content">
                <div class="tpl-login-logo">

                </div>



                <form class="am-form tpl-form-line-form" runat="server">
                    <div class="am-form-group">
                        <input type="text" runat="server" class="tpl-form-input" id="user_name" placeholder="请输入账号"/>

                    </div>

                    <div class="am-form-group">
                        <input type="password" runat="server" class="tpl-form-input" id="user_pwd" placeholder="请输入密码"/>

                    </div>
                    <div class="am-form-group tpl-login-remember-me">
                        <asp:Label ID="Label1" runat="server" Font-Size="Smaller" Text="用户选择："></asp:Label>
                        <br />
                        <div class="am-form-group" style="margin-left: 80px; height: 45px;">
                    角色：<select id="userrole" style="width: 170px; height: 30px; background-color: #808080;" runat="server" >
                        <option>管理员</option>
                        <option>学生</option>
                        <option>教师</option>                     
                    </select>
                </div><br />
                        <div class="am-form-group" style="margin-left: 80px;">
                    验证：<input type="text" style="width: 100px;" class="tpl-form-input" id="usercode"
                        placeholder="请输入验证码" runat="server"/>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/CheckCode.aspx" />
                </div>

                        

                    </div>






                    <div class="am-form-group">
                        <asp:Button ID="btnLogin" runat="server" Text="登录" class="am-btn am-btn-primary  am-btn-block tpl-btn-bg-color-success  tpl-login-btn" OnClick="Button1_Click" />

                    </div>
                </form>
            </div>
        </div>
    </div>
    <script src="assets/js/amazeui.min.js"></script>
    <script src="assets/js/app.js"></script>
</body>
</html>
