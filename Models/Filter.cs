namespace hackaton.Models
{
    public class Filter
    {

        public string route { get; set; }

        public DateOnly date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public string comfort { get; set; }

        public string seats { get; set; }

        public bool conditioner { get; set; }

        public bool trunk { get; set; }
    }
}
