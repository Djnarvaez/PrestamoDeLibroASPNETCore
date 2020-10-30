$(document).ready(() => {
    GetStudents();
});
const showModal = () => {
    clearControl();
    cleanAttr();
    $('#exampleModalLongTitle').html('Nuevo Estudiante');
    $("#isNew").val(true);
    $("#mdEstudiante").modal('show');
}

const clearControl = () => {
    $("#idLector").val('');
    $("#ciEstudiante").val('');
    $("#direccionEstudiante").val('');
    $("#carreraEstudiante").val('');
    $("#edadEstudiante").val('');
    $("#nombreEstudiante").val('');
}

const cleanAttr = () => {
    $("#idLector").removeAttr("readonly");
    $("#ciEstudiante").removeAttr("readonly");
    $("#direccionEstudiante").removeAttr("readonly");
    $("#carreraEstudiante").removeAttr("readonly");
    $("#edadEstudiante").removeAttr("readonly");
    $("#nombreEstudiante").removeAttr("readonly");
}

const GetStudents = () => {
    $('#estudianteData').dataTable({
        "destroy": true,
        "ajax": "/Estudiante/GetStudents",
        "columns": [
            { "data": "ci" },
            { "data": "nombre" },
            { "data": "direccion" },
            { "data": "carrera" },
            { "data": "edad" },
            {
                "data": "idLector", "render": (data) => {
                    return `<div class="btn-group" role="group">
                                <button class="btn btn-sm btn-primary fa fa-eye text-white" onclick="GetStudentById(${data}, ${false})" title="Ver"></button>
                                <button onclick="GetStudentById(${data}, ${true})" class="btn btn-sm btn-info fa fa-pencil text-white" title="Editar"></button>
                                <button class="btn btn-sm btn-danger fa fa-trash text-white" title="Eliminar" onclick="DeletStudentById(${data})"></button>
                                </div>`
                }
            }
        ]
    });
};

const GetStudentById = (id, isEdit) => {
    $.ajax({
        async: true,
        Cache: false,
        url: "/Estudiante/GetStudent/" + id,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: ({ data }) => {
            clearControl();
            $("#mdEstudiante").modal('show');
            $("#idLector").val(data.idLector);
            if (!isEdit) {
                $('#exampleModalLongTitle').html('Dealle Del Estudiante');

                $("#ciEstudiante").val(data.ci);
                $("#direccionEstudiante").val(data.direccion);
                $("#carreraEstudiante").val(data.carrera);
                $("#edadEstudiante").val(data.edad);
                $("#nombreEstudiante").val(data.nombre);

                $("#btnSave").hide();
                $("#idLector").attr("readonly", "readonly");
                $("#ciEstudiante").attr("readonly", "readonly");
                $("#nombreEstudiante").attr("readonly", "readonly");
                $("#direccionEstudiante").attr("readonly", "readonly");
                $("#carreraEstudiante").attr("readonly", "readonly");
                $("#edadEstudiante").attr("readonly", "readonly");

            } else {
                $('#exampleModalLongTitle').html('Editar Libro');
                $("#ciEstudiante").val(data.ci);
                $("#direccionEstudiante").val(data.direccion);
                $("#carreraEstudiante").val(data.carrera);
                $("#edadEstudiante").val(data.edad);
                $("#nombreEstudiante").val(data.nombre);
                $("#btnSave").show();
                cleanAttr();
            }

        },
        error: ({ responseJSON: message }) => {
            sweetAlert("Error!", message, "error");
        }
    });
}

const SaveOrUpdate = () => {
    var isNew = $("#isNew").val();
    const url = isNew === "true" ? "/Estudiante/CreateStudent" : "/Estudiante/UpdateStudent";
    $.ajax({
        async: true,
        url: url,
        type: "POST",
        data: {
            estudiante: {
                idLector: $("#idLector").val(),
                ci: $("#ciEstudiante").val(),
                nombre: $("#nombreEstudiante").val(),
                direccion: $("#direccionEstudiante").val(),
                carrera: $("#carreraEstudiante").val(),
                edad: $("#edadEstudiante").val()
            }
        },
        success: ({ data }) => {
            $("#mdEstudiante").modal('hide');

            if (isNew === "true") {
                sweetAlert("Éxito!", "Registro agregado", "success");
            } else {
                sweetAlert("Éxito!", "Registro actualizado", "success");

            }
            $("#isNew").val(false);
            GetStudents();
        },
        error: ({ responseJSON: message }) => {
            sweetAlert("Error!", message, "error");
            $("#mdEstudiante").modal('hide');
            clearControl();
        }
    });
}

const DeletStudentById = (id) => {

    swal({
        title: "Eliminar Estudiante",
        text: "Seguro que desea eliminar el estudiante?",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Si, Eliminar!",
        cancelButtonText: "No, cancelar !",
        closeOnConfirm: false,
        closeOnCancel: false
    },
        (isConfirm, idLector) => {
            idLector = id;
            if (isConfirm) {
                $.ajax({
                    async: true,
                    cache: false,
                    url: '/Estudiante/DeleteStudent/' + idLector,
                    type: 'POST',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: () => {
                        GetStudents();
                        sweetAlert("Exito", "Registro eliminados ", "info");
                    }, error: ({ responseJSON: message }) => {
                        sweetAlert("Error!", message, "error");

                    },
                })
            } else {
                swal("Cancelled", "Cancelar :)", "error");
            }
        });

}