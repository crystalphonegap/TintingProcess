<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="ShadeListByBase.aspx.cs" Inherits="ShadeCard.ShadeListByBase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <link href="Styles/Custome.css" rel="stylesheet" />

    <div class="card cardMargin">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <div class="col-md-12 card-body" style="margin-bottom: 0px!important">
            <div class="row">
                <div class="col-md-8">
                    <h4>View Shade List</h4>
                </div>

              <%--  <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="DropStatus" CssClass="form-control" OnSelectedIndexChanged="DropStatus_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="P"> In Process</asp:ListItem>
                        <asp:ListItem Value="A"> Pending With MDC</asp:ListItem>
                        <asp:ListItem Value="S"> Send Back</asp:ListItem>
                        <asp:ListItem Value="R"> Rejected</asp:ListItem>
                        <asp:ListItem Value="RV"> Pending With Approver</asp:ListItem>
                        <asp:ListItem Value="M"> Approved</asp:ListItem>
                    </asp:DropDownList>

                </div>--%>


                <div class="col-md-4">
                    <div class="input-group">

                        <asp:TextBox ID="txtShadeCode" runat="server" Text="" CssClass="form-control" ReadOnly="false" placeholder="Search"></asp:TextBox>
                        <div class="input-group-addon" style="padding: 0px;">
                            <asp:LinkButton runat="server" ID="btnSearch" CssClass="btn btn-primary" OnClick="btnSearch_Click"><i class="fa fa-search" style="color:white">  </i></asp:LinkButton>
                        </div>

                    </div>

                </div>



            </div>
            <hr />
            <div class="rowMargin">
                <asp:Label runat="server" Visible="false" ID="lblBaseId"></asp:Label>
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

                <asp:Label runat="server" ID="lblCounts" Style="padding: 4px"></asp:Label>
                <br />

            <%--    <asp:Repeater ID="rptPager" runat="server">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed" Style="padding: 3px; font-size: 20px; border-style: ridge; font-family: serif;"></asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>--%>



            </div>
        </div>
    </div>
</asp:Content>
