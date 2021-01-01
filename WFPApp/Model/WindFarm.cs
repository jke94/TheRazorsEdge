namespace WFPApp.Model
{
    public class WindFarm
    {
        private string windFarmName;

        public string WindFarmName { get => windFarmName; set => windFarmName = value; }

        public WindFarm(string windFarmName)
        {
            WindFarmName = windFarmName;
        }
    }
}