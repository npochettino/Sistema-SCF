<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado.aspx.cs" Inherits="SCF.facturas.listado" %>

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
                    <h1>Facturas <small>listado de facturas</small></h1>
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
                    <a href="listado_facturas.aspx">Listado Facturas</a>
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
                                <i class="fa fa-bitcoin"></i>Listado de Facturas
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <div class="form-actions top">
                                <div class="btn-set pull-left">
                                    <asp:Button type="button" ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" UseSubmitBehavior="false" class="btn blue" Text="Nuevo" />
                                    <asp:Button type="button" ID="btnEditar" runat="server" OnClick="btnEditar_Click" class="btn yellow" UseSubmitBehavior="false" Text="Editar" />
                                    <asp:Button type="button" ID="btnEliminar" runat="server" OnClientClick="ShowConfirmarEliminarFactura()" UseSubmitBehavior="false" class="btn red" Text="Eliminar" />
                                </div>
                                <div class="btn-set pull-right">
                                    <asp:Button type="button" ID="btnDetalle" runat="server" OnClick="btnDetalle_Click" class="btn green" Text="Detalle" />
                                </div>
                            </div>
                            <div class="form-body" style="height: 600px">
                                <!-- devexpress-->
                                <dx:ASPxGridView ID="gvComprobantes" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="idFactura" Theme="Metropolis">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="idFactura" ReadOnly="True" Visible="False" VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="numeroFactura" VisibleIndex="1" Caption="Numero Factura">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="fechaFactura" VisibleIndex="1" Caption="Fecha Facturación">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="cuil" VisibleIndex="1" Caption="CUIL">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="razonSocialCliente" VisibleIndex="1" Caption="Razon Social">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="importeFactura" VisibleIndex="1" Caption="Importe">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                    </Columns>
                                    <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <Settings ShowFilterRow="True" />
                                    <SettingsPager PageSize="10">
                                    </SettingsPager>
                                </dx:ASPxGridView>

                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- END CONTENT -->

    <!-- BEGIN POPUP ELIMINAR ARTICULO -->
    <dx:ASPxPopupControl ID="pcConfirmarEliminarFactura" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarFactura"
        HeaderText="Eliminar Factura" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
        EnableViewState="False" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  txtPrecio.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="Panel2" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="input-group">
                                                ¿Desea eliminar la factura seleccionada?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button1" runat="server" UseSubmitBehavior="false" OnClientClick="pcConfirmarEliminarFactura.Hide();" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="btnConfirmarEliminarFactura" runat="server" OnClick="btnConfirmarEliminarFactura_Click" class="btn blue" Text="Aceptar" />
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

    <dx:ASPxPopupControl ID="pcDetalleComprobante" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcDetalleComprobante"
        HeaderText="Detalle Comprobante" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="1000"
        EnableViewState="False" Theme="Metropolis">
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
                                                            <dx:ASPxGridView ID="gvDetalleComprobante" runat="server" Width="100%" Theme="Metropolis" AutoGenerateColumns="False" EnableTheming="True">
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
                                                       <%-- <div class="form-actions top">
                                                            <div class="btn-set pull-right">
                                                                <button type="button" onclick="pcValidarComprobante.Hide();" class="btn default">Cancelar</button>
                                                                <asp:Button type="button" class="btn blue" runat="server" ID="btnEmitirComprobante" OnClick="btnEmitirComprobante_Click" Text="Emitir Comprobante" />
                                                            </div>
                                                        </div>--%>
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


    <script lang="javascript" type="text/javascript">
        function ShowConfirmarEliminarFactura() {
            pcConfirmarEliminarFactura.Show();
        }
    </script>
</asp:Content>


