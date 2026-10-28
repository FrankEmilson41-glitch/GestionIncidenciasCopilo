# Gestión de incidencias con SDD y GitHub Copilot

Proyecto de Programación Avanzada en C#, Universidad Técnica de Machala, paralelo 4A.
**Santiago Nicolás Blacio Quimis y Frank Emilson Cárdenas Figueroa.**

Aplicación de escritorio Windows Forms, C# y .NET Framework 4.7.2. Registra y edita incidencias, combina búsqueda y filtros, controla estados y conserva datos en XML.

## Documentos del proyecto

| Consultar | Contenido |
|---|---|
| [Índice de documentación](docs/README.md) | Acceso a toda la entrega |
| [Revisión del cumplimiento](docs/03-verificacion/CUMPLIMIENTO.md) | Qué está hecho, qué falta y evidencia |
| [Metodología SDD](docs/01-metodologia/SDD.md) | Las seis fases indicadas por el ingeniero |
| [Especificación original](specs/001-incidencias/requirements.md) | Requisitos, contratos, plan y tareas |
| [Arquitectura y manual](docs/02-tecnica/ARQUITECTURA_Y_USO.md) | Entidades, controlador, datos y formularios |
| [Flujo de Git y revisión](docs/04-gestion/FLUJO_DE_TRABAJO.md) | Ramas, PR y colaboración |
| [Informe y presentación](docs/05-entregables/README.md) | Archivos para editar por los integrantes |
| [Pruebas y evidencias](docs/03-verificacion/VERIFICACION.md) | Resultados locales y Actions |

## Código

- [Entidades](GestionIncidenciasCopilot/Entidades): Incidencia y enumeraciones.
- [Controladores](GestionIncidenciasCopilot/Controladores): validaciones y reglas.
- [Datos](GestionIncidenciasCopilot/Datos): contrato y repositorio XML.
- [Formularios](GestionIncidenciasCopilot/Formularios): FrmPrincipal, FrmIncidencia y FrmDetalle, con diseñadores editables.
- [Pruebas](Pruebas): consola de aserciones sin paquetes externos.
- [Pipeline](.github/workflows/ci.yml): compilar, probar y conservar binarios Release.

## Abrir y ejecutar

1. Abrir `GestionIncidenciasCopilot.slnx` en Visual Studio 2026 con desarrollo de escritorio .NET y targeting pack de .NET Framework 4.7.2.
2. Seleccionar `GestionIncidenciasCopilot` como proyecto de inicio y configuración **Release**.
3. Ejecutar con Ctrl+F5. Los formularios se editan desde la carpeta Formularios.

En una consola de desarrollador de Visual Studio, desde la raíz:

```powershell
msbuild Pruebas/GestionIncidenciasCopilot.Pruebas.csproj /p:Configuration=Release /p:Platform=AnyCPU
.\Pruebas\bin\Release\GestionIncidenciasCopilot.Pruebas.exe
```

El verificador retorna 0 al aprobar y 1 ante fallos. No usa Test Explorer ni `dotnet test`. Datos del usuario: `%LOCALAPPDATA%/GestionIncidenciasCopilot/incidencias.xml`.

## Estado verificado al 25 de octubre de 2026

Aplicación compilada y recorridos manuales verificados en Release. Nueve grupos de aserciones aprobados tras la corrección de temporales. [Actions verificado](https://github.com/FrankEmilson41-glitch/GestionIncidenciasCopilo/actions/runs/40164956737). [PR #1 listo para revisión](https://github.com/FrankEmilson41-glitch/GestionIncidenciasCopilo/pull/1).

La implementación está en `feature/gestor-incidencias`. `main` conserva la línea base hasta integrar la revisión. Se recibió evidencia de revisión técnica asistida del commit 6042e94; la decisión y publicación personal del compañero siguen pendientes. Consultar la matriz de cumplimiento antes de afirmar que terminó toda la entrega.

## Procedencia

Copilot Agent dentro de Visual Studio generó especificaciones, código, formularios, pruebas y workflow mediante solicitudes sucesivas. La plantilla inicial la creó el estudiante. Codex coordinó, operó Visual Studio, verificó y preparó documentación y archivos operativos. El historial del chat permanece en el entorno local. No se exporta una conversación inventada.

Se investigó GitHub Spec Kit, sin ejecutar su CLI. Las pruebas se escribieron después de la aplicación, por lo que no se acredita un ciclo TDD completo. El repositorio es público según la consulta de GitHub del 25 de octubre. No incluye credenciales ni datos personales de ejecución.

### Corrección de temporales
Copilot generó una prueba negativa antes de modificar la persistencia. Se ejecutó y falló por el temporal sobrante (ead1743). Tras perder control remoto de Windows, Codex implementó la limpieza en Datos y los nueve grupos pasaron (074a9fc). Consultar [registro rojo/verde](docs/03-verificacion/TEMPORALES.md).
La aplicación WinForms .NET Framework 4.7.2 compila en Release y pasan nueve grupos de aserciones. Se verificaron registro, edición, transiciones, filtros y persistencia tras reiniciar. Dos ejecuciones de Actions para d007240 terminaron correctamente.

La entrega académica aún requiere revisión del compañero, edición final del informe y presentación. La matriz distingue lo realizado de las propuestas. El usuario editará el diseño de los documentos.

## Seguimiento del cierre
[Tablero Kanban](https://github.com/users/FrankEmilson41-glitch/projects/1) y [milestone del primer parcial](https://github.com/FrankEmilson41-glitch/GestionIncidenciasCopilo/milestone/1). Issues #2 y #3 conservan los pendientes del dúo. Issue #4 registra temporales corregidos. [Registro de gestión](https://github.com/FrankEmilson41-glitch/GestionIncidenciasCopilo/blob/feature/gestor-incidencias/docs/04-gestion/SEGUIMIENTO_GITHUB.md). La corrección de temporales está publicada y [Actions aprobó nueve grupos](https://github.com/FrankEmilson41-glitch/GestionIncidenciasCopilo/actions/runs/40204708554).

## Actualización de revisión — 27 de octubre de 2026

Se corrigió el texto de edición y se añadieron ocho casos XML explícitos dentro de los nueve grupos. Compilación Release correcta y nueve grupos aprobados con TEMP/TMP escribible. [Registro de correcciones y evidencias](docs/03-verificacion/CIERRE_REVISION.md). [Actions del código corregido aprobado](https://github.com/FrankEmilson41-glitch/GestionIncidenciasCopilo/actions/runs/40631339669). El PR #1 está Ready for review, vinculado al milestone y en In review junto con Issue #2. Continúan pendientes la decisión de Santiago, integración y documentos finales; no se cierra el milestone. [Instrucciones para la revisión final de Santiago](docs/04-gestion/PARA_SANTIAGO_REVISION_FINAL.txt).

Los tres diseñadores (FrmPrincipal, FrmIncidencia y FrmDetalle) cargaron en Visual Studio 2026 Insiders. Se conservan capturas y el registro en docs/03-verificacion/CIERRE_REVISION.md.
