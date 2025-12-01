namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class ProductionSensorLog : BaseEntity
    {
        public Machine Machine { get; private set; } = default!;
        public string SensorName { get; private set; } = default!;
        public string Metric { get; private set; } = default!;
        public decimal Value { get; private set; }
        public DateTimeOffset CapturedAt { get; private set; } = DateTimeOffset.UtcNow;

        public ProductionSensorLog(Machine machine, string sensorName, string metric, decimal value)
        {
            Machine = machine;
            SensorName = sensorName;
            Metric = metric;
            Value = value;
        }
    }
}
