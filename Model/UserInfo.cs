using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_UCP.Model
{
	public class UserInfo : ObservableObject
	{
		#region 属性
		//用户名
		private string _uname;

		public string Uname
		{
			get { return _uname; }
			set { _uname = value; RaisePropertyChanged(() => Uname); }
		}
		//密码
		private string _upwd;

		public string Upwd
		{
			get { return _upwd; }
			set { _upwd = value; RaisePropertyChanged(() => Upwd); }
		}
		//登录状态
		private string _flag="";

		public string Flag
		{
			get { return _flag; }
			set { _flag = value; RaisePropertyChanged(() => Flag); }
		}
		//提示内容
		private string _word ;

		public string Word
		{
			get { return _word; }
			set { _word = value; RaisePropertyChanged(() => Word); }
		}
		#endregion

	}
}
