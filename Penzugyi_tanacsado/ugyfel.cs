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
    
    public partial class ugyfel
    {
        public ugyfel()
        {
            this.talalkozo = new HashSet<talalkozo>();
        }
    
        public int ugyfel_id { get; set; }
        public string nev { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
    
        public virtual ICollection<talalkozo> talalkozo { get; set; }
        public virtual ugyfel ugyfel1 { get; set; }
        public virtual ugyfel ugyfel2 { get; set; }
    }
}