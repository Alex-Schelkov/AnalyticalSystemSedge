using System.ComponentModel.DataAnnotations;

namespace AnalyticalSystemSedge.App.Data.Charts
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
