# Entendiendo DataContract y DataMember de WCF con GTK# y MonoDevelop

Un contrato se define como: “un acuerdo entre partes que se debe de cumplir de manera obligada por cada una de ellas”, los contratos deben ser claros, definidos y sin ambigüedad para no dar lugar a una mala interpretación.

Windows Communication Foundation WCF utiliza este mismo concepto para definir un acuerdo entre clientes y servicios de un ambiente SOAP, en este contexto el contrato WCF define:

Las operaciones soportadas por el servicio.
Los parámetros y los tipos de datos que regresan las operaciones.
La estructura de los tipos de datos complejos que se pasan.
Errores que pueden ocurrir al ejecutar una operación.
Hay que recordar que los ambientes SOA son heterogéneos, por eso es recomendable que el contrato este separado de la implementación y que esa implementaciòn evite tipos específicos de su tecnología ya que esto podría causar problemas de portabilidad para comunicarse con un cliente que este implementado con una tecnología diferente.

Los contratos en el contexto SOA proporcionan todo el metadata necesario para comunicarse con el servicio, el metadata describe: tipos de datos, operaciones, patrones de intercambio de mensajes y el protocolo de transporte que se utiliza.

WCF define tres principales tipos de contrato:

Service contract: Define las operaciones que el servicio tendrá disponibles para que los clientes puedan invocar mediante una petición request.
Data contract: Define la estructura de los datos que serán incluidos en el intercambio de los mensajes que van y vienen del servicio al cliente y viceversa.
Message contract: Habilita el control de los headers (encabezados) que utilizan los mensajes y como son utilizados por el servicio.
WCF utiliza el protocolo SOAP (Simple Object Access Protocol) como el formato de mensajería para las operaciones, cada operación desde el service contract (contrato de servicio) se vuelve un elemento en el cuerpo del mensaje cuando la operación es invocada.

En la definición de la operación se especifican los datos que son intercambiados entre el cliente y el servicio cuando la operación es invocada, como ejemplo la siguiente operación createAuthor para agregar un autor a una base de datos:

            [OperationContract]
        string CreateAuthor (string Firstname,
            string Lastname,
            DateTime Birthdate,
            bool Gender); 
        
Los parámetros de entrada en la operación definen los contenidos del cuerpo del mensaje enviado desde el cliente al servicio.
El valor de retorno en la operación define los contenidos del cuerpo del mensaje enviado desde el servicio al cliente.
De manera predetermina el runtime de WCF toma la responsabilidad de convertir los tipos simples de .NET a tipos SOAP y viceversa, definiendo los tipos simples como:

Primitivos como enteros y cadenas.
Tipos compuestos simples (struct) como DateTime
Tipos basados en XML como un XmlElement
Colecciones
Enumeraciones
Sin embargo para tipos mas complejos como las clases o los tipos de datos definidos por el usuario es recomendable que se programe manualmente el mecanismo de serialización/ desealización y esto se logra definiendo un DataContract para ese tipo de dato.

En síntesis, para que un tipo de dato complejo sea serializado por el serializador de WCF se le debe aplicar un atributo DataContract a la definición de la clase y aplicar un atributo DataMember a cada uno de los campos que necesiten ser serializados sean estos un miembro de datos o una propiedad, los campos a los que no se les aplique el atributo DataMember son ignorados por el serializador.

Como ejemplo de los atributos DataContract y DataMember definimos una clase Author que encapsula los parámetros de entrada de una nueva versión de la operación createAuthor.



Ahora la versión de la operación createAuthor

            
        [OperationContract]
        string CreateAuthor (Author a); 
        
Adicionalmente podemos agregarle las siguientes propiedades al atributo DataContract:

Name: Define el nombre del tipo que se genera en el metadata. Por default se utiliza el nombre del tipo.
NameSpace: Define el namespace utilizado en el esquema. Por default utiliza “http://tempuri.org”
De igual modo podemos agregar las siguientes propiedades al atributo DataMember:

Name: Define el nombre que se utilizará en la generación del metadata. Por default es el nombre del campo.
IsRequired: Campo requerido, arroja una excepción si este campo no está cuando ocurra la deserialización.
EmitDefaultValue: Le dice al serializador que incluya el valor por default del campo cuando ocurra la serialización.
Order: Indica la posición del campo en la secuencia de serialización.
Ejemplo de una aplicación GTK# y un servicio WCF
Ahora un ejemplo funcional de una aplicación GTK# que hace uso de un servicio WCF para insertar y obtener registros de una tabla de autores en una base de datos PostgreSQL, aquí esta el esquema de la tabla. (Para más información de una solución WCF en Monodevelop consultar Introducción a WCF con GTK# y MonoDevelop)



A continuación el código del store en PL/SQL para insertar un registro



Bien ahora una vista de la solución en el explorador de soluciones de Monodevelop.



La solución se llama Samples.WCF.AuthorsCatalog y tiene los siguientes proyectos:

Samples.WCF.AuthorsCatalog: Este proyecto contiene la entidad Author que es la clase que es serializada por el runtime para intercambiar los datos entre la aplicación GTK# y el servicio WCF.
Samples.WCF.AuthorsCatalogService: Este es el proyecto del servicio WCF, contiene la clase AuthorsDataHelper que es la que se comunica con la base de datos, la clase AuhorServiceImplementation que es la implementación del servicio y la interface IAuthorServiceContract que es el contrato del servicio.
Samples.WCF.AuthorServiceHost: Este proyecto contiene una aplicación de consola que es el hosting para el servicio WCF.
Samples.WCF.GUIAuthorsCatalog: Este proyecto contiene al cliente GTK# que tiene una GUI (Graphical User Interface) que utiliza la clase proxy para comunicarse con el servicio WCF.
El proyecto Samples.WCF.AuthorsCatalog ejemplifica la aplicación de los atributos DataContract y DataMember con el código de la siguiente clase:



Esta clase sirve como argumento de petición y de respuesta en el contrato y por consecuente en la implementación del servicio como muestro en el código fuente del contrato y de la implementación que se encuentran en el proyecto [Samples.WCF.AuthorsCatalogService]. Aquí esta el código fuente del contrato del servicio IAuthorServiceContract:


Ahora el código fuente de la implementación AuthorServiceImplementation:


Para ejecutar la solución primeramente ejecutamos el programa de consola [Samples.WCF.AuthorServiceHost.exe] que activa el proceso que alberga el servicio WCF, el ejecutable se encuentra dentro del directorio “bin” debajo de la ruta Samples.WCF.AuthorsCatalog/Samples.WCF.AuthorServiceHost/bin/Debug. con el siguiente comando:

            $ mono Samples.WCF.AuthorServiceHost.exe
        


Ahora ejecutamos la solución desde MonoDevelop.


Podemos probar la aplicación al agregar un par de autores, como se muestran en la siguientes imágenes, después de ingresar cada autor pulsamos el botón refresh grid




Cada uno de estos eventos se manejan a tráves de la clase proxy que se genera con el siguiente comando aplicándolo a la dll del servicio.

            $svcutil /out:AuthorServiceReference.cs  Samples.WCF.AuthorsCatalogService.dll
        


Conclusión
WCF proporciona facilidades para tomar el control de la serialización de datos. Sin embargo, hay que entender que entre más control manual tomes de tus servicios estos tenderán a ser menos interoperables.
