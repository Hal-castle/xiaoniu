using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //用户角色表
    public class Staff_Role
    {
        //用户外键
        public int Staff_Id { get; set; }

        //权限外键
        public int Role_Id { get; set; }
    }
}
