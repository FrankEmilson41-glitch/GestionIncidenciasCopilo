# Plan técnico — 001-incidencias

## Arquitectura y compatibilidad

- Mantener Windows Forms, .NET Framework 4.7.2 y C# compatible con el proyecto clásico existente.
- Capas y responsabilidades: `Entidades` (`Incidencia`, `Prioridad`, `EstadoIncidencia`); `Datos` (`IRepositorioIncidencias`, `RepositorioXmlIncidencias`); `Controladores` (`ControladorIncidencias`, validación y reglas); `Formularios` (presentación y eventos). Formularios no acceden directamente al archivo.
- Registrar archivos/clases en el `.csproj` clásico. Evitar dependencias de paquetes externos.

## Persistencia XML segura

- Guardar en ruta local configurable; definir estructura XML versionada y validar todo el documento antes de aceptarlo.
- Crear temporal único en el mismo directorio; escribir documento completo, `Flush(true)` y cerrar antes de promoverlo.
- Primera escritura: mover temporal al destino. Actualización: reemplazar con `File.Replace`; no borrar destino previamente ni sobrescribirlo mediante fallback directo.
- Si leer, validar, escribir o reemplazar falla, propagar error y conservar destino original. Nunca interpretar corrupción como colección vacía ni guardar tras fallo de carga.
- Fechas UTC: ISO 8601 con `Z`; rechazar fechas sin zona, valores inválidos, estados/prioridades desconocidos e IDs duplicados.

## Interfaz WinForms

- `FrmPrincipal.cs` + `FrmPrincipal.Designer.cs`: `DataGridView`, búsqueda, filtros de prioridad/estado, botones nueva/editar/detalle.
- `FrmIncidencia.cs` + `FrmIncidencia.Designer.cs`: alta/edición, título, descripción, prioridad, validación y guardar/cancelar.
- `FrmDetalle.cs` + `FrmDetalle.Designer.cs`: datos de solo lectura, fechas y acción con transiciones de estado válidas.
- Mantener controles y disposición editables desde el diseñador; lógica de eventos delega en controlador. Mensajes y textos en español.

## Pruebas y CI

- Crear proyecto ejecutable de consola de pruebas, sin framework ni dependencias externas; referenciar la aplicación o las capas pertinentes. Aserciones propias con salida legible y código de salida distinto de cero ante fallo.
- Usar repositorio XML con rutas temporales aisladas: validar altas/ediciones, límites, enums, transiciones, IDs, UTC, recarga y conservación de archivo corrupto ante carga/escritura fallida.
- Probar búsqueda/filtros y reglas del controlador. Eliminar solo temporales creados por cada prueba.
- Pruebas manuales en Visual Studio: abrir los tres formularios en diseñador, revisar controles/propiedades, ejecutar flujos de alta, edición, filtros, detalle, cambios de estado, reinicio y mensajes de error.
- CI en GitHub Actions sobre `windows-latest`: checkout, localizar MSBuild, compilar aplicación y ejecutable de pruebas con MSBuild, ejecutar pruebas y fallar el job ante error. No incluir pasos que instalen dependencias de terceros.

## Tareas de implementación

| Tarea | Entregable |
|---|---|
| T01 | Entidades, enums y reglas UTC básicas. |
| T02 | Contrato del repositorio y persistencia XML validada. |
| T03 | Escritura temporal, reemplazo seguro y protección ante corrupción. |
| T04 | Controlador: validaciones, IDs, búsqueda/filtros y transiciones. |
| T05 | `FrmPrincipal` con diseñador, tabla, búsqueda y filtros. |
| T06 | `FrmIncidencia` y `FrmDetalle` con archivos Designer y flujos. |
| T07 | Consola de pruebas automatizadas; casos positivos y de error. |
| T08 | Workflow CI Windows/MSBuild y verificación manual de diseñadores. |

## Matriz de trazabilidad RF / CA / prueba

| Requisito | Aceptación | Prueba prevista |
|---|---|---|
| RF-01–04 | CA-01–05 | P01 alta; P02 título/límites; P03 prioridad/estado inicial. |
| RF-05 | CA-06 | P04 editar y comprobar ID/fechas/datos. |
| RF-06 | CA-07 | P05 listado y detalle; manual diseñador. |
| RF-07–08 | CA-08 | P06 búsqueda y filtros combinados. |
| RF-09 | CA-09–10 | P07 transiciones permitidas y rechazo de inválidas. |
| RF-10 | CA-11 | P08 persistencia XML tras recarga/reinicio. |
| RF-11–12 | CA-12–13 | P09 XML corrupto, IDs repetidos y archivo intacto. |
| RF-10 | CA-14 | P10 simular fallo de escritura y verificar error/no éxito. |
