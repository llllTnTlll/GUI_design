using GalaSoft.MvvmLight;
using Lab_UCP.Model;
using Lab_UCP.View.UserContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_UCP.ViewModel.MainVM
{
    
    public class MenuListViewModel:ViewModelBase
    {
        public List<MenuListModel> ItemList
        {
            get
            {
                return new List<MenuListModel>()
                {
                    new MenuListModel(){Kind="AlignHorizontalLeft",Text="View" },
                    new MenuListModel(){Kind="Accounts",Text="Accounts" },
                    new MenuListModel(){Kind="Gear",Text="Setting" },
                    new MenuListModel(){Kind="HelpBox",Text="Help" },
                    new MenuListModel(){Kind="EmergencyExit",Text="Exit" },
                };
            }
        }

        public MenuListViewModel()
        {
                       
        }

    }
}
