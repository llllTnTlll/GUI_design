using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_UCP.Model
{
    public class MenuListModel:ObservableObject
    {
        //这里没必要实现INotificationObject但是作者太懒不想改了

        //MenuList菜单的图标样式
        private string _kind;
        public string Kind
        {
            get { return _kind; }
            set { _kind = value;RaisePropertyChanged(()=>Kind); }
        }

        //MenuList菜单的文字内容
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; RaisePropertyChanged(() => Text); }
        }
    }
}
