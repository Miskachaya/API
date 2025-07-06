namespace API.Models
{
    public partial class ParametersChange
    {
        public int ChangeID { get; set; }
        public int StepID { get; set; }
        public string Parameter {  get; set; }
        public double ParaneterValue { get; set; }
    }
}
