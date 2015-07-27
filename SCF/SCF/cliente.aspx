<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="cliente.aspx.cs" Inherits="SCF.cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- BEGIN CONTENT -->
        <div class="page-content-wrapper">
            <div class="page-content">
                <!-- BEGIN PAGE HEAD -->
                <div class="page-head">
                    <!-- BEGIN PAGE TITLE -->
                    <div class="page-title">
                        <h1>Cliente <small>editar/nuevo Cliente</small></h1>
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
                        <a href="cliente.aspx">Cliente</a>
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
                                    <i class="fa fa-user"></i>Cliente
                                </div>
                                <div class="tools">
                                    <a href="javascript:;" class="fullscreen"></a>
                                </div>
                            </div>
                            <div class="portlet-body form">
                                <!-- BEGIN FORM-->
                                <%--<form action="#">
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
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="control-label">Text</label>
                                        <input type="text" class="form-control" placeholder="Enter text">
                                        <span class="help-block">A block of help text. </span>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label">Email Address</label>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-envelope"></i>
                                            </span>
                                            <input type="email" class="form-control" placeholder="Email Address">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label">Password</label>
                                        <div class="input-group">
                                            <input type="password" class="form-control" placeholder="Password">
                                            <span class="input-group-addon">
                                                <i class="fa fa-user"></i>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label">Left Icon</label>
                                        <div class="input-icon">
                                            <i class="fa fa-bell-o"></i>
                                            <input type="text" class="form-control" placeholder="Left icon">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label">Right Icon</label>
                                        <div class="input-icon right">
                                            <i class="fa fa-microphone"></i>
                                            <input type="text" class="form-control" placeholder="Right icon">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label">Input With Spinner</label>
                                        <input type="password" class="form-control spinner" placeholder="Password">
                                    </div>
                                    <div class="form-group last">
                                        <label class="control-label">Static Control</label>
                                        <p class="form-control-static">
                                            email@example.com
                                        </p>
                                    </div>
                                </div>
                                <div class="form-actions">
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
                            </form>--%>
                                <!-- END FORM-->
                                <!-- BEGIN FORM-->
                                <form action="#" class="horizontal-form">
                                    <div class="form-body">
                                        <h3 class="form-section">Info del Cliente</h3>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Razón Social</label>
                                                    <input type="text" id="txtRazonSocial" runat="server" class="form-control" placeholder="Razón Social" required>
                                                </div>
                                            </div>
                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">CUIL</label>
                                                    <input type="text" id="txtCUIL" runat="server" class="form-control" placeholder="Cuil" required>
                                                </div>
                                            </div>
                                            <!--/span-->
                                        </div>
                                        <!--/row-->
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Dirección</label>
                                                    <input type="text" id="txtDireccion" runat="server" class="form-control" placeholder="Direccion" required>
                                                </div>
                                            </div>
                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Teléfono</label>
                                                    <input type="text" id="txtTelefono" runat="server" class="form-control" placeholder="Telefono" required>
                                                </div>
                                            </div>
                                            <!--/span-->
                                        </div>
                                        <!--/row-->
                                        <div class="row">
                                            <div class="col-md-12 ">
                                                <div class="form-group">
                                                    <label>Email</label>
                                                    <input type="text" id="txtMail" placeholder="Mail" runat="server" class="form-control" required>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Provincia</label>
                                                    <input type="text" id="txtProvincia" runat="server" class="form-control" placeholder="Provincia" required>
                                                </div>
                                            </div>
                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Ciudad</label>
                                                    <input type="text" id="txtCiudad" runat="server" class="form-control" placeholder="Ciudad" required>
                                                </div>
                                            </div>
                                            <!--/span-->
                                        </div>
                                        <!--/row-->
                                        <%--<div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Gender</label>
                                                <select class="form-control">
                                                    <option value="">Male</option>
                                                    <option value="">Female</option>
                                                </select>
                                                <span class="help-block">Select your gender </span>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Date of Birth</label>
                                                <input type="text" class="form-control" placeholder="dd/mm/yyyy">
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>--%>
                                        <!--/row-->
                                        <%--<div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Category</label>
                                                <select class="select2_category form-control" data-placeholder="Choose a Category" tabindex="1">
                                                    <option value="Category 1">Category 1</option>
                                                    <option value="Category 2">Category 2</option>
                                                    <option value="Category 3">Category 5</option>
                                                    <option value="Category 4">Category 4</option>
                                                </select>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Membership</label>
                                                <div class="radio-list">
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" checked>
                                                        Option 1
                                                    </label>
                                                    <label class="radio-inline">
                                                        <input type="radio" name="optionsRadios" id="optionsRadios2" value="option2">
                                                        Option 2
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>--%>
                                        <!--/row-->
                                        <%--<h3 class="form-section">Address</h3>
                                    <div class="row">
                                        <div class="col-md-12 ">
                                            <div class="form-group">
                                                <label>Street</label>
                                                <input type="text" class="form-control">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>City</label>
                                                <input type="text" class="form-control">
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>State</label>
                                                <input type="text" class="form-control">
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <!--/row-->
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Post Code</label>
                                                <input type="text" class="form-control">
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Country</label>
                                                <select class="form-control">
                                                </select>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>--%>
                                    </div>
                                    <div class="form-actions right">
                                        <button type="button" class="btn default" onclick="location.href='listado_clientes.aspx'">Cancelar</button>
                                        <asp:Button type="button" class="btn blue" runat="server" ID="btnGuardar"  OnClick="btnGuardar_Click" Text="Guardar" />
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
        <script lang="javascript" type="text/javascript">

            function validate() {
                var emailExp
                emailExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/; // to validate email id

                if (document.getElementById("<%=txtRazonSocial.ClientID%>").value == "") {
                    //alert("El campo Nombre es requerido");
                    swal({ title: "<small>Razon Social incompleto</small>!", text: "Complete el campo <span style=color:#F8BB86><span> razon social.", html: true });
                    document.getElementById("<%=txtRazonSocial.ClientID%>").focus();
                    return false;
                }
                if (document.getElementById("<%=txtCUIL.ClientID%>").value == "") {
                    //alert("El campo Nombre es requerido");
                    swal({ title: "<small>CUIL incompleto</small>!", text: "Complete el campo <span style=color:#F8BB86><span> cuil.", html: true });
                    document.getElementById("<%=txtCUIL.ClientID%>").focus();
                    return false;
                }



                if ((document.getElementById("<%=txtDireccion.ClientID%>").value == "")) {
                    swal({ title: "<small>Dirección</small>!", text: "El campo <span style=color:#F8BB86><span> direccion no puede estar vacio.", html: true });
                    document.getElementById("<%=txtDireccion.ClientID%>").focus();
                    return false;
                }


                if ((document.getElementById("<%=txtTelefono.ClientID%>").value == "")) {
                    swal({ title: "<smallTeléfono</small>!", text: "El campo <span style=color:#F8BB86><span> telefono no puede estar vacio.", html: true });
                    document.getElementById("<%=txtTelefono.ClientID%>").focus();
                    return false;
                }

                if (document.getElementById("<%=txtMail.ClientID%>").value == "") {
                    //alert("El campo Nombre es requerido");
                    if (!document.getElementById("<%=txtMail.ClientID%>").value.match(emailExp)) {
                        swal({ title: "<small>Email incompleto</small>!", text: "Complete el campo <span style=color:#F8BB86><span> email.", html: true });
                        document.getElementById("<%=txtMail.ClientID%>").focus();
                    return false;
                }
            }

            if (document.getElementById("<%=txtProvincia.ClientID%>").value == "") {
                    //alert("El campo Nombre es requerido");
                    swal({ title: "<small>Provincia incompleto</small>!", text: "Complete el campo <span style=color:#F8BB86><span> provincia.", html: true });
                    document.getElementById("<%=txtProvincia.ClientID%>").focus();
                    return false;
                }

                if (document.getElementById("<%=txtCiudad.ClientID%>").value == "") {
                    //alert("El campo Nombre es requerido");
                    swal({ title: "<small>Ciudad incompleto</small>!", text: "Complete el campo <span style=color:#F8BB86><span> ciudad.", html: true });
                    document.getElementById("<%=txtCiudad.ClientID%>").focus();
                    return false;
                }
            }
        </script>

</asp:Content>
