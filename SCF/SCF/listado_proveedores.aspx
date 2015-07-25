<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado_proveedores.aspx.cs" Inherits="SCF.listado_proveedores" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <!-- BEGIN CONTENT -->
        <div class="page-content-wrapper">
            <div class="page-content">
                <!-- BEGIN PAGE HEAD -->
                <div class="page-head">
                    <!-- BEGIN PAGE TITLE -->
                    <div class="page-title">
                        <h1>Proveedores <small>listado de proveedores</small></h1>
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
                        <a href="listado_proveedores.aspx">Listado Proveedores</a>
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
                                    <i class="fa fa-users"></i>Listado de Proveedores
                                </div>
                                <div class="tools">
                                    <a href="javascript:;" class="fullscreen"></a>
                                </div>
                            </div>
                            <div class="portlet-body form">
                                <!-- BEGIN FORM-->
                                    <div class="form-actions top">
                                        <div class="btn-set pull-left">
                                            <asp:Button type="button" id="btnNuevo" runat="server" OnClick="btnNuevo_Click" class="btn blue" Text="Nuevo" />
                                            <asp:Button type="button" id="btnEditar" runat="server" OnClick="btnEditar_Click" class="btn yellow" Text="Editar" />
                                            <asp:Button type="button" id="btnEliminar" runat="server" OnClick="btnEliminar_Click" class="btn red" Text="Eliminar" />
                                        </div>
                                    </div>
                                    <div class="form-body" style="height: 600px">
                                        <!-- devexpress-->
                                        <%--<dx:ASPxGridView ID="gvProveedores" runat="server" KeyFieldName="codigoProveedor" AutoGenerateColumns="False" EnableTheming="True" Theme="Metropolis" Width="100%">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="Razón Social" VisibleIndex="1" FieldName="razonSocial" Visible="true">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Provincia" VisibleIndex="3" FieldName="provincia">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Localidad" VisibleIndex="3" FieldName="localidad">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Direccion" VisibleIndex="4" FieldName="direccion">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Telefono" VisibleIndex="5" FieldName="telefono">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Mail" VisibleIndex="6" FieldName="mail">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="CUIL" VisibleIndex="2" FieldName="cuil">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsBehavior AllowFocusedRow="True" />
                                            <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                            <Settings ShowFilterRow="True" />
                                        </dx:ASPxGridView>--%>
                                        <dx:ASPxGridView ID="gvProveedores" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableTheming="True" KeyFieldName="codigoProveedor" Theme="Metropolis">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="codigoProveedor" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="razonSocial" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="provincia" VisibleIndex="2">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="localidad" VisibleIndex="3">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="direccion" VisibleIndex="4">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="telefono" VisibleIndex="5">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="mail" VisibleIndex="6">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="cuil" VisibleIndex="7">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                            <SettingsBehavior AllowFocusedRow="True" />
                                            <Settings ShowFilterRow="True" />
                                        </dx:ASPxGridView>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SCFConnectionString %>" SelectCommand="SELECT * FROM [Proveedores]"></asp:SqlDataSource>
                                    </div>
    
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <!-- END CONTENT -->
    </form>
</asp:Content>
