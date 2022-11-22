using System.Drawing;

namespace AnalyticalSystemSedge.App.Data.Charts
{
    public class Chart: EntityBase
    {
        public TypeChart Type { get; set; }
        public List<DataChart> Datas { get; set; }

        public Sigment Sigment { get; set; }

        public Size SizeChart { get; set; } 

        public int SortIndex { get; set; } = 0;

        public OptionsChart? Options { get; set; }
       

    }
}
