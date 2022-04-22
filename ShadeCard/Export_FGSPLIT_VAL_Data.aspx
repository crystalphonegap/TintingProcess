<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Export_FGSPLIT_VAL_Data.aspx.cs" Inherits="ShadeCard.Export_FGSPLIT_VAL_Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       <link href="Styles/Custome.css" rel="stylesheet" />
    <div class="card cardMargin">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <div class="col-md-12 card-body" style="margin-bottom: 0px!important">

            <div class="col-md-12">
                <div class="col-md-10">
                    <h4> FG Split Val Template</h4>
                </div>

                <div class="col-md-2" style="text-align: right">
                    <asp:LinkButton runat="server" ID="btnExport" CssClass="btn btn-primary" OnClick="btnExport_Click"><i class="fa fa-download" style="color:white;font-size: 18px;"> Export To Excel  </i></asp:LinkButton>
                </div>

                <div class="col-md-12" style="padding-bottom: 10px">
                    <hr />
                </div>
            </div>
            <div class="row rowMargin table-responsive">
                <div class="table-responsive">
                    <asp:GridView ID="GrvData" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover table-checkable mb-0"
                        AllowPaging="true" PageSize="15" HeaderStyle-BackColor="#026099" HeaderStyle-ForeColor="White" OnRowEditing="GrvData_RowEditing"
                        OnPageIndexChanging="GrvData_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="SR">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblSRNo" Text=' <%# Container.DataItemIndex+1 %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="A" HeaderText="Column1" />
                            <asp:BoundField DataField="B" HeaderText="Column2" />
                            <asp:BoundField DataField="C" HeaderText="Column3" />
                            <asp:BoundField DataField="D" HeaderText="Column4" />
                            <asp:BoundField DataField="E" HeaderText="Column5" />
                            <asp:BoundField DataField="F" HeaderText="Column6" />
                            <asp:BoundField DataField="G" HeaderText="Column7" />
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
