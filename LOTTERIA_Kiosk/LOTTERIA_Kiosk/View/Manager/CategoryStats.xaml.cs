﻿using LiveCharts;
using LiveCharts.Wpf;
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

namespace LOTTERIA_Kiosk.View.Manager
{
    /// <summary>
    /// CategoryStats.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CategoryStats : Page
    {
        public CategoryStats()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "판매 수량",
                    Values = new ChartValues<double> { 51, 25, 60, 4 }
                }
            };

            Labels = new[] { "햄버거", "음료수", "디저트", "치킨" };
            Formatter = value => value.ToString("N");
            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

    }
}

