# Spec-Driven Development aplicado

La especificación guía las decisiones de implementación y aceptación. La recomendación del Ing. Cartuche del 23 de octubre de 2026 requiere investigar primero y después aplicar el caso con código generado por IA.

| Fase | Aplicación en este repositorio | Evidencia |
|---|---|---|
| 1. Requerimientos | Necesidades, alcance y restricciones | [requirements.md](../../specs/001-incidencias/requirements.md), commit 7cc7511 |
| 2. Especificación | Modelo, contratos, transiciones, persistencia y formularios | [spec.md](../../specs/001-incidencias/spec.md), 1554f64 |
| 3. Plan técnico | Capas, decisiones y tareas T01-T08 | [plan.md](../../specs/001-incidencias/plan.md), ea58db6 |
| 4. Implementación | Copilot Agent en Visual Studio genera cambios por tarea | Historial real local, commits por capa y formulario |
| 5. Verificación | Compilación Release, consola de aserciones y recorridos manuales | [Verificación](../03-verificacion/VERIFICACION.md) |
| 6. Evolución | Ajustes visuales, correcciones y documentos actualizados | Commits posteriores, PR #1 y propuestas de evolución |

## Solicitudes a la IA

Aportar documento de referencia, tarea concreta, restricciones y aceptación. Ejemplo orientativo: «Implementa la edición conforme a spec.md. Conserva ID y fecha de creación. Persiste antes de confirmar éxito y comprueba el fallo de almacenamiento». No es una transcripción literal del chat.

Las solicitudes pequeñas facilitaron revisar y guardar cambios. Copilot corrigió llamadas a un método renombrado y el manejo de InvalidDataException. Los integrantes deben comprender y comprobar el código. El historial del chat del proyecto permanece en Visual Studio.

## Relación con Spec Kit

[GitHub Spec Kit](https://github.com/github/spec-kit) aporta un flujo de especificación, planificación y tareas. Se investigó como referencia. Los documentos aplican SDD, pero no prueban instalación ni ejecución de la CLI. El PDF pide investigar Spec Kit y aplicar especificaciones, no establece expresamente que se deba ejecutar su CLI.

## Próxima evolución propuesta

Para una nueva función: definir necesidad y aceptación, actualizar especificación, generar con Copilot una prueba que falle, conservar su resultado, generar implementación y volver a probar. Esto permitiría acreditar TDD en una evolución. El trabajo actual contiene pruebas posteriores al código.
