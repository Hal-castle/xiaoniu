using SqlSugar;
using System;

namespace Model
{
    public class Student
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        public int Id { get; set; }
        public int? SchoolId { get; set; }
        public string Name { get; set; }
    }
}
