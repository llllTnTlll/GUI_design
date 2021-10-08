using GalaSoft.MvvmLight.Messaging;
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

namespace Lab_UCP
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //在接收到来自MenuList.xaml.cs的Messenger的ExitApp指令时关闭程序
            Messenger.Default.Register<bool>(this, "ExitApp", ExitApp);
            this.Unloaded += (sender, e) => Messenger.Default.Unregister(this);

            
        }


        private void ExitApp(bool obj)
        {
            if (obj == true)
                this.Close();
        }
    }
}
