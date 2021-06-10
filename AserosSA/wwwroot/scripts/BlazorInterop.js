var blazorInterop = blazorInterop || {};

blazorInterop.deleteSwal = function () {
    swal({
        title: "¿Estas seguro,",
        text: "que deseas eliminarlo?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            swal("¡Ha sido eliminado con éxito!", {
                icon: "success",
            });
        }else {
            swal("¡Tus datos permanecen Activos!");
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