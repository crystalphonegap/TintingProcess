<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="ViewApprovedShadeList.aspx.cs" Inherits="ShadeCard.ViewApprovedShadeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <link href="Styles/Custome.css" rel="stylesheet" />

    <div class="card cardMargin">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <div class="col-md-12 card-body" style="margin-bottom: 0px!important">
            <div class="row">
                <div class="col-md-3">
                    <h4>View Shade List</h4>
                </div>

                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="DropStatus" CssClass="form-control" OnSelectedIndexChanged="DropStatus_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="M"> Approved</asp:ListItem>
                        <asp:ListItem Value="S"> Send Back</asp:ListItem>
                        <asp:ListItem Value="R"> Rejected</asp:ListItem>
                        <asp:ListItem Value="RV"> Pending </asp:ListItem>
                        <asp:ListItem Value="All"> All</asp:ListItem>
                    </asp:DropDownList>

                </div>
                <div class="col-md-2">


                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control Nedate" ReadOnly="false" onkeypress="return isNumberKey(event)" placeholder="From Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFromDate"
                        ErrorMessage="Please Enter a Start Rate" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                </div>
                <div class="col-md-2">


                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control Nedate" ReadOnly="false" onkeypress="return isNumberKey(event)" placeholder="To Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtToDate"
                        ErrorMessage="Please Enter a End Date" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                </div>


                <div class="col-md-3">
                    <div class="input-group">

                        <asp:TextBox ID="txtShadeCode" runat="server" Text="" CssClass="form-control" ReadOnly="false" placeholder="Search"></asp:TextBox>
                        <div class="input-group-addon" style="padding: 0px;">
                            <asp:LinkButton runat="server" ID="btnSearch" CssClass="btn btn-primary" OnClick="btnSearch_Click"><i class="fa fa-search" style="color:white">  </i></asp:LinkButton>
                        </div>
                        <div class="input-group-addon" style="padding: 0px;">
                            <asp:LinkButton runat="server" ID="btnExport" CssClass="btn btn-primary" OnClick="btnExport_Click"><i class="fa fa-file-excel" style="color:white">  </i></asp:LinkButton>
                        </div>

                    </div>

                </div>



            </div>
            <hr />
            <div class="rowMargin">

                <div class="table-responsive">
                    <asp:GridView ID="gvShadeCard" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover table-checkable mb-0"
                        AllowPaging="true" PageSize="15" HeaderStyle-BackColor="#026099" HeaderStyle-ForeColor="White" OnRowEditing="gvShadeCard_RowEditing"
                        OnRowCommand="gvShadeCard_RowCommand" OnPageIndexChanging="gvShadeCard_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="SR">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblSRNo" Text=' <%# Container.DataItemIndex+1 %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DOCUMENT_NUMBER" HeaderText="DOC NO" />
                            <asp:BoundField DataField="SHADE_NAME" HeaderText="Shade Name" />
                            <asp:BoundField DataField="PARENT_CODE" HeaderText="Constant SKU CODE" />
                            <asp:BoundField DataField="SHADE_CODE" HeaderText="SHADE CODE" />

                            <asp:BoundField DataField="NMG" HeaderText="NMG (Level3)" />
                            <asp:BoundField DataField="LEVEL4" HeaderText="(Level4)" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblStatus" Text='<%# Eval("DOCSTATUS") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="linkview" CommandName="View" CommandArgument='<%# Eval("Id") %>' Text=""><i class="fa fa-eye"></i> </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>


            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            $('.Nedate').datepicker({
                format: "yyyy-mm-dd"
            });
        });
    </script>
</asp:Content>
