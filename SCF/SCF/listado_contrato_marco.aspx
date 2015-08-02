﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado_contrato_marco.aspx.cs" Inherits="SCF.listado_contrato_marco" %>

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
                    <h1>Contratos Marco <small>listado de Contratos Marco</small></h1>
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
                    <a href="listado_contrato_marco.aspx">Listado de Contratos Marco</a>
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
                                <i class="fa fa-file"></i>Listado de Contratos Marco
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <div class="form-actions top">
                                <div class="btn-set pull-left">
                                    <asp:Button type="button" ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" class="btn blue" Text="Nuevo" />
                                    <asp:Button type="button" ID="btnEditar" runat="server" OnClick="btnEditar_Click" class="btn yellow" Text="Editar" />
                                    <asp:Button type="button" ID="btnEliminar" runat="server" OnClientClick="ShowConfirmarEliminarContratoMarco()" UseSubmitBehavior="false" class="btn red" Text="Eliminar" />
                                </div>
                                <div class="btn-set pull-right">
                                    <asp:Button type="button" ID="btnVer" runat="server" OnClick="btnVer_Click" class="btn blue" Text="Ver" />
                                </div>
                            </div>
                            <div class="form-body" style="height: 600px">
                                <!-- devexpress-->
                                <dx:ASPxGridView ID="gvContratosMarco" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableTheming="True" KeyFieldName="codigoContratoMarco" Theme="Metropolis">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="codigoContratoMarco" ReadOnly="True" Visible="False" VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcion" VisibleIndex="1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="fechaInicio" VisibleIndex="2">
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="fechaFin" VisibleIndex="3">
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataTextColumn FieldName="razonSocial" VisibleIndex="4">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="cuil" VisibleIndex="5">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <Settings ShowFilterRow="True" />
                                </dx:ASPxGridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SCFConnectionString %>" SelectCommand="SELECT CM.codigoContratoMarco,CM.descripcion,CM.fechaInicio,CM.fechaFin,C.razonSocial,C.cuil
FROM ContratosMarco CM
INNER JOIN Clientes C
ON CM.codigoCliente = C.codigoCliente "></asp:SqlDataSource>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- END CONTENT -->

    <!-- BEGIN POPUP ELIMINAR ARTICULO -->
    <dx:ASPxPopupControl ID="pcConfirmarEliminarContratoMarco" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarContratoMarco"
        HeaderText="Eliminar Contrato Marco" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
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
                                                ¿Decea eliminar el Contrato Marco seleccionado?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button1" runat="server" UseSubmitBehavior="false" OnClientClick="pcConfirmarEliminarContratoMarco.Hide();" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="btnAceptarEliminarContratoMarco" runat="server" OnClick="btnAceptarEliminarContratoMarco_Click" class="btn blue" Text="Aceptar" />
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
        function ShowConfirmarEliminarContratoMarco() {
            pcConfirmarEliminarContratoMarco.Show();
        }
    </script>
</asp:Content>


