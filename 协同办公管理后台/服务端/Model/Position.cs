using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace Model
{
    //岗位表
    public class Position
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        ///主键
        public int Position_id { get; set; }
        ///岗位编码
        public string Position_code { get; set; }
        ///岗位名称
        public string Position_name { get; set; }
        ///排序
        public int Position_sort { get; set; }
        ///备注
        public string Position_list { get; set; }
        ///最后修改时间
        public DateTime Position_times { get; set; }
    }
}
