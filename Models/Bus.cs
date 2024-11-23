namespace hackaton.Models
{
    public class Bus
    {
        public int id { get; set; }

        public string route { get; set; }

        public DateOnly date { get; set; }

        public string comfort { get; set; }

        public string seats { get; set; }

        public bool conditioner { get; set; }

        public bool trunk { get; set; }

        public bool isSelected { get; set; }

        public string tg_name { get; set; }
    }
}
