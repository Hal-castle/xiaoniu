using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace Model
{
    //群组表
    public class Groups
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        ///主键
        public int Gid { get; set; }
        ///群组名称
        public string Gname { get; set; }
        ///所属部门(外键)
        public int Gsection { get; set; }
        ///群组描述
        public string Gdescribe { get; set; }
        ///创建时间
        public DateTime Gtimes { get; set; }
        ///人员(外键)
        public int Gpeople { get; set; }
    }
}
