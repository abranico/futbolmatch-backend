# Futbol Match

1. [Descripción](#descripción)
2. [Funcionalidades Principales](#funcionalidades-principales)
3. [Tecnologías Utilizadas](#tecnologías-utilizadas)
4. [Arquitectura y Patrones de Diseño](#arquitectura-y-patrones-de-diseño)
5. [Entidades](#entidades)
6. [Screenshot](#screenshot)


## Descripción

**Futbol Match** es una API desarrollada en ASP.NET Core Web API que proporciona una plataforma para la organización de partidos de fútbol entre jugadores y equipos. La API facilita la búsqueda de rivales y la gestión de partidos, ofreciendo una solución estructurada para la conexión de interesados en jugar.

Este proyecto es un trabajo práctico para la universidad, destinado a aplicar y demostrar habilidades en el desarrollo de backend utilizando tecnologías modernas y patrones de diseño. 

Puedes consultar la [minuta de relevamiento](docs/MinutaDeRelevamiento.md) para más detalles sobre los requisitos y el contexto del proyecto.

## Funcionalidades Principales

1. **Creación de Perfiles**:
   - Los usuarios pueden crear perfiles con información personal (nombre, edad, ubicación) y características futbolísticas (descripción, pierna hábil, posición).

2. **Creación de Equipos**:
   - Los usuarios pueden formar equipos, asignando un capitán con permisos de gestión. El capitán puede invitar jugadores y modificar detalles del equipo.

3. **Creación de Partidos**:
   - Los capitanes pueden crear partidos con detalles como fecha, hora, lugar, tipo (fútbol 5, fútbol 7, etc.), y modo (competitivo o casual).

4. **Búsqueda de Equipos y Partidos**:
   - Los usuarios pueden buscar equipos para unirse o partidos disponibles utilizando filtros como ubicación, fecha, tipo de partido, etc.

5. **Creación de Ligas**:
   - Los capitanes de equipos premium pueden crear ligas, especificando formato, reglas y fechas de juego.

6. **Gestión de Partidos**:
   - Permite la cancelación, resolución de disputas y actualización de detalles del partido.

7. **Confirmación del Equipo Vencedor**:
   - Al finalizar un partido competitivo, los capitanes confirman el equipo ganador para actualizar el ranking. Los partidos casuales no afectan el ranking.

8. **Historial de Partidos**:
   - Los equipos tienen un historial accesible que muestra detalles de cada partido, como resultados, equipos rivales y comentarios.

## Tecnologías Utilizadas

El proyecto utiliza **ASP.NET Core Web API** para construir la API, **Entity Framework Core** como ORM para interactuar con la base de datos **SQLite**, y **JWT (JSON Web Tokens)** para la autenticación y autorización de usuarios. La aplicación sigue el enfoque **Code First** para el diseño de la base de datos y utiliza el **patrón DTO** para la transferencia de datos.

## Arquitectura y Patrones de Diseño

El proyecto se basa en **Clean Architecture**, lo que facilita la creación de un código mantenible y escalable. Se emplea el **patrón Repository** para separar la lógica de acceso a datos de la lógica de negocio, promoviendo una mejor organización del código. Además, se utiliza **inyección de dependencias** para mejorar la flexibilidad y la prueba del código mediante una gestión eficiente de las dependencias.
## Entidades

El sistema está compuesto por las siguientes entidades:

- **CasualMatch**: Representa un partido casual entre equipos o jugadores.
- **CompetitiveMatch**: Representa un partido competitivo con implicaciones en el ranking.
- **League**: Representa una liga que agrupa partidos y equipos.
- **Match**: Representa un partido en general, tanto casual como competitivo.
- **Player**: Representa a un jugador individual.
- **Team**: Representa un equipo de jugadores.
- **User**: Representa a un usuario del sistema.

Estas entidades se implementan utilizando clases abstractas para facilitar la herencia y la reutilización de código.

## Screenshot

![image](https://github.com/user-attachments/assets/73088747-b623-41ef-a832-d66aeace8441)
![image](https://github.com/user-attachments/assets/7721cac7-ea01-4c92-9a1d-428a927fe995)





