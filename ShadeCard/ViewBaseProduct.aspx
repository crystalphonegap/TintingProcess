<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="ViewBaseProduct.aspx.cs" Inherits="ShadeCard.ViewBaseProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <%-- <link href="Styles/CustomeViewProduct.css" rel="stylesheet" />--%>
    <link href="Styles/style.bundle.css" rel="stylesheet" />
    <style>
        .btn-sm, .btn-group-sm > .btn {
            padding: 3px 12px;
        }
    </style>
    <div class="card cardMargin">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <div class="col-md-12 card-body" style="margin-bottom: 0px!important">
            <div class="row">
                <div class="col-md-10">
                    <h4>View Base Product</h4>
                </div>
                <div class="col-md-2" style="float: right">
                    <asp:LinkButton runat="server" ID="LinkView" CssClass="btn btn-sm btn-brand-back" Style="float: right;" OnClick="LinkView_Click"><i class="fa fa-backward"></i> Back</asp:LinkButton>
                </div>
            </div>
            <hr />

            <div class="row rowMargin">
                <asp:Label runat="server" ID="lblNMGCode" Text="" Visible="false"></asp:Label>
                <asp:Repeater ID="RptBase" runat="server" OnItemCommand="RptBase_ItemCommand">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>

                        <div class="col-xl-4">
                            <asp:LinkButton runat="server" ID="linkButton" CommandArgument='<%# Eval("CODE") %>' CommandName="View">
                                <div class="bg-b-green info-box">
                                    <span class="info-box-text">
                                        <asp:Label runat="server" ID="lblNMG" Text='<%#Eval("NAME") %>'></asp:Label></span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblCount" Text='<%#Eval("TOTAL") %>'></asp:Label></span>
                                </div>
                            </asp:LinkButton>
                        </div>

                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>



    </div>


</asp:Content>
