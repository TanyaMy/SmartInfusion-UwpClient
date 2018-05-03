using SmartInfusion_UwpClient.Data.Entities.Metric;
using SmartInfusion_UwpClient.Data.Entities.Treatment;
using SmartInfusion_UwpClient.Presentation.Models.UserInfo;
using System.Collections.Generic;


namespace SmartInfusion_UwpClient.Data.Entities.DiseaseHistory
{
    public class DiseaseHistoryDetailsModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public UserInfoDetailedModel PatientInfo { get; set; }

        public List<MetricListItemViewModel> Metrics { get; set; }

        public List<TreatmentListItemViewModel> Treatments { get; set; }
    }
}
