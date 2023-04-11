using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace KursovayaColledge.PageFolder.DirectorPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AllStatisticPage.xaml
    /// </summary>
    public partial class AllStatisticPage : Page
    {
        public AllStatisticPage()
        {
            InitializeComponent();

            var years = new[] { "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022" };
            var adsCount = new[] { 1000, 2000, 3000, 4000, 4500, 5000, 5500, 6000 };

            
            var series = new LineSeries
            {
                Title = "Количество рекламы",
                Values = new ChartValues<int>(adsCount),
                PointGeometry = null
            };

            
            AdsChart.Series = new SeriesCollection { series };

           
            AdsChart.AxisX.Add(new Axis { Title = "Год", Labels = years });
            AdsChart.AxisY.Add(new Axis { Title = "Количество рекламы" });

        }
    }
}
