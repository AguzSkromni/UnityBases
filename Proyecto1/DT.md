# Proyecto1: Esquiva 2D

## Resumen
Un cubo corre solo hacia la derecha. El jugador solo salta para esquivar obstáculos. El puntaje sube con el tiempo. Al chocar, el juego se reinicia.

## Mecánicas
- **Correr automático:** el mundo se mueve hacia el jugador; el jugador no se desplaza horizontalmente.
- **Salto simple:** pulsación corta, altura base.
- **Salto variable:** mantener el botón más tiempo produce un salto más alto.
- **Obstáculo bajo:** se esquiva con salto simple.
- **Obstáculo alto:** requiere salto mantenido.
- **Puntaje:** tiempo sobrevivido.
- **Dificultad:** la velocidad del mundo sube cada 10 segundos hasta un tope.
- **Game over:** al chocar con un obstáculo. Una tecla reinicia.

## Controles
- Saltar: Espacio o botón Sur (A en mando).
- Reiniciar: R o botón Start.
- Acciones en Input Actions: `Saltar`, `Reiniciar`.

## Escena
Única: `Juego`. Sin menús.

## Objetos
- **Jugador:** cubo 2D (sprite cuadrado de Unity), `Rigidbody2D`, `Collider2D`.
- **Suelo:** rectángulo estático con collider.
- **Obstáculo bajo y alto:** prefabs con `Collider2D`.
- **Límite:** collider invisible al lado izquierdo; destruye obstáculos al cruzarlo.

## Sistemas (sin código)
- **Jugador:** detecta el salto, aplica la fuerza solo si está en el suelo.
- **Mundo:** mueve los obstáculos a la velocidad actual.
  - Decisión: los obstáculos usan `Rigidbody2D` cinemático, no `Transform`, para que las colisiones sean confiables.
- **Generador:** crea obstáculos cada X–Y segundos, tipo aleatorio, con separación mínima entre ellos.
- **Puntaje:** suma tiempo y lo muestra en UI.
- **Dificultad:** sube la velocidad del mundo cada 10 segundos.
- **Game over:** detiene el mundo, muestra un texto y espera el reinicio.

## Capas (Layers)
- `Jugador`
- `Suelo`
- `Obstaculo`
- `Limite`

## Fuera de alcance
Sprites propios, audio, menú, récord guardado, partículas.

## Riesgos
- **Salto mal calibrado:** ajustar gravedad y fuerza en el Inspector, no en el código.
- **Obstáculos superpuestos:** dejar separación mínima al generar.
- **Obstáculos que no desaparecen:** revisar que el `Limite` tenga collider y capa correcta.
