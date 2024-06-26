$(document).ready(function() {
    listarLibros()
})

function listarLibros() {
    const url = 'https://localhost:44320/libros/GetAll'
    fetch(url)
    .then(response => response.json())
    .then((response) => {
        if(!response.success){
            alert('Error al consumir la api')
        }
        else {
            const cuerpoTabla = document.querySelector("tbody")
            response.data.forEach(libro => {
                const fila = document.createElement("tr")
                fila.innerHTML += `<td>${libro.titulo}</td>`
                fila.innerHTML += `<td>${libro.autor.nombre}</td>`
                fila.innerHTML += `<td>${libro.genero.nombre}</td>`
                fila.innerHTML += `<td><button type="button" class="btn btn-danger" id="btnEliminar" onclick="eliminarLibro('${libro.isbn}')">Eliminar</button></td>`
                
                cuerpoTabla.append(fila)
            });
        }
    }).catch(err => {
        alert("Algo salio mal " + err)
    })
}

function eliminarLibro(isbn) {
    const url = `https://localhost:44320/libros/DeleteLibro/${isbn}`

    fetch(url, {
        method: 'DELETE'
    })
    .then(response => response.json())
    .then(response => {
        if(response.success){
            Swal.fire({
                icon: "success",
                title: "Libro eliminado",
                showConfirmButton: false,
                timer: 1800
            });
            setTimeout(() => location.reload(), 3000)
        }
        else {
            console.log(responsel.errorMessage)
        }
    })
    .catch(error => {
        console.log(error)
    })
} 
