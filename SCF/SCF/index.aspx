<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SCF.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="" name="Sitio Web desarrollado a medida para la empresa S.C.F SRL" />
    <meta content="" name="SempaIT Desarrllo de Software" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
    <link href="assets/global/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/fullcalendar/fullcalendar.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/morris/morris.css" rel="stylesheet" type="text/css">
    <!-- END PAGE LEVEL PLUGIN STYLES -->
    <!-- BEGIN PAGE LEVEL MODAL -->
    <link href="assets/global/plugins/bootstrap-modal/css/bootstrap-modal-bs3patch.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/bootstrap-modal/css/bootstrap-modal.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL MODAL -->
    <!-- BEGIN PAGE STYLES -->
    <link href="assets/admin/pages/css/tasks.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE STYLES -->
    <!-- Page level plugin styles sweetAlert -->
    <script src="assets/sweetalert-dev.js" type="text/javascript"></script>
    <script src="assets/sweetalert.min.js" type="text/javascript"></script>
    <link href="assets/sweetalert.css" rel="stylesheet" type="text/css">
    <!-- Page level plugin styles sweetAlert -->
    <!-- BEGIN THEME STYLES -->
    <!-- DOC: To use 'rounded corners' style just load 'components-rounded.css' stylesheet instead of 'components.css' in the below style tag -->
    <link href="assets/global/css/components-md.css" id="style_components" rel="stylesheet" type="text/css" />
    <link href="assets/global/css/plugins-md.css" rel="stylesheet" type="text/css" />
    <link href="assets/admin/layout4/css/layout.css" rel="stylesheet" type="text/css" />
    <link href="assets/admin/layout4/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="assets/admin/layout4/css/custom.css" rel="stylesheet" type="text/css" />
    <!-- END THEME STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- BEGIN CONTENT -->
        <div class="page-content-wrapper">
            <div class="page-content">
                <!-- BEGIN PAGE HEAD -->
                <div class="page-head">
                    <!-- BEGIN PAGE TITLE -->
                    <div class="page-title">
                        <h1>Inicio <small>reportes & estadisticas</small></h1>
                    </div>
                    <!-- END PAGE TITLE -->
                    
                </div>
                <!-- END PAGE HEAD -->
                <!-- BEGIN PAGE CONTENT INNER -->
                <div class="row margin-top-10">
                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                        <div class="dashboard-stat2">
                            <div class="display">
                                <div class="number">
                                    <h3 class="font-green-sharp">7800<small class="font-green-sharp"></small></h3>
                                    <small>NOTAS DE PEDIDO</small>
                                </div>
                                <div class="icon">
                                    <i class="icon-docs"></i>
                                </div>
                            </div>
                            
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                        <div class="dashboard-stat2">
                            <div class="display">
                                <div class="number">
                                    <h3 class="font-red-haze">1349</h3>
                                    <small>ENTREGAS</small>
                                </div>
                                <div class="icon">
                                    <i class="icon-like"></i>
                                </div>
                            </div>
                            
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                        <div class="dashboard-stat2">
                            <div class="display">
                                <div class="number">
                                    <h3 class="font-blue-sharp">567</h3>
                                    <small>CLIENTES</small>
                                </div>
                                <div class="icon">
                                    <i class="icon-users"></i>
                                </div>
                            </div>
                            
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                        <div class="dashboard-stat2">
                            <div class="display">
                                <div class="number">
                                    <h3 class="font-purple-soft">276</h3>
                                    <small>PROVEEDORES</small>
                                </div>
                                <div class="icon">
                                    <i class="icon-users"></i>
                                </div>
                            </div>
                           
                        </div>
                    </div>
                </div>
                <!-- END PAGE CONTENT INNER -->
            </div>
        </div>
        <!-- END CONTENT -->
</asp:Content>
