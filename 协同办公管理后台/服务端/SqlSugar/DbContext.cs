using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.IO;
using Model;

namespace SqlSugar
{
    public class DbContext<T> where T : class, new()
    {
        public readonly static IConfiguration Configuration = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: true)
                       .Build();
        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = Configuration.GetConnectionString("DB").ToString(),//连接符字串
                DbType = (SqlSugar.DbType)Enum.Parse(typeof(SqlSugar.DbType), Configuration.GetConnectionString("Type").ToString()),//数据库类型
                InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
                IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

            });
            CreateTable(false, 50,typeof(ULog), typeof(Student), typeof(Units), typeof(InsertApply), typeof(AppArrange), typeof(Developers), typeof(Staff), typeof(Staff_Role), typeof(Role), typeof(Role_Power), typeof(Power));
        }
        private void CreateTable(bool Backup = false, int StringDefaultLength = 50, params Type[] types)
        {
            Db.CodeFirst.SetStringDefaultLength(StringDefaultLength);
            Db.DbMaintenance.CreateDatabase();
            if (Backup)
            {
                Db.CodeFirst.BackupTable().InitTables(types);
            }
            else
            {
                Db.CodeFirst.InitTables(types);
            }
        }
        public SimpleClient<ULog> ULogDb { get { return new SimpleClient<ULog>(Db); } }//操作日志
        public SimpleClient<Developers> DevelopersDb { get { return new SimpleClient<Developers>(Db); } }//开发商管理
        public SimpleClient<AppArrange> AppArrangeDb { get { return new SimpleClient<AppArrange>(Db); } }//应用分类表
        public SimpleClient<Student> studentDb { get { return new SimpleClient<Student>(Db); } }//学生表
        public SimpleClient<Units> UnitsDb { get { return new SimpleClient<Units>(Db); } }//字典表
        public SimpleClient<InsertApply> InsertApplyDb { get { return new SimpleClient<InsertApply>(Db); } }//接入应用表
        public SimpleClient<Staff> StaffDb { get { return new SimpleClient<Staff>(Db); } }//用户表
        public SimpleClient<Staff_Role> Staff_RoleDb { get { return new SimpleClient<Staff_Role>(Db); } }//用户角色表
        public SimpleClient<Role> RoleDb { get { return new SimpleClient<Role>(Db); } }//角色表
        public SimpleClient<Role_Power> Role_PowerDb { get { return new SimpleClient<Role_Power>(Db); } }//角色权限表
        public SimpleClient<Power> PowerDb { get { return new SimpleClient<Power>(Db); } }//权限表
        //注意：不能写成静态的
        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作

        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }//用来处理T表的常用操作



        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetList()
        {
            return CurrentDb.GetList();
        }

        /// <summary>
        /// 根据表达式查询
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetList(Expression<Func<T, bool>> whereExpression)
        {
            return CurrentDb.GetList(whereExpression);
        }


        /// <summary>
        /// 根据表达式查询分页
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel)
        {
            return CurrentDb.GetPageList(whereExpression, pageModel);
        }

        /// <summary>
        /// 根据表达式查询分页并排序
        /// </summary>
        /// <param name="whereExpression">it</param>
        /// <param name="pageModel"></param>
        /// <param name="orderByExpression">it=>it.id或者it=>new{it.id,it.name}</param>
        /// <param name="orderByType">OrderByType.Desc</param>
        /// <returns></returns>
        public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
        {
            return CurrentDb.GetPageList(whereExpression, pageModel, orderByExpression, orderByType);
        }


        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <returns></returns>
        public virtual T GetById(dynamic id)
        {
            return CurrentDb.GetById(id);
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(dynamic id)
        {
            return CurrentDb.Delete(id);
        }


        /// <summary>
        /// 根据实体删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(T data)
        {
            return CurrentDb.Delete(data);
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(dynamic[] ids)
        {
            return CurrentDb.AsDeleteable().In(ids).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 根据表达式删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(Expression<Func<T, bool>> whereExpression)
        {
            return CurrentDb.Delete(whereExpression);
        }


        /// <summary>
        /// 根据实体更新，实体需要有主键
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Update(T obj)
        {
            return CurrentDb.Update(obj);
        }

        /// <summary>
        ///批量更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Update(List<T> objs)
        {
            return CurrentDb.UpdateRange(objs);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Insert(T obj)
        {
            return CurrentDb.Insert(obj);
        }


        /// <summary>
        /// 批量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Insert(List<T> objs)
        {
            return CurrentDb.InsertRange(objs);
        }

        /// <summary>
        /// 查询sql 返回list
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public List<T> SqlQueryList(string sqlstr)
        {
            return this.Db.SqlQueryable<T>(sqlstr).ToList();
        }

        /// <summary>
        /// 查询sql 返回table
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public DataTable SqlQueryTab(string sqlstr)
        {
            return this.Db.Ado.GetDataTable(sqlstr);
        }



    }
}