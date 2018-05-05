using System;

namespace SmartInfusion_UwpClient.Data.Entities.Metric
{
    public class MetricListItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public int DiseaseHistoryId { get; set; }

        public DateTime Created { get; set; }

        public string DisplayName
        {
            get => Name + ":";
        }

    }
}
