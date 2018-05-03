using System.Collections.Generic;

namespace SmartInfusion_UwpClient.Data.Entities.Treatment
{
    public class TreatmentListViewModel
    {
        public ICollection<TreatmentListItemViewModel> Treatments { get; set; }
    }
}
