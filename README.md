# Entendiendo DataContract y DataMember de WCF con C#
		
<p align="justify">
Un contrato se define como: “un acuerdo entre partes que se debe de cumplir de manera obligada por cada una de ellas”, los contratos deben ser claros, definidos y sin ambigüedad para no dar lugar a una mala interpretación.
</p>

<p align="justify">
<a href="https://msdn.microsoft.com/en-us/library/dd456779(v=vs.110).aspx">Windows Communication Foundation</a> WCF utiliza este mismo concepto para definir un acuerdo entre clientes y servicios de un ambiente SOAP, en este contexto el contrato WCF define:
        <ul>
            <li>Las operaciones soportadas por el servicio.</li>
            <li>Los parámetros y los tipos de datos que regresan las operaciones.</li>
            <li>La estructura de los tipos de datos complejos que se pasan.</li>
            <li>Errores que pueden ocurrir al ejecutar una operación.</li>
        </ul>
</p>
<p align="justify">
Hay que recordar que los ambientes SOA son heterogéneos, por eso es recomendable que el contrato este separado de la implementación y que esa implementaciòn evite tipos específicos de su tecnología ya que esto podría causar problemas de portabilidad para comunicarse con un cliente que este implementado con una tecnología diferente.
</p>
<p align="justify">
Los contratos en el contexto SOA proporcionan todo el metadata necesario para comunicarse con el servicio, el metadata describe: tipos de datos, operaciones, patrones de intercambio de mensajes y el protocolo de transporte que se utiliza.
</p>
<p align="justify">
WCF define tres principales tipos de contrato:
</p>
<p align="justify">
        <ul>
            <li><b>Service contract:</b> Define las operaciones que el servicio tendrá disponibles para que los clientes puedan invocar mediante una petición request.</li>
            <li><b>Data contract:</b> Define la estructura de los datos que serán incluidos en el intercambio de los mensajes que van y vienen del servicio al cliente y viceversa.</li>
            <li><b>Message contract:</b> Habilita el control de los headers (encabezados) que utilizan los mensajes y como son utilizados por el servicio.</li>
        </ul>
</p>
<p align="justify">WCF utiliza el protocolo SOAP (Simple Object Access Protocol) como el formato de mensajería para las operaciones, cada operación desde el service contract (contrato de servicio) se vuelve un elemento en el cuerpo del mensaje cuando la operación es invocada.</p>
<p align="justify">En la definición de la operación se especifican los datos que son intercambiados entre el cliente y el servicio cuando la operación es invocada, como ejemplo la siguiente operación createAuthor para agregar un autor a una base de datos:</p>
<pre>
            [OperationContract]
        string CreateAuthor (string Firstname,
            string Lastname,
            DateTime Birthdate,
            bool Gender); 
</pre>
        <p align="justify">
            <ul>
                <li>Los parámetros de entrada en la operación definen los contenidos del cuerpo del mensaje enviado desde el cliente al servicio.</li>
                <li>El valor de retorno en la operación define los contenidos del cuerpo del mensaje enviado desde el servicio al cliente.</li>
            </ul>
        </p>
        <p align="justify">De manera predetermina el runtime de WCF toma la responsabilidad de convertir los tipos simples de .NET a tipos SOAP y viceversa, definiendo los tipos simples como:
        <ul>
            <li>Primitivos como enteros y cadenas.</li>
            <li>Tipos compuestos simples (struct) como DateTime</li>
            <li>Tipos basados en XML como un XmlElement</li>
            <li>Colecciones</li>
            <li>Enumeraciones</li>
        </ul>
        </p>
        <p align="justify">Sin embargo para tipos mas complejos como las clases o los tipos de datos definidos por el usuario es recomendable que se programe manualmente el mecanismo  de serialización/ desealización y esto se logra definiendo un <b>DataContract</b> para ese tipo de dato.</p>
        <p align="justify">En síntesis, para que un tipo de dato complejo sea serializado por el serializador de WCF se le debe aplicar un atributo <b>DataContract</b> a la definición de la clase y aplicar un atributo <b>DataMember</b> a cada uno de los campos que necesiten ser serializados sean estos un miembro de datos o una propiedad, los campos a los que no se les aplique el atributo <b>DataMember</b> son ignorados por el serializador.</p>
        <p align="justify">Como ejemplo de los atributos <b>DataContract</b> y <b>DataMember</b> definimos una clase <i>Author</i> que encapsula los parámetros de entrada de una nueva versión de la operación <i>createAuthor</i>.</p>
<p align="justify">Ahora la  versión de la operación <i>createAuthor</i> </p>
        <pre>            
        [OperationContract]
        string CreateAuthor (Author a); 
        </pre>
        <p align="justify">Adicionalmente podemos agregarle las siguientes propiedades al atributo <b>DataContract</b>:
        <ul>
            <li><b>Name:</b> Define el nombre del tipo que se genera en el metadata. Por default se utiliza el nombre del tipo.</li>
            <li><b>NameSpace:</b> Define el namespace utilizado en el esquema. Por default utiliza http://tempuri.org</li>
        </ul>
        </p>
        <p align="justify">De igual modo podemos agregar las siguientes propiedades al atributo <b>DataMember</b>:
        <ul>
            <li><b>Name:</b> Define el nombre que se utilizará en la generación del metadata. Por default es el nombre del campo.</li>
            <li><b>IsRequired:</b> Campo requerido, arroja una excepción si este campo no está cuando ocurra la deserialización.</li>
            <li><b>EmitDefaultValue:</b> Le dice al serializador que incluya el valor por default del campo cuando ocurra la serialización.</li>
            <li><b>Order:</b> Indica la posición del campo en la secuencia de serialización.</li>
        </ul>
        </p>
<p><h2>Ejemplo de una aplicación C# y un servicio WCF</h2></p>
<p align="justify">
Ahora un ejemplo funcional de una aplicación C# que hace uso de un servicio WCF para insertar y obtener registros de una tabla de autores en una base de datos PostgreSQL.
</p>
<p align="justify">
Para ejecutar la solución primeramente ejecutamos el programa de consola <i>[Samples.WCF.AuthorServiceHost.exe]</i> que activa el proceso que alberga el servicio WCF, el ejecutable se encuentra dentro del directorio <i>bin</i> con el siguiente comando:
</p>
        <pre>
            $ mono Samples.AuthorsServiceHost.exe
        </pre>
        <div>Fig 1. Ejecytando el servidor desde la linea de comando</div><br>
        <p>Ahora ejecutamos la solución cliente.</p>
        <div>
        <div>Fig 2. Iniciando el cliente</div>
        </div><br>
        <p align="justify">Podemos probar la aplicación al agregar un par de autores, como se muestran en la siguientes imágenes, después de ingresar cada autor pulsamos el botón <i>refresh grid</i></p>
        <div>Fig 3. Agregando un nuevo autor</div><br>
        <div>
        </div><br>
        <div>Fig 4. Pulsando el boton refrescar </div><br>
        <p>Cada uno de estos eventos se manejan a tráves de la clase proxy que se genera con el siguiente comando aplicándolo a la dll del servicio.</p>
        <pre>
            $svcutil /out:AuthorServiceReference.cs  Samples.WCF.AuthorsCatalogService.dll
        </pre>
        <div>Fig 5. El cliente y el servidor en ejecuccion</div><br>
        <p><h2>Conclusión</h2></p>
        <p>WCF proporciona facilidades para tomar el control de la serialización de datos. Sin embargo, hay que entender que entre más control manual tomes de tus servicios estos tenderán a ser menos interoperables.</p>
