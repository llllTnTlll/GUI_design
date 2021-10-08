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
using System.Windows.Shapes;

namespace Lab_UCP.View.Windows
{
    /// <summary>
    /// CheckWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CheckWindow : Window
    {
        public CheckWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<bool>(this, "CheckOver", CloseThis);
            this.Unloaded += (sender, e) => Messenger.Default.Unregister(this);
        }

        private void CloseThis(bool flag)
        {
            if(flag==true)
            {
                this.Close();
            }
        }
    }
}
