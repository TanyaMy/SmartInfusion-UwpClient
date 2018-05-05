using System;
using System.Collections.Generic;

namespace SmartInfusion_UwpClient.Data.Entities.DiseaseHistory
{
    public class DiseaseHistoryListModel
    {
        public ICollection<DiseaseHistoryListItemModel> DiseaseHistoryList { get; set; }
    }
}
