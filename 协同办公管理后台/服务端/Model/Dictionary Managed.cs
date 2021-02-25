using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace Model
{
    //字典表
   public  class Dictionary_Managed
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        //字典主键
        public int Dictionary_Id { get; set; }
        //字典名称
        public string Dictionary_Name { get; set; }
        //字典代号
        public string Dictionary_Code { get; set; }
        //字典排序
        public int Dictionary_Sort { get; set; }
        //状态
        public int Dictionary_Sale { get; set; }
        //修改时间
        public DateTime Dictionary_ModTime { get; set; }
    }
}
