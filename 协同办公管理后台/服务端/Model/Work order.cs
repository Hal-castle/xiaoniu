using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace Model
{
    //工单表
    public class Work_order
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        ///主键
        public int Wid { get; set; }
        ///工单编号
        public string Wnumber { get; set; }
        ///工单标题
        public string Wtitle  { get; set; }
        ///当前步骤
        public string Wstep { get; set; }
        ///当前处理人(外键)
        public int Whandler { get; set; }
        ///状态
        public int Wstate { get; set; }
        ///提交人(外键)
        public int Wsubmitter { get; set; }
        ///提交时间
        public DateTime Wbegin { get; set; }
        ///结果时间
        public DateTime Wend { get; set; }
    }
}
