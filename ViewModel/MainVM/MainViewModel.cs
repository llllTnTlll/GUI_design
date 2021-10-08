using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Lab_UCP.View.UserContent;
using System;
using System.Windows.Controls;

namespace Lab_UCP.ViewModel.MainVM
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        //列表控件属性
        private MenuList _menuListControl;
        public MenuList MenuListControl
        {
            get { return _menuListControl; }
            set { _menuListControl = value; RaisePropertyChanged(() => MenuListControl); }
        }

        //主窗体UserContent属性
        private UserControl _userContent;
        public UserControl UserContent
        {
            get { return _userContent; }
            set { _userContent = value; RaisePropertyChanged(() => UserContent); }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            MenuListControl = new MenuList();
            UserContent = new ScreenSaverPage();    //默认情况下UserContent为屏保

            //在接收到来自MenuList.xaml.cs的Messenger的SwitchViewPage指令时切换主窗体UserContent
            Messenger.Default.Register<bool>(this, "SwitchViewPage", SwitchViewPage);

        }

        private void SwitchViewPage(bool obj)
        {
            if (obj == true)
                this.UserContent = new ViewPage();
        }
    }
    
}