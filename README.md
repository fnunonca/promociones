# promociones
web app de promociones

01 - Base de datos: SQL Server - Ejecutar el scripts.sql

02 - cambiar la cadena de conexion en el archivo promociones\Src\Backend\Promociones.Services.WebApi\appsettings.json linea 9 
03 - cambiar el CORS, colocar el ip de la maquina donde se levantara el front en el archivo promociones\Src\Backend\Promociones.Services.WebApi\appsettings.json linea 12

04 - Docker:
  Abril powershell como administrador, ubicarse en la ruta de la solucion backend
  Ejecutar los siguientes comandos:
  docker image build -t promociones:1.0.0 -f "Promociones.Services.WebApi\Dockerfile" .
  docker image ls
  **ver el id de la imagen creada y luego colocarla al final del siguiente comando
  docker container run --name PromocionesWebApi -d -p 8070:80 
  
  para corroborar colocar la siguiente url en el navegador
  http://localhost:8070/swagger/index.html
  
05 - Front:
  - actualizar la linea 201 del archivo src/components/Promociones.vue se debe ingresar alli el ip del backend levantado en docker
  - Abril power shell y ubicarse en la ruta del front
  - escribir los siguientes comandos
  - npm install
  - npm run serve
  
