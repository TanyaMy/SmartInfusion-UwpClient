using System;
using SmartInfusion_UwpClient.Data.Entities.Base;

namespace SmartInfusion_UwpClient.Data.Entities.Identity
{
    public class AppUser : IBaseEntity
    {
        public virtual UserInfo UserInfo { get; set; }

        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? Updated { get; set; }
    }
}
