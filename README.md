# Título
*UTNFra Laboratorio de Computación II - Primer Parcial - Comisión 2do D - 2do cuatrimestre 2021*

[Enunciado del parcial](https://codeutnfra.github.io/programacion_2_laboratorio_2_apuntes/docs/evaluaciones/parciales/2d-primer-parcial/)

## Sobre mí

Bacchetta, Tomás. Soy alumno de 1° año de la Tecnicatura Superior en Programación. Si bien soy bachiller recibido en Informática desde hace ya ciertos años, sólo al terminar recientemente otra carrera (Técnico Superior en Producción Gráfica) descubrí un renovado interés por la programación gracias a una de las materias del último año, donde vimos casi como un juego el lenguaje PostScript (un antiguo lenguaje de comunicación de impresora, antecesor del PDF, ya obsoleto). 

## Resumen

-El programa simula una situación de negocio de un cyber, con clientes y equipos generados al azar. Para asignar un cliente a un equipo, este debe cumplir con los requerimientos del cliente en cuando a software, juegos, periféricos y tipo de llamada (segun el número de teléfono que el cliente va a discar). 
Para más detalles está el tutorial en el formulario principal del programa.
***NOTA***: Puede tardar unos segundos en iniciar por cómo funciona el motor de randomización, ya que a fines de un mejor testeo es posible que deba "relloear" muchas tiradas randomizadas, que son la base de la generación de datos del programa (sacando el login, no hay ningún tipo de input de texto de ningún tipo).



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

-Como propuesta nueva está la posibilidad del usuario de ofrecer a los clientes en sesión diversos productos que aumentan la facturación y también tienen ciertos atributos dinámicos que hacen más divertida la experiencia apuntando a un fin lúdico de la aplicación. Me gustaría manejar mejor el concepto del tiempo, ya que el hecho de cerrar a discreción las sesiones trivializa la meta de facturar lo más posible. Podría buscarse una forma de que uno de los objetivos cruciales, por ejemplo, sea que el cliente pase el mayor tiempo posible en un equipo, para que siga consumiendo en base a un nivel de felicidad que hay que mantener dinámicamente.
