namespace API.Models
{
    public partial class InstructionStep
    {
        public int StepID { get; set; }
        public int StepNumber { get; set; }
        public int InstructionID { get; set; }
        public DateTime Time { get; set; }
        public int BlockID {  get; set; }
    }
}
