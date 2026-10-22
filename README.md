# Videojuego de Pelea 3D – Unity

Juego de pelea en tercera persona desarrollado en **Unity 3D** con **C#**, en el que el jugador recorre un escenario y se enfrenta a enemigos controlados por inteligencia artificial.

> Proyecto académico del curso de Desarrollo de Videojuegos – Universidad Privada del Norte (UPN). **Estado: en desarrollo.**

## Características implementadas

- **Control del personaje:** movimiento y rotación con teclado, salto con física (`Rigidbody`) y detección de suelo mediante un trigger en los pies.
- **Sistema de combate:** dos tipos de golpe, con bloqueo del movimiento mientras se ataca y un impulso hacia adelante sincronizado con la animación mediante *Animation Events*.
- **Animaciones:** `Animator Controller` con parámetros de velocidad, salto, caída y ataques para el jugador y el enemigo.
- **IA del enemigo (NavMesh):**
  - Patrulla aleatoria por el escenario cuando el jugador está lejos.
  - Persigue al jugador cuando entra en su rango de detección.
  - Se detiene, lo mira y lo ataca cuando está en rango de ataque.
- **Sistema de vida** con barra en pantalla (`Slider`) y paso a Game Over al llegar a 0.
- **Puntaje** mostrado en pantalla con TextMesh Pro.
- **Flujo de escenas:** Menú principal → Nivel 1 → Game Over (reintentar o volver al menú).

## Controles

| Tecla | Acción |
|---|---|
| Flechas / WASD | Moverse y girar |
| Espacio | Saltar |
| Z | Golpe 1 |
| X | Golpe 2 |

## Tecnologías

- Unity 3D (C#)
- NavMesh / NavMeshAgent (IA de navegación)
- Animator y Animation Events
- Física con Rigidbody y Colliders
- UI con Slider y TextMesh Pro
- SceneManager

## Estructura de scripts

| Script | Función |
|---|---|
| `Codigos/LogicaPersonaje1.cs` | Movimiento, salto, ataques y control de animaciones del jugador |
| `Codigos/LogicaPies.cs` | Detección de suelo para habilitar el salto |
| `Codigos/PlayerHealth.cs` | Vida del jugador, barra de vida y Game Over |
| `Codigos/ScoreManager.cs` | Puntaje en pantalla |
| `Codigos/MainMenu.cs` | Menú principal (jugar / salir) |
| `Codigos/GameOverMenu.cs` | Pantalla de Game Over (reintentar / volver al menú) |
| `CodigosBots/LogicaMutante.cs` | IA del enemigo: patrulla, persecución y ataque con NavMesh |

## Cómo abrirlo

1. Clonar el repositorio.
2. Abrir la carpeta con **Unity Hub** (*Add project from disk*).
3. Abrir la escena `Assets/Scenes/MainMenu.unity` y presionar **Play**.

> **Nota:** el escenario (*Abandoned World*) y el cielo (*Real Stars Skybox*) son paquetes de la Unity Asset Store y no se incluyen en el repositorio por su licencia. Para ver el escenario completo hay que importarlos desde la Asset Store.

## Créditos

- **Programación y lógica del juego:** Fabrizio Castro Barrientos
- **Personajes y animaciones:** [Mixamo](https://www.mixamo.com)
- **Escenario y skybox:** Unity Asset Store

## Próximas mejoras

- Daño del enemigo conectado a la barra de vida del jugador
- Más enemigos y niveles
- Combos y sistema de bloqueo
- Efectos de sonido y partículas
