//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechnologicalPracticeApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EcoType_Ecolabel
    {
        public int Id { get; set; }
        public int EcoTypeID { get; set; }
        public int EcolabelID { get; set; }
    
        public virtual Ecolabel Ecolabel { get; set; }
        public virtual EcoType EcoType { get; set; }
    }
}