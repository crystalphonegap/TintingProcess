<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="AddEmployees.aspx.cs" Inherits="ShadeCard.AddEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        .cardMargin {
            margin: 10px;
        }

        .rowMargin {
            padding-bottom: 10px;
            margin: 2px
        }

        .CardStyle {
            border: solid 1px #ccc;
            border-radius: 5px;
            box-shadow: 5px 10px 5px #3661a914;
            background: linear-gradient(180deg, rgba(8,153,208,1) 0%, rgba(17,92,194,1) 51%, rgba(4,95,162,1) 100%);
            color: white;
            margin-bottom: 5px;
            min-height: 110px;
        }

        .BaseCardStyle {
            border: solid 1px #ccc;
            border-radius: 5px;
            box-shadow: 5px 10px 5px #3661a914;
            background-color: #dcb355;
            color: white;
            margin-bottom: 5px;
        }

        hr {
            margin-top: 4px;
            margin-bottom: 1px;
            border: 0;
            border-top: 1px solid #eee;
        }

        @media (min-width: 992px) {
            .modal-lg {
                width: 1500px;
            }
        }

        element.style {
            background-color: cadetblue;
        }

        .CardStyle {
            border: solid 1px #ccc;
            border-radius: 5px;
            box-shadow: 5px 10px 5px #3661a914;
            background-color: #547ab8;
            color: white;
            margin-bottom: 5px;
            min-height: 110px;
        }

        @media (min-width: 768px) {
            .col-sm-3 {
                width: 24%;
                margin: 6px;
            }
        }

        p {
            margin: 7px 1px 10px;
            font-size: 12px;
        }

      
    </style>

    <script language="Javascript">

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

    </script>
    <div class="card cardMargin">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <div class="col-md-12 card-body" style="margin-bottom: 0px!important">
            <div class="row">
                <asp:Label runat="server" ID="lblId" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="lblHexaCode" Text="" Style="display: none"></asp:Label>
                <asp:Label runat="server" ID="lblUserName" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="lblUserCode" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="lblUserType" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="lblUserEmail" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="lblUserId" Text="" Visible="false"></asp:Label>

                <div class="col-md-12">
                    <div class="col-md-10">
                        <h4>Add Employees</h4>
                    </div>
                    <div class="col-md-2" style="text-align: right;">
                        <a href="ViewEmployees.aspx" class="btn btn-primary"><i class="fa fa-eye" style="color: white"></i></a>
                    </div>


                </div>
                <div class="col-md-12" style="padding-bottom: 10px">
                    <hr />
                </div>
            </div>
            <div class="row rowMargin">

                <div class="col-md-3">
                    <label class="lableclass2">Employee Code (Username) *</label>
                    <asp:TextBox ID="txtEmpCode" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="R1" runat="server" ControlToValidate="txtEmpCode"
                        ErrorMessage="Please Enter a Employee Code" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <label class="lableclass2">Employee Name *</label>

                    <asp:TextBox ID="txtEmpName" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpName"
                        ErrorMessage="Please Enter a Employee Name" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>
                    <asp:Label runat="server" ID="lblcolorcode" Text="" Style="display: none;"></asp:Label>

                </div>
                <div class="col-md-3">
                    <label class="lableclass2">Employee Type *</label>
                    <div class="input-group">

                        <asp:DropDownList runat="server" ID="dropType" CssClass="form-control">
                            <asp:ListItem Value="0">Select </asp:ListItem>

                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dropType"
                            ErrorMessage="Select Employee Type" InitialValue="0" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>
                        <div class="input-group-addon">
                            <label data-toggle="modal" data-target="#myModal">+ NEW ROLE</label>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <label class="lableclass2">Email </label>
                    <asp:TextBox ID="txtEmail" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                        ErrorMessage="Invalid Email Address" ValidationGroup="Valid1" Display="None" />

                </div>
                <div class="col-md-3">
                    <label class="lableclass2">Mobile </label>
                    <asp:TextBox ID="txtMobile" runat="server" Text="" CssClass="form-control" ReadOnly="false" MaxLength="12" onkeypress="return isNumberKey(event)"></asp:TextBox>


                </div>
                <div class="col-md-3">
                    <label class="lableclass2">Position No. *</label>
                    <asp:TextBox ID="txtPosition" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPosition"
                        ErrorMessage="Please Enter a Position" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                </div>
                <div class="col-md-3">
                    <label class="lableclass2">Password *</label>
                    <asp:TextBox ID="txtPassword" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="Please Enter a Password" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <label class="lableclass2">Status</label>
                    <asp:DropDownList runat="server" ID="DropStatus" CssClass="form-control">
                        <asp:ListItem Value="1">Active</asp:ListItem>
                        <asp:ListItem Value="0">Inactive</asp:ListItem>
                    </asp:DropDownList>

                </div>
                <div class="col-md-12">
                    <label class="lableclass2">Address </label>
                    <asp:TextBox ID="txtAddress" runat="server" Text="" CssClass="form-control" ReadOnly="false" TextMode="MultiLine"></asp:TextBox>

                </div>

                <br />
                <div class="col-md-12 rowMargin" style="text-align: center; margin-top: 20px">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Valid1" ShowMessageBox="true" ShowSummary="false" />
                    <asp:Button runat="server" ID="btnAdd" Text="Save" CssClass="btn btn-primary" ValidationGroup="Valid1" OnClick="btnAdd_Click" />
                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>

        <div class="container">

            <!-- Modal -->
            <div class="modal fade" id="myModal" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">

                            <h4 class="modal-title">Details</h4>
                        </div>
                        <div class="modal-body">

                            <label>USER ROLE </label>
                            <asp:TextBox runat="server" ID="txtUserRole" CssClass="form-control" Placeholder="USER ROLE"></asp:TextBox>

                        </div>
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="btnSaveRole" OnClick="btnSaveRole_Click" Text="Save" CssClass="btn btn-primary" />
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>

                </div>
            </div>

        </div>

    </div>

    <div class="demo">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div id="testimonial-slider" class="owl-carousel">
                        <div class="testimonial">
                            <h3 class="title">Web Design</h3>
                            <p class="description">
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget vehicula nibh. Duis eu interdum dolor. Pellentesque mollis nisl vitae.
                            </p>
                            <div class="testimonial-content">
                                <div class="pic">
                                    <img src="images/img-1.jpg" alt="">
                                </div>
                                <div class="content">
                                    <h4 class="name">Williamson</h4>
                                    <span class="post">Web Developer</span>
                                    <ul class="rating">
                                        <li class="fa fa-star"></li>
                                        <li class="fa fa-star"></li>
                                        <li class="fa fa-star"></li>
                                        <li class="fa fa-star"></li>
                                        <li class="fa fa-star"></li>
                                    </ul>
                                </div>
                            </div>
                        </div>

                        <div class="testimonial">
                            <h3 class="title">Web Development</h3>
                            <p class="description">
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget vehicula nibh. Duis eu interdum dolor. Pellentesque mollis nisl vitae.
                            </p>
                            <div class="testimonial-content">
                                <div class="pic">
                                    <img src="images/img-2.jpg" alt="">
                                </div>
                                <div class="content">
                                    <h4 class="name">kristiana</h4>
                                    <span class="post">Web Designer</span>
                                    <ul class="rating">
                                        <li class="fa fa-star"></li>
                                        <li class="fa fa-star"></li>
                                        <li class="fa fa-star"></li>
                                        <li class="fa fa-star"></li>
                                        <li class="fa fa-star"></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
