# Revisión del PDF y de la indicación del ingeniero

Fecha: 25 de octubre de 2026. Fuente: Proyecto Parcial I - PA.pdf y mensaje del Ing. Cartuche aportados por el estudiante. La guía describe una empresa hipotética y exige una propuesta, no un sistema empresarial de incidencias con alcance funcional predefinido.

## Actividad práctica obligatoria

| Punto del PDF | Resultado | Evidencia / límite |
|---|---|---|
| Repositorio GitHub | Cumplido | Repositorio existente y público |
| Proyecto simulado en C# | Cumplido | WinForms .NET Framework 4.7.2 compilado |
| Control de versiones y ramas | Cumplido | main y feature/gestor-incidencias, historial incremental |
| Pull Requests | Cumplido como creación | PR #1 abierto en borrador, integración y revisión pendientes |
| Al menos un pipeline Actions | Cumplido | Dos ejecuciones success comprobadas por API |
| Especificaciones | Cumplido | requirements.md, spec.md y plan.md versionados antes del código |
| Documentar flujo de trabajo | Cumplido | docs/04-gestion/FLUJO_DE_TRABAJO.md |

## Investigación y producto final

| Requisito | Estado | Observación |
|---|---|---|
| Git avanzado y Git Flow vs Trunk Based | Documentado | Investigación y decisión del caso |
| GitHub, PR y Code Review | Parcial | PR real, falta revisión del compañero |
| SDD y GitHub Spec Kit | Documentado | SDD aplicado, Spec Kit investigado sin CLI |
| CI/CD, build/test/deploy | Parcial en práctica | Build/test y paquete reales. Deploy explicado como propuesta, sin destino productivo |
| Copilot y prompt engineering | Realizado y documentado | Uso real en Visual Studio, historial local |
| TDD y pruebas en pipeline | Parcial en práctica | TDD investigado, pruebas posteriores al código integradas en CI |
| Issues, Projects, milestones | Investigación y plan | Falta creación remota verificable |
| Informe APA 7 con seis apartados | Base existente por revisar | Usuario hará edición final, corregir cuarta reflexión y referencias |
| Presentación de 8-12 diapositivas | Base de 12 existente | Usuario hará edición final y revisión del ejemplo práctico |
| Cuatro reflexiones | Corregidas en documento separado | La cuarta pregunta de la base anterior no coincidía con el PDF |
| Trabajo en equipo | Pendiente de acreditar revisión | Dos integrantes identificados, no se inventan contribuciones |

## Indicación complementaria del docente

Investigar SDD antes del caso y seguir requerimientos, especificación, plan, implementación con IA, verificación y evolución. Los documentos y commits conservan esa secuencia. Copilot generó la implementación en Visual Studio; Codex coordinó y documentó. Ajustes de interfaz y errores se trataron como cambios posteriores. El proceso no acredita ejecución de Spec Kit CLI ni TDD completo, porque no se realizaron.

## ¿Está terminado?

**La aplicación base está implementada y funciona en Release. La entrega académica completa todavía requiere cierre.**

- Revisión auténtica del compañero y decisión de integración del PR en main.
- Edición y aprobación final del informe y PowerPoint por los integrantes.
- Creación y uso comprobable de Issues, Project y milestone si se presentan como aplicados.
- Limpieza de temporales resuelta y verificada en 074a9fc. Se conserva prueba roja y verde en TEMPORALES.md.
- Decidir con el docente si espera ejecutar Spec Kit CLI, un ciclo TDD y deploy real: el PDF los incluye como investigación y no los detalla en la lista práctica obligatoria. No inventar evidencia para cubrir esa ambigüedad.

El estado verde de CI demuestra que pasan las comprobaciones existentes, no que toda la rúbrica esté completa. La pantalla de main solo con plantilla no representa la implementación de la rama feature pendiente de revisión.

## Actualización posterior: corrección de temporales
Nueve grupos pasan tras el arreglo. Esta evolución sí conserva evidencia de prueba fallida antes de la corrección y prueba aprobada después. No cambia el hecho de que las pruebas de la aplicación base se escribieron posteriormente al código. Los pendientes de revisión del compañero y edición final continúan.

## Actualización de gestión remota
Issues #2 a #5, Project Kanban y milestone #1 creados y vinculados. La corrección de temporales está publicada y CI aprobó nueve grupos en 61fa095. La revisión del compañero y edición final de documentos siguen pendientes. [Enlaces y estados actuales](../04-gestion/SEGUIMIENTO_GITHUB.md). Esta actualización sustituye las menciones anteriores que indicaban falta de creación remota.

## Cierre parcial del 27 de octubre de 2026

PR #1 fuera de borrador y listo para revisión. Paquete técnico de Santiago recibido y examinado; todavía no contiene su aprobación publicada. Se atendieron las tres observaciones: texto de edición, ocho casos XML y descripción del PR. Release correcto y nueve grupos aprobados; Actions del código 563a7d6 aprobado. [Evidencia y límites](CIERRE_REVISION.md). Issue #2 y PR en In review, ambos vinculados al milestone; Issue #3 sigue abierto y el milestone también. Frank entregará después los documentos finales. Esto actualiza los estados históricos anteriores sin atribuir trabajo o aprobación no realizados.
