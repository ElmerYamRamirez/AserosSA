var blazorInterop = blazorInterop || {};

blazorInterop.elmer = function () {
    return true;
};

blazorInterop.deleteSwal = function (descripcion) {
    return swal({
        title: "¿Estas seguro,",
        text: `que deseas eliminar ${descripcion}?`,
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            swal("¡Ha sido eliminado con éxito!", {
                icon: "success",
            });
            return true;
        }else {
            swal("¡Tus datos permanecen Activos!");
            return false;
        }
    });
};

blazorInterop.CancelSwal = function () {
    swal({
        title: "¿Estas seguro,",
        text: "que deseas cancelar?",
        buttons: ["No", true],
    }).then((value) => {
        if (value) {
            swal("Seras redirigido");
                //DotNet.invokeMethodAsync("Yolo_Gest_SDA_Req", "moverLista");
            }
            else {
                swal("Permanceras en la pantalla");
            }
        });
};


blazorInterop.saveSwal = function () {
    swal("¡Guardado exitosamente!", {
        icon: "success",
    });
}