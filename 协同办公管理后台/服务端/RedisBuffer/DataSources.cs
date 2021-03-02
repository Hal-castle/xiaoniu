using Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisBuffer
{
    /*
     该类可从redis获取数据，提高了程序的高性能
     */
    public class DataSources
    {
        /// <summary>
        /// 从Redis获取数据
        /// </summary>
        /// <typeparam name="T">要获取的实体类</typeparam>
        /// <param name="ff">SqlSugar框架的实体类</param>
        /// <param name="iss">是否是对数据操作</param>
        /// <returns></returns>
        public static List<T> GetData<T>(UnitOfWork ff, bool iss = false) where T : class, new()
        {
            Type t = typeof(T);//获取传入的数据类型
            var Key = t.Name;//获取数据的名称
            if (iss)//如果是对数据执行了操作，则将数据重新写入redis
            {
                var a = ff.db<T>().GetList();
                new RedisHelper().Set(Key, a, 10);
                return new RedisHelper().Get<List<T>>(Key);
            }
            else
            {
                if (new RedisHelper().IsSet(Key))//如果已经有该redis数据，则直接返回
                    return new RedisHelper().Get<List<T>>(Key);
                //如果没有，则新建一个并返回
                else
                {
                    var a = ff.db<T>().GetList();
                    new RedisHelper().Set(Key, a, 10);
                    return new RedisHelper().Get<List<T>>(Key);
                }
            }

        }
    }
}
