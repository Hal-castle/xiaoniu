using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //插入应用
    public  class InsertApply
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        ///主键
        public int InsertApply_id { get; set; }

        //应用类型
        public int AppType { get; set; }

        //应用名称
        public string InsertApply_Name { get; set; }

        //应用编码
        public string InsertApply_encoding { get; set; }

        //应用简介
        public string InsertApply_synopsis { get; set; }

        //应用状态
        public int InsertApply_tatus { get; set; }
        //应用图片
        public string InsertApply_Img { get; set; }
        //应用最后修改时间
        public DateTime InsertApply_ChangeTime { get; set; }
    }
}
