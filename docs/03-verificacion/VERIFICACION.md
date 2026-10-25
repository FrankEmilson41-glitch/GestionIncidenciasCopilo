# Verificación al 25 de octubre de 2026

## Comprobaciones actuales

MSBuild compiló aplicación y pruebas en Release tras el retiro del formulario de plantilla. Se ejecutó el verificador con una carpeta temporal autorizada y los ocho grupos aprobaron. Se conserva la salida anterior equivalente en evidencias/pruebas_release.txt.

1. Alta, límites y enums.
2. Edición conserva ID y fechas UTC.
3. Transiciones válidas e inválidas.
4. Búsqueda y filtros combinados.
5. Copias no exponen el estado interno.
6. Fallo al guardar no cambia memoria.
7. XML, recarga y reemplazo seguro.
8. Corrupción, versión, IDs y UTC conservan archivo y bloquean guardado.

Cada grupo contiene varias aserciones. No se midió cobertura ni se acreditó TDD completo. Los casos son posteriores a la implementación.

## GitHub Actions

[Run 40164956737](https://github.com/FrankEmilson41-glitch/GestionIncidenciasCopilo/actions/runs/40164956737) y [run 40164737074](https://github.com/FrankEmilson41-glitch/GestionIncidenciasCopilo/actions/runs/40164737074) aparecen completed/success en la API de GitHub para el commit d0072402a5204ed25672d4ee4ace6f489843ecf2. El JSON conserva una selección de campos públicos verificados.

Esto no acredita automáticamente las ejecuciones de commits posteriores. El workflow genera binarios, sin despliegue productivo. Los logs remotos detallados no se incorporan en esta revisión.

## Recorridos manuales anteriores

Título vacío rechazado. Alta de la incidencia DEMO SDD - Error al iniciar sesion con prioridad Alta. Edición conservó ID y creación. Transiciones Pendiente a EnProceso y EnProceso a Resuelta. Búsqueda por descripción sin distinguir mayúsculas. Filtros combinados y lista sin coincidencias. Reinicio conservó ID, prioridad, estado y fechas. Las capturas son reales. La del PR corresponde a una fase anterior con la comprobación aún ejecutándose.

## Límite frente a la especificación

La limpieza del temporal cuando falla la promoción del archivo no está implementada en todos los caminos. El destino original queda protegido, pero el contrato de limpieza no está plenamente satisfecho. Registrar una prueba negativa y una corrección posterior. No declarar conformidad total con spec.md mientras persista.
