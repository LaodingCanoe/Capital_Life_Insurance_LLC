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
    
    public partial class Grade
    {
        public int GradeID { get; set; }
        public int CandidateID { get; set; }
        public int UserID { get; set; }
        public int QuestionID { get; set; }
        public Nullable<double> Grade1 { get; set; }
    
        public virtual CandidateCard CandidateCard { get; set; }
        public virtual Users Users { get; set; }
        public virtual Question Question { get; set; }
    }
}
