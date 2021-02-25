using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace Model
{
    //操作日志
    public class ULog
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        ///主键
        public int Uid { get; set; }
        ///时间
        public DateTime Utimes { get; set; }
        ///作者
        public string Uname { get; set; }
        ///操作应用
        public string Uapply { get; set; }
        ///操作类型
        public string Utype { get; set; }
        ///操作内容
        public string Ucontent { get; set; }



    }
}
