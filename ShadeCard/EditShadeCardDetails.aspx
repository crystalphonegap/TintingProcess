<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="EditShadeCardDetails.aspx.cs" Inherits="ShadeCard.EditShadeCardDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        .col-md-6 {
            padding: 2px;
        }
    </style>
    <link href="Styles/Custome.css" rel="stylesheet" />
    <script type="text/javascript">  

        function newBackgroundColor(color) {
            debugger
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
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

    </script>
    <style>
        .lableclass {
            padding: 4px;
            margin-top: 4px;
            margin-bottom: 4px;
            width: 70px;
        }
    </style>
    <div class="card cardMargin">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <asp:Label runat="server" ID="lblStatus" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color1" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color2" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color3" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color4" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color5" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color6" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color7" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color8" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color9" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color10" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color11" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color12" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color13" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color14" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="Color15" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="C1ltRate" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="C1ltWSSRate" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="C1ltDRate" Text="0" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="lblOldShadeCode" Text="0" Visible="false"></asp:Label>
        <asp:HiddenField runat="server" ID="HiddenR" />
        <asp:HiddenField runat="server" ID="HiddenG" />
        <asp:HiddenField runat="server" ID="HiddenB" />
        <asp:Label runat="server" ID="lblSessionId" Text="0" Visible="false"></asp:Label>


        <div class="col-md-12 card-body" style="margin-bottom: 0px!important; padding-bottom: 1px">
            <div class="row">


                <div class="col-md-11">
                    <h4>Edit Shade Card Details</h4>

                </div>



                <div class="col-md-1">
                    <asp:LinkButton runat="server" ID="LinkView" CssClass="btn btn-brand-back" Style="float: right;" OnClick="LinkView_Click"><i class="fa fa-backward"></i> Back</asp:LinkButton>
                </div>
            </div>
            <hr />
            <div class="row rowMargin">

                <div class="col-md-6">
                    <div class="col-md-3">
                        <label class="lableclass2">Documnet Date </label>
                    </div>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtDate" runat="server" Text="" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="col-md-3">
                        <label class="lableclass2">Document No. :</label>
                    </div>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtDocNumber" runat="server" Text="D0001" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="col-md-3">
                        <label class="lableclass2">Division *</label>
                    </div>
                    <div class="col-md-9">
                        <asp:DropDownList ID="DropDivision" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDivision_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None"
                            ControlToValidate="DropDivision" InitialValue="0" runat="server" ErrorMessage="Please Select Division" ValidationGroup="Valid"></asp:RequiredFieldValidator>
                    </div>

                </div>
                <div class="col-md-6">
                    <div class="col-md-3">
                        <label class="lableclass2">Sales Group *</label>
                    </div>
                    <div class="col-md-9">
                        <asp:DropDownList ID="DropSalesGroup" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropSalesGroup_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="None"
                            ControlToValidate="DropSalesGroup" InitialValue="0" runat="server" ErrorMessage="Please Select Salary Group" ValidationGroup="Valid"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-6" runat="server" visible="false">
                    <div class="col-md-3">
                        <label class="lableclass2">Material Type *</label>
                    </div>
                    <div class="col-md-9">
                        <asp:DropDownList ID="DropMaterialType" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropMaterialType_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="None"
                            ControlToValidate="DropMaterialType" InitialValue="0" runat="server" ErrorMessage="Please Select Material Type" ValidationGroup="Valid"></asp:RequiredFieldValidator>
                    </div>
                </div>


                <div class="col-md-6">
                    <div class="col-md-3">
                             <label class="lableclass2">Product(NMG) *</label>
                    </div>
                    <div class="col-md-9">
                        <asp:DropDownList ID="DropLevel3" runat="server" CssClass="form-control chzn-select" OnSelectedIndexChanged="DropLevel3_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="None"
                            ControlToValidate="DropLevel3" InitialValue="0" runat="server" ErrorMessage="Please Select NMG" ValidationGroup="Valid"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="col-md-3">
                        <label class="lableclass2">Product Code</label>
                    </div>
                    <div class="col-md-9">
                        <asp:Label ID="lblnmgCode" runat="server" Text="" CssClass="form-control" Style="background-color: #c0c0c030;"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="col-md-3">
                        <label class="lableclass2">Varient Name *</label>
                    </div>
                    <div class="col-md-9">
                        <asp:DropDownList ID="DropLevel4" runat="server" CssClass="form-control chzn-select" OnSelectedIndexChanged="DropLevel4_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="None"
                            ControlToValidate="DropLevel4" InitialValue="0" runat="server" ErrorMessage="Please Select Level4" ValidationGroup="Valid"></asp:RequiredFieldValidator>
                    </div>
                </div>


                <div class="col-md-6">
                    <div class="col-md-3">
                          <label class="lableclass2">Varient Code *</label>
                    </div>
                    <div class="col-md-9">
                        <asp:Label ID="lblLevel4Code" runat="server" Text="" CssClass="form-control" Style="background-color: #c0c0c030;"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="col-md-3">
                        <label class="lableclass2">Constant SKU Code</label>
                    </div>
                    <div class="col-md-9">
                        <div class="input-group">
                            <div class="input-group-addon">
                                <input type="color" name="color1" id="HColor1" runat="server" onchange="newBackgroundColor(this.value);" class="form-control"  />
                            </div>
                            <asp:Label ID="lblParentCode" runat="server" Text="" CssClass="form-control" Style="background-color: #c0c0c030;" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblcolorcode" Text="" Style="display: none;"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="col-md-3">
                        <label class="lableclass2">Constant SKU Description</label>
                    </div>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtParentDescription" runat="server" Text="" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6" runat="server" visible="false">
                    <div class="col-md-3">
                        <label class="lableclass2">Shade/Variant Code *</label>
                    </div>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtShadeCode" runat="server" Text="" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="col-md-3">
                        <label class="lableclass2">Sub Product Name *</label>
                    </div>
                    <div class="col-md-9">
                        <asp:DropDownList ID="DropSubProdDesc" runat="server" CssClass="form-control chzn-select" OnSelectedIndexChanged="DropSubProdDesc_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="None"
                            ControlToValidate="DropSubProdDesc" InitialValue="0" runat="server" ErrorMessage="Please Select Sub Product" ValidationGroup="Valid"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="col-md-3">
                        <label class="lableclass2">Sub Product Code</label>
                    </div>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtSubProductCode" runat="server" Text="" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="col-md-3">
                        <label class="lableclass2">Shade Name *</label>
                    </div>
                    <div class="col-md-9">
                        <asp:DropDownList ID="DropShadeName" runat="server" CssClass="form-control chzn-select" OnSelectedIndexChanged="DropShadeName_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="None"
                            ControlToValidate="DropShadeName" InitialValue="0" runat="server" ErrorMessage="Please Select Shade Name" ValidationGroup="Valid"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="col-md-3">
                        <label class="lableclass2">Shade Code *</label>
                    </div>
                    <div class="col-md-9">
                        <asp:DropDownList ID="DropShadeCode" runat="server" CssClass="form-control chzn-select" OnSelectedIndexChanged="DropShadeCode_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="None"
                            ControlToValidate="DropShadeCode" InitialValue="0" runat="server" ErrorMessage="Please Select Shade Code" ValidationGroup="Valid"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <%--<div class="col-md-6">
                    <div class="col-md-3">
                        <label class="lableclass2">Shade Name *</label>
                    </div>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtShade" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="None"
                            ControlToValidate="txtShade" runat="server" ErrorMessage="Please Enter Shade Name" ValidationGroup="Valid"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="col-md-3">
                        <label class="lableclass2">Shade Code *</label>
                    </div>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtCodeShade" runat="server" Text="" CssClass="form-control" MaxLength="6"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="None"
                            ControlToValidate="txtCodeShade" runat="server" ErrorMessage="Please Enter Shade Code" ValidationGroup="Valid"></asp:RequiredFieldValidator>
                    </div>
                </div>--%>

                <div class="col-md-12" runat="server">

                    <label class="" style="margin-bottom: 9px; margin-top: 30px; color: red">Note : Enter the Colourant value for 1 ltr Pack size in ml. </label>
                </div>
                <div class="col-md-6" runat="server" visible="false">
                    <div class="col-md-4">
                        <label class="lableclass">Rate</label>
                        <asp:TextBox ID="txtRate" runat="server" Text="0" CssClass="form-control " onkeypress="return isNumberKey(event)" ReadOnly="false"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="lableclass3">WHS Rate</label>
                        <asp:TextBox ID="TextBox3" runat="server" Text="0" CssClass="form-control " onkeypress="return isNumberKey(event)" ReadOnly="false"></asp:TextBox>

                    </div>
                    <div class="col-md-4">
                        <label class="lableclass3">Dealer Rate</label>
                        <asp:TextBox ID="TextBox4" runat="server" Text="" CssClass="form-control " onkeypress="return isNumberKey(event)" ReadOnly="false"></asp:TextBox>
                    </div>

                    <asp:DropDownList ID="DropSku" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropSku_SelectedIndexChanged" AutoPostBack="true" Visible="false">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>


                </div>

            </div>
        </div>

        <div class="row rowMargin">
            <div class="col-md-2">
                <label class="Colorentclass" style="margin-bottom: 9px;">Basic Colourant</label>

                <asp:Button ID="btnCalculate" runat="server" CssClass="btn btn-primary" Text="Calculate Colourant" OnClick="btnCalculate_Click" />
            </div>
            <div class="col-md-10">
                <asp:Repeater ID="RptColorant" runat="server" OnItemDataBound="RptColorant_ItemDataBound">
                    <HeaderTemplate>
                        <table>
                            <tr>

                                <td>
                                    <div id="td1" runat="server" class="lableclass colorstyle">
                                        <asp:Label runat="server" ID="BColor1"></asp:Label>
                                    </div>

                                </td>
                                <td>
                                    <div id="td2" runat="server" class="lableclass colorstyle">
                                        <asp:Label runat="server" ID="BColor2"></asp:Label>
                                    </div>

                                </td>
                                <td>
                                    <div id="td3" runat="server" class="lableclass colorstyle">
                                        <asp:Label runat="server" ID="BColor3"></asp:Label>
                                    </div>

                                </td>
                                <td>
                                    <div id="td4" runat="server" class="lableclass colorstyle">
                                        <asp:Label runat="server" ID="BColor4"></asp:Label>
                                    </div>

                                </td>
                                <td>
                                    <div id="td5" runat="server" class="lableclass colorstyle">
                                        <asp:Label runat="server" ID="BColor5"></asp:Label>
                                    </div>

                                </td>
                                <td>
                                    <div id="td6" runat="server" class="lableclass colorstyle">
                                        <asp:Label runat="server" ID="BColor6"></asp:Label>
                                    </div>

                                </td>
                                <td>
                                    <div id="td7" runat="server" class="lableclass colorstyle">
                                        <asp:Label runat="server" ID="BColor7"></asp:Label>
                                    </div>

                                </td>
                                <td>
                                    <div id="td8" runat="server" class="lableclass colorstyle">
                                        <asp:Label runat="server" ID="BColor8"></asp:Label>
                                    </div>

                                </td>
                                <td>
                                    <div id="td9" runat="server" class="lableclass colorstyle">
                                        <asp:Label runat="server" ID="BColor9"></asp:Label>
                                    </div>

                                </td>
                                <td>
                                    <div id="td10" runat="server" class="lableclass colorstyle">
                                        <asp:Label runat="server" ID="BColor10"></asp:Label>
                                    </div>

                                </td>
                                <td>
                                    <div id="td11" runat="server" class="lableclass colorstyle">
                                        <asp:Label runat="server" ID="BColor11"></asp:Label>
                                    </div>

                                </td>
                                <td>
                                    <div id="td12" runat="server" class="lableclass colorstyle">
                                        <asp:Label runat="server" ID="BColor12"></asp:Label>
                                    </div>

                                </td>
                                <td>
                                    <div id="td13" runat="server" class="lableclass colorstyle">
                                        <asp:Label runat="server" ID="BColor13"></asp:Label>
                                    </div>

                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>

                            <td>
                                <asp:TextBox ID="txtColor1" runat="server" Text='<%# Eval("COLORANT1") %>' CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtColor2" runat="server" Text='<%# Eval("COLORANT2") %>' CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtColor3" runat="server" Text='<%# Eval("COLORANT3") %>' CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtColor4" runat="server" Text='<%# Eval("COLORANT4") %>' CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtColor5" runat="server" Text='<%# Eval("COLORANT5") %>' CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtColor6" runat="server" Text='<%# Eval("COLORANT6") %>' CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtColor7" runat="server" Text='<%# Eval("COLORANT7") %>' CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtColor8" runat="server" Text='<%# Eval("COLORANT8") %>' CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtColor9" runat="server" Text='<%# Eval("COLORANT9") %>' CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtColor10" runat="server" Text='<%# Eval("COLORANT10") %>' CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtColor11" runat="server" Text='<%# Eval("COLORANT11") %>' CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtColor12" runat="server" Text='<%# Eval("COLORANT12") %>' CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtColor13" runat="server" Text='<%# Eval("COLORANT13") %>' CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>

                        </tr>



                    </ItemTemplate>
                    <FooterTemplate>
                        </table>  
                   
                    </FooterTemplate>
                </asp:Repeater>
            </div>


        </div>
        <div class="row rowMargin table-scroll" id="table-scroll">


            <asp:Repeater ID="RepSKU" runat="server" OnItemDataBound="RepSKU_ItemDataBound">
                <HeaderTemplate>

                    <table class="table table-responsive main-table" style="width: 100%;">
                        <tr>
                            <th class="fixed-side" scope="col">Sr No
                            </th>
                            <th class="fixed-side" scope="col">Shade Card Code
                            </th>
                            <th class="fixed-side" scope="col">SKU Code
                            </th>
                            <th class="fixed-side" scope="col">Item Name
                            </th>
                            <th class="fixed-side" scope="col">Pack Size
                            </th>

                            <td scope="col">

                                <asp:Label runat="server" ID="Label1" class="lableclass colorstyle"></asp:Label>
                                <asp:Label runat="server" ID="Rate1" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="WRate1" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="DRate1" class="" Visible="false"></asp:Label>

                            </td>
                            <td scope="col">

                                <asp:Label runat="server" ID="Label2" class="lableclass colorstyle"></asp:Label>
                                <asp:Label runat="server" ID="Rate2" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="WRate2" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="DRate2" class="" Visible="false"></asp:Label>
                            </td>
                            <td scope="col">

                                <asp:Label runat="server" ID="Label3" class="lableclass colorstyle"></asp:Label>
                                <asp:Label runat="server" ID="Rate3" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="WRate3" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="DRate3" class="" Visible="false"></asp:Label>
                            </td>
                            <td scope="col">

                                <asp:Label runat="server" ID="Label4" class="lableclass colorstyle"></asp:Label>
                                <asp:Label runat="server" ID="Rate4" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="WRate4" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="DRate4" class="" Visible="false"></asp:Label>
                            </td>
                            <td scope="col">
                                <asp:Label runat="server" ID="Label5" class="lableclass colorstyle"></asp:Label>
                                <asp:Label runat="server" ID="Rate5" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="WRate5" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="DRate5" class="" Visible="false"></asp:Label>
                            </td>
                            <td scope="col">

                                <asp:Label runat="server" ID="Label6" class="lableclass colorstyle"></asp:Label>
                                <asp:Label runat="server" ID="Rate6" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="WRate6" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="DRate6" class="" Visible="false"></asp:Label>
                            </td>
                            <td scope="col">

                                <asp:Label runat="server" ID="Label7" class="lableclass colorstyle"></asp:Label>
                                <asp:Label runat="server" ID="Rate7" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="WRate7" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="DRate7" class="" Visible="false"></asp:Label>
                            </td>
                            <td scope="col">

                                <asp:Label runat="server" ID="Label8" class="lableclass colorstyle"></asp:Label>
                                <asp:Label runat="server" ID="Rate8" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="WRate8" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="DRate8" class="" Visible="false"></asp:Label>
                            </td>
                            <td scope="col">

                                <asp:Label runat="server" ID="Label9" class="lableclass colorstyle"></asp:Label>
                                <asp:Label runat="server" ID="Rate9" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="WRate9" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="DRate9" class="" Visible="false"></asp:Label>
                            </td>
                            <td scope="col">

                                <asp:Label runat="server" ID="Label10" class="lableclass colorstyle"></asp:Label>
                                <asp:Label runat="server" ID="Rate10" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="WRate10" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="DRate10" class="" Visible="false"></asp:Label>
                            </td>
                            <td scope="col">

                                <asp:Label runat="server" ID="Label11" class="lableclass colorstyle"></asp:Label>
                                <asp:Label runat="server" ID="Rate11" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="WRate11" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="DRate11" class="" Visible="false"></asp:Label>

                            </td>
                            <td scope="col">

                                <asp:Label runat="server" ID="Label12" class="lableclass colorstyle"></asp:Label>
                                <asp:Label runat="server" ID="Rate12" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="WRate12" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="DRate12" class="" Visible="false"></asp:Label>

                            </td>
                            <td scope="col">

                                <asp:Label runat="server" ID="Label13" class="lableclass colorstyle"></asp:Label>
                                <asp:Label runat="server" ID="Rate13" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="WRate13" class="" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="DRate13" class="" Visible="false"></asp:Label>
                            </td>

                            <td scope="col">Rate
                            </td>
                            <td scope="col">WSS Rate
                            </td>
                            <td scope="col">Dealer Rate
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tblrowcolor ">
                        <td class="fixed-side">
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Row")%>'></asp:Label>
                        </td>
                        <td class="fixed-side">
                            <asp:TextBox ID="txtRnewSKu" runat="server" CssClass="form-control" Width="150px" Text='<%#Eval("MAXSHADE")%>' ReadOnly="true"></asp:TextBox>
                        </td>
                        <td class="fixed-side">
                            <asp:Label ID="lbrpSku" runat="server" Text='<%#Eval("VcMaterialCode")%>'></asp:Label>
                        </td>
                        <td class="fixed-side">

                            <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("VcMaterialDesc")%>'></asp:Label>
                        </td>
                        <td class="fixed-side">
                            <asp:TextBox ID="txtPackSize" runat="server" Text='<%#Eval("UOM")%>' CssClass="form-control" OnTextChanged="txtPackSize_TextChanged" AutoPostBack="true" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRColor1" runat="server" Text="0" CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRColor2" runat="server" Text="0" CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRColor3" runat="server" Text="0" CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRColor4" runat="server" Text="0" CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>

                        <td>
                            <asp:TextBox ID="txtRColor5" runat="server" Text="0" CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRColor6" runat="server" Text="0" CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRColor7" runat="server" Text="0" CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRColor8" runat="server" Text="0" CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRColor9" runat="server" Text="0" CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRColor10" runat="server" Text="0" CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRColor11" runat="server" Text="0" CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRColor12" runat="server" Text="0" CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRColor13" runat="server" Text="0" CssClass="form-control textboxclass" onkeypress="return isNumberKey(event)" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>

                        <td>
                            <asp:TextBox ID="txtRate1" runat="server" CssClass="form-control" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtWRate" runat="server" CssClass="form-control" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDRate" runat="server" CssClass="form-control" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>  
                   
                </FooterTemplate>
            </asp:Repeater>


        </div>


        <div class="row rowMargin">
            <div class="col-md-12">
                <label>Remarks</label>
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="col-md-12">

                <asp:CheckBox runat="server" ID="chkChecck" Text="" Font-Size="13px" />
                <label style="color: red;">I have Checked all the Above details and find ok.</label>

            </div>
            <div class="col-md-12">
                <asp:Button ID="btnDraft" runat="server" CssClass="btn btn-primary" Text="Save As Draft" ValidationGroup="Valid" OnClick="btnDraft_Click" />
                <asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Valid" />
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="Valid" />
                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="btnCancel_Click" />
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

                        <p>SKU Code : Red</p>
                        <p>level4 : Comming Soon</p>
                        <p>Level5 : Comming Soon</p>
                        <p>Rate : 1500</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>

    </div>
    <div class="col-md-12">
        <asp:Repeater ID="RptColorantDetails" runat="server" OnItemDataBound="RptColorantDetails_ItemDataBound">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col-md-4" style="border-style: groove;">
                    <asp:Label runat="server" ID="lblHexa1" Text='<%# Eval("HEXDECIMAL") %>' Visible="false"></asp:Label>
                    <div class="col-md-1" runat="server">
                        <asp:Label runat="server" ID="lblHexa" Text="CL"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label runat="server" ID="Label16" Text='<%# Eval("SHORT_CODE") %>'></asp:Label>
                    </div>
                    <div class="col-md-8">
                        <asp:Label runat="server" ID="Label17" Text='<%# Eval("COLOR_NAME") %>'></asp:Label>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <script>
        // requires jquery library
        jQuery(document).ready(function () {
            jQuery(".main-table").clone(true).appendTo('#table-scroll').addClass('clone');
        });

    </script>
</asp:Content>
