# Título
*UTNFra Laboratorio de Computación II - Primer Parcial - Comisión 2do D - 2do cuatrimestre 2021*

[Enunciado del parcial](https://codeutnfra.github.io/programacion_2_laboratorio_2_apuntes/docs/evaluaciones/parciales/2d-primer-parcial/)

## Sobre mí


## Resumen

Bacchetta, Tomás

El programa trata de simular una situación de negocio de un cyber, con clientes y equipos generados al azar. Para asignar un cliente a un equipo, este debe cumplir con los requerimientos del cliente en cuando a software, juegos, periféricos y tipo de llamada (segun el número de teléfono que el cliente va a discar). Por esta misma naturaleza azarosa, todavia hay que afinar un poco la forma en que se asignan estos valores en los equipos porque puede darse el caso de que se den combinaciones dificiles para los clientes (para eso se agregó el botón "Echar" que en realidad debería ser utilizado como última instancia). 

El richtextbox de la derecha muestra al próximo cliente a atender, de la cola de clientes:

*Para seleccionar un equipo hay que hacer click en el botón radial correspondiente
*Para ver el equipo hay que hacer click en el botón Ver Equipo
*Para asignar un cliente en el equipo seleccionado, presionar el botón "Asignar"
*El cliente asignado pasa a una subcola vinculada a un equipo particular (pero esta tambien es un atributo instanciado de la clase cyber). 
*El hecho de usar subcolas por equipos permite descongestionar la cola principal ya que esta tiene una mezcla de clientes de computadora y de cabinas 
*Las subcolas pueden parecer un concepto extraño, pero es era real en muchos cyber que haya máquinas, por diversos motivos, más preciadas que otras, y clientes dispuestos a esperar a que se desocupen dichas maquinas en particular.
*Las subcolas en las cabinas telefónicas se explican porque no todas admiten llamadas de larga distancia e internacionales
*Si el equipo no esta en uso actualmente, y no hay nadie en la subcola, se genera una sesion que enlaza ese cliente asignado con su equipo. Caso contrario este debe esperar en la subcola del equipo correspondiente.
*Si se finaliza sesión y hay un cliente en la subcola, éste se asigna automáticamente
*Con las sesiones se formaran historiales y a partir de estos, los informes (a los que todavia no se pueden acceder). Las sesiones se guardan en un atributo del objeto cybercafe
*En el formulario de equipo, se puede ver los datos de la maquina, el cliente de la sesion actual (si es que esta en uso), el proximo cliente de la subcola en el richtextbox de la derecha, y además se puede consultar el historial de sesiones del equipo en particular.

Cosas que faltan de la funcionalidad:

-Entre las cosas principales todavía falta generar informes (a los que se accederá desde el historial)
-Como funcionalidad inédita, los clientes tendrán un atributo nivelDeFelicidad, que reflejará el nivel de satisfacción a la hora de utilizar un equipo
-Al ser asignado a un equipo, el cliente verá su nivel de felicidad aumentado dependiendo de cuántos requisitos en juegos, software, perifericos y llamadas fueron satisfechos
-Los puntos de felicidad permitirán al usuario del programa vender al cliente diversos productos como gaseosas y golosinas, los que tendrán un costo en felicidad y por supuesto monetario (pero el determinante sera la felicidad).
-Algunos de estos productos tendrán habilidades únicas que alterarán la dinámica del programa, de forma positiva o negativa.

-Una facturacion mas detallada
-Afinar el motor que genera datos al azar
-Aun no encontre un nuget que me pueda servir
Cosas que faltan del codigo:
-Comprobar y afianzar los niveles de protección
-Comentar lo que sea necesario


Cosas que van mas alla de lo pedido pero que no se haran en el parcial:
-El por que se genera todo al azar responde a la idea de convertir en este programa en un videojuego, pero para que esto tenga sentido deberia haber visto hilos, ya que quiero que el tiempo de uso de las computadoras este determinado por atributos del cliente (por ejemplo, "Felicidad"). Sea realista o no, yo buscaria una forma de que sea conveniente economicamente que el cliente este el mayor tiempo posible en una maquina, y se pueda aumentar esta felicidad por diversos atributos propios del equipo (de ahi que seleccionar la maquina mas conveniente sea muy importante). La felicidad permitira que el cliente pueda gastar dinero en otros productos como gaseosas, caramelos, cigarrillos (solo en la sesion nocturna). También estaria  la posibilidad de que aparezcan grupos de clientes y formen una LAN PARTY, donde el consumo de estos productos aumentará.
El objetivo del juego seria facturar lo mayor posible en una jornada, con la posibilidad de utilizar dividendos para actualizar equipamiento.



## Diagrama de clases


## Justificación técnica


## Propuesta de valor agregado
