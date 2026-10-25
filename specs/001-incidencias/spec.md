# Especificación — Gestor de incidencias

**ID:** 001-incidencias · **Base:** `requirements.md` · **Estado:** Para revisión  
**Plataforma:** Windows Forms, .NET Framework 4.7.2; C# compatible con el proyecto.

## 1. Modelo y contratos

`Incidencia` contiene `Id` (GUID), `Titulo`, `Descripcion`, `Prioridad`, `Estado`, `FechaCreacionUtc` y `FechaActualizacionUtc`. Enums: `Prioridad` = Baja/Media/Alta; `EstadoIncidencia` = Pendiente/EnProceso/Resuelta. Título recortado, requerido y máximo 120; descripción opcional, máximo 2000.

Los contratos siguientes expresan comportamiento esperado, no código de aplicación.

### `ControladorIncidencias`

- `ObtenerTodas() -> IReadOnlyList<Incidencia>`: devuelve una copia/lista no modificable de los datos cargados; propaga errores de almacenamiento.
- `Buscar(texto, prioridad?, estado?) -> IReadOnlyList<Incidencia>`: aplica conjuntamente filtros opcionales y búsqueda sin distinción de mayúsculas en título/descripción; texto vacío no restringe.
- `ObtenerPorId(id) -> Incidencia o no encontrado`: no modifica datos.
- `Crear(titulo, descripcion, prioridad) -> Incidencia`: valida; asigna ID nuevo, Pendiente y ambas fechas UTC actuales; persiste antes de confirmar éxito.
- `Editar(id, titulo, descripcion, prioridad) -> Incidencia`: valida; conserva ID/fecha de creación, actualiza fecha UTC y persiste; error no se presenta como éxito.
- `CambiarEstado(id, destino) -> Incidencia`: solo permite Pendiente→EnProceso, EnProceso→Resuelta y Resuelta→EnProceso; actualiza fecha UTC y persiste. Rechaza transiciones inválidas sin alterar datos.
- Toda entrada de prioridad/estado debe pertenecer a su enum definido. Errores de validación, ausencia de ID y fallos de datos deben distinguirse y comunicarse a la interfaz.

### `IRepositorioIncidencias` / implementación XML local

- `Cargar() -> IReadOnlyList<Incidencia>`: archivo ausente significa colección vacía; archivo presente se parsea y valida completo antes de exponer datos. XML inválido, campos inválidos o IDs repetidos producen error explícito; no se reemplaza ni modifica el archivo.
- `Guardar(incidencias) -> éxito/error`: valida unicidad/validez antes de escribir. Escribe XML completo a un temporal único en el mismo directorio, vacía buffers (`Flush(true)`) y cierra; si el destino no existe, mueve el temporal; si existe, usa `File.Replace` para reemplazo seguro compatible con .NET Framework 4.7.2. No borrar destino antes del reemplazo ni usar fallback que lo sobrescriba directamente. Si reemplazar falla, conservar destino intacto, informar error y eliminar temporal solo si es seguro.
- XML versionado, con un elemento por incidencia y campos explícitos para ID, texto, enums y fechas. Cualquier versión/estructura no admitida se reporta como error; nunca se trata un archivo ilegible como vacío.
- Fallo de carga/integridad bloquea escrituras durante la sesión para evitar perder el archivo original. El error se propaga hasta la interfaz.

## 2. Fechas y consistencia

- Obtener tiempo actual exclusivamente en UTC; ambas fechas se guardan como `DateTime` con `Kind.Utc`.
- Serializar fecha/hora ISO 8601 UTC con sufijo `Z`; al cargar, validar formato y recuperar `Kind.Utc`. Rechazar fechas inválidas o sin zona horaria.
- Al crear, creación y actualización usan el mismo instante UTC. Editar o cambiar estado actualiza solo actualización; nunca debe ser anterior a creación.
- El controlador confirma alta/edición/transición solo después de que el repositorio guarda correctamente. Ante error, informa fallo y no anuncia persistencia.

## 3. Formularios y comportamiento

### `FrmPrincipal`

- `DataGridView` de solo lectura con ID, título, prioridad, estado, fecha de creación y actualización; acciones visibles para nueva incidencia, editar y ver detalle.
- Caja de búsqueda, selector de prioridad y selector de estado; opciones “Todas”/vacío eliminan el filtro correspondiente. Reaplicar criterios en conjunto al cambiar controles.
- Abrir detalle/edición sobre la fila seleccionada; sin selección, deshabilitar acciones dependientes. Mostrar lista vacía cuando no hay coincidencias y mensajes en español para errores de datos.

### `FrmIncidencia`

- Modo nuevo/edición; controles: título, descripción multilínea, prioridad Baja/Media/Alta, botones Guardar y Cancelar.
- No permite escoger estado al crear. En edición muestra estado y fechas como solo lectura; ID/creación no editables.
- Validar y delegar en controlador; errores señalan el campo y mantienen el formulario abierto. Cerrar con resultado correcto solo tras guardar.

### `FrmDetalle`

- Presenta ID, título, descripción, prioridad, estado y fechas, sin edición directa del texto.
- Acción de estado ofrece solo destinos válidos para el estado actual; al confirmar delega en controlador y actualiza la vista únicamente tras éxito. Transición inválida o error se informa sin fingir cambio.
- Acceso a editar abre `FrmIncidencia` en modo edición; volver/cerrar retorna al listado actualizado.

Todos los controles se disponen en diseñador WinForms editable; interfaz, etiquetas y mensajes en español. Persistencia y reglas de negocio permanecen fuera de los formularios.
