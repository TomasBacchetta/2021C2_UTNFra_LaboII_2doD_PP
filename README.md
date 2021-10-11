# Título
*UTNFra Laboratorio de Computación II - Primer Parcial - Comisión 2do D - 2do cuatrimestre 2021*

[Enunciado del parcial](https://codeutnfra.github.io/programacion_2_laboratorio_2_apuntes/docs/evaluaciones/parciales/2d-primer-parcial/)

## Sobre mí

<<<<<<< HEAD

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

-Una facturacion mas detallada
-Afinar el motor que genera datos al azar
-Aun no encontre un nuget que me pueda servir
Cosas que faltan del codigo:
-Comprobar y afianzar los niveles de protección
-Encapsular lo más posible con métodos
-Comentar lo que sea necesario


Cosas que van mas alla de lo pedido pero que no se haran en el parcial:
-El por que se genera todo al azar responde a la idea de convertir en este programa en un videojuego, pero para que esto tenga sentido deberia haber visto hilos, ya que quiero que el tiempo de uso de las computadoras este determinado por atributos del cliente (por ejemplo, "Felicidad"). Sea realista o no, yo buscaria una forma de que sea conveniente economicamente que el cliente este el mayor tiempo posible en una maquina, y se pueda aumentar esta felicidad por diversos atributos propios del equipo (de ahi que seleccionar la maquina mas conveniente sea muy importante). La felicidad permitira que el cliente pueda gastar dinero en otros productos como gaseosas, caramelos, cigarrillos (solo en la sesion nocturna). También estaria  la posibilidad de que aparezcan grupos de clientes y formen una LAN PARTY, donde el consumo de estos productos aumentará.
El objetivo del juego seria facturar lo mayor posible en una jornada, con la posibilidad de utilizar dividendos para actualizar equipamiento.
=======
Bacchetta, Tomás. Soy alumno de 1° año de la Tecnicatura Superior en Programación. Si bien soy bachiller recibido en Informática desde hace ya ciertos años, sólo al terminar recientemente otra carrera (Técnico Superior en Producción Gráfica) descubrí un renovado interés por la programación gracias a una de las materias del último año, donde vimos casi como un juego el lenguaje PostScript (un antiguo lenguaje de comunicación de impresora, antecesor del PDF, ya obsoleto). 

## Resumen

-El programa simula una situación de negocio de un cyber, con clientes y equipos generados al azar. Para asignar un cliente a un equipo, este debe cumplir con los requerimientos del cliente en cuando a software, juegos, periféricos y tipo de llamada (segun el número de teléfono que el cliente va a discar). 
Para más detalles está el tutorial en el formulario principal del programa.
***NOTA***: Puede tardar unos segundos en iniciar por cómo funciona el motor de randomización, ya que a fines de un mejor testeo es posible que deba "relloear" muchas tiradas randomizadas, que son la base de la generación de datos del programa (sacando el login, no hay ningún tipo de input de texto de ningún tipo).
>>>>>>> 2e80dd3e24007d9cf6171baa53e5c91b3edaefe6



## Diagrama de clases
https://drive.google.com/file/d/184N28Ab6uuHVgrIjFP2YMAoh2GZNBoXl/view?usp=sharing

## Justificación técnica

-Sobre métodos estáticos: Se usan para resolver algunos métodos simples que no requieran interacción con instancias. Lo cierto es que si la clase principal, CyberCafé, fuese estática, el uso de métodos estáticos a lo largo y ancho del código sería mucho mayor. Pero decidí que CyberCafé sea una clase de instancia con la posibilidad de expandir el código (lo veo como una solución posible a agregar jornadas de trabajo en un futuro).
-Sobre programación orientada a objetos, fue la base de este parcial y el paradigma utilizado, se trató de respetar lo más posible la independencia de clases aunque hay ciertos casos como en la generación al azar de clientes, que denota una inconsistencia comparado a como se manejan la clase de Equipo pero eso fue consecuencia de la falta de una refactorización más exhaustiva. Cualquier tipo de expansión futura del código deberá arreglar ésto puesto que se haría más difícil a medida que aumenta la complejidad del código. Pero cierto es que la funcionalidad nueva (productos) fue relativamente fácil de integrar al código gracias a un trabajo de previo de encapsulamiento.
-La sobrecarga es utilizada sobre todo en constructores de clientes, también es utilizada en Carga y sus derivadas. Se sobrecargan también operadores binarios, aunque esto puede seguir aplicándose a más operadores por supuesto.
-Sobre Windows Forms: se utilizan extensamente los conceptos vistos en clase, se explotan tambien cosas no vistas como el aprovechamiento la propiedad tag, muy útil para indentificar y enlazar lógicamente controles. Se experimenta también la generación dinámica de controles en el formulario de historial. Se utilizan también archivos media embebidos en Recursos.
-Las colecciones se aprovechan lo más posible, siendo las estrellas las genéricas Queue (para, por supuesto, las colas), Dictionary (para catalogar colecciones), y también List como respuesta a la necesidad de arrays dinámicos.
-El encapsulamiento se aprovecha lo más posible, pero siendo algo complejo, siempre está sujeto a mejoras. Los modificadores de acceso fueron aprovechados lo más posible no sólo como una forma de hacer más seguro el código, sino también hacer más legible la herramienta Intellisense ya que ésta sólo mostrar lo que me sirva en el contexto apropiado.
-La herencia es muy explotada varias de las clases, ahorrando código y casteos innecesarios.
-El polimorfismo es muy utilizado en los métodos que devuelven un string en clases derivadas, sobreescribiendo los de la base.

## Propuesta de valor agregado

<<<<<<< HEAD
-Como funcionalidad inédita, los clientes tendrán un atributo nivelDeFelicidad, que reflejará el nivel de satisfacción a la hora de utilizar un equipo
-Al ser asignado a un equipo, el cliente verá su nivel de felicidad aumentado dependiendo de cuántos requisitos en juegos, software, perifericos y llamadas fueron satisfechos
-Los puntos de felicidad permitirán al usuario del programa vender al cliente diversos productos como gaseosas y golosinas, los que tendrán un costo en felicidad y por supuesto monetario (pero el determinante sera la felicidad).
-El fin ultimo de poder vender esos productos naturalmente es poder aumentar de forma más dinámica la facturacion
-Algunos de estos productos tendrán habilidades únicas que alterarán la dinámica del programa, de forma positiva o negativa.
=======
-Como propuesta nueva está la posibilidad del usuario de ofrecer a los clientes en sesión diversos productos que aumentan la facturación y también tienen ciertos atributos dinámicos que hacen más divertida la experiencia apuntando a un fin lúdico de la aplicación. Me gustaría manejar mejor el concepto del tiempo, ya que el hecho de cerrar a discreción las sesiones trivializa la meta de facturar lo más posible. Podría buscarse una forma de que uno de los objetivos cruciales, por ejemplo, sea que el cliente pase el mayor tiempo posible en un equipo, para que siga consumiendo en base a un nivel de felicidad que hay que mantener dinámicamente.
>>>>>>> 2e80dd3e24007d9cf6171baa53e5c91b3edaefe6
