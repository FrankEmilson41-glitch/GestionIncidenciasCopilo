# Flujo de trabajo y revisión

La línea base SDD se conserva en main. La implementación incremental está en feature/gestor-incidencias y el [PR #1](https://github.com/FrankEmilson41-glitch/GestionIncidenciasCopilo/pull/1) solicita su integración.

1. Registrar necesidad y criterio de aceptación.
2. Revisar requisitos y especificación antes de modificar código.
3. Solicitar el cambio a Copilot en Visual Studio por una tarea pequeña.
4. Revisar, guardar, compilar y ejecutar pruebas. Registrar commit con propósito claro.
5. Publicar la rama y comprobar Actions en el commit correspondiente.
6. El compañero revisa los cambios reales y deja su revisión con su cuenta.
7. Integrar cuando se hayan resuelto observaciones y preparar la entrega.

No se han inventado revisiones ni contribuciones del segundo integrante. El PR permanece en borrador. La demostración no acredita un flujo Trunk Based completo: una rama de funcionalidad agrupa el caso. Para el siguiente trabajo se proponen ramas de menor duración.

## Guía para la revisión del compañero

- Leer spec.md y verificar las transiciones y límites.
- Abrir los tres diseñadores y ejecutar registro, edición, búsqueda, filtros y reinicio.
- Ejecutar el verificador Release y revisar los casos negativos.
- Consultar Actions, observar diferencias del PR y registrar observaciones reales.
- Confirmar la corrección de las cuatro reflexiones y la versión final del informe y la presentación.

La integración en main queda pendiente de esta revisión. Una captura del tablero o el estado verde de CI no sustituye la evaluación de otra persona.
