## Este documento contiene correcciones del proyecto entregado el 28-11

### Generales:
 - La solución no contiene separados los ambientes de Front End y Back End por lo que todas las funcionalidades se pueden acceder desde cualquier parte del sitio. Los administradores debían estar separados de la presentación de las notas.
 - No se cumplió el requerimiento de nube de tags.
 - No se cumplió con el requerimiento de búsqueda de notas. Solamente las lista, no se las puede filtrar.
 - No se administraron las credenciales necesarias para poder probar la aplicación.
 - Las notas debían ser visibles para todos los usuarios.
 - No se cumple el requerimiento de control de intentos de acceso.

### Proyecto Blog:

#### Usuarios
 - La aplicación muestra que es posible agregar autenticación de dos factores pero no se encuentra configurado.
 - La aplicación muestra la cantidad de accesos externos que se realizaron pero no hay ningún servicio conectado para dicha opción.

#### Notas
 - Los links que están en la descripción del perfil están rotos, no está la acción NotesCategory en el controlador Home.
 - Las notas podrían estar mejor separadas ya que no se termina de entender donde termina cada una.
 - La fecha que aparece en el detalle de las notas está mal formateada.
 - Los comentarios que se muestran en la nota son editables.
 - Luego de generar un comentario nuevo se debería redirigir al detalle de la nota, no al listado.
 - Se puede postear una nota sin título ni descripción, esto rompe la aplicación.
 - La tabla de edición de notas no está clara.

#### Comentarios
 - Hay un título incorrecto en la edición de comentarios.
 - El usuario que se muestra en el listado de los comentarios no es amigable, no se sabe a qué usuario se refiere.

### Proyecto Blog.Contrats:

 - Typo en el nombre del proyecto.
 - En los contratos se utilizan mal las palabras para expresar las acciones.

### Proyecto Blog.DataAccess:

 - Cuenta con una clase que no se utiliza.

### Proyecto Blog.Services:

 - Typo en variables.
 - En varios métodos se devuelve siempre true, incluso si el guardado falla.

## **Nota Final: 6**