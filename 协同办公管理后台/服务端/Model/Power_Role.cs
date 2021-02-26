using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //角色权限表
    public class Role_Power
    {
        //角色外键
        public int Role_Id { get; set; }

        //权限外键
        public int Power_Id { get; set; }
    }
}
