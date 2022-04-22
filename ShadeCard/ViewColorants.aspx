<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="ViewColorants.aspx.cs" Inherits="ShadeCard.ViewColorants" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   

      <link href="Styles/Custome.css" rel="stylesheet" />
    <div class="card cardMargin">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <div class="col-md-12 card-body" style="margin-bottom: 0px!important">
            <div class="row">


                <div class="col-md-12">
                    <div class="col-md-8">
                        <h4>View Colorants</h4>
                    </div>
                    <div class="col-md-4" style="text-align: right">
                        <div class="input-group" >
                            <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Search" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                            <div class="input-group-addon" style="padding:0px">
                                <asp:LinkButton runat="server" ID="btnSearch" CssClass="btn btn-primary"><i class="fa fa-search" style="color:white">  </i></asp:LinkButton>
                            </div>
                            <div class="input-group-addon" style="padding:0px">
                                <asp:LinkButton runat="server" ID="btnAdd" CssClass="btn btn-primary" OnClick="btnAdd_Click" ><i class="fa fa-plus" style="color:white">  </i></asp:LinkButton>
                            </div>
                        </div>


                    </div>
                    
                </div>
                <div class="col-md-12" style="padding-bottom:10px">
                    <hr />
                </div>
            </div>
            <div class="row rowMargin table-responsive">

                <asp:GridView ID="gvColorants" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                    EmptyDataText="No Records Found..!" CssClass="table" AllowPaging="true"  PageSize="15"
                    HeaderStyle-BackColor="#026099" OnRowDataBound="gvColorants_RowDataBound" HeaderStyle-ForeColor="White"
                    OnRowCommand="gvColorants_RowCommand" OnRowEditing="gvColorants_RowEditing" OnPageIndexChanging="gvColorants_PageIndexChanging">

                    <Columns>

                        <asp:TemplateField HeaderText="SR No" HeaderStyle-Width="10px">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSrNo" Text='<%#Eval("ROWNUMBER") %>'></asp:Label>
                                <asp:Label runat="server" ID="lblHexa1" Text='<%#Eval("HEXDECIMAL") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <div class="col-md-4" runat="server" id="DivColor" style="border-radius:2px">
                                       <asp:Label runat="server" ID="lblHexa" Text="" Visible="true" style="padding: 7px;border-radius: 50%;"></asp:Label>
                                </div>
                            
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SKU Code">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSKU" Text='<%#Eval("PILSKU_CODE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Colorant Name">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblName" Text='<%#Eval("COLOR_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Short Code">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblShortCode" Text='<%#Eval("SHORT_CODE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RATE" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblRate" Text='<%#Eval("RATE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WSS RATE" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblWssrate" Text='<%#Eval("WSSRATE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DEALER RATE" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDealerRate" Text='<%#Eval("DEALERRATE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="R" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblRUnit" Text='<%#Eval("R_UNIT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="G" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblGUnit" Text='<%#Eval("G_UNIT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="B" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblBUnit" Text='<%#Eval("B_UNIT") %>'></asp:Label>
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
