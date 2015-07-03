using System;

namespace EF_TPT.Domain.Entities.Base
{
    public class BaseAuditedEntity : BaseEntity
    {
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
