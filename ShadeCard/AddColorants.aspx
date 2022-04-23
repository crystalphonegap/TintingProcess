<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="AddColorants.aspx.cs" Inherits="ShadeCard.AddColorants" %>

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

        .row-box {
    background: #fff;
    padding: 15px;
    border-radius: 8px;
    box-shadow: 3px 5px 7px #cccccc3d;
}
    </style>
    <link href="Styles/CustomeDashboard.css" rel="stylesheet" />
    <script type="text/javascript">  

        function newBackgroundColor(color) {
            debugger;
            var a = document.getElementById('<%=lblcolorcode.ClientID %>');
            a.value = color;
            document.getElementById('<%=lblcolorcode.ClientID %>').innerHTML = a.value;

            let rgbV = hexTorgb(a.value);

            document.getElementById("<%= HiddenR.ClientID %>").value = rgbV[0];
            document.getElementById("<%= HiddenG.ClientID %>").value = rgbV[1];
            document.getElementById("<%= HiddenB.ClientID %>").value = rgbV[2];
        }
        function hexTorgb(hex) {
            return ['0x' + hex[1] + hex[2] | 0, '0x' + hex[3] + hex[4] | 0, '0x' + hex[5] + hex[6] | 0];
        }

    </script>
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

                
                    <div class="col-md-10">
                        <h4>Add Colorants</h4>
                    </div>
                    <div class="col-md-2" style="text-align: right;">
                        <a href="ViewColorants.aspx" class="btn btn-primary"><i class="fa fa-eye" style="color: white"></i></a>
                    </div>


                
                <div class="col-md-12" style="padding-bottom: 10px">
                    <hr />
                </div>
            </div>
            <div class="row row-box rowMargin">

                <div class="col-md-4">
                    <label class="lableclass2">SKU Code *</label>
                    <asp:TextBox ID="txtSKU" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="R1" runat="server" ControlToValidate="txtSKU"
                        ErrorMessage="Please Enter a SKU Code" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <label class="lableclass2">Color Name *</label>

                    <div class="input-group">
                        <div class="input-group-addon">

                            <input type="color" name="color1" id="color1" runat="server" onchange="newBackgroundColor(this.value);" class="form-control" style="width: 78px; height: 20px; padding: 0px;" />
                        </div>
                        <asp:TextBox ID="txtColorName" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtColorName"
                            ErrorMessage="Please Enter a Color Name" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>
                        <asp:Label runat="server" ID="lblcolorcode" Text="" Style="display: none;"></asp:Label>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="lableclass2">Short Code *</label>
                    <asp:TextBox ID="txtShortCode" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtShortCode"
                        ErrorMessage="Please Enter a Short Code" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                </div>
                <div class="col-md-3">
                    <label class="lableclass2">Start Date *</label>

                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control Nedate" ReadOnly="false" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFromDate"
                        ErrorMessage="Please Enter a Start Rate" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                </div>
                <div class="col-md-3">
                    <label class="lableclass2">End Date *</label>

                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control Nedate" ReadOnly="false" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtToDate"
                        ErrorMessage="Please Enter a End Date" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                </div>
                <div class="col-md-2">
                    <label class="lableclass2">Rate *</label>
                    <asp:TextBox ID="txtRate" runat="server" Text="0" CssClass="form-control " ReadOnly="false" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRate"
                        ErrorMessage="Please Enter a Rate" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                </div>
                <div class="col-md-2">
                    <label class="lableclass2">WSS Rate *</label>
                    <asp:TextBox ID="txtWssRate" runat="server" Text="0" CssClass="form-control" ReadOnly="false" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtWssRate"
                        ErrorMessage="Please Enter a WSS Rate" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                </div>
                <div class="col-md-2">
                    <label class="lableclass2">Dealer Rate *</label>
                    <asp:TextBox ID="txtDealerRate" runat="server" Text="0" CssClass="form-control" ReadOnly="false" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDealerRate"
                        ErrorMessage="Please Enter a Dealer Rate" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-12">
                    <label class="lableclass2">Remarks</label>
                    <asp:TextBox ID="txtRemarks" runat="server" Text="" CssClass="form-control" TextMode="MultiLine" ReadOnly="false"></asp:TextBox>
                </div>
                <br />
                <div class="col-md-12 rowMargin" style="text-align: left; margin-top: 20px">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Valid1" ShowMessageBox="true" ShowSummary="false" />
                    <asp:Button runat="server" ID="btnAdd" Text="Save" CssClass="btn btn-primary" ValidationGroup="Valid1" OnClick="btnAdd_Click" />
                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                </div>

            </div>
        </div>

    </div>

    <script type="text/javascript">
        $(function () {
            $('.Nedate').datepicker({
                format: "dd/mm/yyyy"
            });
        });
    </script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>

</asp:Content>
