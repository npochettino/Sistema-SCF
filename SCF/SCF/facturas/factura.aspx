<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="factura.aspx.cs" Inherits="SCF.facturas.factura" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridLookup" TagPrefix="dx" %>

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
                    <h1>Factura <small>editar/nuevo Factura</small></h1>
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
                    <a href="factura.aspx">Factura</a>
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
                                <i class="fa icon-note"></i>Factura
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <div class="form-actions top">
                                <div class="btn-set pull-left">
                                    <asp:Button type="button" ID="btnUltimoNroComprobante" runat="server" OnClick="btnUltimoNroComprobante_Click" UseSubmitBehavior="false" class="btn blue" Text="Ult. Nro Comprobante" />
                                </div>
                            </div>
                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <div class="form-body">
                                    <h3 class="form-section">Detalle de la Factura</h3>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Tipo de Comprobante</label>
                                                <dx:ASPxComboBox ID="cbTipoComprobante" runat="server" DropDownStyle="DropDownList" EnableTheming="True" Theme="Metropolis" CssClass="form-control" Width="100%">
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Nro. Factura</label>
                                                <dx:ASPxTextBox ID="txtNroFactura" runat="server" CssClass="form-control" Width="100%" placeholder="Nro Factura"></dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Fecha Facturación</label>
                                                <dx:ASPxDateEdit ID="txtFechaFacturacion" runat="server" CssClass="form-control" DropDownStyle="DropDownList" EnableTheming="True" Theme="Metropolis" Width="100%" EditFormat="DateTime" AutoPostBack="false">
                                                    <TimeSectionProperties Visible="True">
                                                    </TimeSectionProperties>
                                                </dx:ASPxDateEdit>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Remito</label>
                                                <dx:ASPxGridLookup ID="gluRemito" runat="server" SelectionMode="Multiple" CssClass="form-control"
                                                    ClientInstanceName="gridLookup" Theme="Metropolis"
                                                    KeyFieldName="codigoNotaDePedido" Width="100%" TextFormatString="{0} ({1})" MultiTextSeparator=", ">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" Width="100%" Caption=" " />
                                                        <dx:GridViewDataColumn FieldName="codigoNotaDePedido" Caption="Nro Remito" Width="100%" />
                                                        <dx:GridViewDataColumn FieldName="razonSocialCliente" Caption="Cliente" Width="100%" />
                                                        <%--<dx:GridViewDataColumn FieldName="cuil" Caption="CUIL" />--%>
                                                    </Columns>
                                                    <GridViewProperties>
                                                        <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                                    </GridViewProperties>
                                                </dx:ASPxGridLookup>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Tipo de Moneda</label>
                                                <dx:ASPxComboBox ID="cbTipoMoneda" runat="server" DropDownStyle="DropDownList" EnableTheming="True"
                                                    Theme="Metropolis" CssClass="form-control" Width="100%">
                                                    <Items>
                                                        <dx:ListEditItem Selected="true" Text="Seleccione un tipo de moneda" Value="0" />
                                                        <dx:ListEditItem Text="Peso" Value="1" />
                                                        <dx:ListEditItem Text="Dolar" Value="2" />
                                                        <dx:ListEditItem Text="Euro" Value="2" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Concepto</label>
                                                <dx:ASPxComboBox ID="cbConcepto" runat="server" DropDownStyle="DropDownList" EnableTheming="True"
                                                    Theme="Metropolis" CssClass="form-control" Width="100%">
                                                    <Items>
                                                        <dx:ListEditItem Selected="true" Text="Seleccione un tipo de concepto" Value="0" />
                                                        <dx:ListEditItem Text="Producto" Value="1" />
                                                        <dx:ListEditItem Text="Producto y Servicio" Value="2" />
                                                        <dx:ListEditItem Text="Servicio" Value="2" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <!--/row-->

                                    <!-- BEGIN ROW -->
                                    <h3 class="form-section">Items de la Factura</h3>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <!-- BEGIN CHART PORTLET-->
                                            <div class="portlet light">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="icon-bar-chart font-green-haze"></i>
                                                        <span class="caption-subject bold uppercase font-green-haze">Artículos</span>
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
                                                    <div id="chart_8" class="chart" style="height: auto">
                                                        <!-- GRID VIEW ARTICULOS-->
                                                        <dx:ASPxGridView ID="gvItemsFactura" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoItemNotaDePedido" Theme="Metropolis" Width="100%">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="codigoArticulo" ReadOnly="True" Visible="False" VisibleIndex="1">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="descripcionCorta" VisibleIndex="2" Visible="true" Caption="Descripción Corta">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="codigoInternoCliente" VisibleIndex="2" Width="100px" Visible="true" Caption="Codigo">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="posicion" VisibleIndex="2" Width="150px" Visible="true" Caption="Posición">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataSpinEditColumn Caption="Precio Unitario" Width="100px" VisibleIndex="4" FieldName="precio">
                                                                    <PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <DataItemTemplate>
                                                                        <dx:ASPxSpinEdit runat="server" ID="txtTitle" Width="100px" Number="1" MinValue="1" MaxValue="100">
                                                                        </dx:ASPxSpinEdit>
                                                                    </DataItemTemplate>
                                                                </dx:GridViewDataSpinEditColumn>
                                                                <dx:GridViewDataSpinEditColumn Caption="Cantidad" Width="60px" VisibleIndex="4" FieldName="cantidad">
                                                                    <PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <DataItemTemplate>
                                                                        <dx:ASPxSpinEdit runat="server" ID="txtTitle" Width="100px" Number="1" MinValue="1" MaxValue="100">
                                                                        </dx:ASPxSpinEdit>
                                                                    </DataItemTemplate>
                                                                </dx:GridViewDataSpinEditColumn>
                                                                <dx:GridViewDataSpinEditColumn Caption="Importe" Width="100px" VisibleIndex="4" FieldName="precio">
                                                                    <PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <DataItemTemplate>
                                                                        <dx:ASPxSpinEdit runat="server" ID="txtTitle" Width="100px" Number="1" MinValue="1" MaxValue="100">
                                                                        </dx:ASPxSpinEdit>
                                                                    </DataItemTemplate>
                                                                </dx:GridViewDataSpinEditColumn>
                                                            </Columns>
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            <SettingsPager PageSize="10">
                                                            </SettingsPager>
                                                            <Settings ShowFilterRow="True" />
                                                        </dx:ASPxGridView>

                                                    </div>
                                                </div>
                                                <!-- END CHART PORTLET-->
                                            </div>
                                        </div>
                                    </div>
                                    <!-- END ROW -->
                                    <div class="portlet light">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="icon-calculator font-green-haze"></i>
                                                <span class="caption-subject bold uppercase font-green-haze">Total</span>
                                            </div>
                                            <div class="tools">
                                                <a href="javascript:;" class="collapse"></a>
                                            </div>
                                        </div>
                                        <div class="portlet-body">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">SUBTOTAL</label>
                                                        <div class="col-md-9">
                                                            <dx:ASPxLabel ID="lblSubtotal" runat="server" Text="123123"></dx:ASPxLabel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">IVA</label>
                                                        <div class="col-md-9">
                                                            <dx:ASPxComboBox ID="cbCondicionIVA" runat="server" DropDownStyle="DropDownList"
                                                                EnableTheming="True" Theme="Metropolis" CssClass="form-control" Width="80">
                                                                <Items>
                                                                    <dx:ListEditItem Text="0 %" Value="3" />
                                                                    <dx:ListEditItem Text="10,5 %" Value="4" />
                                                                    <dx:ListEditItem Selected="true" Text="21 %" Value="5" />
                                                                    <dx:ListEditItem Text="27 %" Value="6" />
                                                                    <dx:ListEditItem Text="5 %" Value="8" />
                                                                    <dx:ListEditItem Text="2,50 %" Value="9" />
                                                                </Items>
                                                            </dx:ASPxComboBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">TOTAL</label>
                                                        <div class="col-md-9">
                                                            <dx:ASPxLabel ID="lblTotal" runat="server" Text="123123"></dx:ASPxLabel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-actions right">
                                        <button type="button" class="btn default" onclick="location.href='listado.aspx'">Cancelar</button>
                                        <asp:Button type="button" class="btn blue" runat="server" ID="btnEmitir" Text="Emitir Factura" OnClick="btnEmitir_Click" />
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
    <!-- BEGIN POPUP ELIMINAR ARTICULO -->
    <dx:ASPxPopupControl ID="pcError" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcError"
        HeaderText="Error" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
        EnableViewState="False" Theme="Metropolis">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="input-group">
                                                <dx:ASPxLabel ID="lblError" Text="Hola" runat="server">
                                                </dx:ASPxLabel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="pcValidarComprobante" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcValidarComprobante"
        HeaderText="Validar Comprobante" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="1000"
        EnableViewState="False" Theme="Metropolis" OnUnload="pcValidarComprobante_Unload">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl5" runat="server">
                <dx:ASPxPanel ID="ASPxPanel3" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent5" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-body">
                                                            <h3 class="form-section">Detalle Factura &nbsp;&nbsp;
                                                    <asp:Label ID="lblNroFactura" runat="server" Text="0001-00002678"></asp:Label></h3>
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-3">Cliente:</label>
                                                                        <div class="col-md-9">
                                                                            <p class="form-control-static">
                                                                                Bob
                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-3">Domicilio:</label>
                                                                        <div class="col-md-9">
                                                                            <p class="form-control-static">
                                                                                Nilson
                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                            </div>
                                                            <!--/row-->
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-3">Localidad:</label>
                                                                        <div class="col-md-9">
                                                                            <p class="form-control-static">
                                                                                Male
                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-3">C.U.I.T:</label>
                                                                        <div class="col-md-9">
                                                                            <p class="form-control-static">
                                                                                20.01.1984
                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                            </div>
                                                            <!--/row-->
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-3">Condición de Venta:</label>
                                                                        <div class="col-md-9">
                                                                            <p class="form-control-static">
                                                                                Category1
                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-3">Remito:</label>
                                                                        <div class="col-md-9">
                                                                            <p class="form-control-static">
                                                                                Free
                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                            </div>
                                                            <!--/row-->
                                                        </div>
                                                        <div class="form-group">
                                                            <dx:ASPxGridView ID="gvDetalleFactura" runat="server" Width="100%" Theme="Metropolis" AutoGenerateColumns="False" EnableTheming="True">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoArticulo" ReadOnly="True" Visible="False" VisibleIndex="1">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="descripcionCorta" VisibleIndex="2" Visible="true" Caption="Descripción Corta">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoInternoCliente" VisibleIndex="2" Width="100px" Visible="true" Caption="Codigo">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="posicion" VisibleIndex="2" Width="150px" Visible="true" Caption="Posición">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataSpinEditColumn Caption="Precio Unitario" Width="100px" VisibleIndex="4" FieldName="precio">
                                                                        <PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <DataItemTemplate>
                                                                            <dx:ASPxSpinEdit runat="server" ID="txtTitle" Width="100px" Number="1" MinValue="1" MaxValue="100">
                                                                            </dx:ASPxSpinEdit>
                                                                        </DataItemTemplate>
                                                                    </dx:GridViewDataSpinEditColumn>
                                                                    <dx:GridViewDataSpinEditColumn Caption="Cantidad" Width="60px" VisibleIndex="4" FieldName="cantidad">
                                                                        <PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <DataItemTemplate>
                                                                            <dx:ASPxSpinEdit runat="server" ID="txtTitle" Width="100px" Number="1" MinValue="1" MaxValue="100">
                                                                            </dx:ASPxSpinEdit>
                                                                        </DataItemTemplate>
                                                                    </dx:GridViewDataSpinEditColumn>
                                                                    <dx:GridViewDataSpinEditColumn Caption="Importe" Width="100px" VisibleIndex="4" FieldName="precio">
                                                                        <PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <DataItemTemplate>
                                                                            <dx:ASPxSpinEdit runat="server" ID="txtTitle" Width="100px" Number="1" MinValue="1" MaxValue="100">
                                                                            </dx:ASPxSpinEdit>
                                                                        </DataItemTemplate>
                                                                    </dx:GridViewDataSpinEditColumn>
                                                                </Columns>
                                                            </dx:ASPxGridView>
                                                        </div>
                                                        <div class="form-body">
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-3">CAE:</label>
                                                                        <div class="col-md-9">
                                                                            <p class="form-control-static">
                                                                                123123123123123123
                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-3">SUBTOTAL:</label>
                                                                        <div class="col-md-9">
                                                                            <p class="form-control-static">
                                                                                3455
                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                            </div>
                                                            <!--/row-->
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-3">FECHA VENC. CAE:</label>
                                                                        <div class="col-md-9">
                                                                            <p class="form-control-static">
                                                                                05/10/2015
                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-3">I.V.A: (21%)</label>
                                                                        <div class="col-md-9">
                                                                            <p class="form-control-static">
                                                                                4567
                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                            </div>
                                                            <!--/row-->
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                </div>
                                                                <!--/span-->
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-3">TOTAL:</label>
                                                                        <div class="col-md-9">
                                                                            <p class="form-control-static">
                                                                                5000
                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                            </div>
                                                            <!--/row-->
                                                        </div>
                                                        <div class="form-actions top">
                                                            <div class="btn-set pull-right">
                                                                <button type="button" onclick="pcValidarComprobante.Hide();" class="btn default">Cancelar</button>
                                                                <asp:Button type="button" class="btn blue" runat="server" ID="btnEmitirComprobante" OnClick="btnEmitirComprobante_Click" Text="Emitir Comprobante" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <!--END POPUP-->


    <dx:ASPxPopupControl ID="pcUltimoComprobanteAfip" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcUltimoComprobanteAfip"
        HeaderText="Ultimo Comprobante AFIP" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="650"
        EnableViewState="False" Theme="Metropolis">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                            <div>
                                <div class="modal-body">
                                    <h3 class="form-section">Datos Enviados</h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-12">CUIT Contribuyente: 27-29680438-5</label>
                                                
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-12">Punto de Venta: 002</label>
                                                
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-12">Tipo de Comprobante: Factura Tipo A</label>
                                                
                                            </div>
                                        </div>
                                    </div>
                                    <!--/row-->
                                    <h3 class="form-section">Ultimo Nro. de comprobante: &nbsp;&nbsp; <strong>
                                        <asp:Label ID="lblUltimoNroComprobante" runat="server" Text="0001-00002345"></asp:Label></strong></h3>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>



</asp:Content>



