<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="proveedor.aspx.cs" Inherits="SCF.proveedores.proveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">
            <!-- BEGIN PAGE HEAD -->
            <div class="page-head">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Proveedor <small>editar/nuevo proveedor</small></h1>
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
                    <a href="proveedor.aspx">Proveedor</a>
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
                                <i class="fa fa-user"></i>Proveedor
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <div class="form-body">
                                    <h3 class="form-section">Info del Proveedor</h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Nro. Proveedor</label>
                                                <input type="text" id="txtNroInternoCliente" placeholder="Nro. Proveedor" runat="server" class="form-control" required>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">CUIL</label>
                                                <input type="text" id="txtCUIL" runat="server" class="form-control" placeholder="Cuil" required>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Razón Social</label>
                                                <input type="text" id="txtRazonSocial" runat="server" class="form-control" placeholder="Razón Social" >
                                            </div>
                                        </div>
                                        <!--/span-->
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Persona de Contacto</label>
                                                <input type="text" id="txtPersonaContacto" runat="server" class="form-control" placeholder="Persona de Contacto" >
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <!--/row-->
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Dirección</label>
                                                <input type="text" id="txtDireccion" runat="server" class="form-control" placeholder="Direccion" >
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Email</label>
                                                <input type="text" id="txtMail" placeholder="Mail" runat="server" class="form-control" >
                                            </div>
                                        </div>
                                    </div>
                                    <!--/row-->
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Provincia</label>
                                                <input type="text" id="txtProvincia" runat="server" class="form-control" placeholder="Provincia" >
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Ciudad</label>
                                                <input type="text" id="txtCiudad" runat="server" class="form-control" placeholder="Ciudad" >
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <div class="row">                                       
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Teléfono</label>
                                                <input type="text" id="txtTelefono" runat="server" class="form-control" placeholder="Telefono" >
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Fax</label>
                                                <input type="text" id="txtFax" runat="server" class="form-control" placeholder="Fax" >
                                            </div>
                                        </div>
                                    </div>
                                    <h3 class="form-section">Datos Bancarios</h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Banco</label>
                                                <input type="text" id="txtBanco" placeholder="Banco" runat="server" class="form-control" >
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">CBU</label>
                                                <input type="text" id="txtCBU" runat="server" class="form-control" placeholder="CBU" >
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Nro. de Cuenta</label>
                                                <input type="text" id="txtNroCuentaBancaria" placeholder="Nro. de Cuenta Bancaria" runat="server" class="form-control" >
                                            </div>
                                        </div>                                        
                                    </div>
                                    <h3>Observación</h3>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <textarea type="text" id="txtObservacion" placeholder="Observación" runat="server" class="form-control" rows="5"></textarea>
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

