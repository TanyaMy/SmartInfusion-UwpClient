using System.Collections.Generic;

namespace SmartInfusion_UwpClient.Data.Entities.Medicine
{
    public class MedicineListViewModel
    {
        public ICollection<MedicineListItemViewModel> Medicines { get; set; }
    }
}
