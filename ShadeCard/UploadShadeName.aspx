<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="UploadShadeName.aspx.cs" Inherits="ShadeCard.UploadShadeName" %>

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


                <div class="col-md-9">
                    <h4>Upload Shade Name/Code</h4>
                </div>

                <div class="col-md-3">

                    <div>
                        <asp:LinkButton runat="server" ID="btnSampleFile" OnClick="btnSampleFile_Click">
                            <asp:Label runat="server" ID="lblfileName" Text=""></asp:Label>
                            <i class="fa fa-download" style="font-size: 20px;">Download Sample File</i>
                        </asp:LinkButton>

                       <%-- <a href="ViewColorants.aspx" class="btn btn-primary"><i class="fa fa-eye" style="color: white"></i></a>--%>
                    </div>
                </div>



                <div class="col-md-12" style="padding-bottom: 10px">
                    <hr />
                </div>


            </div>
            <div class="row rowMargin row-box">
                <label>Upload file</label>
                <div class="col-md-8">



                    <asp:FileUpload runat="server" ID="fileupload" CssClass=" form-control" />



                </div>
                <div class="col-md-2">
                    <asp:Button runat="server" ID="btnUpload" CssClass="btn btn-primary" Text="Upload" OnClick="btnUpload_Click" />
                </div>





                <br />
                <br />


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
