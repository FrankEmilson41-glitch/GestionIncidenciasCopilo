# Evidencias reales y pendientes

## Generación en Visual Studio
Proyecto: C:/Users/Emilson/source/repos/GestionIncidenciasCopilot.
WinForms clásico, .NET Framework 4.7.2, Visual Studio Insiders.
GitHub Copilot Agent, chat «hola» del proyecto, con historial de solicitudes y ediciones.

| Etapa de Copilot | Commit |
|---|---|
| Requisitos | 7cc7511 |
| Especificación de contratos y formularios | 1554f64 |
| Plan técnico y tareas T01-T08 | ea58db6 |
| Entidad, enums e interfaz de repositorio | b03e4c3 |
| Repositorio XML | ba59b9c |
| Controlador y reglas | b995abb |
| Formulario de alta y edición | c848b66 |
| Formulario de detalle y estados | aefe422 |
| Listado principal y arranque, con correcciones | 2ea2668 |
| Proyecto de pruebas | ff93e93 |
| Adaptación a pantalla y cierre | 543661f |
| Workflow CI | 00f1a4c |

## Verificación local ejecutada
MSBuild compiló aplicación y pruebas en Release. Los ocho grupos aprobaron con salida 0:

1. Alta, límites y enums.
2. Edición conserva ID y fechas UTC.
3. Transiciones válidas e inválidas.
4. Búsqueda y filtros combinados.
5. Clones no exponen el estado interno.
6. Fallo al guardar no cambia la memoria.
7. XML roundtrip y reemplazo seguro.
8. Corrupción, versión, IDs y UTC conservan archivo y bloquean guardado.

Cada grupo contiene varias aserciones. No se midió cobertura. Un primer intento encontró una restricción de acceso de la carpeta temporal del entorno controlado. Se utilizó una carpeta temporal autorizada y todos los grupos pasaron. Se volvió a probar Release tras el ajuste visual y aprobaron.

La compilación del listado detectó dos llamadas a un método renombrado. Copilot las corrigió. Se detectó además que Program debía capturar InvalidDataException explícitamente y Copilot agregó el manejo.

## Revisión visual
La ventana principal abrió y mostró encabezado, búsqueda, filtros y tabla. Editar/Detalle estaban deshabilitados sin selección. A 150 % se detectó exceso de altura. Copilot agregó ajuste a WorkingArea y desplazamiento donde corresponde. Release compiló tras ese cambio.

Verificación manual posterior: se ejecutó Release desde Visual Studio. Se rechazó título vacío y se registró la incidencia DEMO SDD - Error al iniciar sesion con prioridad Alta. Se comprobaron detalle, transiciones Pendiente a EnProceso y EnProceso a Resuelta, edición conservando ID y fecha de creación, búsqueda por descripción sin distinguir mayúsculas, filtros combinados y lista sin coincidencias. Tras cerrar y reabrir se conservaron ID, prioridad, estado y fechas. Se guardaron capturas y salida de pruebas Release. El ajuste de altura dejó accesibles las acciones inferiores. Debug permaneció bloqueado por una instancia anterior; Release permitió completar los flujos.

## GitHub comprobado y pendientes
Repositorio privado: https://github.com/FrankEmilson41-glitch/GestionIncidenciasCopilo.
Main y feature/gestor-incidencias se publicaron mediante Git integrado de Visual Studio.
PR #1 en borrador: https://github.com/FrankEmilson41-glitch/GestionIncidenciasCopilo/pull/1.
La vista del PR en Visual Studio mostró todas las comprobaciones opcionales superadas. La captura del PR incluida corresponde al momento previo, aún en ejecución. No se exportó un log remoto detallado.
Pendientes: revisión auténtica del compañero, Issues, Project/Kanban y milestone. El PR no se ha fusionado.

## TDD y Spec Kit
Las pruebas de esta implementación se escribieron después de la aplicación. No existe un ciclo rojo-verde-refactor previo documentado. Para una evolución debe definirse el nuevo criterio, generarse una prueba que falle y conservarse el resultado antes y después de implementar con Copilot.
Se consultó Spec Kit, sin afirmar uso de su CLI.


