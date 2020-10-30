$(document).ready(() => {
    GetBooks();
    GetStudents();
    GetBooksBorrowed();
});

const formatDate = (date) => {
    var value = "";
    if (date) {
        return moment(date).format('DD/MM/YYYY')
    }
    return value;
}

const showModal = () => {
    $("#mdPrestamo").modal('show');
}

const InserBorrowedBook = () => {
    $.ajax({
        async: true,
        cache: false,
        url: '/Prestamo/LendBooks',
        type: 'POST',
        data: {
            studentBook: {
                idlibro: $("#ddlLibro").val(),
                idLector: $("#ddlLector").val()
            }
        },
        success: (data) => {
            $("#mdPrestamo").modal("hide");
            GetBooksBorrowed();
            sweetAlert("Éxito!", "Solicitud aprobada", "success");

        }, error: ({ responseJSON: message }) => {
            $("#mdPrestamo").modal("hide");
            sweetAlert("Error!", message, "error");

        }
    })
}

const GetBooksBorrowed = () => {
    $.ajax({
        type: "GET",
        url: "/Prestamo/GetBooksBorrowed",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: ({ data }) => {
            var row = "";
            var tbody = $("#libroDataTbody");
            $.each(data, (i, item) => {
                row += '<tr>';
                row += '<td>' + item.titulo + '</td>';
                row += '<td>' + item.nombre + '</td>';
                row += '<td>' + formatDate(item.fechaPrestamo) + '</td>';
                row += '<td><button class="btn btn-sm btn-info" onclick="ReturnBooks(' + item.idLector + "," + item.idLibro + ')" title="Devolver Libro">Devolver Libro</button></td>';
                row += '</tr>';
            });
            tbody.html(row);
        }
    });

}

const ReturnBooks = (idLector, idLibro) => {

    swal({
        title: "Entregar Libro",
        text: "Seguro que desea entregar el libro?",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Si, Entregar!",
        cancelButtonText: "No, cancelar !",
        closeOnConfirm: false,
        closeOnCancel: false
    },
        (isConfirm, idLec, idLib) => {
            idLec = idLector;
            idLib = idLibro;
            if (isConfirm) {
                $.ajax({
                    async: true,
                    cache: false,
                    url: '/Prestamo/ReturnBooks',
                    type: 'POST',
                    data: {
                        studentBook: {
                            idLibro: idLib,
                            idLector: idLec
                        }
                    },
                    success: () => {
                        GetBooksBorrowed();
                        sweetAlert("Exito", "Libro entregado!", "info");
                    }, error: ({ responseJSON: message }) => {
                        sweetAlert("Error!", message, "error");

                    },
                })
            } else {
                swal("Cancelled", "Cancelar :)", "error");
            }
        });

}

const GetBooks = () => {
    $.ajax({
        type: "GET",
        url: "/Libro/GetBooks",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: ({ data }) => {
            var ddlLibro = $("#ddlLibro");
            ddlLibro.empty();
            $.each(data, (i, item) => {

                ddlLibro.append("<option value=" + item.idLibro + ">" + item.titulo + "</option>");
            });

        }, error: ({ responseJSON: message }) => {
            sweetAlert("Error!", message, "error");

        }
    });
}

const GetStudents = () => {
    $.ajax({
        type: "GET",
        url: "/Estudiante/GetStudents",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function ({ data }) {
            var ddlLector = $("#ddlLector");
            ddlLector.empty();
            $.each(data, (i, item) => {

                ddlLector.append("<option value=" + item.idLector + ">" + item.nombre + "</option>");
            });

        }, error: ({ responseJSON: message }) => {
            sweetAlert("Error!", message, "error");

        }
    });
}