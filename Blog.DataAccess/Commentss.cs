
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Blog.DataAccess
{

using System;
    using System.Collections.Generic;
    
public partial class Commentss
{

    public int Id { get; set; }

    public int IdNote { get; set; }

    public string Description { get; set; }

    public bool Active { get; set; }

    public string IdUser { get; set; }



    public virtual Notes Notes { get; set; }

}

}
