using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace Model
{
    //权限表
    public class Power
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        ///主键
        public int Pid { get; set; }
        ///权限类型
        public int Ptypes { get; set; }
        ///权限分类
        public string Pclassify { get; set; }
        ///权限名称
        public string  Pname { get; set; }
        ///上级权限
        public int Pprev_authority { get; set; }
        ///排序
        public int Psort { get; set; }
        ///备注
        public string Plist { get; set; }
    }
}
