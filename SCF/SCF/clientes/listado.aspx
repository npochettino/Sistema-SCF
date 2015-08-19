<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado.aspx.cs" Inherits="SCF.clientes.listado" %>

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
                        <h1>Clientes <small>listado de clientes</small></h1>
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
                        <a href="listado.aspx">Listado Clientes</a>
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
                                    <i class="fa fa-users"></i>Listado de Clientes
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
                                        <asp:Button type="button" ID="btnEditar" runat="server" OnClick="btnEditar_Click" UseSubmitBehavior="false" class="btn yellow" Text="Editar" />
                                        <asp:Button type="button" ID="btnEliminar" runat="server" OnClientClick="ShowConfirmarEliminarCliente()" UseSubmitBehavior="false" class="btn red" Text="Eliminar" />
                                        <asp:Button type="button" ID="btnInactivarCliente" runat="server" OnClientClick="ShowInactivarCliente()" UseSubmitBehavior="false" class="btn red-intense" Text="Inactivar" />
                                        <asp:Button type="button" ID="btnActivarCliente" runat="server" OnClick="btnActivarCliente_Click" UseSubmitBehavior="false" class="btn green" Text="Activar" />
                                    </div>
                                    <div class="btn-set pull-right">
                                        <asp:RadioButton type="radio" Text="Activo" id="rbActivoSi" GroupName="EstadoCliente" runat="server" Checked="true" AutoPostBack="true" OnCheckedChanged="rbActivoSi_CheckedChanged" />
                                        <asp:RadioButton type="radio" Text="Inactivo" id="rbActivoNo" GroupName="EstadoCliente" runat="server" AutoPostBack="true" OnCheckedChanged="rbActivoNo_CheckedChanged" />    
                                    </div>
                                </div>
                                <div class="form-body" style="height: 600px">
                                    <!-- devexpress-->
                                    
                                    <dx:ASPxGridView ID="gvClientes" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoCliente" Theme="Metropolis">
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="codigoCliente" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                <EditFormSettings Visible="False" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="razonSocial" Caption="Razon Social" VisibleIndex="1">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="provincia" Caption="Provincia" VisibleIndex="2">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="localidad" Caption="Localidad" VisibleIndex="3">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="direccion" Caption="Dirección" VisibleIndex="4">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="telefono" Caption="Teléfono" VisibleIndex="5">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="mail" Caption="Mail" VisibleIndex="6">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="cuil" Caption="CUIL" VisibleIndex="2">
                                                <Settings AutoFilterCondition="Contains" />
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
    <dx:ASPxPopupControl ID="pcConfirmarEliminarCliente" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarCliente"
        HeaderText="Eliminar Cliente" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
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
                                                ¿Desea eliminar el Cliente seleccionado?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button1" runat="server" UseSubmitBehavior="false" OnClientClick="pcConfirmarEliminarCliente.Hide();" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="btnAceptarEliminarCliente" runat="server" OnClick="btnAceptarEliminarCliente_Click" class="btn blue" Text="Aceptar" />
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="pcShowInactivarCliente" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcShowInactivarCliente"
        HeaderText="Inactivar Cliente" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
        EnableViewState="False" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  txtPrecio.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server">
                            <div>
                                <form action="#" class="horizontal-form">
                                    <div class="form-body">
                                        <label>¿Desea inactivar el Cliente seleccionado? Usted puede ingresar una observación.</label>
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
                                        <asp:Button type="button" ID="Button2" runat="server" UseSubmitBehavior="false" OnClientClick="pcShowInactivarCliente.Hide();" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="btnAceptarInactivarCliente" runat="server" OnClick="btnAceptarInactivarCliente_Click" class="btn blue" Text="Aceptar" />
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
        function ShowConfirmarEliminarCliente() {
            pcConfirmarEliminarCliente.Show();
        }
        function ShowInactivarCliente() {
            pcShowInactivarCliente.Show();
        }
    </script>
</asp:Content>

