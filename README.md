# Gestor de incidencias con SDD y GitHub Copilot

Proyecto académico de Programación Avanzada en C#, 4A, Universidad Técnica de Machala.
Integrantes: Santiago Nicolás Blacio Quimis y Frank Emilson Cárdenas Figueroa.

## Aplicación y ejecución
Windows Forms, C# y .NET Framework 4.7.2. Registro, edición, detalle, búsqueda por título/descripción, filtros combinados y transiciones Pendiente > EnProceso > Resuelta, con reapertura a EnProceso.

Abrir GestionIncidenciasCopilot.slnx con Visual Studio 2026 y desarrollo de escritorio .NET instalado. Compilar y ejecutar GestionIncidenciasCopilot. Los tres formularios de la carpeta Formularios tienen archivos Designer editables.

Datos: %LOCALAPPDATA%/GestionIncidenciasCopilot/incidencias.xml. La ausencia del archivo inicia una lista vacía. La corrupción impide el arranque y conserva el archivo. No hay login, eliminación ni sincronización entre procesos.

## Compilar y probar
En una consola de desarrollador de Visual Studio, desde la raíz:

    msbuild Pruebas/GestionIncidenciasCopilot.Pruebas.csproj /p:Configuration=Release /p:Platform=AnyCPU
    .\Pruebas\bin\Release\GestionIncidenciasCopilot.Pruebas.exe

Las pruebas son una consola con aserciones propias, sin NuGet. Devuelve 0 al aprobar y 1 ante fallos. No usa xUnit, MSTest ni dotnet test.

## SDD y procedencia
requirements.md define necesidades y aceptación; spec.md fija contratos y reglas; plan.md organiza capas, tareas y trazabilidad. Se revisaron antes de implementar.

GitHub Copilot Agent dentro de Visual Studio Insiders generó documentos SDD, código de aplicación, formularios, pruebas y workflow mediante solicitudes sucesivas en el chat «hola». La plantilla inicial la creó el estudiante. Codex operó la interfaz, formuló prompts, revisó cambios, ejecutó compilaciones y pruebas y registró commits. Codex redactó esta guía y el registro de evidencias.

Se consultó GitHub Spec Kit como referencia. No se afirma instalación o ejecución de su CLI. Las pruebas se generaron después del código, por lo que no se presenta la implementación como un ciclo TDD previo.

## GitHub
main contiene plantilla y línea base SDD. feature/gestor-incidencias contiene la implementación incremental. El workflow Windows compila, prueba y genera un artefacto Release. Su archivo no demuestra ejecución remota. Publicación, PR, revisión del compañero, tablero y Actions requieren evidencia real antes de la entrega. No se simulan aprobaciones del compañero.

Consultar docs/EVIDENCIAS.md.


## Estado remoto al 25 de octubre de 2026
Ramas main y feature/gestor-incidencias publicadas. PR #1 en borrador: https://github.com/FrankEmilson41-glitch/GestionIncidenciasCopilo/pull/1. Comprobaciones opcionales superadas observadas en Visual Studio. Revisión auténtica del compañero y gestión Issues/Project/milestone pendientes. Consultar docs/EVIDENCIAS.md para el registro actualizado.
