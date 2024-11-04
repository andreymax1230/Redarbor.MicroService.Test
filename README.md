# Prueba tecnica RedArbor
Prueba Tecnica WebApi

# Diseño
La prueba técnica se desarrollo con arquitectura EDA(Arquitectura basada en Eventos), utilizando Kafka como cola de mensajería.
Por ultimo se utilizo el patron arquitectonico (Clean Arquitecture) para la comunicacion de la capa del cliente y la aplicación.

# Ejecucion
Para ejecutar el proyecto es necesario ejecutar las imagenes de docker (docker-compose.yaml) que contiene los siguientes servicios para el funcionamiento correcto del proyecto

* Sql Server 
* Kafka Broker
* Zookeeper
* Mongo DB

Se utiliza una consola de powershell para ejecutar el docker compose, ejemplo
* cd C:\Users\USER\source\repos\Redarbor.MicroService.Test\Redarbor.Presentation.Api
* docker-compose up -d
