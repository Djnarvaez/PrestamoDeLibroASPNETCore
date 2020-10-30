$(document).ready(() => {
    GetBooks();
});
const showModal = () => {
    clearControl();
    cleanAttr();
    $('#exampleModalLongTitle').html('Nuevo Libro');
    $("#isNew").val(true);
    $("#mdLibro").modal('show');
}

const clearControl = () => {
    $("#idLibro").val('');
    $("#tituloLibro").val('');
    $("#editorialLibro").val('');
    $("#areaLibro").val('');

}

const cleanAttr = () => {
    $("#idLibro").removeAttr("readonly");
    $("#tituloLibro").removeAttr("readonly");
    $("#editorialLibro").removeAttr("readonly");
    $("#areaLibro").removeAttr("readonly");
}

const GetBooks = () => {

    $('#libroData').dataTable({
        "destroy": true,
        "ajax": "/Libro/GetBooks",
        "columns": [
            { "data": "titulo" },
            { "data": "editorial" },
            { "data": "area" },
            {
                "data": "idLibro", "render": (data) => {
                    return `<div class="btn-group" role="group">
                                    <button class="btn btn-sm btn-primary text-white fa fa-eye" onclick="GetBookById(${data}, ${false})" title="Ver"></button>
                                    <button class="btn btn-sm btn-info text-white" title="Editar" onclick="GetBookById(${data}, ${true})"><i class="fa fa-pencil"></i></button>
                                    <button class="btn btn-sm btn-danger text-white" title="Eliminar" onclick="DeleteBook(${data})"><i class="fa fa-trash"></i></button>                       
                                    <button type="button" class="btn btn-sm btn-success fa fa-users" title="Asignar Autores del libro" onclick="AssignAuthor(${data})"></button>
                                </div>`
                }
            }
        ]
    });
};

const GetBookById = (id, isEdit) => {

    $.ajax({
        async: true,
        Cache: false,
        url: "/Libro/GetBook/" + id,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: ({ data }) => {
            clearControl();
            $("#mdLibro").modal('show');
            $("#idLibro").val(data.idLibro);
            if (!isEdit) {
                $('#exampleModalLongTitle').html('Dealle Del Libro');
                $("#tituloLibro").val(data.titulo);
                $("#editorialLibro").val(data.editorial);
                $("#areaLibro").val(data.area);
                $("#btnSave").hide();
                $("#idLibro").attr("readonly", "readonly");
                $("#tituloLibro").attr("readonly", "readonly");
                $("#editorialLibro").attr("readonly", "readonly");
                $("#areaLibro").attr("readonly", "readonly");
            } else {
                $('#exampleModalLongTitle').html('Editar Libro');
                $("#tituloLibro").val(data.titulo);
                $("#editorialLibro").val(data.editorial);
                $("#areaLibro").val(data.area);
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
    const url = isNew === "true" ? "/Libro/CreateBook" : "/Libro/UpdateBook";
    $.ajax({
        async: true,
        url: url,
        type: "POST",
        data: {
            libro: {
                idLibro: $("#idLibro").val(),
                titulo: $("#tituloLibro").val(),
                editorial: $("#editorialLibro").val(),
                area: $("#areaLibro").val()
            }
        },
        success: ({ data }) => {
            $("#mdLibro").modal('hide');

            if (isNew === "true") {
                sweetAlert("Éxito!", "Registro agregado", "success");
            } else {
                sweetAlert("Éxito!", "Registro actualizado", "success");

            }
            $("#isNew").val(false);
            GetBooks();
        },
        error: ({ responseJSON: message }) => {
            sweetAlert("Error!", message, "error");
            $("#mdLibro").modal('hide');
            clearControl();
        }
    });
}

const DeleteBook = (id) => {

    swal({
        title: "Eliminar Libro",
        text: "Seguro que desea eliminar el Autor?",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Si, Eliminar!",
        cancelButtonText: "No, cancelar !",
        closeOnConfirm: false,
        closeOnCancel: false
    },
        (isConfirm, idLibro) => {
            idLibro = id;
            if (isConfirm) {
                $.ajax({
                    async: true,
                    cache: false,
                    url: '/Libro/DeleteBook/' + idLibro,
                    type: 'POST',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: () => {
                        GetBooks();
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

const AssignAuthor = (id) => {
    $("#mdLibroAutor").modal("show");
    $("#idLibroAutor").val(id);
    $.ajax({
        type: "GET",
        url: "/Autor/GetAuthors",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: ({ data }) => {
            debugger;
            var ddlAutor = $("#ddlAutor");
            ddlAutor.empty();
            $.each(data, (i, item) => {

                ddlAutor.append("<option value=" + item.idAutor + ">" + item.nombre + "</option>");
            });

        }, error: ({ responseJSON: message }) => {
            sweetAlert("Error!", message, "error");

        }
    });
}

const SaveAssignAuthor = () => {
    $.ajax({
        async: true,
        cache: false,
        url: '/Libro/AssignAuthor',
        type: 'POST',
        data: {
            libAut: {
                idlibro: $("#idLibroAutor").val(),
                idAutor: $("#ddlAutor").val()
            }
        },
        success: (data) => {
            $("#mdLibroAutor").modal("hide");
            GetBooks();
            sweetAlert("Éxito!", "Se ha asignado el autor del libro", "success");

        }, error: ({ responseJSON: message }) => {
            sweetAlert("Error!", message, "error");

        }
    })

}