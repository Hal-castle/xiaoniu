using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace Model
{
    //部门表
    public class Department
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        ///主键
        public int Did { get; set; }
        ///所属单位(单位的外键)
        public int  Dunit { get; set; }
        ///部门名称
        public string  Dname { get; set; }
        ///部门代码
        public string  Dcode { get; set; }
        ///上级部门
        public int Dpid { get; set; }
        ///部门简称
        public string Djian { get; set; }
        ///分管领导'
        public string Dlead { get; set; }
        ///排序
        public int Dsort { get; set; }
        ///启用
        public bool Dstate { get; set; }
        ///创建时间
        public DateTime Dtimes { get; set; }
    }
}



