//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppS2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Printer
    {
        public int code { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public string type { get; set; }
        public Nullable<decimal> price { get; set; }
    
        internal virtual Product Product { get; set; }
    }
}
