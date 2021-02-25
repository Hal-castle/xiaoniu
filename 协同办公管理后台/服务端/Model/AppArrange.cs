using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace Model
{
    //应用分类
    public class AppArrange
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        ///主键
        public int Aid { get; set; }
        ///应用名称'
        public string Aname { get; set; }
        ///岗位编码
        public string APost_code { get; set; }
        ///备注
        public string Alist { get; set; }
        ///排序
        public int Asort { get; set; }
        ///最后修改时间
        public DateTime Atimes { get; set; }
    }
}
