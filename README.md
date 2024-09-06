
# Proyecto de Transfer Market en C# y .NET

## Descripción

Este proyecto es una aplicación web desarrollada con C# y .NET que incluye:
- Un sistema de **login seguro** para administradores.
- Un **dashboard** para la gestión de traspasos y plantillas de clubes.
- Una **vista principal** que muestra todos los traspasos realizados y el valor actual de las plantillas de los clubes.


## Caracteristicas

- **Autenticación**: Sistema de login seguro para administradores con autenticación y autorización.
- **Dashboard**: Interfaz para la gestión de traspasos y plantillas de clubes, incluyendo funcionalidades CRUD (Crear, Leer, Actualizar, Eliminar).
- **Vista Principal**: Muestra todos los traspasos realizados y la plantilla actual de todos los clubes con su valor de plantilla.

## Tecnologías Utilizadas

- **C#**: Lenguaje de programación principal.
- **.NET**: Plataforma de desarrollo para la aplicación.
- **Bootstrap**: Framework CSS para el diseño y estilo.
- **Entity Framework Core**: ORM para el manejo de bases de datos.
- **MySQL Server**: Base de datos relacional utilizada para el almacenamiento.

## Instalación

1. **Clona el repositorio:**

   ```bash
   git clone https://github.com/AlejandroLondonoValle/Transfer_Market.git
   ```

2. **Navega al directorio del proyecto:**

   ```bash
   cd TuRepositorio
   ```

3. **Restaura las dependencias del proyecto:**

   ```bash
   dotnet restore
   ```

4. **Construye el proyecto:**

   ```bash
   dotnet build
   ```

5. **Aplica las migraciones de la base de datos:**

   ```bash
   dotnet ef database update
   ```

6. **Ejecuta la aplicación:**

   ```bash
   dotnet run
   ```

## Uso

1. **Abre la aplicación en tu navegador**: La URL predeterminada es [http://localhost:5000](http://localhost:5000).
2. **Inicia sesión**: Utiliza las credenciales de administrador proporcionadas.
3. **Accede al dashboard**: Para gestionar traspasos y plantillas de clubes.
4. **Visita la vista principal**: Para consultar todos los traspasos realizados y el estado actual de las plantillas de los clubes.

## Enlaces

- [GitHub](https://github.com/AlejandroLondonoValle)
- [LinkedIn](https://www.linkedin.com/in/luís-alejandro-londoño-valle)
- [Instagram](https://www.instagram.com/alejandro_londono206/)

## Contribuciones

Si deseas contribuir a este proyecto, sigue estos pasos:

1. **Haz un fork del repositorio**.
   
2. **Crea una nueva rama**:

   ```bash
   git checkout -b feature/nueva-caracteristica
   ```

3. **Realiza tus cambios y haz commit**:

   ```bash
   git commit -am 'Añade nueva característica'
   ```

4. **Empuja los cambios a tu fork**:

   ```bash
   git push origin feature/nueva-caracteristica
   ```

5. **Abre un Pull Request** en GitHub.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.

## Contacto

Para preguntas o comentarios, por favor envíame un correo a [londonovalleluisalejandro@gmail.com](mailto:londonovalleluisalejandro@gmail.com).
