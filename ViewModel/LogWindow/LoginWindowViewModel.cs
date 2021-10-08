using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Lab_UCP.Model;
using Lab_UCP.View.UserContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab_UCP.ViewModel
{
    public class LoginWindowViewModel:ViewModelBase
    {
        private UserControl _userContent;            //LoginPage用户控件属性
        public UserControl UserContent
        {
            get { return _userContent; }
            set
            {
                if (_userContent == value)
                    return;
                _userContent = value;
                RaisePropertyChanged(() => UserContent);
            }
        }

        private UserInfo _user;                      //用户信息类属性
        public UserInfo User
        {
            get { return _user; }
            set { _user = value; RaisePropertyChanged(() => User); }
        }

        public LoginWindowViewModel()                //登录窗体构造函数
        {
            UserContent = new LoginPage();
            this.User = new UserInfo();
            Messenger.Default.Register<UserInfo>(this, "LoginPageUserInfo", SetUser);
        }

        private void SetUser(UserInfo obj)
        {
            this.User = obj;
        }
    }
}
