﻿function OnClickAceptarDireccion(s, e) {
    gvClientes.GetRowValues(gvClientes.GetFocusedRowIndex(), "codigoCliente", OnCallBackDireccionCliente);
}

function OnCallBackDireccionCliente(s, e) {
    PageMethods.InsertarActualizarDireccionCliente(s, txtProvincia.GetValue(), txtLocalidad.GetValue(),txtDireccion.GetValue(), OnSucces, OnFail);
    pcNuevaRelacionDireccionCliente.Hide();
    pcRelacionDireccionCliente.Hide();
}

function OnSucces(s, e) {
    alert("Se ha guardado la direccion correctamente");
}

function OnFail(s, e) {
    alert("Error en guardar la direccion");
}