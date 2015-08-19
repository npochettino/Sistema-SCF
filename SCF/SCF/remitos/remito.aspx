<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="remito.aspx.cs" Inherits="SCF.remitos.remito" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">
            <!-- BEGIN PAGE HEAD -->
            <div class="page-head">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Remito <small>editar/nuevo Remito</small></h1>
                </div>
                <!-- END PAGE TITLE -->

            </div>
            <!-- END PAGE HEAD -->

            <!-- BEGIN PAGE BREADCRUMB -->
            <ul class="page-breadcrumb breadcrumb">
                <li>
                    <a href="../index.aspx">Inicio</a>
                    <i class="fa fa-circle"></i>
                </li>
                <li>
                    <a href="remito.aspx">Remito</a>
                    <i class="fa fa-circle"></i>
                </li>
            </ul>
            <!-- END PAGE BREADCRUMB -->
            <!-- END PAGE HEADER-->
            <div class="row">
                <div class="col-md-12">
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa icon-note"></i>Remito
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">

                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <div class="form-body">
                                    <h3 class="form-section">Detalle del Remito</h3>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Nota de Pedido</label>

                                                <dx:ASPxComboBox ID="cbNotaDePedido" runat="server" DropDownStyle="DropDownList" CssClass="form-control"
                                                    ValueField="codigoCliente" IncrementalFilteringMode="Contains" ValueType="System.Int32" TextFormatString="{0} ({1})" Width="100%" EnableTheming="True" Theme="Metropolis">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="codigoCliente" Width="100px" Visible="false" />
                                                        <dx:ListBoxColumn FieldName="cuil" Width="100px" />
                                                        <dx:ListBoxColumn FieldName="razonSocial" Width="300px" />
                                                    </Columns>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Fecha Emisión</label>
                                                <dx:ASPxDateEdit ID="txtFechaEmision" runat="server" CssClass="form-control" Theme="Metropolis" Width="100%" EditFormat="DateTime" AutoPostBack="false">
                                                    <TimeSectionProperties Visible="True">
                                                    </TimeSectionProperties>

                                                </dx:ASPxDateEdit>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Codigo</label>
                                                <dx:ASPxTextBox ID="txtCodigoRemito" runat="server" CssClass="form-control"  Width="100%" placeholder="Codigo"></dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <!--/row-->

                                    <!-- BEGIN ROW -->
                                    <h3 class="form-section">Items de la Nota de Pedido</h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <!-- BEGIN CHART PORTLET-->
                                            <div class="portlet light">
                                                 <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="icon-bar-chart font-green-haze"></i>
                                                        <span class="caption-subject bold uppercase font-green-haze">Seleccione los Artículos</span>
                                                    </div>
                                                    <div class="tools">
                                                        <a href="javascript:;" class="collapse"></a>
                                                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                                        <a href="javascript:;" class="reload"></a>
                                                        <a href="javascript:;" class="fullscreen"></a>
                                                        <a href="javascript:;" class="remove"></a>
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="chart_8" class="chart" style="height:auto">
                                                        <!-- GRID VIEW ARTICULOS-->
                                                        <dx:ASPxGridView ID="gvArticulos" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoArticulo" Theme="Metropolis" Width="100%">
                                                            <Columns>
                                                                <dx:GridViewCommandColumn ShowSelectCheckbox="True"
                                                                    VisibleIndex="0" Caption="Seleccionar">
                                                                </dx:GridViewCommandColumn>
                                                                <dx:GridViewDataTextColumn FieldName="codigoArticulo" ReadOnly="True" Visible="False" VisibleIndex="1">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="descripcionCorta" VisibleIndex="2">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Visible="false" FieldName="descripcionLarga" VisibleIndex="3">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="marca" VisibleIndex="4">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>

                                                                <dx:GridViewDataTextColumn Caption="cantidad" Visible="false" VisibleIndex="5" FieldName="cantidad">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="fechaEntrega" Visible="false" VisibleIndex="6" FieldName="fechaEntrega">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>

                                                                <dx:GridViewDataTextColumn Caption="codigoItemNotaDePedido" Visible="false" VisibleIndex="7" FieldName="codigoItemNotaDePedido">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>

                                                                <dx:GridViewDataTextColumn Caption="precio" VisibleIndex="8" FieldName="precio">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                            </Columns>
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            <SettingsPager PageSize="10">
                                                            </SettingsPager>
                                                            <Settings ShowFilterRow="True" />
                                                        </dx:ASPxGridView>
                                                        <br />
                                                        <div>
                                                            <div class="btn-set pull-right">
                                                                <asp:Button type="button" class="btn green" runat="server" ID="btnSeleccionarArticulos" Text="Seleccionar" />
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                                <!-- END CHART PORTLET-->
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <!-- BEGIN CHART PORTLET-->
                                            <div class="portlet light">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="icon-bar-chart font-green-haze"></i>
                                                        <span class="caption-subject bold uppercase font-green-haze">Items a Entregar</span>
                                                        <span class="caption-helper">cargar items</span>
                                                    </div>
                                                    <div class="tools">
                                                        <a href="javascript:;" class="collapse"></a>
                                                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                                        <a href="javascript:;" class="reload"></a>
                                                        <a href="javascript:;" class="fullscreen"></a>
                                                        <a href="javascript:;" class="remove"></a>
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="chart_9" class="chart" style="height:auto">
                                                        <!-- GRID VIEW ITEMS SELECCIONADOS-->
                                                        <dx:ASPxGridView ID="gvArticulosSeleccionados" runat="server" Theme="Metropolis" AutoGenerateColumns="False" KeyFieldName="codigoArticulo"
                                                            Width="100%">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn Caption="codigoArticulo" VisibleIndex="0" FieldName="codigoArticulo"
                                                                    Visible="false">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="descripcionCorta" VisibleIndex="1" FieldName="descripcionCorta">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="descripcionLarga" Visible="false" VisibleIndex="2" FieldName="descripcionLarga">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="marca" VisibleIndex="3">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>

                                                                <dx:GridViewDataSpinEditColumn Caption="Cantidad" VisibleIndex="4" FieldName="cantidad">
                                                                    <PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>

                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />

                                                                    <DataItemTemplate>
                                                                        <dx:ASPxSpinEdit runat="server" ID="txtTitle" Width="100px" Number="1" MinValue="1" MaxValue="100">
                                                                        </dx:ASPxSpinEdit>
                                                                    </DataItemTemplate>


                                                                </dx:GridViewDataSpinEditColumn>
                                                                <dx:GridViewDataDateColumn Caption="fechaEntrega" VisibleIndex="5"  FieldName="fechaEntrega">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />

                                                                </dx:GridViewDataDateColumn>

                                                                <dx:GridViewDataTextColumn Caption="codigoItemNotaDePedido" Visible="false" VisibleIndex="6" FieldName="codigoItemNotaDePedido">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>

                                                                <dx:GridViewDataTextColumn Caption="precio" VisibleIndex="7" FieldName="precio">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                
                                                            </Columns>
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            
                                                            <Settings ShowFilterRow="True" />
                                                        </dx:ASPxGridView>
                                                        <br />
                                                        <div>
                                                            <div class="btn-set pull-left">
                                                                <asp:Button type="button" class="btn red" runat="server" ID="btnEliminar" Text="Eliminar" />
                                                            </div>
                                                            <div class="btn-set pull-right">
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                            <!-- END CHART PORTLET-->
                                        </div>
                                    </div>
                                    <!-- END ROW -->
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label">Observación</label>
                                                <textarea id="txtObservacion" placeholder="Observación" runat="server" rows="3" class="form-control"></textarea>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-actions right">
                                        <button type="button" class="btn default" onclick="location.href='listado.aspx'">Cancelar</button>
                                        <asp:Button type="button" class="btn blue" runat="server" ID="btnGuardar" Text="Guardar" />
                                    </div>
                                </div>
                            </form>
                            <!-- END FORM-->
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- END CONTENT -->
    <!-- COMIENZO DE POP UP-->
    
    <script type="text/javascript">
        function ShowEditarItemsNotaDePedido() {
            pcEditarItemsNotaDePedido.Show();
        }
    </script>


</asp:Content>

