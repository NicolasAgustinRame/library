$(document).ready(function() {
    $('#formNuevoLibro').validate({
        rules: {
            isbn: {
                required: true
            },
            titulo: {
                required: true
            },
            autor: {
                required: true
            },
            genero: {
                required: true
            },
            fechaPublicacion: {
                required: true
            }
        },
        messages: {
            isbn: {
                required: 'Ingrese ISBN'
            },
            titulo: {
                required: "Ingrese TITULO"
            },
            autor: {
                required: "Ingrese AUTOR"
            },
            genero: {
                required: "Ingrese GENERO"
            },
            fechaPublicacion: {
                required: "Ingrese FECHA DE PUBLICACION"
            }
        },
        errorClass: "text-danger mt-2"
    })

    $('#btnRegistrar').click(function() {
        if($('#formNuevoLibro').valid()){
            postLibro();
            setTimeout(function() {
                $(location).attr('href', 'http://127.0.0.1:5500/index.html')
            }, 3000);
        }
    })
})

function postLibro() {
    const url = 'https://localhost:44320/libros/PostLibro'
    const isbn = $('#idISBN').val()
    const titulo = $('#idTitulo').val()
    const autor = $('#idAutor').val()
    const genero = $('#idGenero').val()
    const fecha = $('#idFechaPublicacion').val()

    fetch(url, {
        method: 'POST',
        headers: {
            "Content-Type":"application/json"
        },
        body: JSON.stringify({
            isbn: isbn,
            titulo: titulo,
            autor: autor,
            fechaDePublicacion: fecha,
            genero: genero
        })
    })
    .then(response => response.json())
    .then(response => {
        if(response.success){
            Swal.fire({
                icon: "success",
                title: "Libro registrado",
                showConfirmButton: false,
                timer: 1800
            });
        }
        else {
            console.log(response.errorMessage)
        }
    })
    .catch(error => {
        console.log(error)
    })


}