using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace Model
{
    //流程表
    public class Process
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        ///主键
        public int Process_id { get; set; }
        ///调用应用
        public int Process_Application { get; set; }
        ///流程定义编码
        public string Process_code { get; set; }
        ///流程定义全称
        public string Process_Name { get; set; }
        ///备注
        public string Process_list { get; set; }
        ///创建时间
        public DateTime Process_begin { get; set; }
        ///更新时间
        public DateTime Process_update { get; set; }
    }
}
