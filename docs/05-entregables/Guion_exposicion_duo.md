# Guion sugerido para el dúo
Duración orientativa: 10 a 12 minutos. Ambos deben comprender toda la aplicación.

## Santiago, diapositivas 1 a 6
Presentar el caso académico y el problema de perder versiones. Explicar por qué Git conserva decisiones y cómo SDD fija criterios antes de generar código. Recorrer las seis fases. Mostrar el criterio que rechaza pasar directamente de Pendiente a Resuelta. Aclarar que se investigó Spec Kit y se aplicó la metodología sin su CLI.

## Frank, diapositivas 7 a 11
Abrir la solución en Visual Studio y mostrar Entidades, Controladores, Datos y Formularios. Abrir FrmPrincipal en diseñador. Mostrar el chat real de Copilot del proyecto y explicar una solicitud y sus cambios. Abrir el PR #1 sin atribuir aprobación al compañero.

Demostración: intentar guardar un título vacío, registrar un caso, editarlo y comprobar el ID, pasar a EnProceso y a Resuelta, filtrar por texto/prioridad/estado y reiniciar para verificar XML. Ejecutar el verificador Release y explicar que son ocho grupos con múltiples aserciones.

## Ambos, diapositiva 12
Responder las cuatro reflexiones del informe. Reconocer límites: aplicación local, sin autenticación ni concurrencia empresarial. Explicar que revisión del compañero, tablero y milestone siguen pendientes. No afirmar TDD completo porque las pruebas se escribieron después del código.

## Preguntas probables
- ¿Por qué existe un controlador? Centraliza reglas y evita duplicarlas en eventos de los formularios.
- ¿Qué ocurre si falla el guardado? No confirma el cambio en memoria como exitoso.
- ¿Qué pasa con XML corrupto? Informa error y bloquea escritura para conservarlo.
- ¿Qué garantiza CI? Repite las comprobaciones definidas, no garantiza ausencia de todos los errores.
- ¿Qué aportó la IA? Generó código a partir de especificaciones. La revisión y aceptación conservan responsabilidad humana.
