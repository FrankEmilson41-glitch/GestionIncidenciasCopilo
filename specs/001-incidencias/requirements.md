# Requisitos — Gestor de incidencias

**Identificador:** 001-incidencias  
**Estado:** Borrador para revisión  
**Producto:** Aplicación de escritorio para gestionar incidencias de software  
**Usuarios del proyecto:** Dos estudiantes  

## 1. Propósito y contexto

La aplicación busca ayudar a una empresa de software en Ecuador que pierde versiones, trabaja de forma desorganizada, encuentra errores en producción y carece de documentación y automatización. Permitirá registrar y consultar incidencias en una aplicación local de escritorio. El trabajo académico deberá poder evidenciar el uso de Git/GitHub, ramas, pull requests, revisión entre compañeros, GitHub Actions, Copilot, GitHub Spec Kit, TDD e Issues/Projects/Milestones; estos elementos describen el proceso del proyecto y no son funcionalidades internas de la aplicación.

## 2. Alcance

### Incluido

- Aplicación de escritorio Windows Forms, conservando .NET Framework 4.7.2 y compatibilidad con el C# configurado en el proyecto.
- Registro, edición y consulta de incidencias.
- Listado en `FrmPrincipal` mediante `DataGridView`, búsqueda y filtros.
- Formularios `FrmIncidencia` para registrar o editar y `FrmDetalle` para consultar y cambiar el estado.
- Separación conceptual en Entidades, Controladores, Datos y Formularios.
- Persistencia local entre ejecuciones.
- Validación de las reglas de negocio antes de aceptar los cambios.

### Fuera del alcance inicial

- Sincronización entre equipos, uso de servicios en la nube o almacenamiento compartido.
- Autenticación, roles, asignación de responsables, comentarios, adjuntos, notificaciones o reportes.
- Integración con herramientas externas de seguimiento de incidencias.
- Eliminación de incidencias, salvo que se acuerde posteriormente como evolución.

## 3. Entidad de incidencia

Cada incidencia deberá contener, como mínimo:

| Campo | Requisito |
|---|---|
| ID | Identificador único, asignado por la aplicación y estable durante la vida de la incidencia. |
| Título | Obligatorio; tras quitar espacios al inicio y al final, no puede estar vacío; máximo 120 caracteres. |
| Descripción | Texto opcional; máximo 2000 caracteres. |
| Prioridad | Uno de los valores Baja, Media o Alta. |
| Estado | Uno de los valores Pendiente, EnProceso o Resuelta; al crear una incidencia se asigna Pendiente. |
| Fecha de creación | Fecha y hora asignadas al registrar la incidencia y conservadas al editarla. |
| Fecha de actualización | Fecha y hora de la última edición o cambio de estado; debe actualizarse cuando ocurra cualquiera de esas acciones. |

## 4. Requisitos funcionales

### RF-01 — Registrar incidencia

El usuario podrá registrar una incidencia indicando título, descripción y prioridad. La aplicación validará los campos, asignará un ID único, establecerá el estado inicial Pendiente y registrará las fechas correspondientes. Si los datos no son válidos, no guardará la incidencia y mostrará un mensaje comprensible.

### RF-02 — Validar título y descripción

El título será obligatorio y tendrá como máximo 120 caracteres. La descripción podrá quedar vacía y tendrá como máximo 2000 caracteres. Los límites se comprobarán después de normalizar los espacios externos del título, sin exceder los máximos indicados.

### RF-03 — Asignar y validar prioridad

Cada incidencia tendrá exactamente una prioridad válida: Baja, Media o Alta. No se aceptarán valores distintos de los enumerados.

### RF-04 — Asignar y validar estado inicial

Toda incidencia nueva comenzará en estado Pendiente. El formulario de registro no permitirá crearla directamente en otro estado.

### RF-05 — Editar incidencia

El usuario podrá modificar los datos editables de una incidencia existente. La edición conservará el ID y la fecha de creación, validará nuevamente título, descripción y prioridad, actualizará la fecha de actualización y persistirá el cambio.

### RF-06 — Listar y consultar incidencias

La pantalla principal mostrará las incidencias guardadas en una tabla `DataGridView`, incluyendo información suficiente para distinguirlas y reconocer su prioridad, estado y fechas. El usuario podrá abrir una incidencia para consultar su detalle.

### RF-07 — Buscar incidencias

El usuario podrá buscar incidencias por texto en título o descripción. La búsqueda no distinguirá mayúsculas de minúsculas y actualizará el listado para mostrar las coincidencias; una búsqueda vacía mostrará todas las incidencias que cumplan los filtros activos.

### RF-08 — Filtrar incidencias

El usuario podrá limitar el listado por prioridad y por estado. Cada filtro podrá dejarse sin seleccionar para no restringir por ese criterio. La búsqueda y los filtros podrán aplicarse conjuntamente.

### RF-09 — Cambiar estado conforme a las transiciones permitidas

Desde la consulta de detalle, el usuario podrá cambiar el estado solamente mediante estas transiciones:

- Pendiente → EnProceso.
- EnProceso → Resuelta.
- Resuelta → EnProceso.

Un estado no podrá cambiarse a sí mismo ni a un destino distinto de los indicados. Al confirmar una transición válida, la aplicación actualizará la fecha de actualización y guardará el cambio. Si la transición no es válida, el estado persistido permanecerá sin cambios y se informará al usuario.

### RF-10 — Persistir datos localmente

Las incidencias registradas, editadas o actualizadas se guardarán en almacenamiento local para que sigan disponibles después de cerrar y volver a iniciar la aplicación. La aplicación informará de errores de lectura o escritura; no comunicará un guardado exitoso si este no se completó.

### RF-11 — Proteger datos ante almacenamiento corrupto

Si el archivo local existe pero no puede leerse o validarse por estar corrupto o tener un formato inválido, la aplicación no lo sobrescribirá ni lo reemplazará silenciosamente con una colección vacía. Conservará intacto el archivo problemático, informará del error y no ejecutará operaciones que impliquen guardar sobre ese archivo hasta que el usuario pueda recuperar los datos o resolver el problema. La recuperación automática de registros corruptos no forma parte del alcance inicial.

### RF-12 — Mantener identificadores únicos

La aplicación no asignará el mismo ID a dos incidencias. La unicidad deberá mantenerse al crear registros y al cargar los datos existentes. Si los datos persistidos contienen IDs duplicados o inválidos, se tratará como un error de integridad: se informará al usuario y no se sobrescribirá el archivo afectado.

## 5. Requisitos no funcionales

### RNF-01 — Compatibilidad

La solución deberá conservar Windows Forms sobre .NET Framework 4.7.2 y emplear sintaxis y APIs compatibles con la versión de C# configurada en el proyecto. No se migrará a .NET moderno ni a otro tipo de interfaz.

### RNF-02 — Organización por capas

La solución deberá mantener separadas las responsabilidades de Entidades, Controladores, Datos y Formularios. Las validaciones y transiciones de negocio no deberán depender exclusivamente de controles de interfaz, y los formularios no deberán implementar directamente la persistencia.

### RNF-03 — Usabilidad y lenguaje

La interfaz y los mensajes visibles al usuario estarán en español. Los formularios utilizarán controles WinForms y permanecerán editables mediante el diseñador de Visual Studio; el diseño no dependerá de generar toda la interfaz exclusivamente en tiempo de ejecución.

### RNF-04 — Consistencia de datos

Las operaciones deberán preservar las reglas de validación, la unicidad de IDs, las fechas y las transiciones permitidas tanto antes de guardar como al recuperar datos locales. Un error de persistencia no deberá presentarse como éxito.

### RNF-05 — Trazabilidad y mantenibilidad

Los requisitos y su verificación deberán poder relacionarse mediante identificadores RF/RNF y escenarios de aceptación. El diseño deberá ser comprensible para dos estudiantes que trabajan con control de versiones y revisión entre compañeros.

## 6. Criterios de aceptación (Given / When / Then)

### CA-01 — Alta válida

**Given** que el usuario abre el formulario de nueva incidencia y proporciona un título válido, una descripción dentro del límite y una prioridad válida  
**When** confirma el registro  
**Then** la aplicación crea una incidencia con ID único, estado Pendiente, fecha de creación y fecha de actualización, y la muestra en el listado.

### CA-02 — Título obligatorio

**Given** que el formulario de nueva incidencia está abierto  
**When** el usuario deja el título vacío o compuesto únicamente por espacios y confirma  
**Then** la aplicación muestra una validación, no guarda la incidencia y permite corregir el dato.

### CA-03 — Límites de longitud

**Given** que el usuario ingresa un título de más de 120 caracteres o una descripción de más de 2000  
**When** intenta guardar la incidencia  
**Then** la aplicación rechaza el registro o la edición, indica el campo inválido y conserva los datos previamente guardados.

### CA-04 — Prioridad admitida

**Given** que el usuario registra o edita una incidencia  
**When** selecciona Baja, Media o Alta y guarda los datos válidos  
**Then** la incidencia conserva exactamente la prioridad seleccionada; ningún valor fuera de esas opciones es aceptado.

### CA-05 — Estado inicial

**Given** que el usuario registra una incidencia nueva  
**When** el registro se completa correctamente  
**Then** su estado inicial es Pendiente.

### CA-06 — Edición conserva identidad y creación

**Given** que existe una incidencia guardada  
**When** el usuario edita y guarda sus datos con valores válidos  
**Then** el ID y la fecha de creación permanecen iguales, la fecha de actualización cambia y los nuevos datos quedan guardados.

### CA-07 — Listado y detalle

**Given** que existen incidencias guardadas  
**When** el usuario abre la pantalla principal y selecciona una incidencia  
**Then** el listado las muestra en un `DataGridView` y la vista de detalle presenta los datos de la incidencia seleccionada.

### CA-08 — Búsqueda combinada con filtros

**Given** que existen incidencias con títulos, descripciones, prioridades y estados diferentes  
**When** el usuario escribe un texto de búsqueda y selecciona filtros de prioridad o estado  
**Then** el listado muestra únicamente las incidencias que coinciden con el texto en título o descripción y cumplen todos los filtros seleccionados; al limpiar el texto o un filtro se amplían los resultados correspondientes.

### CA-09 — Transiciones de estado válidas

**Given** que una incidencia está Pendiente, EnProceso o Resuelta  
**When** el usuario solicita, respectivamente, Pendiente → EnProceso, EnProceso → Resuelta o Resuelta → EnProceso  
**Then** la aplicación acepta la transición, actualiza la fecha de actualización y persiste el nuevo estado.

### CA-10 — Transición de estado inválida

**Given** que una incidencia está guardada en un estado determinado  
**When** el usuario solicita una transición que no está en la lista permitida  
**Then** la aplicación rechaza el cambio, conserva el estado persistido y comunica que la transición no está permitida.

### CA-11 — Persistencia tras reinicio

**Given** que se registró o modificó una incidencia y el guardado terminó correctamente  
**When** se cierra y vuelve a iniciar la aplicación  
**Then** la incidencia aparece con sus datos, ID, estado y fechas guardados.

### CA-12 — Archivo local corrupto

**Given** que el archivo de datos existe y no puede interpretarse o validarse  
**When** la aplicación intenta cargarlo  
**Then** informa del error, conserva el archivo original sin modificar y no lo reemplaza automáticamente por datos vacíos.

### CA-13 — IDs repetidos en datos existentes

**Given** que el archivo local contiene IDs duplicados o inválidos  
**When** la aplicación intenta cargar los datos  
**Then** informa del error de integridad y no sobrescribe el archivo afectado.

### CA-14 — Error al guardar

**Given** que ocurre un error al escribir los datos locales  
**When** el usuario registra, edita o cambia el estado de una incidencia  
**Then** la aplicación comunica que el guardado falló y no presenta la operación como persistida correctamente.

## 7. Supuestos y decisiones pendientes

- La descripción es opcional porque solo se definió un límite máximo; no se estableció un mínimo.
- La búsqueda aplica a título y descripción, como criterio funcional inicial para encontrar incidencias.
- Los controles exactos para presentar fechas y el formato del almacenamiento local se decidirán en la especificación y el plan técnico, sin alterar estas reglas.
- La aplicación es local y de un solo usuario en el alcance inicial; no se requiere resolver escrituras simultáneas desde varias instancias.
- El tratamiento definido para un archivo corrupto prioriza conservarlo y reportar el problema; no se presupone que la aplicación pueda recuperar automáticamente su contenido.
