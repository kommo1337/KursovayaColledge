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
    /// Логика взаимодействия для StatisticVidReklamaPage.xaml
    /// </summary>
    public partial class StatisticVidReklamaPage : Page
    {
        private SeriesCollection seriesCollection;
        public SeriesCollection SeriesCollection
        {
            get { return seriesCollection; }
            set
            {
                seriesCollection = value;
                OnPropertyChanged("SeriesCollection");
            }
        }

        private string[] labels;
        public string[] Labels
        {
            get { return labels; }
            set
            {
                labels = value;
                OnPropertyChanged("Labels");
            }
        }
        public Func<double, string> Formatter { get; set; }

        public StatisticVidReklamaPage()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Наружная реклама",
                    Values = new ChartValues<double> { 1, 1.2, 1.5, 1.8, 1.9, 2, 2.1, 2.2 }
                },
                new ColumnSeries
                {
                    Title = "ТВ Реклама",
                    Values = new ChartValues<double> { 0.8, 1, 1.2, 1.5, 1.8, 2, 2.2, 2.3 }
                },
                new ColumnSeries
                {
                    Title = "Реклама в интернете",
                    Values = new ChartValues<double> { 0.5, 0.7, 1, 1.2, 1.5, 2, 2.4, 2.8 }
                }
            };

            Labels = new[] { "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", };

            Formatter = value => value.ToString("N") + "K";

            DataContext = this;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

