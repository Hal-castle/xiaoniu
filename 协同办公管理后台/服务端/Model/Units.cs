using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace Model
{
    //单位表
    public class Units
    {
        ///主键
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        public int Uid { get; set; }
        ///单位名称
        public string Uname { get; set; }
        ///单位编码
        public string  Ucoding { get; set; }
        //单位级别
        public string Unit_level { get; set; }
        ///排序
        public int Usort { get; set; }
        ///状态
        public bool Ustate { get; set; }
        ///创建时间
        public DateTime Ubegin { get; set; }
        ///结束时间
        public DateTime Uend { get; set; }
        //上级单位自连接
        public int MyProperty { get; set; }
    }
}
