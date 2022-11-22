using System.Collections;
using System.Data;

namespace AnalyticalSystemSedge.App.Data.Charts
{
    public class DataChart : EntityBase
    {
        public List<Labels> labels { get; set; }

     public List<DataSetChart> dataSetCharts { get; set; }

    }
}
