using AnalyticalSystemSedge.App.Data.Charts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace AnalyticalSystemSedge.App.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public Chart TestChart { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            Chart chart = new Chart();
        //--- УСТАНОВКА параметов char


        chart.Sigment = new Sigment() { Id = 1 };
            chart.Id = 1;
            chart.Type = TypeChart.bar;

            //опции
            OptionsChart options = new OptionsChart();
            options.Vertical = true;
            options.Cumulative = true;
            options.Text = "Количество обращений (в штуках) [на 12.11.2022]";
            chart.Options = options;


            List<DataChart> datas = new List<DataChart>();


            List<DataSetChart> datasets = new List<DataSetChart>();
            datasets.Add(new DataSetChart() { Caption = "Благодарности", Values = new List<double>() { 3, 6, 7, 7, 11, 15, 3, 15, 13, 10, 8, 5 }, Color = Color.Orange });
            datasets.Add(new DataSetChart() { Caption = "Жалобы", Values = new List<double>() { 1, 2, 3, 1, 5, 7, 9, 11, 1, 15, 12, 9 }, Color = Color.HotPink });
            datasets.Add(new DataSetChart() { Caption = "Нейтральные отзывы", Values = new List<double>() { 6, 3, 5, 7, 9, 12, 14, 4, 3, 2, 1, 2 }, Color = Color.Lime });


            List<Labels> labels = new List<Labels>();
            labels.Add(new Labels() { Text = "КЦСОН Северный округ Оренбург" });
            labels.Add(new Labels() { Text = "КЦСОН Южный округ Оренбург" });
            labels.Add(new Labels() { Text = "КЦСОН Орск" });
            labels.Add(new Labels() { Text = "КЦСОН Сорочинск" });
            labels.Add(new Labels() { Text = "КЦСОН Соль-Илецк" });
            labels.Add(new Labels() { Text = "КЦСОН Бузулук" });
            labels.Add(new Labels() { Text = "КЦСОН Бугуруслан" });
            labels.Add(new Labels() { Text = "КЦСОН Гай" });
            labels.Add(new Labels() { Text = "КЦСОН Ясный" });
            labels.Add(new Labels() { Text = "КЦСОН Медногорск" });
            labels.Add(new Labels() { Text = "КЦСОН Кувандык" });
            labels.Add(new Labels() { Text = "КЦСОН Оренбургский" });


            datas.Add(new DataChart() { labels = labels, dataSetCharts = datasets });

            chart.Datas = datas;

            TestChart = chart;


        }
    }
}