<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="articulo.aspx.cs" Inherits="SCF.articulo" %>

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
                    <a href="index.aspx">Inicio</a>
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
                                        <div class="col-md-12 ">
                                            <div class="form-group">
                                                <label>Marca</label>
                                                <input type="text" id="txtMarca" placeholder="Marca" runat="server" class="form-control">
                                            </div>
                                        </div>
                                    </div>
                                    <!--/row-->
                                </div>
                                <div class="form-actions right">
                                    <button type="button" class="btn default" onclick="location.href='listado_arituclo.aspx'">Cancelar</button>
                                    <asp:Button type="button" class="btn blue" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" Text="Guardar" />
                                </div>
                            </form>
                            <!-- END FORM-->
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
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
                                        <dx:ASPxButton ID="btnNuevoArticuloProveedor" runat="server" Text="Nuevo" AutoPostBack="False" UseSubmitBehavior="false" CssClass="btn blue">
                                            <ClientSideEvents Click="function(s, e) { ShowArticuloProveedor(); }" />
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="btnEditarArticuloProveedor" runat="server" Text="Editar" OnClick="btnEditarArticuloProveedor_Click" AutoPostBack="False" UseSubmitBehavior="false" CssClass="btn yellow">
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="btnEliminarArticuloProveedor" runat="server" Text="Eliminar" OnClick="btnEliminarArticuloProveedor_Click" AutoPostBack="False" UseSubmitBehavior="false" CssClass="btn red">
                                        </dx:ASPxButton>

                                    </div>
                                </div>
                                <div class="form-body">
                                    <h3 class="form-section">Info del Proveedores</h3>
                                    <%-- Grid View del Articulo - proveedor --%>
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
                                    <div class="row">
                                        <div class="col-md-12">
                                            Código Interno:
                                            <div class="input-group">
                                                <dx:ASPxTextBox ID="txtCodigoInterno" runat="server" CssClass="form-control" placeholder="Codigo Interno" ClientInstanceName="txtCodigoInterno"></dx:ASPxTextBox>

                                            </div>
                                            <br />
                                            Proveedor:
                                            <div class="input-group">
                                                <dx:ASPxComboBox ID="cbProveedores" runat="server" DropDownStyle="DropDownList" 
                                                    ValueField="codigoProveedor" IncrementalFilteringMode="Contains" ValueType="System.String" TextFormatString="{0} ({1})" Width="100%" EnableTheming="True" Theme="Metropolis">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="codigoProveedor" Width="100px" Visible="false" />
                                                        <dx:ListBoxColumn FieldName="cuil" Width="100px" />
                                                        <dx:ListBoxColumn FieldName="razonSocial" Width="300px" />
                                                    </Columns>
                                                </dx:ASPxComboBox>
                                                <span class="input-group-btn">
                                                    <button class="btn blue" type="button" onclick="location.href='proveedor.aspx'"><span class="md-click-circle md-click-animate" style="height: 49px; width: 49px; top: -8.5px; left: -20.5px;"></span>+</button>
                                                </span>
                                            </div>
                                            <br />
                                            Precio:
                                            <div class="input-group">

                                                <div class="form-actions top">
                                                    <div class="btn-set pull-left">
                                                        <dx:ASPxButton ID="btnNuevoPrecio" runat="server" Text="Nuevo" AutoPostBack="False" UseSubmitBehavior="false" CssClass="btn blue">
                                                            <ClientSideEvents Click="function(s, e) { ShowAddPrecio(); }" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnEditarPrecio" runat="server" Text="Editar" OnClick="btnEditarPrecio_Click" AutoPostBack="False" UseSubmitBehavior="false" CssClass="btn yellow">
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnEliminarPrecio" runat="server" Text="Eliminar" OnClick="btnEliminarPrecio_Click" AutoPostBack="False" UseSubmitBehavior="false" CssClass="btn red">
                                                        </dx:ASPxButton>

                                                    </div>
                                                </div>
                                                <dx:ASPxGridView ID="gvHistorialPrecio" runat="server" Width="100%" Theme="Metropolis"></dx:ASPxGridView>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <dx:ASPxButton ID="btnGuardarArticuloProveedor" runat="server" Text="Guardar" OnClick="btnGuardarArticuloProveedor_Click" AutoPostBack="False" class="btn blue">
                                        <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('entryGroup')) pcArticuloProveedor.Hide(); }" />
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="btnCancelarArticuloProveedor" runat="server" Text="Cancelar" AutoPostBack="False" class="btn btn-default">
                                        <ClientSideEvents Click="function(s, e) { pcArticuloProveedor.Hide(); }" />
                                    </dx:ASPxButton>
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
        HeaderText="Añadir Precio" AllowDragging="True" Modal="True" PopupAnimationType="Fade"
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
                                            Precio:
                                            <div class="input-group">
                                                <dx:ASPxTextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="Codigo Interno" ClientInstanceName="txtPrecio"></dx:ASPxTextBox>

                                            </div>

                                            <div class="form-group">
                                                <label>Tipo de Cambio:</label>
                                                <div class="radio-list">
                                                    <label class="radio-inline">
                                                        <span class="checked">
                                                            <input type="radio" name="optionsRadios" id="optionsRadios4" value="option1" checked=""></span>

                                                        Peso
                                                    </label>
                                                    <label class="radio-inline">

                                                        <span class="">
                                                            <input type="radio" name="optionsRadios" id="optionsRadios5" value="option2"></span>
                                                        Dolar
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Guardar" OnClick="btnGuardarArticuloProveedor_Click" AutoPostBack="False" class="btn blue">
                                        <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('entryGroup')) pcAddPrecio.Hide(); }" />
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Cancelar" AutoPostBack="False" class="btn btn-default">
                                        <ClientSideEvents Click="function(s, e) { pcAddPrecio.Hide(); }" />
                                    </dx:ASPxButton>
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
    </script>
</asp:Content>

