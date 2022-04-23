<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ShadeCard.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <style>
        .ApproverClass {
            background: linear-gradient(45deg, #99d081, #0da313);
        }

        .MDC {
            background: linear-gradient(45deg, #07d2de, #0090c6);
        }
    </style>

    <link href="Styles/style.bundle.css" rel="stylesheet" />
    <link href="Styles/CustomeDashboard.css" rel="stylesheet" />
    <div class="card cardMargin">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <div class="col-md-12 card-body" style="margin-bottom: 0px!important">
            <div class="row">
                <div class="col-md-12">
                    <h4>Dashboard</h4>
                    <hr />
                </div>
            </div>

            <div class="" runat="server" id="DivAdmin">
                <div class="row" style="margin-top: 20px;">
                    <div class="col-xl-3 col-md-6 col-12">
                        <asp:LinkButton ID="btnAccepted1" runat="server" OnClick="btnAccepted1_Click">
                            <div class="bg-b-green info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-check"></i>
                                </span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Approved</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblAccepted" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>

                    <div class="col-xl-3 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="btnSendBack1" OnClick="btnSendBack1_Click">
                            <div class="bg-b-yellow info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-backward"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Send Back</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblSendBack" Text="0"></asp:Label></span>

                                </div>
                            </div>

                        </asp:LinkButton>
                    </div>
                    <div class="col-xl-3 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="btnReject1" OnClick="btnReject1_Click">
                            <div class="bg-b-pink info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-ban"></i>
                                </span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Rejected </span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblRejected" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>

                    <div class="col-xl-3 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="btnPendingReviwer" OnClick="btnPendingReviwer_Click">
                            <div class="bg-b-pengding info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-hourglass-half"></i>
                                </span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Pending</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblPending" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>
                    <div class="col-xl-4 col-md-6 col-12" runat="server" visible="false">
                        <asp:LinkButton runat="server" ID="btnPendingApprover" OnClick="btnPendingApprover_Click">
                            <div class="ApproverClass info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-hourglass-half"></i>
                                </span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Pending</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblPendingWithApprover" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>
                    <div class="col-xl-4 col-md-6 col-12" runat="server" visible="false">
                        <asp:LinkButton runat="server" ID="btnPedningithMDD" OnClick="btnPedningithMDD_Click">
                            <div class="MDC info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-hourglass-half"></i>
                                </span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Pending</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblPendingWithMDC" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>




                </div>

            </div>

            <div class="" runat="server" id="DivMaker">
                <div class="row" style="margin-top: 20px;">
                    <div class="col-xl-3 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="btnMApprove" OnClick="btnMApprove_Click">
                            <div class="bg-b-green info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-check"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Approved</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblMApprove" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>

                    <div class="col-xl-3 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="btnMsendBack" OnClick="btnMsendBack_Click">
                            <div class="bg-b-yellow info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-backward"></i>
                                </span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Send Back</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblMSendBAck" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>

                    <div class="col-xl-3 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="btnDraftLink" OnClick="btnDraftLink_Click">
                            <div class="bg-b-draft info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-box-open"></i>
                                </span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Draft</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblDraft" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>

                    <div class="col-xl-3 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="btnMakerRejected" OnClick="btnMakerRejected_Click">
                            <div class="bg-b-pink info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-ban"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Rejected </span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblMRejected" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>


                </div>

            </div>

            <div class="" runat="server" id="DivChecker">
                <div class="row" style="margin-top: 20px;">
                    <div class="col-xl-3 col-md-6 col-12" runat="server" visible="false">
                        <div class="bg-b-green info-box">
                            <span class="info-box-icon push-bottom">
                                <i class="fa fa-comment"></i>
                            </span>

                            <div class="info-box-content">
                                <span class="info-box-text">Review</span>
                                <span class="info-box-number">
                                    <asp:Label runat="server" ID="lblReview" Text="0"></asp:Label></span>

                            </div>
                        </div>

                    </div>
                    <div class="col-xl-4 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="btn1" OnClick="btnPendingReviwer_Click2">
                            <div class="bg-b-pengding info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-hourglass-start"></i>
                                </span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Pending</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblRPending" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>
                    <div class="col-xl-4 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="btn2" OnClick="btnSendBack1_Click">
                            <div class="bg-b-yellow info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-backward"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Send Back</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblRSendBack" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>



                    <div class="col-xl-4 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="btn3" OnClick="btnReject1_Click">
                            <div class="bg-b-pink info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-ban"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Rejected </span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblRReject" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>


                </div>

            </div>

            <div class="" runat="server" id="DivApprover">

                <div class="row" style="margin-top: 20px;">
                    <div class="col-xl-4 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="btnA1" OnClick="btnPendingApprover_Click">
                            <div class="bg-b-pengding info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-hourglass-half"></i>
                                </span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Pending</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblAReview" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>

                    <div class="col-xl-4 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="LinkButton1" OnClick="btnSendBack1_Click">
                            <div class="bg-b-yellow info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-backward"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Send Back</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblASendBack" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>

                    <div class="col-xl-4 col-md-6 col-12" runat="server" visible="false">
                        <div class="bg-b-blue info-box">
                            <span class="info-box-icon push-bottom">
                                <i class="fa fa-hourglass-start"></i>
                            </span>

                            <div class="info-box-content">
                                <span class="info-box-text">Pending</span>
                                <span class="info-box-number">
                                    <asp:Label runat="server" ID="lblAPending" Text="0"></asp:Label></span>

                            </div>
                        </div>

                    </div>

                    <div class="col-xl-4 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="LinkButton2" OnClick="btnReject1_Click">
                            <div class="bg-b-pink info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-ban"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Rejected </span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblARejected" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>


                </div>

            </div>

            <div class="" runat="server" id="DivMDC">
                <div class="row" style="margin-top: 20px;">
                     <div class="col-xl-3 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="btnMdc" OnClick="btnMdc_Click">
                            <div class="bg-b-pengding info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-hourglass-half"></i>
                                </span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Pending</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblMDPending" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>
                    <div class="col-xl-3 col-md-6 col-12">
                        <asp:LinkButton ID="btnMDCApprove" runat="server" OnClick="btnMDCApprove_Click">
                            <div class="bg-b-green info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-check"></i>
                                </span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Approved</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblMDApprove" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>

                    <div class="col-xl-3 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="LinkButton4" OnClick="btnSendBack1_Click">
                            <div class="bg-b-yellow info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-backward"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Send Back</span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblMDSendBack" Text="0"></asp:Label></span>

                                </div>
                            </div>

                        </asp:LinkButton>
                    </div>
                    <div class="col-xl-3 col-md-6 col-12">
                        <asp:LinkButton runat="server" ID="LinkButton5" OnClick="btnReject1_Click">
                            <div class="bg-b-pink info-box">
                                <span class="info-box-icon push-bottom">
                                    <i class="fa fa-ban"></i>
                                </span>

                                <div class="info-box-content">
                                    <span class="info-box-text">Rejected </span>
                                    <span class="info-box-number">
                                        <asp:Label runat="server" ID="lblMDReject" Text="0"></asp:Label></span>

                                </div>
                            </div>
                        </asp:LinkButton>

                    </div>

                    
                   




                </div>

            </div>


            <asp:Repeater ID="RptNMG" runat="server" OnItemCommand="RptNMG_ItemCommand">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>

                    <div class="col-xl-3 col-md-6 col-12" style="padding-left: 0px;">
                        <asp:LinkButton runat="server" ID="linkButton" CommandArgument='<%# Eval("CODE") %>' CommandName="View">
                            <div class=" bg-success info-box" style="text-align: center">

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

</asp:Content>
