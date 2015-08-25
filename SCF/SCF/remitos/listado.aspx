<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado.aspx.cs" Inherits="SCF.remitos.listado" %>

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
                    <h1>Remitos <small>listado de remitos</small></h1>
                </div>
                <!-- END PAGE TITLE -->

            </div>
            <!-- END PAGE HEAD -->

            <!-- BEGIN PAGE BREADCRUMB -->
            <ul class="page-breadcrumb breadcrumb">
                <li>
                    <a href="index.aspx">Inicio</a>
                    <i class="fa fa-circle"></i>
                </li>
                <li>
                    <a href="../remitos/listado.aspx">Listado de Remitos</a>
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
                                <i class="fa fa-car"></i>Listado de Remitos
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
                                    <asp:Button type="button" ID="btnEliminar" runat="server" OnClientClick="ShowConfirmarEliminarRemito()" UseSubmitBehavior="false" class="btn red" Text="Eliminar" />
                                </div>
                                <div class="btn-set pull-right">
                                    <asp:Button type="button" ID="btnVerDetalle" runat="server" OnClick="btnVerDetalle_Click" class="btn blue" Text="Ver" />
                                </div>
                            </div>
                            <div class="form-body" style="height: 600px">
                                <!-- devexpress-->

                                <dx:ASPxGridView ID="gvEntregas" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoEntrega" Theme="Metropolis">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="codigoEntrega" ReadOnly="True" Visible="False" VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="codigoNotaDePedido" VisibleIndex="1" Visible="false">
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="codigoCliente" VisibleIndex="2" Visible="false">
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="razonSocialCliente" VisibleIndex="3" Caption="Cliente">
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="fechaEmision" VisibleIndex="4" Caption="Fecha Emision">
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataTextColumn FieldName="numeroRemito" VisibleIndex="5" Caption="Numero Remito">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoEstado" VisibleIndex="6" Visible="false">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="observaciones" VisibleIndex="7" Caption="Observaciones">
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
    <dx:ASPxPopupControl ID="pcConfirmarEliminarRemito" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarRemito"
        HeaderText="Eliminar Remito" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
        EnableViewState="False" Theme="Metropolis">
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
                                                ¿Desea eliminar el remito seleccionado?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button1" runat="server" UseSubmitBehavior="false" OnClientClick="pcConfirmarEliminarRemito.Hide();" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="btnAceptarEliminarRemito" runat="server" OnClick="btnAceptarEliminarRemito_Click" UseSubmitBehavior="false" class="btn blue" Text="Aceptar" />
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

    <dx:ASPxPopupControl ID="pcShowDetalleRemito" runat="server" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcShowDetalleRemito"
        HeaderText="Detalle de Remito" AllowDragging="True" EnableViewState="False" Width="800px"
        PopupAnimationType="Fade" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  txtCodigoInterno.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" DefaultButton="btnGuardarAticuloProveedor">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server">
                            <div data-width="760">
                                <div class="modal-body">
                                    <!--INFO DEL ARTICULO-->
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <label style="font-size: medium"><strong>Info del Remito</strong></label>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label class="control-label">Nota de Pedido</label>
                                                            <dx:ASPxTextBox ID="txtNotaDePedido" runat="server" CssClass="form-control" Width="100%" placeholder="Nota de Pedido"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                    <!--/span-->
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label class="control-label">Fecha Remito</label>
                                                            <dx:ASPxDateEdit ID="txtFechaRemito" runat="server" CssClass="form-control" DropDownStyle="DropDownList" EnableTheming="True" Theme="Metropolis" Width="100%" EditFormat="DateTime" AutoPostBack="false">
                                                                <TimeSectionProperties Visible="True">
                                                                </TimeSectionProperties>

                                                            </dx:ASPxDateEdit>
                                                        </div>
                                                    </div>
                                                    <!--/span-->
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label class="control-label">Código</label>
                                                            <dx:ASPxTextBox ID="txtCodigo" runat="server" CssClass="form-control" Width="100%" placeholder="Código"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/row-->
                                            </div>
                                        </form>
                                        <!-- END FORM-->
                                    </div>

                                    <!--INFO DEL CLIENTE-->
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <label style="font-size: medium"><strong>Items</strong></label>
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div class="form-group">
                                                            <dx:ASPxGridView runat="server" ID="gvItemsRemito" Width="100%" Theme="Metropolis" AutoGenerateColumns="False" EnableTheming="True">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoItemRemito" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="descripcionCorta" Caption="Desc. Corta" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="proveedor" Caption="Proveedor" VisibleIndex="2">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="precio" Caption="Precio" VisibleIndex="3">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="cantidad" Caption="Cantidad" VisibleIndex="3">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="importe" Caption="Importe" VisibleIndex="3">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                </Columns>
                                                            </dx:ASPxGridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                    <!--FIN INFO DEL CLIENTE-->
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label class="control-label">Observación</label>
                                                            <textarea id="txtObservacion" placeholder="Observación" runat="server" rows="3" class="form-control"></textarea>
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

    <script lang="javascript" type="text/javascript">
        function ShowConfirmarEliminarRemito() {
            pcConfirmarEliminarRemito.Show();
        }
    </script>
</asp:Content>

