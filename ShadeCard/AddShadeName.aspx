<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="AddShadeName.aspx.cs" Inherits="ShadeCard.AddShadeName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        label {
            display: inline-block;
            max-width: 100%;
            margin-bottom: 5px;
            font-weight: 700;
            padding-left: 0px;
            padding-top: 4px;
            font-weight: normal;
            font-weight: normal;
        }
    </style>
    <link href="Styles/CustomeDashboard.css" rel="stylesheet" />
    <link href="AutoComplete/chosen.css" rel="stylesheet" />
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
                <asp:HiddenField runat="server" ID="HiddenR" />
                <asp:HiddenField runat="server" ID="HiddenG" />
                <asp:HiddenField runat="server" ID="HiddenB" />

                <div class="col-md-12">
                    <div class="col-md-10">
                        <h4>Add Shade Name/Code</h4>
                    </div>
                    <div class="col-md-2" style="text-align: right;">
                        <a href="ViewColorants.aspx" class="btn btn-primary"><i class="fa fa-eye" style="color: white"></i></a>
                    </div>
                </div>
                <div class="col-md-12" style="padding-bottom: 10px">
                    <hr />
                </div>
            </div>
            <div class="row rowMargin">



                <div class="col-md-6">
                    <label class="lableclass2">Sub Product Name *</label>
                    <asp:DropDownList ID="DropSubProdDesc" runat="server" CssClass="form-control chzn-select" AutoPostBack="true" OnSelectedIndexChanged="DropSubProdDesc_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="None"
                        ControlToValidate="DropSubProdDesc" InitialValue="0" runat="server" ErrorMessage="Please Select Sub Product Name" ValidationGroup="Valid"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label class="lableclass2">Sub Product Code *</label>
                    <asp:TextBox ID="txtSubProductCode" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSubProductCode"
                        ErrorMessage="Please Enter a  Sub Product  Code" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                </div>
                <div class="col-md-6">
                    <label class="lableclass2">Shade Name *</label>
                    <asp:TextBox ID="txtShade" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtShade"
                        ErrorMessage="Please Enter a Shade Code" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                </div>
                <div class="col-md-6">
                    <label class="lableclass2">Shade Code *</label>
                    <asp:TextBox ID="txtShadeCode" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtShadeCode"
                        ErrorMessage="Please Enter a Shade Code" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                </div>

                <br />
                <div class="col-md-12 rowMargin" style="text-align: center; margin-top: 20px">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Valid1" ShowMessageBox="true" ShowSummary="false" />
                    <asp:Button runat="server" ID="btnAdd" Text="Save" CssClass="btn btn-primary" ValidationGroup="Valid1" OnClick="btnAdd_Click" />
                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                </div>

            </div>


        </div>

    </div>


    <script src="https://code.jquery.com/jquery-1.11.3.min.js"></script>
    <script src="AutoComplete/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(".chzn-select").chosen();
        $(".chzn-select-deselect").chosen({
            allow_single_deselect: true
        });
        $('.selector').hide();
    </script>

</asp:Content>
