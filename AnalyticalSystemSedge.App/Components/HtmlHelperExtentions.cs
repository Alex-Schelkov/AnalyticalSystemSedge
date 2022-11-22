using AnalyticalSystemSedge.App.Data.Charts;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace AnalyticalSystemSedge.App.Components
{
    public static class HtmlHelperExtentions
    {
        public static HtmlString Chart()
        {
            StringBuilder htmlCollector = new StringBuilder();

            //--- УСТАНОВКА параметов char
            Chart chart = new Chart();
            
            chart.Sigment = new Sigment() { Id = 1};
            chart.Id = 1;
            chart.Type = TypeChart.bar;

            //опции
            OptionsChart options = new OptionsChart();
            options.Vertical = true;
            options.Cumulative = true;
            options.Text = "Количество обращений (в штуках) [на 12.11.2022]";
            chart.Options = options;
         

            List<DataChart> datas = new List<DataChart>();

        
            List <DataSetChart> datasets = new List<DataSetChart>();
            datasets.Add(new DataSetChart() { Caption = "Благодарности", Values = new List<double>() { 3, 6, 7, 7, 11, 15, 3, 15, 13, 10,  8, 5 }, Color = Color.Orange });
           datasets.Add(new DataSetChart() { Caption = "Жалобы",         Values = new List<double>() { 1, 2, 3, 1,  5,  7, 9, 11, 1, 15, 12, 9 }, Color = Color.HotPink });
            datasets.Add(new DataSetChart() { Caption = "Нейтральные отзывы", Values = new List<double>() { 6, 3, 5, 7, 9, 12, 14, 4, 3, 2, 1, 2 }, Color = Color.Lime });


            List<Labels> labels = new List<Labels>();
            labels.Add(new Labels() { Text = "КЦСОН Северный округ Оренбург" });
            labels.Add(new Labels() { Text = "КЦСОН Южный округ Оренбург"});
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


            datas.Add(new DataChart() { labels = labels , dataSetCharts= datasets});
            //---------------------------------

            //--размеры доделать
            htmlCollector.AppendLine($"<canvas id=\"{"chart_orb" + chart.Id}\"></canvas>");


            //--генерация js
            htmlCollector.AppendLine("<script>");

            //--name
            htmlCollector.AppendLine($"const {"chart_orb" + chart.Id} = document.getElementById('{"chart_orb" + chart.Id}');");

            //--trueoptions
            htmlCollector.AppendLine($"const {"chart" + chart.Id} = new Chart({"chart_orb" + chart.Id}, {{");
            htmlCollector.AppendLine($"type: '{chart.Type.ToString()}',");
            htmlCollector.AppendLine("axis: 'y',");
       
            //--data
            foreach (var data in datas)
           {
                htmlCollector.AppendLine("data: {");

                //--labels добавить перечисление
                htmlCollector.AppendLine("labels: [");
                foreach (var label in data.labels)
                {
                    if (label != data.labels[data.labels.Count - 1])
                    {
                        htmlCollector.AppendLine($"'{label.Text}',");
                    }
                    else
                    {
                        htmlCollector.AppendLine($"'{label.Text}'],");
                    }
                }

                //--datasets

                htmlCollector.AppendLine("datasets: [");
                foreach (var dataSet in data.dataSetCharts)
                {
                    //--labels set
                    htmlCollector.AppendLine($"{{label: '{dataSet.Caption}',");

                    //--Data раскидать через перечисление

                    htmlCollector.AppendLine($"data: [");
                    
                    for (int i = 0; i < dataSet.Values.Count; ++i)
                    {
                        double  val =  dataSet.Values[i];
                        if (i == (dataSet.Values.Count-1))
                        {
                            htmlCollector.AppendLine($"{val}]");
                        }
                        else
                        {
                            htmlCollector.AppendLine($"{val},");
                        }
                    }

                    //--цвет линий
                 htmlCollector.AppendLine($",fill: true, backgroundColor: 'rgb({dataSet.Color.R}, {dataSet.Color.G}, {dataSet.Color.B},0.5)',borderColor: 'rgb({dataSet.Color.R}, {dataSet.Color.G}, {dataSet.Color.B})'");

                    if (dataSet != data.dataSetCharts.Last())
                    {
                        htmlCollector.AppendLine("},");
                    }
                    else
                    {
                        htmlCollector.AppendLine("}]");
                    }
                }
                htmlCollector.AppendLine("}");
            }

            // htmlCollector.AppendLine($"alert('{"chart_orb" + chart.Id}');");

            //option
            if (chart.Options != null)
            {
                htmlCollector.AppendLine(", options: { ");

                //for bar
                if (chart.Options.Vertical == true)
                {
                    //Первернуть диаграмму
                    if (chart.Options.Vertical == true)
                        htmlCollector.AppendLine(" indexAxis: 'y' ,");

                    //диаграмма с накоплением
                    if (chart.Options.Cumulative == true)
                        htmlCollector.AppendLine(" scales:{  x: { stacked: true},y: { stacked: true }}");
                }


                //plagins
                htmlCollector.AppendLine(",plugins:{");
                //Отображение легенды
                htmlCollector.AppendLine("legend:{position: 'top', },");
                //Наименование схемы
                htmlCollector.AppendLine($"title: {{ display: true, text: '{chart.Options.Text}'}}");
                htmlCollector.AppendLine("}");

                htmlCollector.AppendLine("}");
            }
            htmlCollector.AppendLine("});");

            htmlCollector.AppendLine("</script>");

            return new HtmlString(htmlCollector.ToString());
        }
    }
}


