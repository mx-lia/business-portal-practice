
namespace Domain.Entities
{
    public class Salary
    {
        public int Id { get; set; }
        public Function Function { get; set; }
        public Region Region { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

    }
}
