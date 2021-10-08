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

namespace Lab_UCP.View.UserContent
{
    /// <summary>
    /// MenuListControl.xaml 的交互逻辑
    /// </summary>
    public partial class MenuList : UserControl
    {
        public MenuList()
        {
            InitializeComponent();
        }

        //点击左侧菜单栏按钮后，切换相应UserControl
        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(MenuListBox.SelectedIndex){
                case 0:
                    {
                        Messenger.Default.Send<bool>(true,"SwitchViewPage");
                        break;
                    }
                case 4:
                    {
                        Messenger.Default.Send<bool>(true, "ExitApp");
                        break;
                    }
            }
        }
    }
}
