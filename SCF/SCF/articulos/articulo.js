function OnClickAceptarCliente(s, e) {
    gvArticulos.GetRowValues(gvArticulos.GetFocusedRowIndex(), "codigoArticulo", OnCallBack);
}

function OnCallBack(s, e) {
    alert(s);
    PageMethods.InsertarActualizarArticuloCliente(s, txtCodigoClienteArticulo.GetValue(), cbClientes.GetValue(), OnSucces, OnFail);
}

function OnSucces(s, e) {
    alert(s);
}

function OnFail(s, e) {
    alert("Error");
}