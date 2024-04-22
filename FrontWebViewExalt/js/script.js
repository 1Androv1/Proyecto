const hamBurger = document.querySelector(".toggle-btn");

hamBurger.addEventListener("click", function () {
  document.querySelector("#sidebar").classList.toggle("expand");
});

function fillTable() {
  fetch('http://localhost:5235/api/allAlimentos')
      .then(response => response.json())
      .then(data => {
          const alimentosTable = document.getElementById('alimentosTable');
          alimentosTable.innerHTML = '';

          data.forEach(alimento => {
              const row = alimentosTable.insertRow();

              row.dataset.alimentoId = alimento.idAlimentos;

              row.insertCell(0).textContent = alimento.idAlimentos;
              row.insertCell(1).textContent = alimento.nombre;
              row.insertCell(2).textContent = alimento.descripción;
              row.insertCell(3).textContent = alimento.precio;
              row.insertCell(4).textContent = alimento.cantidadDisponible;
              
              // Obtener userData del almacenamiento local
              const userData = JSON.parse(localStorage.getItem('userData'));

              // Verificar si userData existe y tiene la propiedad 'role'
              if (userData && userData.rolId === 1) {
                // Si el usuario tiene el rol 1 (administrador), mostrar botones de eliminar y editar
                const deleteButton = document.createElement('button');
                deleteButton.textContent = 'Eliminar';
                deleteButton.classList.add('btn', 'btn-danger');
                deleteButton.addEventListener('click', function() {
                    const idAlimento = alimento.idAlimentos;
  
                    fetch(`http://localhost:5235/api/deleteAlimento/${idAlimento}`, {
                            method: 'DELETE',
                            headers: {
                                'Content-Type': 'application/json'
                            }
                        })
                        .then(response => {
                            if (response.ok) {
                                fillTable();
                            } else {
                                throw new Error('Failed to delete');
                            }
                        })
                        .catch(error => {
                            console.error('Error al eliminar alimento:', error);
                        });
                });
                row.insertCell().appendChild(deleteButton);
                
                const editButton = document.createElement('button');
                editButton.textContent = 'Editar';
                editButton.classList.add('btn', 'btn-primary', 'btn-edit');
                editButton.setAttribute('data-bs-toggle', 'modal');
                editButton.setAttribute('data-bs-target', '#exampleModal2');
                editButton.addEventListener('click', function() {
                    document.getElementById('id_producto_editar').value = alimento.idAlimentos;
                    document.getElementById('nombre_producto_editar').value = alimento.nombre;
                    document.getElementById('descripcion_producto_editar').value = alimento.descripción;
                    document.getElementById('precio_producto_editar').value = alimento.precio;
                    document.getElementById('cantidad_producto_editar').value = alimento.cantidadDisponible;
                });
                row.insertCell().appendChild(editButton);
              } else if (userData && userData.rolId === 2) {
                const buyButton = document.createElement('button');
                buyButton.textContent = 'Comprar';
                buyButton.classList.add('btn', 'btn-success', 'btn-buy');
                buyButton.setAttribute('data-bs-toggle', 'modal');
                buyButton.setAttribute('data-bs-target', '#staticBackdrop');
                
                buyButton.addEventListener('click', function() {
                  document.getElementById('nombre_producto_label').textContent = alimento.nombre;
                  document.getElementById('id_producto_compra').value = alimento.idAlimentos;


                });
                row.insertCell().appendChild(buyButton);
              } else {
                console.log("ROL: " + userData.rolId)
                console.error('Rol de usuario no válido');
              }
          });
      })
      .catch(error => {
          console.error('Error al obtener datos:', error);
      });
}



document.getElementById('crearProductoBtn').addEventListener('click', function() {
    var nombre = document.getElementById('nombre_producto').value;
    var precio = document.getElementById('precio_producto').value;
    var cantidad = document.getElementById('cantidad_producto').value;
    var descripcion = document.getElementById('descripcion_producto').value;

    var data = {
        nombre: nombre,
        descripción: descripcion,
        precio: parseFloat(precio),
        cantidadDisponible: parseInt(cantidad)
    };

    fetch('http://localhost:5235/api/saveAlimentos', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
    .then(response => {
        if (response.ok) {
            fillTableCreate();
            return response.json();
        } else {
            throw new Error('Failed to create product');
        }
    })
    .then(data => {
        console.log('Producto creado exitosamente', data);
    })
    .catch(error => {
        console.error('Error al crear producto', error);
    });
});

document.addEventListener("DOMContentLoaded", function() {
  var botonActualizarProducto = document.getElementById('actualizarProductoBtn');
  botonActualizarProducto.addEventListener('click', function() {
      actualizarProducto();
  });
});

document.addEventListener("DOMContentLoaded", function() {
  var botonActualizarProducto = document.getElementById('confirmarCompra');
  botonActualizarProducto.addEventListener('click', function() {

  });
});

function actualizarProducto() {

  var idAlimento = document.getElementById('id_producto_editar').value;
  var nombre = document.getElementById('nombre_producto_editar').value;
  var descripcion = document.getElementById('descripcion_producto_editar').value;
  var precio = document.getElementById('precio_producto_editar').value;
  var cantidad = document.getElementById('cantidad_producto_editar').value;

  fetch('http://localhost:5235/api/updateAlimentos', {
      method: 'POST',
      headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
      },
      body: JSON.stringify({
          idAlimentos: idAlimento,
          nombre: nombre,
          descripción: descripcion,
          precio: parseFloat(precio), 
          cantidadDisponible: parseInt(cantidad) 
      })
  })
  .then(response => {
      if (response.ok) {
          location.reload();
          console.log('Producto actualizado correctamente');
      } else {
          console.error('Error al actualizar el producto:', response.statusText);
      }
  })
  .catch(error => {
      console.error('Error al realizar la solicitud de actualización:', error);
  });
}




var userData = JSON.parse(localStorage.getItem('userData'));

if (userData) {
    document.getElementById('Usuario').textContent = userData.name + " " + userData.lastName;

    nombreRol = "";
    if(userData.rolId === 1){
      nombreRol = "Administrador";
    }else{
      nombreRol = "Cliente";
    }

    document.getElementById('mensaje').textContent = nombreRol + " " + "Dashboard";
    document.getElementById('Rol').textContent = nombreRol;
}

document.getElementById('confirmarCompra').addEventListener('click', function() {
  var cantidadCompra = document.getElementById('cantidad_producto_compra').value;

  if (cantidadCompra <= 0) {
      alert('La cantidad de compra debe ser mayor que cero.');
      return; 
  }

  const userData = JSON.parse(localStorage.getItem('userData'));

  var idAlimento = document.getElementById('id_producto_compra').value;

  var data = {
      idAlimentos: idAlimento,
      cantidadDisponible: cantidadCompra,
      userId: userData.idUser 
  };

  fetch('http://localhost:5235/api/comprarAlimentos', {
          method: 'POST',
          headers: {
              'accept': '*/*',
              'Content-Type': 'application/json'
          },
          body: JSON.stringify(data)
      })
      .then(response => {
          if (response.ok) {
              alert('Compra realizada con éxito');
          } else {
              alert('Error al realizar la compra. Inténtelo de nuevo.');
          }
      })
      .catch(error => {
          console.error('Error al realizar la solicitud de compra:', error);
          alert('Error al realizar la compra. Inténtelo de nuevo.');
      });
});
fillTable();
