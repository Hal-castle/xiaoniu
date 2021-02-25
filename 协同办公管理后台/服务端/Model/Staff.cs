using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace Model
{
    //人员表
    public class Staff
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        //主键
        public int Staff_Id { get; set; }
        //名称
        public string Staff_Name { get; set; }
        //代码
        public string Staff_Code { get; set; }
        //单位(外键)
        public int Staff_Unit_Id { get; set; }
        //部门(外键)
        public int Staff_Department_Id { get; set; }
        //电话
        public int Staff_Phone { get; set; }
        //身份证
        public string Staff_IdCare { get; set; }
        //性别
        public int Staff_Sex { get; set; }
        //出生年月
        public DateTime Staff_Birthday { get; set; }
        //邮件
        public string Staff_Email{ get; set; }
        //籍贯
        public string Staff_Origin { get; set; }
        //地址
        public string Staff_Adress { get; set; }
        //备注
        public string Staff_Remark { get; set; }
        //照片
        public string Staff_Picture { get; set; }
        //创建时间
        public DateTime Staff_CreateTime { get; set; }
        //结束时间
        public DateTime Staff_EndTime { get; set; }
        //登入名
        public string Staff_Account { get; set; }
        //密码
        public string Staff_Password { get; set; }
        //角色（外键）
        public int Staff_Role_Id { get; set; }
    }
}
