//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capital_Life_Insurance_LLC
{
    using System;
    using System.Collections.Generic;
    
    public partial class EducationDocument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EducationDocument()
        {
            this.CandidateCard = new HashSet<CandidateCard>();
        }
    
        public int EducationDocumentID { get; set; }
        public string EducationDocumentTitle { get; set; }
        public int SpecialityID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidateCard> CandidateCard { get; set; }
        public virtual Speciality Speciality { get; set; }
    }
}
