using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_UCP.Common
{
    public class UserService
    {
        #region 常量、变量的定义
        private readonly string connString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
        #endregion


        #region 用户登陆检查
        /// <summary>
        /// 管理员权限登录检查
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="loginPwd"></param>
        /// <returns></returns>
        public string CheckUserLogin(string loginId, string loginPwd)
        {
            //创建sql语句
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * from UserInfo");
            sb.AppendLine("where Uname=@LoginId and Upwd=@LoginPwd");
            //为stringbuilder填充参数
            SqlParameter[] parameters =
            {
                    new SqlParameter("@LoginID",loginId),
                    new SqlParameter("@LoginPwd", loginPwd)
                };
            string flag = "false";
            //创建连接对象
            SqlConnection conn = new SqlConnection(connString);
            //执行登录
            try
            {
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    flag = "true";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }
        #endregion
    }
}
