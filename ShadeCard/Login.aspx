<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Product_Work_Flow.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
    <meta charset="utf-8" />
    <title>Shade Card</title>
    <meta name="description" content="Login" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!--begin::Fonts -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700|Roboto:300,400,500,600,700" />


    <!--end::Fonts -->

    <!--begin::Page Custom Styles(used by this page) -->
   
    <link href="assets/css/login-6.css" rel="stylesheet" />

    <!--end::Page Custom Styles -->
    

    <!--begin::Global Theme Styles(used by all pages) -->
    <link href="assets/plugins/global/plugins.bundle.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.bundle.css" rel="stylesheet" type="text/css" />

    <!--end::Global Theme Styles -->

    <!--begin::Layout Skins(used by all pages) -->

    <!--end::Layout Skins -->
    <link rel="shortcut icon" href="assets/media/logos/favicon.ico" />
</head>

<body class="kt-quick-panel--right kt-demo-panel--right kt-offcanvas-panel--right kt-header--fixed kt-header-mobile--fixed kt-subheader--enabled kt-subheader--transparent kt-aside--enabled kt-aside--fixed kt-page--loading">

    <form id="form1" runat="server" class="kt-grid kt-grid--ver kt-grid--root kt-page">
        <!-- begin:: Page -->

        <div class="kt-grid kt-grid--hor kt-grid--root  kt-login kt-login--v6 kt-login--signin" id="kt_login">
            <div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--desktop kt-grid--ver-desktop kt-grid--hor-tablet-and-mobile">
                <div class="kt-grid__item  kt-grid__item--order-tablet-and-mobile-2  kt-grid kt-grid--hor kt-login__aside" style="background: linear-gradient(178deg, #d5eaeb, transparent);">
                    <div class="kt-login__wrapper">
                        <div class="kt-login__container">
                            <div class="kt-login__body">
                                <div class="kt-login__logo">
                                    <a href="#">
                                        <img src="assets/media/logos/pidilight-logo.png" />
                                    </a>
                                </div>
                                <div class="kt-login__signin">
                                    <div class="kt-login__head">
                                        <h3 class="kt-login__title">Log In</h3>
                                    </div>
                                    <div class="kt-login__form" id="divotp">
                                        <asp:Label ID="lbip" runat="server" Visible="false"></asp:Label>
                                        <div class="kt-form" style="padding: 10px;">
                                            <div class="form-group">
                                                 <asp:TextBox ID="txtUsercode" CssClass="form-control" runat="server" placeholder="Enter User Code" name="email" autocomplete="off"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" placeholder="Enter Password" MaxLength="10" autocomplete="off"></asp:TextBox>
                                            </div>
                                            <%--<div class="kt-login__extra">
                                                <asp:LinkButton ID="btnforget" runat="server" OnClick="btnforget_Click">Forget Password ?</asp:LinkButton>
                                            </div>--%>
                                            <div class="kt-login__actions">
                                                <asp:Button ID="BtnLogin" CssClass="btn btn-brand btn-pill btn-elevate" runat="server" Text="Login" OnClick="BtnLogin_Click" />
                                                <asp:Button ID="kt_login_forgot_cancel2" runat="server" OnClick="kt_login_forgot_cancel2_Click" class="btn btn-outline-brand btn-pill" Text="Cancel"></asp:Button>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="kt-login__forgot">
                                    <div class="kt-login__head">
                                        <h3 class="kt-login__title">Forgotten Password ?</h3>
                                        <div class="kt-login__desc">Enter your email to reset your password:</div>
                                    </div>
                                    <div class="kt-login__form">
                                        <div class="kt-form">
                                            <div class="form-group">
                                                <input class="form-control" type="text" placeholder="Email" name="email" id="kt_email" autocomplete="off" />
                                            </div>
                                            <div class="kt-login__actions">
                                                <button id="kt_login_forgot_submit" class="btn btn-brand btn-pill btn-elevate">Request</button>
                                                <button id="kt_login_forgot_cancel1" class="btn btn-outline-brand btn-pill">Cancel</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="kt-grid__item kt-grid__item--fluid kt-grid__item--center kt-grid kt-grid--ver kt-login__content" style="background-image: url(assets/media/logos/pdlt.png); background-size: cover; background-position: left; background-repeat: no-repeat; padding:0px; margin:0px;">
                    <div class="kt-login__section">
                        <div class="kt-login__block">
                            <%--<h3 class="kt-login__title">Join Our Community</h3>
							<div class="kt-login__desc">
								Lorem ipsum dolor sit amet, coectetuer adipiscing

                                    <br />
								elit sed diam nonummy et nibh euismod
							</div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- end:: Page -->
    </form>

    <!-- begin::Global Config(global config for global JS sciprts) -->
    <script>
        var KTAppOptions = {
            "colors": {
                "state": {
                    "brand": "#2c77f4",
                    "light": "#ffffff",
                    "dark": "#282a3c",
                    "primary": "#5867dd",
                    "success": "#34bfa3",
                    "info": "#36a3f7",
                    "warning": "#ffb822",
                    "danger": "#fd3995"
                },
                "base": {
                    "label": ["#c5cbe3", "#a1a8c3", "#3d4465", "#3e4466"],
                    "shape": ["#f0f3ff", "#d9dffa", "#afb4d4", "#646c9a"]
                }
            }
        };
		</script>

    <!-- end::Global Config -->

   
    <!--begin::Global Theme Bundle(used by all pages) -->
    <script src="assets/plugins/global/plugins.bundle.js" type="text/javascript"></script>
    <script src="assets/js/scripts.bundle.js" type="text/javascript"></script>

    <!--end::Global Theme Bundle -->

    <!--begin::Page Scripts(used by this page) -->
    <script src="assets/js/pages/custom/login/login-general.js" type="text/javascript"></script>

    <!--end::Page Scripts -->
</body>
</html>
