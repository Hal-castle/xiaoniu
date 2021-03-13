using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace Model
{
    //角色表
    
    public class Role
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        ///主键
        public int Rid { get; set; }
        ///角色名称
        public string Rname { get; set; }
        ///角色编码
        public string Rcoding { get; set; }
        ///修改时间
        public DateTime Rtimes { get; set; }

    }
}
