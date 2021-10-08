using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_UCP.Model
{
     public class CheckModel:ObservableObject
    {
		//检查项
		private string _checkingItem;

		public string CheckingItem
		{
			get { return _checkingItem; }
			set { _checkingItem = value; RaisePropertyChanged(() => CheckingItem); }
		}
	}
}
