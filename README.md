# Título
*UTNFra Laboratorio de Computación II - Primer Parcial - Comisión 2do D - 2do cuatrimestre 2021*

[Enunciado del parcial](https://codeutnfra.github.io/programacion_2_laboratorio_2_apuntes/docs/evaluaciones/parciales/2d-primer-parcial/)

## Sobre mí

Bacchetta, Tomás. Soy alumno de 1° año de la Tecnicatura Superior en Programación. Si bien soy bachiller recibido en Informática desde hace ya ciertos años, sólo al terminar recientemente otra carrera (Técnico Superior en Producción Gráfica) descubrí un renovado interés por la programación gracias a una de las materias del último año, donde vimos casi como un juego el lenguaje PostScript (un antiguo lenguaje de comunicación de impresora, antecesor del PDF, ya obsoleto).

## Resumen

-El programa simula una situación de negocio de un cyber, con clientes y equipos generados al azar. Para asignar un cliente a un equipo, este debe cumplir con los requerimientos del cliente en cuando a software, juegos, periféricos y tipo de llamada (segun el número de teléfono que el cliente va a discar). Para más detalles está el tutorial en el formulario principal del programa. NOTA: Puede tardar unos segundos en iniciar por cómo funciona el motor de randomización, ya que a fines de un mejor testeo es posible que deba "relloear" muchas tiradas randomizadas, que son la base de la generación de datos del programa (sacando el login, no hay ningún tipo de input de texto de ningún tipo).


## Diagrama de clases
[Diagrama de clases](https://drive.google.com/file/d/184N28Ab6uuHVgrIjFP2YMAoh2GZNBoXl/view?usp=sharing)



## Justificación técnica

 **1. Métodos estáticos:** 
Dónde se usa (ejemplo): En archivosMedia.cs
Justificación: Los métodos de esa clase (que además es estática) son todos estáticos ya que no requieren interactuar con ninguna instancia.

 **2. Programación orientada a objetos**
Fue la base de este parcial y el paradigma utilizado, se trató de respetar lo más posible la independencia de clases.

 **3. Sobrecarga**
 Dónde se usa (ejemplo): 
 - Constructores: En ClienteDeComputadora.cs
 - Métodos: En CyberCafe.cs línea 597
 Justificación: Para el constructor de clientes de computadora me interesa que algunos tengan ciertos gustos en cada categoría, pero no necesariamente todas las categorías. Para el de métodos, en ciertos contextos sirve un método que haga lo mismo pero que tenga otro input diferente.
 **4. Windows Forms**
 Dónde se usa (ejemplo): En el proyecto cyber. En FrmHistorial.cs se utiliza dinámicamente.
 Justificación: Era lo pedido pero también se aprovechó para experimentar un poco.
-Sobre Windows Forms: se utilizan extensamente los conceptos vistos en clase, se explotan tambien cosas no vistas como el aprovechamiento la propiedad tag, muy útil para indentificar y enlazar lógicamente controles. Se experimenta también la generación dinámica de controles en el formulario de historial. Se utilizan también archivos media embebidos en Recursos. -Las colecciones se aprovechan lo más posible, siendo las estrellas las genéricas Queue (para, por supuesto, las colas), Dictionary (para catalogar colecciones), y también List como respuesta a la necesidad de arrays dinámicos. -El encapsulamiento se aprovecha lo más posible, pero siendo algo complejo, siempre está sujeto a mejoras. Los modificadores de acceso fueron aprovechados lo más posible no sólo como una forma de hacer más seguro el código, sino también hacer más legible la herramienta Intellisense ya que ésta sólo mostrar lo que me sirva en el contexto apropiado. -La herencia es muy explotada varias de las clases, ahorrando código y casteos innecesarios. -El polimorfismo es muy utilizado en los métodos que devuelven un string en clases derivadas, sobreescribiendo los de la base.

**5. Colecciones**
Dónde se usa (ejemplo): Atributos de CyberCafe.cs
Justificación:

 - List<Sesion> sesiones: agrupa todas las sesiones del cyber. Su tamaño aumenta dinámicamente por lo que es más cómo utilizar una colección List.
 - Queue<Cliente> colaClientes: la cola de clientes general del cyber. La cola se va vaciando en una lógica FIFO, por lo que es lógico utilizar una colección Queue.
 - Dictionary<string, Queue<Cliente>> colaDeClientesEnUnEquipo: la cola de un equipo en particular. Esta requiere una cola nueva (value), catalogada por un el id del equipo, que es un string (key), por lo que usar un dictionary es una buena opción.


**6. Encapsulamiento**
Dónde se usa (ejemplo) y justificación: En todo el proyecto sobre todo en la lógica de negocio, las clases derivadas están selladas, para que no se las pueda heredar. En muchas clases hay enumerados. Datos, que almacena muchas variables que se asignarán aleatoriamente, utiliza varios indexadores, que facilitan el acceso a esos datos.


**7. Herencia**
Dónde se usa (ejemplo): En la carpeta Equipamiento (Equipo deriva en Computadora o Cabina), Personas(Cliente deriva en Cliente de Computadora, o de Cabina y Sesiones (Sesion deriva en Sesion de computadora o de cabina)
Justificación: Organiza el código y facilita utilizar las clases enumeradas arriba.

**8. Polimorfismo**
Dónde se usa (ejemplo) y justificación: 
 - Se sobreescribe el método virtual Mostrar() de Cliente, en ClienteDeComputadora y ClienteDeCabina. Esto permite no tener que castear, por ejemplo, al extraer estos objetos de una lista y querer mostrarlos.
 - Sesion es una clase abstracta, que define dos campos abstractos, la propiedad EnCurso, y el método CalcularCosto(). Como las clases derivadas SesionComputadora y SesionCabina van a utilizar estos dos de formas diferentes, pero necesito que estén presentes, se justifica que sean abstractas.




## Propuesta de valor agregado

Como propuesta nueva está la posibilidad del usuario de ofrecer a los clientes en sesión diversos productos que aumentan la facturación y también tienen ciertos atributos dinámicos que hacen más divertida la experiencia apuntando a un fin lúdico de la aplicación. Me gustaría manejar mejor el concepto del tiempo, ya que el hecho de cerrar a discreción las sesiones trivializa la meta de facturar lo más posible. Podría buscarse una forma de que uno de los objetivos cruciales, por ejemplo, sea que el cliente pase el mayor tiempo posible en un equipo, para que siga consumiendo en base a un nivel de felicidad que hay que mantener dinámicamente.
