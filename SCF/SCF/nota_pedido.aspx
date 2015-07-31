<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="nota_pedido.aspx.cs" Inherits="SCF.nota_pedido" %>

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
                    <h1>Nota de Pedido <small>editar/nueva Nota de Pedido</small></h1>
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
                    <a href="nota_pedido.aspx">Nota de Pedido</a>
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
                                <i class="fa icon-note"></i>Nota de Pedido
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">

                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <div class="form-body">
                                    <h3 class="form-section">Detalle de la Nota de Pedido</h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Nro. Interno Cliente</label>
                                                <input type="text" id="txtRazonSocial" runat="server" class="form-control" placeholder="Razón Social" required>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Fecha Emisión</label>
                                                <dx:ASPxDateEdit ID="txtFechaEmision" runat="server" CssClass="form-control" Theme="Metropolis" Width="100%" EditFormat="DateTime">
                                                    <TimeSectionProperties Visible="True">
                                                    </TimeSectionProperties>

                                                </dx:ASPxDateEdit>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <!--/row-->
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Estado de la Nota de Pedido</label>
                                                <div class="col-md-9">
                                                    <div class="radio-list">
                                                        <label class="radio-inline">
                                                            <span class="">
                                                                <input type="radio" name="optionsRadios2" value="option1" checked=""
                                                                    onclick="document.getElementById('divObservacion').style.display = 'none';"></span>

                                                            Activa
                                                        </label>
                                                        <label class="radio-inline">

                                                            <span class="checked">
                                                                <input type="radio" name="optionsRadios2" value="option2"
                                                                    onclick="document.getElementById('divObservacion').style.display = 'block';"></span>
                                                            Anulada
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6" id="divObservacion">
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Observación</label>
                                                <div class="col-md-9">
                                                    <textarea id="txtObservacion" runat="server" rows="3" class="form-control"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                        <!--/span-->

                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Cliente</label>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SCFConnectionString %>" SelectCommand="SELECT codigoCliente,razonSocial,cuil FROM Clientes"></asp:SqlDataSource>
                                                <dx:ASPxComboBox ID="cbClientes" runat="server" DropDownStyle="DropDownList" DataSourceID="SqlDataSource1" CssClass="form-control"
                                                    ValueField="codigoCliente" IncrementalFilteringMode="Contains" ValueType="System.String" TextFormatString="{0} ({1})" Width="100%" EnableTheming="True" Theme="Metropolis">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="codigoCliente" Width="100px" Visible="false" />
                                                        <dx:ListBoxColumn FieldName="cuil" Width="100px" />
                                                        <dx:ListBoxColumn FieldName="razonSocial" Width="300px" />
                                                    </Columns>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6" id="divContratoMarco">
                                            <div class="form-group">
                                                <label class="control-label">Contrato Marco</label>
                                                <dx:ASPxComboBox ID="cbContratoMarco" runat="server" DropDownStyle="DropDownList" Width="100%" CssClass="form-control" EnableTheming="True" Theme="Metropolis"></dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <!--/row-->
                                    <div class="row">
                                        <div class="col-md-12 ">
                                            <div class="form-group">
                                                <h3 class="form-section">Items Nota de Pedido</h3>
                                                <%--<label>Items Nota de Pedido</label>--%>
                                                <div class="form-actions top">
                                                    <div class="btn-set pull-left">
                                                        <dx:ASPxButton ID="btnEditarItemsNotaDePedido" runat="server" Text="Agregar/Editar" AutoPostBack="False" UseSubmitBehavior="false" CssClass="btn blue">
                                                            <ClientSideEvents Click="function(s, e) { ShowEditarItemsNotaDePedido(); }" />
                                                        </dx:ASPxButton>
                                                    </div>
                                                </div>
                                                <dx:ASPxGridView ID="gvItemNotaPedido" runat="server" Width="100%" Theme="Metropolis" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="codigoItemNotaDePedido" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                            <EditFormSettings Visible="False" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="cantidad" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="fechaEntrega" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="codigoArticulo" VisibleIndex="3">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="dercripcionCorta" VisibleIndex="4">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="descripcionLarga" VisibleIndex="5">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="marca" VisibleIndex="6">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                </dx:ASPxGridView>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="form-actions right">
                                    <button type="button" class="btn default" onclick="location.href='listado_nota_pedidos.aspx'">Cancelar</button>
                                    <asp:Button type="button" class="btn blue" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" Text="Guardar" />
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
    <dx:ASPxPopupControl ID="pcEditarItemsNotaDePedido" runat="server" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcEditarItemsNotaDePedido"
        HeaderText="Agregar/Editar Items de la Nota de Pedido" AllowDragging="True" EnableViewState="False" Width="700px"
        PopupAnimationType="Fade" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  txtCodigoInterno.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" DefaultButton="btnGuardarAticuloProveedor">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <div data-width="760">
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            Código Interno:
                                            <div class="input-group">
                                                <dx:ASPxTextBox ID="txtCodigoInterno" runat="server" CssClass="form-control" placeholder="Codigo Interno" ClientInstanceName="txtCodigoInterno"></dx:ASPxTextBox>

                                            </div>
                                            
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <dx:ASPxButton ID="btnGuardarItemsNotaDePedido" runat="server" Text="Guardar" OnClick="btnGuardarItemsNotaDePedido_Click" AutoPostBack="False" class="btn blue">
                                        <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('entryGroup')) pcEditarItemsNotaDePedido.Hide(); }" />
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="btnCancelarItemsNotaDePedido" runat="server" Text="Cancelar" AutoPostBack="False" class="btn btn-default">
                                        <ClientSideEvents Click="function(s, e) { pcEditarItemsNotaDePedido.Hide(); }" />
                                    </dx:ASPxButton>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>

            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

     <script type="text/javascript">
         function ShowEditarItemsNotaDePedido() {
             pcEditarItemsNotaDePedido.Show();
         }
    </script>

    
</asp:Content>
