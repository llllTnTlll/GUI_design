using GalaSoft.MvvmLight;
using LiveCharts.Geared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabUCP.Model
{
    public class MeasureModel:ObservableObject
    {
        private DateTime _dateTime;
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateTime
        {
            get
            {
                return _dateTime;
            }
            set
            {
                _dateTime = value;
                RaisePropertyChanged(() => DateTime);
            }
        }

        private double _value;
        /// <summary>
        /// 
        /// </summary>
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                RaisePropertyChanged(() => Value);
            }
        }


        private bool _isReading;
        /// <summary>
        /// 
        /// </summary>
        public bool IsReading
        {
            get
            {
                return _isReading;
            }
            set
            {
                _isReading = value;
                RaisePropertyChanged(() => IsReading);
            }
        }

        private double _axisStep;
        /// <summary>
        /// 
        /// </summary>
        public double AxisStep
        {
            get
            {
                return _axisStep;
            }
            set
            {
                _axisStep = value;
                RaisePropertyChanged(() => AxisStep);
            }
        }

        private double _axisUnit;
        /// <summary>
        /// 
        /// </summary>
        public double AxisUnit
        {
            get
            {
                return _axisUnit;
            }
            set
            {
                _axisUnit = value;
                RaisePropertyChanged(() => AxisUnit);
            }
        }

        private double _axisMax;
        /// <summary>
        /// 
        /// </summary>
        public double AxisMax
        {
            get
            {
                return _axisMax;
            }
            set
            {
                _axisMax = value;
                RaisePropertyChanged(() => AxisMax);
            }
        }

        private double _axisMin;
        /// <summary>
        /// 
        /// </summary>
        public double AxisMin
        {
            get
            {
                return _axisMin;
            }
            set
            {
                _axisMin = value;
                RaisePropertyChanged(() => AxisMin);
            }
        }

        private double _trend;
        /// <summary>
        /// 
        /// </summary>
        public double Trend
        {
            get
            {
                return _trend;
            }
            set
            {
                _trend = value;
                RaisePropertyChanged(() => Trend);
            }
        }

        private double _trend2;
        /// <summary>
        /// 
        /// </summary>
        public double Trend2
        {
            get
            {
                return _trend2;
            }
            set
            {
                _trend2 = value;
                RaisePropertyChanged(() => Trend2);
            }
        }

        private double _trend3;
        /// <summary>
        /// 
        /// </summary>
        public double Trend3
        {
            get
            {
                return _trend3;
            }
            set
            {
                _trend3 = value;
                RaisePropertyChanged(() => Trend3);
            }
        }

        private GearedValues<MeasureModel> _chartValues1;
        /// <summary>
        /// 
        /// </summary>
        public GearedValues<MeasureModel> ChartValues1
        {
            get
            {
                return _chartValues1;
            }
            set
            {
                _chartValues1 = value;
                RaisePropertyChanged(() => ChartValues1);
            }
        }


        private GearedValues<MeasureModel> _chartValues2;
        /// <summary>
        /// 
        /// </summary>
        public GearedValues<MeasureModel> ChartValues2
        {
            get
            {
                return _chartValues2;
            }
            set
            {
                _chartValues2 = value;
                RaisePropertyChanged(() => ChartValues2);
            }
        }

        private GearedValues<MeasureModel> _chartValues3;
        /// <summary>
        /// 
        /// </summary>
        public GearedValues<MeasureModel> ChartValues3
        {
            get
            {
                return _chartValues3;
            }
            set
            {
                _chartValues3 = value;
                RaisePropertyChanged(() => ChartValues3);
            }
        }
    }
}
