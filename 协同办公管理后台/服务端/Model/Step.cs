using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace Model
{
    //步骤表
    public class Step
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        ///主键
        public int Sid { get; set; }
        ///步骤名称
        public string Sname { get; set; }
        ///步骤编码
        public string Scode { get; set; }
        ///处理人(外键)
        public int Speople { get; set; }
        ///返回设置
        public string Sset_up { get; set; }
    }
}
