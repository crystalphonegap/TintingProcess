<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Export_All_Template.aspx.cs" Inherits="ShadeCard.Export_All_Template" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="Styles/Custome.css" rel="stylesheet" />
    <link href="Styles/TabClass.css" rel="stylesheet" />
    <div class="card cardMargin">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <div class=" card-body" style="margin-bottom: 0px!important">

            <div class="col-md-12">
                <div class="col-md-7">
                    <h4>LSMW FG Template </h4>
                </div>
                <div class="col-md-3" style="text-align: right">
                    <div class="input-group">

                        <asp:DropDownList runat="server" ID="dropPlant" CssClass=" form-control">
                            <asp:ListItem Value="0"> Select Plant</asp:ListItem>
                            <asp:ListItem Value="1000"> 10001</asp:ListItem>
                        </asp:DropDownList>
                        <div class="input-group-addon" style="padding: 0px;">
                            <asp:LinkButton runat="server" ID="btnSearch" CssClass="btn btn-primary" OnClick="btnSearch_Click"><i class="fa fa-search" style="color:white;font-size: 12px;">  </i></asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="col-md-2" style="text-align: right">
                    <asp:LinkButton runat="server" ID="btnExport" CssClass="btn btn-primary" OnClick="btnExport_Click"><i class="fa fa-download" style="color:white;font-size: 12px;"> Export To Excel  </i></asp:LinkButton>
                </div>
            </div>

            <div class="col-md-12" style="padding-bottom: 10px">
                <hr />
            </div>

            <div class="row rowMargin table-responsive">
                <div class="table-responsive">
                    <div class="tab" role="tabpanel">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist">
                            <li role="presentation" class="active"><a href="#Section1" aria-controls="home" role="tab" data-toggle="tab">FG BASIC</a></li>
                            <li role="presentation"><a href="#Section2" aria-controls="profile" role="tab" data-toggle="tab">FG ALT UOM</a></li>
                            <li role="presentation"><a href="#Section3" aria-controls="messages" role="tab" data-toggle="tab">FG PALNT</a></li>
                            <li role="presentation"><a href="#Section4" aria-controls="messages" role="tab" data-toggle="tab">FG SPLIT VAL</a></li>
                            <li role="presentation"><a href="#Section5" aria-controls="messages" role="tab" data-toggle="tab">MMSC</a></li>
                            <li role="presentation"><a href="#Section6" aria-controls="messages" role="tab" data-toggle="tab">FG SALES</a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content tabs">

                            <div role="tabpanel" class="tab-pane table-responsive fade in active" id="Section1">
                                <asp:GridView ID="grvFgBasic" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover table-checkable mb-0"
                                    AllowPaging="true" PageSize="15" HeaderStyle-BackColor="#026099" HeaderStyle-ForeColor="White" OnRowEditing="grvFgBasic_RowEditing"
                                    OnPageIndexChanging="grvFgBasic_PageIndexChanging">
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
                                        <asp:BoundField DataField="H" HeaderText="Column8" />
                                        <asp:BoundField DataField="I" HeaderText="Column9" />
                                        <asp:BoundField DataField="J" HeaderText="Column10" />
                                        <asp:BoundField DataField="K" HeaderText="Column11" />
                                    </Columns>
                                </asp:GridView>

                            </div>
                            <div role="tabpanel" class="tab-pane fade table-responsive" id="Section2">
                                <asp:GridView ID="GrvAltUom" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover table-checkable mb-0"
                                    AllowPaging="true" PageSize="15" HeaderStyle-BackColor="#026099" HeaderStyle-ForeColor="White" OnRowEditing="GrvAltUom_RowEditing"
                                    OnPageIndexChanging="GrvAltUom_PageIndexChanging">
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
                                        <asp:BoundField DataField="H" HeaderText="Column8" />
                                        <asp:BoundField DataField="I" HeaderText="Column9" />
                                        <asp:BoundField DataField="J" HeaderText="Column10" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div role="tabpanel" class="tab-pane fade table-responsive " id="Section3">
                                <asp:GridView ID="GrvPlant" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover table-checkable mb-0"
                                    AllowPaging="true" PageSize="15" HeaderStyle-BackColor="#026099" HeaderStyle-ForeColor="White" OnRowEditing="GrvPlant_RowEditing"
                                    OnPageIndexChanging="GrvPlant_PageIndexChanging">
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
                                        <asp:BoundField DataField="H" HeaderText="Column8" />
                                        <asp:BoundField DataField="I" HeaderText="Column9" />
                                        <asp:BoundField DataField="J" HeaderText="Column10" />
                                        <asp:BoundField DataField="K" HeaderText="Column11" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div role="tabpanel" class="tab-pane fade table-responsive " id="Section4">

                                <asp:GridView ID="GrvSplitVal" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover table-checkable mb-0"
                                    AllowPaging="true" PageSize="15" HeaderStyle-BackColor="#026099" HeaderStyle-ForeColor="White" OnRowEditing="GrvSplitVal_RowEditing"
                                    OnPageIndexChanging="GrvSplitVal_PageIndexChanging">
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
                            <div role="tabpanel" class="tab-pane fade table-responsive " id="Section5">
                                <asp:GridView ID="GrvMMSC" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover table-checkable mb-0"
                                    AllowPaging="true" PageSize="15" HeaderStyle-BackColor="#026099" HeaderStyle-ForeColor="White" OnRowEditing="GrvMMSC_RowEditing" OnPageIndexChanging="GrvMMSC_PageIndexChanging">
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
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div role="tabpanel" class="tab-pane fade table-responsive " id="Section6">
                                <asp:GridView ID="grvSales" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover table-checkable mb-0"
                                    AllowPaging="true" PageSize="15" HeaderStyle-BackColor="#026099" HeaderStyle-ForeColor="White" OnRowEditing="grvSales_RowEditing" OnPageIndexChanging="grvSales_PageIndexChanging">
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
                                        <asp:BoundField DataField="H" HeaderText="Column8" />
                                    </Columns>
                                </asp:GridView>
                            </div>


                        </div>
                    </div>
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


    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>

</asp:Content>
