using System;

namespace Models.Currency
{
    public class Rate
    {
        public int CurId { get; set; }
        public DateTimeOffset Date { get; set; }
        public string CurAbbreviation { get; set; }
        public int CurScale { get; set; }
        public string CurName { get; set; }
        public double CurOfficialRate { get; set; }
    }
}