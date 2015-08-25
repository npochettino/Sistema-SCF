<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado.aspx.cs" Inherits="SCF.nota_pedido.listado" %>

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
                    <h1>Notas de Pedido <small>listado de Notas de Pedido</small></h1>
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
                    <a href="listado.aspx">Listado Notas de Pedido</a>
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
                                <i class="fa icon-docs"></i>Listado de Notas de Pedido
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <div class="form-actions top">
                                <div class="btn-set pull-left">
                                    <asp:Button type="button" ID="btnNuevo" runat="server" onclick="btnNuevo_Click" UseSubmitBehavior="false" class="btn blue" Text="Nuevo" />
                                    <asp:Button type="button" ID="btnEditar" runat="server" OnClick="btnEditar_Click" UseSubmitBehavior="false" class="btn yellow" Text="Editar" />
                                    <asp:Button type="button" ID="btnEliminar" runat="server" OnClientClick="ShowConfirmarEliminarNotaPedido()" UseSubmitBehavior="false" class="btn red" Text="Eliminar" />
                                </div>
                                <div class="btn-set pull-right">
                                    <asp:Button type="button" ID="btnShowPopUpObservacion" runat="server" OnClick="btnShowPopUpObservacion_Click" UseSubmitBehavior="false" class="btn red" Text="Anular" />
                                    <asp:Button type="button" ID="btnVerDetalle" runat="server" OnClientClick="ShowDetalleNotaPedido()" UseSubmitBehavior="false" class="btn green" Text="Detalle" />
                                </div>
                            </div>
                            <div class="form-body" style="height: 600px">
                                <!-- devexpress-->

                                <dx:ASPxGridView ID="gvNotasPedido" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="codigoNotaDePedido" EnableTheming="True" Theme="Metropolis" OnCellEditorInitialize="gvNotasPedido_CellEditorInitialize" OnHtmlRowPrepared="gvNotasPedido_HtmlRowPrepared" SettingsBehavior-AllowSort="true" SettingsBehavior-SortMode="Custom">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="codigoNotaDePedido" ReadOnly="True" Visible="False" VisibleIndex="0">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="numeroInternoCliente" VisibleIndex="1" Visible="true" Caption="Nro interno cliente">
                                            <Settings AllowSort ="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="fechaEmision" VisibleIndex="2" Caption="Fecha Emisión">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoEstado" Visible="false" VisibleIndex="3">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="colorEstado" VisibleIndex="4" Visible="False">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoContratoMarco" VisibleIndex="5" Visible="False">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionContratoMarco" VisibleIndex="6" Visible="true" Caption="Contrato marco">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoCliente" VisibleIndex="9" Visible="false">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="razonSocialCliente" VisibleIndex="10" Visible="true" Caption="Razón social">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="fechaHoraProximaEntrega" VisibleIndex="11" Visible="true" Caption="Próxima entrega">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="observaciones" VisibleIndex="12" Visible="true" Caption="Observaciones">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <Settings ShowFilterRow="True" />
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
    <dx:ASPxPopupControl ID="pcConfirmarEliminarNotaPedido" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarNotaPedido"
        HeaderText="Eliminar Nota de Pedido" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
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
                                                ¿Desea eliminar la Nota de Pedido seleccionada?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <button type="button" onclick="pcConfirmarEliminarNotaPedido.Hide();" class="btn default">Cerrar</button>
                                        <asp:Button type="button" ID="btnAceptarEliminarNotaPedido" runat="server" OnClick="btnAceptarEliminarNotaPedido_Click" class="btn blue" Text="Aceptar" />
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

    <!-- BEGIN POPUP OBSERVACION DE LA NOTA DE PEDIDO -->
    <dx:ASPxPopupControl ID="pcShowObservacion" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcShowObservacion"
        HeaderText="Observacion" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="400"
        EnableViewState="False" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  txtPrecio.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server">
                            <div>
                                <!-- BEGIN FORM-->
                                <form action="#" class="horizontal-form">
                                    <div class="form-body">
                                        <h3 class="form-section">Observación de la Nota de Pedido</h3>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <textarea type="text" id="txtObservacion" placeholder="Observación" runat="server" class="form-control" required rows="5"></textarea>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </form>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button2" runat="server" UseSubmitBehavior="false" OnClientClick="pcShowObservacion.Hide();" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="btnGuardarObservacion" runat="server" OnClick="btnGuardarObservacion_Click" class="btn blue" Text="Aceptar" />
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


    <script lang="javascript" type="text/javascript">
        function ShowConfirmarEliminarNotaPedido() {
            pcConfirmarEliminarNotaPedido.Show();
        }
        function ShowObservacion() {
            pcShowObservacion();
        }
    </script>
</asp:Content>

