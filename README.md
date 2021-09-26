# Título
*UTNFra Laboratorio de Computación II - Primer Parcial - Comisión 2do D - 2do cuatrimestre 2021*

[Enunciado del parcial](https://codeutnfra.github.io/programacion_2_laboratorio_2_apuntes/docs/evaluaciones/parciales/2d-primer-parcial/)

## Sobre mí


## Resumen

Bacchetta, Tomás

El programa trata de simular una situación de negocio de un cyber, con clientes y equipos generados al azar. En el caso de las computadoras, a estas se las asignará si cumplen los requerimientos del cliente en cuando a software, juegos y periféricos. Por esta misma naturaleza azarosa, todavia hay que afinar un poco la forma en que se asignan estos valores en los equipos porque puede darse el caso de que se den combinaciones dificiles para los clientes (para eso se agregó el botón "Echar" que en realidad debería ser utilizado como última instancia). A los clientes de cabina se les asignará un telefono, tambien generado al azar, que se encargara el programa de determinar a que tipo de llamada corresponde.

-El richtextbox de la derecha muestra al próximo cliente a atender, de la cola de clientes
-Para ver cada equipo, basta sólo hacer click en el botón radial correspondiente y hacer click en el botón Mostrar Equipo.
-Para asignar un cliente en el equipo seleccionado, presionar el botón "Asignar"
-El cliente asignado pasa a una subcola vinculada a un equipo particular (pero esta tambien es un atributo instanciado de la clase cyber). 
-El hecho de usar subcolas por equipos permite descongestionar la cola principal ya que esta tiene una mezcla de clientes de computadora y de cabinas 
-Las subcolas pueden parecer un concepto extraño, pero es era real en muchos cyber que haya máquinas, por diversos motivos, más preciadas que otras, y clientes dispuestos a esperar a que se desocupen dichas maquinas en particular.
-En el caso de las cabinas, puede que no tenga mucho sentido hablar de subcolas, pero se podria agregar cabinas con ciertos atributos (por ejemplo, que no admitan llamadas internacionales).
-Si el equipo no esta en uso actualmente, y no hay nadie en la subcola, se genera una sesion que enlaza ese cliente asignado con su equipo.
-Con las sesiones se formaran historiales y a partir de estos, los informes (a los que todavia no se pueden acceder). Las sesiones se guardan en una coleccion dentro de cada equipo.
-En el formulario de equipo, se puede ver los datos de la maquina, el cliente de la sesion actual (si es que esta en uso), el proximo cliente de la subcola en el richtextbox de la derecha, y además se puede consultar el historial de sesiones del equipo en particular.

Cosas que faltan de la funcionalidad:
-Todo lo referido a la estetica
-Entre las cosas principales todavía falta mostrar un historial general y hacer los informes.
-Una facturacion mas detallada
-Ese historial general podría utilizar MDIs ya que estamos hablando de varios equipos
-Afinar el motor que genera datos al azar

Cosas que faltan del codigo:
-Aprovechar más la sobrecarga
-Comprobar y afianzar los niveles de protección
-Comentar lo que sea necesario, que para esta correccion casi no fue hecho
-

Cosas que van mas alla de lo pedido pero que no se haran en el parcial:
-El por que se genera todo al azar responde a la idea de convertir en este programa en un videojuego, pero para que esto tenga sentido deberia haber visto hilos, ya que quiero que el tiempo de uso de las computadoras este determinado por atributos del cliente (por ejemplo, "Felicidad"). Sea realista o no, yo buscaria una forma de que sea conveniente economicamente que el cliente este el mayor tiempo posible en una maquina, y se pueda aumentar esta felicidad por diversos atributos propios del equipo (de ahi que seleccionar la maquina mas conveniente sea muy importante). La felicidad permitira que el cliente pueda gastar dinero en otros productos como gaseosas, caramelos, cigarrillos (solo en la sesion nocturna). También estaria  la posibilidad de que aparezcan grupos de clientes y formen una LAN PARTY, donde el consumo de estos productos aumentará.
El objetivo del juego seria facturar lo mayor posible en una jornada, con la posibilidad de utilizar dividendos para actualizar equipamiento.



## Diagrama de clases


## Justificación técnica


## Propuesta de valor agregado
