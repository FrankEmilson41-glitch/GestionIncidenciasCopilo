# Corrección de limpieza de temporales

## Criterio
Ante fallo al reemplazar XML, conservar exactamente el destino, propagar el error de guardado y eliminar únicamente el temporal creado por esa operación cuando el sistema permita borrarlo. No borrar temporales ajenos ni la información original.

## Prueba primero
Copilot Agent en Visual Studio generó el noveno grupo. Crea XML válido, bloquea destino con FileShare.None, verifica IOException, libera el bloqueo y compara bytes. Comprueba ausencia del temporal. Commit **ead1743**. [Salida roja](evidencias/prueba_temporales_roja.txt): los ocho grupos originales pasan y el nuevo falla por temporal sobrante. No se cambió Datos antes de ejecutar esa prueba.

## Corrección
El control remoto falló al recuperar Visual Studio con GetCursorPos Acceso denegado. Codex implementó el cambio desde los archivos, commit **074a9fc**. No se atribuye esa implementación a Copilot.

Guardar usa try/finally. EscribirTemporal marca propiedad del archivo solo después de abrirlo con CreateNew. El finally elimina exclusivamente esa ruta y evita que IOException o UnauthorizedAccessException de limpieza oculten el error original. El bloque cubre escritura, vaciado, cierre y promoción. La limpieza no cambia la interfaz pública ni requiere controles nuevos en los formularios.

## Resultado
MSBuild Release aprobado. [Salida verde](evidencias/prueba_temporales_verde.txt): nueve grupos aprobados, salida 0. Se trata de una evolución concreta con evidencia de prueba fallida y posterior corrección, no de TDD completo de toda la aplicación ni de refactorización adicional acreditada.
