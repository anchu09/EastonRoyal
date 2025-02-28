# 🕵️‍♂️ Easton Royal - VR Escape Room

Easton Royal es un videojuego de realidad virtual de aventura y puzles ambientado en la época victoriana. El jugador asume el papel de un detective del siglo XIX que, tras viajar en el tiempo para evitar la muerte de su abuelo, queda atrapado en una mazmorra y pierde la memoria. A lo largo del juego, deberá resolver enigmas y recolectar pistas para reconstruir la verdad y escapar.

---

## 📜 Historia y Ambientación

Eres un renombrado detective inglés de la época victoriana que, usando una máquina del tiempo, trata de evitar la trágica muerte de su abuelo.  
Un suceso misterioso te deja amnésico y prisionero en una mazmorra.  
A medida que exploras, descubres que no llegaste al pasado por casualidad y que alguien quiere impedir que conozcas la verdad.

El juego mezcla la jugabilidad de escape rooms con una experiencia VR inmersiva, empleando mecánicas como:
- Cerillas
- Farolillos
- Libros con códigos
- Rompecabezas mecánicos

---

## 🎮 Características del Juego

- **Género:** Aventura / Puzle
- **Plataforma:** Oculus Quest
- **Modo de juego:** VR en primera persona
- **Interacción:** Recoger objetos, resolver puzles, explorar entornos y hablar con NPCs

### Mecánicas Clave:
- Recolección de pistas
- Descifrado de mensajes y códigos
- Manipulación de objetos físicos en VR
- Avances en la trama a través de acertijos y eventos

### Niveles del Juego:
- **Mazmorra:** Escapa usando pistas ocultas y resolviendo puzles mecánicos.
- **Despacho (Biblioteca):** Investiga objetos, libros y mecanismos para desbloquear nuevas áreas y acercarte a la verdad.

---

## 📂 Estructura del Código

El repositorio se organiza en varias carpetas, cada una con scripts que manejan aspectos específicos del juego:

### 🔹 HUD/
Scripts relacionados con la interfaz y menús en VR:
- **abrircerrarMenus.cs:** Abre/cierra menús de inventario, pausa y progreso.
- **botonSalir.cs:** Regresa a la escena de inicio destruyendo singletons.
- **notaCogida.cs:** Maneja la recolección de notas y sus indicadores en HUD.
- **spawnearCandelabro.cs:** Instancia un candelabro en la posición configurada.
- **spawnearCerilla.cs:** Instancia cerillas en la ubicación deseada (reseteando sus efectos de fuego).
- **spawnearCodigo.cs:** Instancia el objeto que contiene el código en una posición dada.

### 🔹 Mazmorra/
Scripts y objetos interactivos dentro de la mazmorra:
- **animaciones_puzle.cs:** Controla la lógica y animación de un puzle de bloques secuenciados.
- **botonPuzle.cs:** Resetea las piezas de un puzle y las recoloca en su posición inicial.
- **cadenaBajar.cs:** Activa escaleras al tirar de una cadena, con partículas y sonidos.
- **candelabro.cs:** Al encenderlo con una cerilla, libera otros objetos interactivos.
- **candado.cs:** Maneja la apertura de la mazmorra al usar una llave y activa la cadena.
- **cerilla.cs:** Controla la recogida y estado de la cerilla (fuego).
- **cilindrosgiratorios/**: Conjunto de scripts para cilindros giratorios (cilindroGiratorio, cilindroGir2, etc.). Al girarlos, se desencadenan animaciones (girar).
- **PanelLuces.cs:** Sistema para iluminar u oscurecer zonas.
- **codigo.cs:** Puzle de combinación de códigos.
- **palanca.cs, paredEncenderCerilla.cs:** Más mecánicas de interacción en la mazmorra (activar palancas, encender fuego en paredes).

### 🔹 Biblioteca
Scripts de los puzles y mecánicas en el segundo nivel:
- **baulhud.cs:** Implementa el candado numérico de un baúl y muestra un “HUD” de combinación.
- **botellaprincipal.cs, botellas.cs:** Manejan la lógica de botellas que vierten líquido y activan pistas.
- **cajon_nota2.cs:** Desbloquea un cajón al detectar una llave específica.
- **cajonesEscritorio.cs:** Control de cajones y su contenido.
- **candadobaul.cs:** Abre/cierra el menú para introducir la combinación del baúl.
- **chincheta.cs:** Cuando se coloca correctamente, revela notas o pistas.
- **colisionador.cs:** Detecta la entrada de botellas en una zona delimitada para mezclar líquidos.
- **desbloquearllaveceldabiblio.cs:** Otorga llave cuando se cumplen ciertos requisitos (notas vistas, etc.).
- **estatua.cs:** Puzle de partes de estatua que deben colocarse en la posición correcta.
- **fotoslondres.cs:** Clase Singleton sin lógica adicional (indicador de fotos en el escritorio).
- **llavefinalcolisionador.cs:** Detecta la “llave final” y activa el canvas que anuncia el fin del juego.
- **piano.cs:** Reproduce diferentes sonidos de piano al interactuar.
- **tablonBebidas.cs:** Puzle de botellas y tizas de colores para obtener un trozo de código.

### 🔹 Otros/
Scripts generales de gestión del juego y sistemas auxiliares:
- **AudioManager.cs:** Reproduce y gestiona música, efectos de sonido y voces.
- **Configuration.cs, DataManager.cs, SerializableUserData.cs, Usuario.cs:** Manejan configuración, datos del jugador, serialización y usuario.
- **GameManager.cs, managerjuego.cs:** Controlan la lógica principal de escenas, progreso y estados generales.
- **SaveSystem.cs:** Guarda y carga datos de partida.
- **Singleton.cs:** Implementación de Singleton para varios controladores.
- **LevelReset.cs, Teclado.cs, TecladoManager.cs, UIManager.cs, UIXRManager.cs, neworigin.cs, salirJuego.cs, Parameters.cs:** Scripts de utilidades varias (reinicio de nivel, interfaz, manejo de teclado, gestión de VR, etc.).

---

## 🛠 Instalación y Uso

1. **Clonar el repositorio:**
   ```sh
   git clone https://github.com/tu_usuario/easton-royal.git
