namespace ProjectZen.Service.Model
{
    public class CurrencyDataResult
    {
        public Max GetMax { get; set; }
        public Min GetMin { get; set; }
        public Avrage GetAvrage { get; set; }
     
    }
    public class Max
    {
        public float? max { get; set; }
        public string? date { get; set; }
    }
    public class Min
    {
        public float min { get; set; }
        public string date { get; set; }
    }
    public class Avrage
    {
        public float avrage { get; set; }
    }

}

