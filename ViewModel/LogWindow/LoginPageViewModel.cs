using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Lab_UCP.Common;
using Lab_UCP.Model;
using Lab_UCP.View.UserContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace Lab_UCP.ViewModel
{
    //public class LoginButton:Button
    //{
    //    //定义路由事件
    //    public static readonly RoutedEvent MyRoutedEvent = EventManager.RegisterRoutedEvent("LoginFailed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LoginPage));
    //    //路由事件CLR封装
    //    public event RoutedEventHandler LoginFailed
    //    {
    //        add { this.AddHandler(MyRoutedEvent, value); }
    //        remove { this.RemoveHandler(MyRoutedEvent,value); }
    //    }
    //    //事件触发方法
    //    public void OnLoginFailed()
    //    {
    //        RoutedEventArgs args = new RoutedEventArgs();
    //        this.RaiseEvent(args);
    //    }


    //}

    public class LoginPageViewModel:ViewModelBase
    {
        #region 变量及属性的定义

        

        private UserInfo _user;                      //用户信息类属性
        public UserInfo User
        {
            get { return _user; }
            set { _user = value; RaisePropertyChanged(() => User); }
        }

        #endregion

        

        public LoginPageViewModel()
        {
            User = new UserInfo();
        }

        #region 登录命令
        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand
                    ?? (_loginCommand = new RelayCommand(
                    () =>
                    {
                        UserService myService = new UserService();
                        try
                        {
                            User.Flag = myService.CheckUserLogin(User.Uname.ToString(), User.Upwd.ToString());
                        }
                        catch
                        {
                            User.Word = "请输入用户名与密码";
                            User.Flag = "false";
                            User.Flag = "";
                            return;
                        }
                        if (User.Flag == "true")
                        {
                            //通知LoginWindow进行关闭动画
                            Messenger.Default.Send<UserInfo>(User, "LoginPageUserInfo");
                            //使用Timer为动画显示效果延时
                            Timer timer = new Timer();
                            timer.AutoReset = false;
                            timer.Interval = 400;
                            timer.Elapsed += Timer_Elapsed;
                            timer.Enabled = true;

                        }
                        else
                        {
                            
                            User.Word = "用户名或密码错误";
                            User.Flag = "";
                        }
                        
                        
                        
                    }));
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //通过Dispatcher对UI线程进行操作
            App.Current.Dispatcher.Invoke((Action)(() =>
            {

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Messenger.Default.Send<bool>(true, "LoginOver");
                Messenger.Default.Send<String>(User.Uname, "WhoseUsing");

            }));
        }

        #endregion
    }
}
