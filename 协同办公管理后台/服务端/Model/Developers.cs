using SqlSugar;

namespace Model
{
    /// <summary>
    /// 应用管理
    /// </summary>
    public class Developers
    {
        /// <summary>
        /// 
        /// </summary>
        public Developers()
        {
        }

        private System.Int32 _DId;
        /// <summary>
        /// 开发商主键
        /// </summary>
       [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        public System.Int32 DId { get { return this._DId; } set { this._DId = value; } }

        private System.String _Developers_Name;
        /// <summary>
        /// 开发商名称
        /// </summary>
        public System.String Developers_Name { get { return this._Developers_Name; } set { this._Developers_Name = value; } }

        private System.String _Developers_encoding;
        /// <summary>
        /// 开发商编码
        /// </summary>
        public System.String Developers_encoding { get { return this._Developers_encoding; } set { this._Developers_encoding = value; } }

        private System.String _Developers_synopsis;
        /// <summary>
        /// 开发商备注
        /// </summary>
        public System.String Developers_synopsis { get { return this._Developers_synopsis; } set { this._Developers_synopsis = value; } }

        private System.Int32? _Developers_sort;
        /// <summary>
        /// 开发商排序
        /// </summary>
        public System.Int32? Developers_sort { get { return this._Developers_sort; } set { this._Developers_sort = value; } }

        private System.DateTime? _Developers_changetime;
        /// <summary>
        /// 开发商最后修改时间
        /// </summary>
        public System.DateTime? Developers_changetime { get { return this._Developers_changetime; } set { this._Developers_changetime = value; } }
    }
}
