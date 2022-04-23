<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="ViewEmployees.aspx.cs" Inherits="ShadeCard.ViewEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        .row-box {
    background: #fff;
    padding: 15px;
    border-radius: 8px;
    box-shadow: 3px 5px 7px #cccccc3d;
}
    </style>

      <link href="Styles/Custome.css" rel="stylesheet" />
    <div class="card cardMargin">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <div class="col-md-12 card-body" style="margin-bottom: 0px!important">
            <div class="row">


                <div class="col-md-12">
                    <div class="col-md-8">
                        <h4>View Employees</h4>
                    </div>
                    <div class="col-md-4" style="text-align: right">
                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Search" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                            <div class="input-group-addon" style="padding: 0px">
                                <asp:LinkButton runat="server" ID="btnSearch" CssClass="btn btn-primary"><i class="fa fa-search" style="color:white">  </i></asp:LinkButton>
                            </div>
                            <div class="input-group-addon" style="padding: 0px">
                                <asp:LinkButton runat="server" ID="btnAdd" CssClass="btn btn-primary" OnClick="btnAdd_Click"><i class="fa fa-plus" style="color:white">  </i></asp:LinkButton>
                            </div>
                        </div>


                    </div>

                </div>
                <div class="col-md-12" style="padding-bottom: 10px">
                    <hr />
                </div>
            </div>
            <div class="row row-box rowMargin table-responsive">

                <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                    EmptyDataText="No Records Found..!" CssClass="table" AllowPaging="true"  PageSize="15"
                    HeaderStyle-BackColor="#026099" OnRowDataBound="gvEmployees_RowDataBound" HeaderStyle-ForeColor="White"
                    OnRowCommand="gvEmployees_RowCommand" OnRowEditing="gvEmployees_RowEditing" OnPageIndexChanging="gvEmployees_PageIndexChanging">
                    <Columns>

                        <asp:TemplateField HeaderText="SR No" HeaderStyle-Width="10px">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%#Eval("ROWNUMBER") %>'></asp:Label>
                                <asp:Label runat="server" ID="lblHexa1" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Code">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCode" Text='<%#Eval("EMPLOYEE_CODE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Name">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblName" Text='<%#Eval("EMPLOYEE_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblType" Text='<%#Eval("EMPLOYEE_TYPE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEmail" Text='<%#Eval("EMAIL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblMobile" Text='<%#Eval("MOBILE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Position" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPosition" Text='<%#Eval("POSITION_NO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Password" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPass" Text='<%#Eval("PASSWORD") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10px">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("Id") %>'><i class=" fa fa-edit"></i> </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="View" CommandArgument='<%#Eval("Id") %>'><i class=" fa fa-eye"></i> </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>

             
            </div>
        </div>



    </div>
</asp:Content>
