# Razor.Role

Basicamente es una prueba dew concepto:

 * Recibe en el controlador, a traves de la querystring **(?role=algo)** una variable que identifica el nombre del supuesto rol.
 * Crea en el **ViewBag** una variable llamada **Role** con dicho valor, que es pasada al motor de vistas.
 * El tipo base de vistas (el nucleo de la prueba de concepto) se condiciona con ésta variable y, si existe, busca en todos los elementos del DOM con atributo role y los elimina, de manera que actualmente **la variable Role no define quien tiene permisos, si no quien no los tiene**:
 ```html 
 <p role="admin">algo que solo puede ver el administrador.</p>
 ```
 


Hay que cambiar en la configuración de las vistas el tipo de vistas base que se usará. en nuestro caso, al sobreescribir la funcionalidad basica de renderizado de la pagina y crear la clase WebViewPageCustom tendremos el siguiente codigo en la configuración Razor.Role/Razor.Role.Web/Views/Web.config.

```xml
<pages pageBaseType="Razor.Role.Web.WebViewPageCustom, Razor.Role.Web, Version=1.0.0.0, culture=neutral,  PublicKeyToken=82178810-6aa3-48b8-b865-9a4ca1e714fb">
      <namespaces>
        <add namespace="System.Web.Mvc" />
        <add namespace="System.Web.Mvc.Ajax" />
        <add namespace="System.Web.Mvc.Html" />
        <add namespace="System.Web.Optimization"/>
        <add namespace="System.Web.Routing" />
        <add namespace="Razor.Role.Web" />
      </namespaces>
    </pages>
```

Tenemos los namespaces basicos que usara la pagina, si se necesitan crear helpers o acceder a clases de configuracion estaticas globales se añadirá aquí. Si configuramos el sistema de roles por clase statica global y usamos el sistema actual de ViewBag no es necesario añadir ningún namespace. 


La solución usa MSHTML (vuelta a los COM) para poder navegar entre los nodos del DOM, manipularlos y renderizar en consecuencia. Aunque en éste proyecto no se usa, existe un paquete en Nuget de ésta misma libreria, [no oficial](https://www.nuget.org/packages/Unofficial.Microsoft.mshtml/). 



>  **Nota:**
> - Esto solo es una prueba de concepto, es posible que se extienda para crear nueva funcionalidad o que muera en éste estado.
> - Se ha seguido la documentación de Microsoft sobre [MSHTML](https://msdn.microsoft.com/en-us/library/mshtml(v=vs.110).aspx) para alcanzar el objetivo.
> - No se ha realizado ninguna prueba ni medición del rendimiento, no obstante, en el testeo, la plantilla por defecto del proyecto no aparenta ser afectada en tiempos de carga.
