using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LabUCP.Model;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Geared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;
using LiveCharts.Wpf;
using System.Windows.Controls;

namespace LabUCP.ViewModel
{
    public class ViewPageViewModel : ViewModelBase
    {
        #region 初始化属性
        private Func<double, string> _dateTimeFormatter;
        public Func<double, string> DateTimeFormatter
        {
            get { return _dateTimeFormatter; }
            set { _dateTimeFormatter = value;RaisePropertyChanged(() => DateTimeFormatter); }
        }


        private MeasureModel _myModel;

        public MeasureModel MyModel
        {
            get { return _myModel; }
            set { _myModel = value; RaisePropertyChanged(() => MyModel); }
        }

        #endregion

        public ViewPageViewModel()
        {
            #region 引入MeasureModel
            MyModel = new MeasureModel();
            #endregion

            #region 对View用户控件中的图标进行初始化设置
            var mapper = Mappers.Xy<MeasureModel>()
               .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
               .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);

            //the values property will store our values array
            MyModel.ChartValues1 = new GearedValues<MeasureModel>();
            MyModel.ChartValues2 = new GearedValues<MeasureModel>();
            MyModel.ChartValues3 = new GearedValues<MeasureModel>();


            //lets set how to display the X Labels
            DateTimeFormatter = value => new DateTime((long)value).ToString("hh:mm:ss");

            //AxisStep forces the distance between each separator in the X axis
            MyModel.AxisStep = TimeSpan.FromSeconds(1).Ticks;
            //AxisUnit forces lets the axis know that we are plotting seconds
            //this is not always necessary, but it can prevent wrong labeling
            MyModel.AxisUnit = TimeSpan.TicksPerSecond;

            SetAxisLimits(DateTime.Now);

            //The next code simulates data changes every 300 ms

            MyModel.IsReading = false;

            //DataContext = this;
            #endregion

        }

        private void SetAxisLimits(DateTime now)
        {
            MyModel.AxisMax = now.Ticks + TimeSpan.FromSeconds(1).Ticks; // lets force the axis to be 1 second ahead
            MyModel.AxisMin = now.Ticks - TimeSpan.FromSeconds(8).Ticks; // and 8 seconds behind
        }

        #region 开始读取命令
        private void Read()
        {
            var r1 = new Random();
            var r2 = new Random(1);
            var r3 = new Random(2);

            while (MyModel.IsReading)
            {
                Thread.Sleep(1000);
                var now = DateTime.Now;

                MyModel.Trend = r1.Next(0, 100);
                MyModel.Trend2 = r2.Next(0, 100);
                MyModel.Trend3 = r3.Next(0, 100);

                MyModel.ChartValues1.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = MyModel.Trend
                });
                MyModel.ChartValues2.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = MyModel.Trend2
                });
                MyModel.ChartValues3.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = MyModel.Trend3
                });

                SetAxisLimits(now);

                //lets only use the last 150 values
                if (MyModel.ChartValues1.Count > 150) MyModel.ChartValues1.RemoveAt(0);
                if (MyModel.ChartValues2.Count > 150) MyModel.ChartValues2.RemoveAt(0);
                if (MyModel.ChartValues2.Count > 150) MyModel.ChartValues3.RemoveAt(0);
            }
        }

        private RelayCommand _injectStopOnClick;

        public RelayCommand InjectStopOnClick
        {
            get
            {
                return _injectStopOnClick
                    ?? (_injectStopOnClick = new RelayCommand(
                    () =>
                    {
                        MyModel.IsReading = !MyModel.IsReading;
                        if (MyModel.IsReading) Task.Factory.StartNew(Read);
                    }));
            }
        }
        #endregion
        #region 开始存储为图片命令

        private void SaveToPng(FrameworkElement visual, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            EncodeVisual(visual, fileName, encoder);
        }

        private static void EncodeVisual(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {
            var bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = File.Create(fileName)) encoder.Save(stream);
        }

        private RelayCommand _saveToPngClick;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand SaveToPngClick
        {
            get
            {
                return _saveToPngClick
                    ?? (_saveToPngClick = new RelayCommand(
                    () =>
                    {
                        var myChart = new LiveCharts.Wpf.CartesianChart
                        {
                            DisableAnimations = true,
                            Width = 600,
                            Height = 200,
                            Series = new SeriesCollection
                            {
                                new LineSeries
                                {
                                    Values = MyModel.ChartValues1
                                },
                                new LineSeries
                                {
                                    Values = MyModel.ChartValues2
                                }

                            }
                        };

                        var viewbox = new Viewbox();
                        viewbox.Child = myChart;
                        viewbox.Measure(myChart.RenderSize);
                        viewbox.Arrange(new Rect(new Point(0, 0), myChart.RenderSize));
                        myChart.Update(true, true); //force chart redraw
                        viewbox.UpdateLayout();

                        SaveToPng(myChart, "chart.png");
                        //png file was created at the root directory.
                    }));
            }
        }
        #endregion
        #region 性能监视

        #endregion
    }
}
