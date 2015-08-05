﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="articulo.aspx.cs" Inherits="SCF.articulos.articulo" %>

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
                    <h1>Artículo <small>editar/nuevo Artículo</small></h1>
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
                    <a href="articulo.aspx">Artículo</a>
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
                                <i class="fa fa-user"></i>Articulo
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <div class="form-body">
                                    <h3 class="form-section">Info del Articulo</h3>
                                    <div class="row">
                                        <div class="col-md-12 ">
                                            <div class="form-group">
                                                <label>Descripción Corta</label>
                                                <textarea type="text" id="txtDescripcionCorta" placeholder="Descripción Corta" runat="server" class="form-control" required rows="2"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 ">
                                            <div class="form-group">
                                                <label>Descripción Larga</label>
                                                <textarea type="text" id="txtDescripcionLarga" placeholder="Descripción Larga" runat="server" class="form-control" required rows="5"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 ">
                                            <div class="form-group">
                                                <label>Marca</label>
                                                <input type="text" id="txtMarca" placeholder="Marca" runat="server" class="form-control">
                                            </div>
                                        </div>
                                        <div class="col-md-6 ">
                                            <label>Precio:</label>
                                            <div class="input-group">
                                                <input type="text" id="txtPrecioActual" placeholder="Precio" runat="server" class="form-control">
                                                <span class="input-group-btn">
                                                    <button class="btn blue" type="button" onclick="ShowAddPrecio()"><span class="md-click-circle md-click-animate" style="height: 49px; width: 49px; top: -8.5px; left: -20.5px;"></span>+</button>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <!--/row-->
                                </div>
                                <div class="form-actions right">
                                    <button type="button" class="btn default" onclick="location.href='listado.aspx'">Cancelar</button>
                                    <asp:Button type="button" class="btn blue" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" Text="Guardar" />
                                </div>
                            </form>
                            <!-- END FORM-->
                        </div>
                    </div>
                </div>
            </div>

            <div class="row" id="divProveedores" runat="server">
                <div class="col-md-12">
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-user"></i>Proveedores
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <div class="form-actions top">
                                    <div class="btn-set pull-left">
                                        <button class="btn blue" type="button" onclick="ShowArticuloProveedor()">Nuevo</button>
                                        <asp:Button type="button" ID="btnEditarArticuloProveedor" runat="server" OnClick="btnEditarArticuloProveedor_Click" class="btn yellow" Text="Editar" />
                                        <button class="btn red" type="button" onclick="ShowConfirmarEliminarArticuloProveedor()">Eliminar</button>
                                    </div>
                                </div>
                                <div class="form-body">
                                    <h3 class="form-section">Info del Proveedores</h3>
                                    <dx:ASPxGridView ID="gvArticuloProveedores" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigo" Theme="Metropolis">
                                    </dx:ASPxGridView>
                                </div>
                                <div class="form-actions right">
                                    <asp:Button type="button" class="btn blue" runat="server" ID="btnGurdarAticuloProveedor" OnClick="btnGurdarAticuloProveedor_Click" Text="Guardar" />
                                </div>
                            </form>
                            <!-- END FORM-->
                        </div>
                    </div>
                </div>
            </div>

            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        </div>
    </div>
    <!-- END CONTENT -->

    <!-- COMIENZO DE POP UP-->
    <dx:ASPxPopupControl ID="pcArticuloProveedor" runat="server" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcArticuloProveedor"
        HeaderText="Proveedor del Artículo" AllowDragging="True" EnableViewState="False" Width="600px"
        PopupAnimationType="Fade" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  txtCodigoInterno.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" DefaultButton="btnGuardarAticuloProveedor">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <div data-width="760">
                                <div class="modal-body">

                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div class="form-group">
                                                            <label>Codigo Interno</label>
                                                            <input type="text" id="Textarea1" placeholder="Codigo Interno" runat="server" class="form-control" required />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div class="form-group">
                                                            <label>Proveedor</label>
                                                            <asp:DropDownList ID="Textarea2" placeholder="Seleccione un proveedor" runat="server" class="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div class="form-group">
                                                            <label>Cantidad</label>
                                                            <input type="text" id="Text3" placeholder="Cantidad" runat="server" class="form-control" required />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <label>Costo:</label>
                                                        <div class="input-group">
                                                            <input type="text" id="Text1" placeholder="Costo" runat="server" class="form-control" />
                                                            <span class="input-group-btn">
                                                                <button class="btn blue" type="button" onclick="ShowAddCosto()"><span class="md-click-circle md-click-animate" style="height: 49px; width: 49px; top: -8.5px; left: -20.5px;"></span>+</button>
                                                            </span>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <button class="btn default" type="button" onclick="pcArticuloProveedor.Hide()">Cerrar</button>
                                        <asp:Button type="button" ID="btnCancelarArticuloProveedor" runat="server" OnClick="btnGuardarArticuloProveedor_Click" class="btn blue" Text="Aceptar" />
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>

            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="pcAddPrecio" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcAddPrecio"
        HeaderText="Nuevo Precio" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="450"
        EnableViewState="False" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  txtPrecio.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="Panel2" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <label><strong>Agregar Precio</strong></label>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Precio:</label>
                                                            <input type="text" id="Textarea3" placeholder="Precio" runat="server" class="form-control" required />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Fecha Desde:</label>
                                                            <dx:ASPxDateEdit ID="ASPxDateEdit1" CssClass="form-control" runat="server"></dx:ASPxDateEdit>

                                                        </div>
                                                    </div>

                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label>Tipo de Cambio:</label>
                                                            <div class="radio-list">
                                                                <label class="radio-inline">
                                                                    <span class="checked">
                                                                        <input type="radio" name="optionsRadios" id="Radio1" value="option1" checked=""></span>
                                                                    Peso
                                                                </label>
                                                                <label class="radio-inline">
                                                                    <span class="">
                                                                        <input type="radio" name="optionsRadios" id="Radio2" value="option2"></span>
                                                                    Dolar
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <label><strong>Historico de Precios</strong></label>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <dx:ASPxGridView ID="gvHistoricoPrecio" runat="server" Width="100%" Theme="Metropolis" AutoGenerateColumns="False" EnableTheming="True">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="codigo" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="precio" Caption="Precio" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="fechaDesde" Caption="Fec. Desde" VisibleIndex="2">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="fechaHasta" Caption="Fec. Hasta" VisibleIndex="3">
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
                                    <div class="modal-footer">
                                        <div class="btn-set pull-right">
                                            <button class="btn default" onclick="pcAddPrecio.Hide();">Cerrar</button>
                                            <asp:Button type="button" ID="btnGuardarAddPrecio" runat="server" OnClick="btnGuardarAddPrecio_Click" class="btn blue" Text="Aceptar" />
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
    
    <dx:ASPxPopupControl ID="pcAddCosto" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcAddCosto"
        HeaderText="Nuevo Costo" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="450"
        EnableViewState="False" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  txtCosto.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <label><strong>Agregar Costo</strong></label>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Costo:</label>
                                                            <input type="text" id="Text4" placeholder="Precio" runat="server" class="form-control" required />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Fecha Desde:</label>
                                                            <dx:ASPxDateEdit ID="ASPxDateEdit2" CssClass="form-control" runat="server"></dx:ASPxDateEdit>

                                                        </div>
                                                    </div>

                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label>Tipo de Cambio:</label>
                                                            <div class="radio-list">
                                                                <label class="radio-inline">
                                                                    <span class="checked">
                                                                        <input type="radio" name="optionsRadios" id="Radio3" value="option1" checked=""></span>
                                                                    Peso
                                                                </label>
                                                                <label class="radio-inline">
                                                                    <span class="">
                                                                        <input type="radio" name="optionsRadios" id="Radio4" value="option2"></span>
                                                                    Dolar
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <label><strong>Historico de Costo</strong></label>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <dx:ASPxGridView ID="gvHistoricoCosto" runat="server" Width="100%" Theme="Metropolis" AutoGenerateColumns="False" EnableTheming="True">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="codigo" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="costo" Caption="Costo" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="fechaDesde" Caption="Fec. Desde" VisibleIndex="2">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="fechaHasta" Caption="Fec. Hasta" VisibleIndex="3">
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
                                    <div class="modal-footer">
                                        <div class="btn-set pull-right">
                                            <button class="btn default" onclick="pcAddCosto.Hide();">Cerrar</button>
                                            <asp:Button type="button" ID="btnGuardarAddCosto" runat="server" OnClick="btnGuardarAddCosto_Click" class="btn blue" Text="Aceptar" />
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

    <dx:ASPxPopupControl ID="pcConfirmarEliminarArticuloProveedor" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarArticuloProveedor"
        HeaderText="Eliminar Articulo Proveedor" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
        EnableViewState="False" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  txtPrecio.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="input-group">
                                                ¿Decea eliminar el proveedor seleccionado?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <button class="btn default" onclick="pcConfirmarEliminarArticuloProveedor.Hide();">Cerrar</button>
                                        <asp:Button type="button" ID="btnAceptarEliminarArticuloProveedor" runat="server" OnClick="btnAceptarEliminarArticuloProveedor_Click" class="btn blue" Text="Aceptar" />
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <!-- FIN DE POP UP -->

    <script type="text/javascript">
        function ShowArticuloProveedor() {
            pcArticuloProveedor.Show();
        }
        function ShowAddPrecio() {
            pcAddPrecio.Show();
            txtPrecio.focus();
        }

        function ShowAddCosto() {
            pcAddCosto.Show();
            txtCosto.focus();
        }
        function ShowConfirmarEliminarArticuloProveedor() {
            pcConfirmarEliminarArticuloProveedor.Show();
        }
    </script>
</asp:Content>

