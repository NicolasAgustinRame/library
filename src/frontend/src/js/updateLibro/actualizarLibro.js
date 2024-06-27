$(document).ready(function() {
    $('#btnBuscar').click(function() {
        buscarLibro()
    })

    $('#btnActualizar').click(function() {
        actualizarLibro()
    })

})

function buscarLibro() {
    const isbnLibro = $('#idISBN').val()
    const url = `https://localhost:44320/libros/GetById/${isbnLibro}`

    fetch(url, {headers: {Authorization: `Bearer ${token}`}})
    .then(response => response.json())
    .then(response => {
        if(!response.success){
            Swal.fire({
                icon: "error",
                title: "Libro no encontrado",
                showConfirmButton: false,
                timer: 1800
            });
            $('#idISBN').val('')
        }
        else {
            const fecha = convertDateFormat(response.data.fechaDePublicacion)
            $('#idTitulo').val(response.data.titulo)
            $('#idFechaPublicacion').val(fecha)
            console.log(response)
        }
    })
    .catch(error => {
        console.log(error)
    })
}

function actualizarLibro() {
    const url = 'https://localhost:44320/libros/UpdateLibro'
    const isbn = $('#idISBN').val()
    const titulo = $('#idTitulo').val()
    const fecha = $('#idFechaPublicacion').val()
    const token = localStorage.getItem("token")

    fetch(url, {
        method: 'PUT',
        headers: {
            Authorization: `Bearer ${token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            isbn: isbn,
            titulo: titulo,
            fechaDePublicacion: fecha
        })
    })
    .then(response => response.json())
    .then(response => {
        if(!response.success){
            console.log(response.errorMessage)
        } else {
            Swal.fire({
                icon: "success",
                title: "Libro actualizado",
                showConfirmButton: false,
                timer: 1800
            });
            $('#idISBN').val('')
            $('#idTitulo').val('')
            $('#idFechaPublicacion').val('')
        }
    })
    .catch(error => {
        console.log(error)
    })


}


function convertDateFormat(dateString) {
    const date = new Date(dateString);
    const year = date.getFullYear();
    const month = ('0' + (date.getMonth() + 1)).slice(-2);
    const day = ('0' + date.getDate()).slice(-2);
    return `${year}-${month}-${day}`;
}