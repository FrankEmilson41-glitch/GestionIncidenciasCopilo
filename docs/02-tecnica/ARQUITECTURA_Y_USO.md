# Arquitectura y manual de uso

## Organización

| Carpeta | Responsabilidad |
|---|---|
| GestionIncidenciasCopilot/Entidades | Incidencia, Prioridad y EstadoIncidencia |
| GestionIncidenciasCopilot/Controladores | Validaciones, filtros, transiciones y coordinación de persistencia |
| GestionIncidenciasCopilot/Datos | IRepositorioIncidencias y repositorio XML |
| GestionIncidenciasCopilot/Formularios | Presentación y eventos. Los archivos Designer.cs conservan edición visual |
| Pruebas | Verificador de contratos del controlador y repositorio |

No se mueven los proyectos a otra carpeta para evitar romper referencias y diseñadores. La documentación se agrupa en docs y las especificaciones permanecen en specs como fuente original.

## Operación

Abrir la solución en Visual Studio 2026, seleccionar Release e iniciar GestionIncidenciasCopilot. En FrmPrincipal, Nueva incidencia abre el registro. Título obligatorio hasta 120 caracteres y descripción opcional hasta 2000. Seleccionar prioridad y Guardar. Editar y Detalle requieren una fila seleccionada.

La búsqueda consulta título y descripción sin distinguir mayúsculas y se combina con prioridad y estado. Todas elimina el filtro correspondiente. Sin coincidencias el listado queda vacío.

Estados permitidos: Pendiente a EnProceso, EnProceso a Resuelta y Resuelta a EnProceso. No se permite saltar de Pendiente directamente a Resuelta. Editar conserva ID y creación y actualiza la fecha UTC.

## Datos y errores

Archivo: `%LOCALAPPDATA%/GestionIncidenciasCopilot/incidencias.xml`. Ausencia inicia una colección vacía. Corrupción o formato no admitido informa error y bloquea escritura. Se escribe un temporal y se promueve mediante Move o File.Replace. Los cambios se confirman en memoria después de guardar.

No editar el XML mientras la aplicación está abierta. El prototipo es de una sola instancia local, sin autenticación. La limpieza de temporales propios tras fallos se corrigió en 074a9fc y cuenta con una prueba de destino bloqueado. Si el propio borrado no es posible, se mantiene el error original del guardado.

## Configuración verificada

C# y .NET Framework 4.7.2, Windows Forms. Release compilado y ejecutado. Una instancia anterior bloqueó Debug durante una verificación; no se presenta Debug como comprobado. Form1 era una plantilla sin uso y el estudiante la retiró, conservando el arranque en FrmPrincipal.
