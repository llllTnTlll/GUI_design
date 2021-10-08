using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_UCP.Model
{
    public class ScreenSaverModel : ObservableObject
    {
        private string _time;
        /// <summary>
        /// 当前系统时间
        /// </summary>
        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                RaisePropertyChanged(() => Time);
            }
        }


        private bool _isReading;
        /// <summary>
        /// 状态判定参数
        /// </summary>
        public bool IsReading
        {
            get { return _isReading; }
            set
            {
                _isReading = value;
                RaisePropertyChanged(() => IsReading);
            }
        }

        private string _greetingWord;
        /// <summary>
        /// 欢迎词时间前缀
        /// </summary>
        public string GreetingWord
        {
            get { return _greetingWord; }
            set
            {
                _greetingWord = value;
                RaisePropertyChanged(() => GreetingWord);
            }
        }
    }
}
