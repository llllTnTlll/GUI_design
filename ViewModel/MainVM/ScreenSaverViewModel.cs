using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Lab_UCP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_UCP.ViewModel.MainVM
{


    public class ScreenSaverViewModel:ViewModelBase
    {
        #region 属性注册

        private ScreenSaverModel _saverModel;
        /// <summary>
        /// 
        /// </summary>
        public ScreenSaverModel SaverModel
        {
            get { return _saverModel; }
            set { _saverModel = value; RaisePropertyChanged(() => SaverModel); }
        }

        private UserInfo _uInfo;
        /// <summary>
        /// 
        /// </summary>
        public UserInfo UInfo
        {
            get { return _uInfo; }
            set { _uInfo = value; RaisePropertyChanged(() => UInfo); }
        }

        #endregion
        public ScreenSaverViewModel()
        {
            SaverModel=new ScreenSaverModel { Time = DateTime.Now.ToString("hh:mm:ss"), IsReading = true };
            UInfo = new UserInfo();
            Messenger.Default.Register<String>(this, "WhoseUsing", Userconfir);
            Task.Factory.StartNew(Read);
            Task.Factory.StartNew(Get_Greetings);
        }

        //取得正确的问候语
        private void Get_Greetings()
        {
            while (SaverModel.IsReading)
            {
                var now = DateTime.Now;
                int times = now.Hour;
                if (times >= 6 && times < 9) { SaverModel.GreetingWord = "早上好, " + UInfo.Uname; }
                if (times >= 9 && times < 11) { SaverModel.GreetingWord = "上午好, " + UInfo.Uname; }
                if (times >= 11 && times < 13) { SaverModel.GreetingWord = "中午好, " + UInfo.Uname; }
                if (times >= 13 && times < 17) { SaverModel.GreetingWord = "下午好, " + UInfo.Uname; }
                if (times >= 17 || times < 6) { SaverModel.GreetingWord = "晚上好, " + UInfo.Uname; }
                Thread.Sleep(100);
            }
        }

        //刷新时间
        private void Read()
        {
            while (SaverModel.IsReading)
            {
                SaverModel.Time = DateTime.Now.ToString("hh:mm:ss");
                Thread.Sleep(100);
            };
        }

        //接收Messenger 正确设置问候对象
        private void Userconfir(string obj)
        {
            this.UInfo.Uname = obj;
        }
    }
}
