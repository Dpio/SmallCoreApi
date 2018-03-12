namespace Store.DataAccess.Entities
{
    public class ProductFilterInput
    {
        public int MaxResultCount { get; set;  }
        public int SkipCount { get; set; }
        public string CategoryCode { get; set; }
        public string UnitCode { get; set; }
        public string TypeCode { get; set; }
    }
}