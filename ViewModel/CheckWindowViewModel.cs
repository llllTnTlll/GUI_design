using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Lab_UCP.Model;
using Lab_UCP.View.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_UCP.ViewModel
{
    public class CheckWindowViewModel:ViewModelBase
    {
        #region 常量及属性的定义
        private readonly string connString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
        private CheckModel _check;                      
        public CheckModel Check
        {
            get { return _check; }
            set { _check = value; RaisePropertyChanged(() => Check); }
        }
        #endregion

        public CheckWindowViewModel()
        {
            Check = new CheckModel();
            Task.Factory.StartNew(CheckBegin);

        }

        private void CheckBegin()
        {
            Check.CheckingItem = "  正在检查数据库连接";
            try
            {
                Thread.Sleep(1000);
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
            }
            catch
            {
                MessageBox.Show("数据库连接存在问题");
            }
            
            Check.CheckingItem = "  检查日志文件完整性";
            //Do something more
            Thread.Sleep(1000);
            
            //通过Dispatcher对UI线程进行操作
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                Messenger.Default.Send<bool>(true,"CheckOver");

            }));

            
            
        }
    }
}
