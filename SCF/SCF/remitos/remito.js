function s() {
    var a = 0;
}

function btnGuardar_Click(s, e) {
    gvItemsEntrega.GetPageRowValues("codigoItemEntrega;codigoArticulo;codigoProveedor;spinCantidad", OnCallBack);
}

function OnCallBack(s, e) {
    PageMethods.GuardarGrilla(s, OnCallBackExito, OnCallBackFallo);
}

function OnCallBackExito() {
    alert("Guardó correctamente");
}

function OnCallBackFallo() {
    alert("Error");
}