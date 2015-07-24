<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado_proveedores.aspx.cs" Inherits="SCF.listado_proveedores" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                            <form action="#">
                                <div class="form-actions top">
                                    <div class="btn-set pull-left">
                                        <button type="submit" class="btn green">Submit</button>
                                        <button type="button" class="btn blue">Other Action</button>
                                    </div>
                                    <div class="btn-set pull-right">
                                        <button type="button" class="btn default">Action 1</button>
                                        <button type="button" class="btn red">Action 2</button>
                                        <button type="button" class="btn yellow">Action 3</button>
                                    </div>
                                </div>
                                <div class="form-body" style="height: 600px">
                                    <!-- devexpress-->
                                    <dx:ASPxGridView ID="gvProveedoes" runat="server" KeyFieldName="codigoProveedor" AutoGenerateColumns="False" EnableTheming="True" Theme="Metropolis" Width="100%">
                                        <Columns>
                                            <dx:GridViewCommandColumn Caption="razonSocial" VisibleIndex="0" Name="razonSocial">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewCommandColumn Caption="provincia" VisibleIndex="0" Name="provincia">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewCommandColumn Caption="localidad" VisibleIndex="0" Name="localidad">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewCommandColumn Caption="direccion" VisibleIndex="0" Name="direccion">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewCommandColumn Caption="telefono" VisibleIndex="0" Name="telefono">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewCommandColumn Caption="mail" VisibleIndex="0" Name="mail">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewCommandColumn Caption="cuit" VisibleIndex="0" Name="cuit">
                                            </dx:GridViewCommandColumn>
                                        </Columns>
                                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                    </dx:ASPxGridView>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
