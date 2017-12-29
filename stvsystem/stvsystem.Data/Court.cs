namespace stvsystem.Data
{
    public class Court
    {
        public int CourtID { get; set; }
        public int? CourtTypeID { get; set; }
        public string CourtName { get; set; }
    }

    public class CourtItem
    {
        public int CourtID { get; set; }
        public int? CourtTypeID { get; set; }
        public string CourtTypeName { get; set; }
        public string CourtName { get; set; }
    }
}
