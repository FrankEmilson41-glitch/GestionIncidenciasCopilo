# Investigación y aplicación de los siete bloques

El caso es hipotético. No se atribuyen mejoras cuantitativas a una empresa real.

| Bloque | Análisis y decisión para el caso | Fuente primaria |
|---|---|---|
| Git avanzado | Ramas aíslan cambios; merge integra historias, rebase reorganiza commits y cherry-pick selecciona cambios. Revert conserva el historial compartido. Se proponen ramas breves. Git Flow aporta ramas de versión y correcciones útiles al mantener varias versiones. Trunk Based facilita integrar frecuentemente, con pruebas y revisión. La rama actual agrupa la demostración y no acredita integración diaria. | [Pro Git](https://git-scm.com/book/en/v2/Git-Branching-Branching-Workflows) |
| GitHub y revisión | PR #1 reúne la implementación. Revisar reglas, casos negativos y evidencia antes de integrar. Una revisión automática no equivale a la aprobación del compañero. | [Pull requests](https://docs.github.com/en/pull-requests/reference/pull-requests) |
| SDD y Spec Kit | Especificar requisitos y criterios antes de generar. Plan y tareas conectan contratos con implementación. Se consultó Spec Kit sin ejecutar CLI. | [Spec Kit](https://github.com/github/spec-kit) |
| DevOps y CI/CD | Actions ejecuta compilación y pruebas Windows y conserva binarios. No existe despliegue productivo. Para WinForms se propone un paquete firmado, entorno piloto y reversión mediante versión anterior. | [Actions para .NET](https://docs.github.com/en/actions/tutorials/build-and-test-code/net) |
| Copilot y prompts | Pedir cambios acotados con archivos de contexto, restricciones y criterios. Revisar código generado y no asumir que una respuesta convincente es correcta. | [Prompt engineering](https://docs.github.com/en/copilot/concepts/prompting-and-context/prompt-engineering), [Agent en Visual Studio](https://learn.microsoft.com/en-us/visualstudio/ide/copilot-agent-mode) |
| TDD y pipeline | TDD requiere prueba fallida, implementación y refactorización. La suite actual se escribió después del código. Los fallos del ejecutable detienen CI con salida distinta de cero. | [Pruebas .NET](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices) |
| Issues, Project y milestones | Cada issue debe expresar una tarea con aceptación y evidencias. Kanban propuesto: Pendiente, En curso, En revisión y Terminado. Un milestone agrupa la entrega. Su creación remota debe comprobarse. | [GitHub Projects](https://docs.github.com/en/issues/planning-and-tracking-with-projects/learning-about-projects/about-projects) |

## Propuesta para la empresa

Comenzar por repositorio compartido, especificaciones versionadas y revisión del compañero. Automatizar compilación y pruebas antes de integrar. Adoptar un tablero para hacer visible el estado del trabajo. Evaluar un piloto con cambios vinculados a requisitos, revisiones realizadas y fallos detectados antes de producción. Son indicadores propuestos, sin valores inventados.

La aplicación local demuestra el proceso. Para producción requeriría autenticación, almacenamiento transaccional, coordinación multiusuario, copia de seguridad y distribución controlada. Estas ampliaciones deben especificarse primero.
