<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="ApproveShadeList.aspx.cs" Inherits="ShadeCard.ApproveShadeList" %>

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
            background-color: #547ab8;
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
            font-size: 16px;
        }
    </style>

    <asp:ScriptManager ID="scriptmanager" runat="server"></asp:ScriptManager>

    <div class="card cardMargin">

        <div class="col-md-12 card-body" style="margin-bottom: 0px!important">
            <div class="row">
                <div class="col-md-9">
                    <h4>View Shade List</h4>
                </div>
                <div class="col-md-3">
                    <asp:LinkButton runat="server" ID="LinkView" CssClass="btn btn-brand-back" Style="float: right;" OnClick="LinkView_Click"><i class="fa fa-file-excel"></i> Export</asp:LinkButton>
                </div>

            </div>
            <hr />

            <div class="row rowMargin">
                <div class="col-md-12" style="margin-top: 20px">
                    <asp:RadioButtonList runat="server" ID="Radiolist" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0" Selected="True"> All</asp:ListItem>
                        <asp:ListItem Value="1"> Pending</asp:ListItem>
                        <asp:ListItem Value="2"> Send Back</asp:ListItem>
                        <asp:ListItem Value="3"> Approve</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="table-responsive" style="margin-top: 20px">
                    <asp:GridView ID="gvShadeCard" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover table-checkable mb-0" AllowPaging="true" PageSize="10" HeaderStyle-BackColor="#45a9ff">
                        <Columns>
                            <asp:BoundField DataField="SR" HeaderText="SR" />

                            <asp:BoundField DataField="DOCNo" HeaderText="DOC No" />
                            <asp:BoundField DataField="DocDate" HeaderText="Doc Date" />
                            <asp:BoundField DataField="ShadeName" HeaderText="Shade Name" />
                            <asp:BoundField DataField="ShadeCode" HeaderText="Shade Code" />
                            <asp:BoundField DataField="NMG" HeaderText="NMG (Level3)" />
                            <asp:BoundField DataField="Level4" HeaderText="(Level4)" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                        </Columns>
                    </asp:GridView>
                </div>


            </div>

        </div>
    </div>

    <!-- Modal2 -->
    <div class="modal fade" id="myModal2" role="dialog">
        <div class="modal-dialog modal-lg" style="max-width: 1500px !important">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-10">
                        <h4 class="modal-title">Details</h4>
                    </div>
                    <div class="col-md-2" style="text-align: right">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>

                </div>
                <div class="modal-body">
                    <img src="Img/ShadeImage.png" style="max-width: 1456px" />
                    <asp:Button runat="server" ID="btnApprove" Text="Approve" CssClass="btn btn-primary" />
                    <asp:Button runat="server" ID="Button1" Text="Reject" CssClass="btn btn-danger" /> 
         
                </div>
                <div class="modal-footer">

                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>


            </div>

        </div>
    </div>
    <script>
        function myFunction() {
            /*document.getElementById("myModal2").showModal();*/
            $('#myModal').modal('show');
            console.log("Hello");
        }

    </script>
</asp:Content>
