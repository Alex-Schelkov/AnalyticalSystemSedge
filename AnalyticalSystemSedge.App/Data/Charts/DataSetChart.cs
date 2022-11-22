using System.Drawing;

namespace AnalyticalSystemSedge.App.Data.Charts
{
    public class DataSetChart:EntityBase
    {
        public string Caption { get; set; }

        public Color Color { get; set; }
        public List<double> Values { get; set; }
    }
}
