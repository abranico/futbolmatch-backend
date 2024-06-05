# Futbol Match

## Contexto
Se ha identificado la necesidad de desarrollar un sistema para facilitar la organización de
partidos de fútbol entre jugadores y equipos, así como la búsqueda de rivales para jugar. El
objetivo es crear una plataforma llamada Futbol Match que conecte a personas interesadas
en jugar fútbol, brindando una herramienta eficiente para encontrar partidos y adversarios.

## Proceso actual
Actualmente, la organización de partidos de fútbol se realiza de manera informal a través de
redes personales, grupos de mensajería instantánea o redes sociales. Los interesados en
jugar pueden enfrentar dificultades para encontrar jugadores disponibles, equipos
dispuestos a competir o rivales adecuados para sus habilidades.

## Proceso con el sistema de información deseado
Futbol Match permitirá a los usuarios buscar partidos disponibles, ya sea como equipos
completos en busca de rivales o como jugadores individuales buscando un equipo. Los
usuarios podrán crear perfiles de equipos, especificar detalles de los partidos como fecha,
hora, lugar, tipo de partido (fútbol 5, fútbol 7, etc...), modo de partido (competitivo o casual)
y así como confirmar su asistencia a los partidos. También si cuentan con la aplicación
premium se les dará la opción de crear ligas. La plataforma también facilitará la
comunicación entre los usuarios interesados en un partido y proporcionará herramientas
para la gestión de partidos, como la cancelación y la resolución de disputas. Al concluir el
encuentro competitivo, los capitanes designados deberán confirmar el equipo vencedor del
mismo. Esta confirmación es crucial para que el equipo ganador pueda acumular puntos en
el ranking del equipo, si es casual no habrá sumatoria de puntos.

## Requerimientos Funcionales
- Creación de perfil:
Se loguea el usuario ingresando sus datos personales (nombre, edad, ubicación,
etc...) y sus características futbolísticas (descripción, pierna hábil, jugador de
campo/arquero).

- Creación de partido casual:
El sistema permitirá a los usuarios crear salas que brindaran a los usuarios unirse
para jugar partidos de forma casual. El usuario que creó la sala tendrá permisos
como administrador para invitar jugadores, expulsar y organizar el partido.
Las salas de partido casual tendrán un código para compartir el acceso a estas.

- Busqueda de partido casual:
El sistema permitirá a los usuarios buscar salas de partidos de fútbol casual
disponibles para participar o a los equipos, jugar partidos que no sumen puntos.
Se podrá ingresar a través de un código o buscando en una lista, pudiendo filtrar.

- Creación de Equipos:
Permitir a los usuarios crear equipos, especificando detalles, como el nombre. El
creador del equipo es asignado como capitán y tiene permisos de modificar sus
detalles. El capitán puede aceptar solicitudes o invitar jugadores.
El capitán puede transferir el rol a otro jugador.

- Búsqueda de Equipos:
El sistema permitirá a los usuarios buscar equipos de fútbol disponibles para unirse
como jugadores individuales. Esta funcionalidad está diseñada para usuarios que
deseen encontrar equipos para participar en partidos o competiciones de fútbol.

- Búsqueda de Partidos:
Permitir a los capitanes de los equipos buscar partidos disponibles utilizando filtros
como ubicación, fecha, tipo de partido (fútbol 5, fútbol 7, etc.), y modo de partido
(competitivo o casual). El modo competitivo sumará 3 puntos al equipo en caso de
victoria y 1 en caso de empate

- Creación de Partidos:
Permitir a los capitanes de los equipos crear partidos especificando detalles como
fecha, hora, lugar, tipo de partido y modo de partido.

- Creación de Ligas:
Permitir a los capitanes de equipos crear ligas, especificando detalles como formato
de la liga, reglas, fechas de juego, etc.

- Unirse a ligas:
El capitán de un equipo puede unir el equipo a una Liga.

- Gestión de Partidos:
Permitir a los usuarios gestionar los partidos, incluyendo acciones como la
cancelación, la resolución de disputas y la actualización de detalles del partido.

- Confirmación del Equipo Vencedor:
Al concluir el encuentro competitivo, permitir a los capitanes designados confirmar el
equipo vencedor del mismo. Esta confirmación es fundamental para que el equipo
ganador pueda acumular puntos en el ranking del equipo, si es casual no habrá
sumatoria de puntos.

- Historial de partidos:
Los equipos contarán con un historial de partidos. Cualquier usuario puede acceder
al historial de un equipo. El historial de partidos comparte detalles de cada partido
como el resultado, equipo rival y comentarios del partido

- Comentarios en partidos:
Cada partido brindará a los jugadores la opción de dejar comentarios para compartir
la experiencia.
