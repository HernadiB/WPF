//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Penzugyi_tanacsado
{
    using System;
    using System.Collections.Generic;
    
    public partial class szakterulet
    {
        public szakterulet()
        {
            this.tanacsado = new HashSet<tanacsado>();
        }
    
        public int szakterulet_id { get; set; }
        public string megnevezes { get; set; }
    
        public virtual ICollection<tanacsado> tanacsado { get; set; }
    }
}
