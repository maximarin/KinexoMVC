
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
    
public partial class Notes
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Notes()
    {

        this.Commentss = new HashSet<Commentss>();

    }


    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int IdCategory { get; set; }

    public System.DateTime Date { get; set; }

    public bool Active { get; set; }



    public virtual Categories Categories { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Commentss> Commentss { get; set; }

}

}
