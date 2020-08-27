function LoadingOverlayShow(id) {
    $(id).LoadingOverlay("show", {
        color: "rgba(255,255,255,0.5)",
        image: "/Content/loading.gif",
        imageResizeFactor: 3
    });

}

function LoadingOverlayHide(id) {
    $(id).LoadingOverlay("hide");
}

function disenoTabla(dt) {



}

function ListarUsuarios(myCallback) {
    $.ajax({
        type: "GET",
        url: '/aspnetusers/listarusuarios',
        dataType: "json",
        success: function (result) {
            $.each(result.data, function (key, item) {
                $("#UsuarioId").append('<option value=' + item.Id + '>' + item.UserName + '</option>');
            });

            if (myCallback !== undefined)
                return myCallback(result.data);
        },
        error: function (data) {
            alert('error');
        }
    });
}



function ListarRoles(myCallback) {
    $.ajax({
        type: "GET",
        url: '/aspnetroles/listarroles',
        dataType: "json",
        success: function (result) {
            $.each(result.data, function (key, item) {
                $("#RolId").append('<option value=' + item.Id + '>' + item.Name + '</option>');
            });

            if (myCallback !== undefined)
                return myCallback(result.data);
        },
        error: function (data) {
            alert('error');
        }
    });
}



//function getDistritos(myCallback) {
//    $.ajax({
//        type: "GET",
//        url: '/distrito/getdistritos',
//        dataType: "json",
//        success: function (result) {
//            $.each(result.data, function (key, item) {
//                $("#Id_Distrito").append('<option value=' + item.Id_Distrito + '>' + item.Nombre_Distrito + '</option>');
//            });

//            if (myCallback != undefined)
//                return myCallback(result.data);
//        },
//        error: function (data) {
//            alert('error');
//        }
//    });
//}


function GetProvincias(myCallback) {
    $.ajax({
        type: "GET",
        url: '/provincia/getprovincias',
        dataType: "json",
        success: function (result) {
            $.each(result.data, function (key, item) {
                $("#Id_Provincia").append('<option value=' + item.Id_Provincia + '>' + item.Nombre_Provincia + '</option>');
            });

            if (myCallback !== undefined)
                return myCallback(result.data);
        },
        error: function (data) {
            alert('error');
        }
    });
}


function GetBancos(myCallback) {
    $.ajax({
        type: "GET",
        url: '/banco/getbancos',
        dataType: "json",
        success: function (result) {
            $.each(result.data, function (key, item) {
                $("#Id_Banco").append('<option value=' + item.Id_Banco + '>' + item.Nombre_Banco + '</option>');
            });

            if (myCallback !== undefined)
                return myCallback(result.data);
        },
        error: function (data) {
            alert('error');
        }
    });
}


function GetMonedas(myCallback) {
    $.ajax({
        type: "GET",
        url: '/moneda/getmonedas',
        dataType: "json",
        success: function (result) {
            $.each(result.data, function (key, item) {
                $("#Id_Moneda").append('<option value=' + item.Id_Moneda + '>' + item.Nombre_Moneda + '</option>');
            });

            if (myCallback !== undefined)
                return myCallback(result.data);
        },
        error: function (data) {
            alert('error');
        }
    });
}


function GetGeneros(myCallback) {
    $.ajax({
        type: "GET",
        url: '/genero/getgeneros',
        dataType: "json",
        success: function (result) {
            $.each(result.data, function (key, item) {
                $("#Id_Genero").append('<option value=' + item.Id_Genero + '>' + item.Nombre_Genero + '</option>');
            });

            if (myCallback !== undefined)
                return myCallback(result.data);
        },
        error: function (data) {
            alert('error');
        }
    });
}





//function ObtenerDireccion(myCallback) {
//    $.ajax({
//        type: "GET",
//        url: '/direccion/ObtenerDireccionDetalle',
//        dataType: "json",
//        success: function (result) {
//            $.each(result.data, function (key, item) {
//                $("#Id_Direccion").append('<label value=' + item.Id_Direccion + '>' + item.DetalleDireccionCompleto_Direccion + '</label>');
//            });

//            if (myCallback != undefined)
//                return myCallback(result.data);
//        },
//        error: function (data) {
//            alert('error');
//        }
//    });
//}

