using SqlSugar;

namespace Model
{
    /// <summary>
    /// Ӧ�ù���
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
        /// ����������
        /// </summary>
       [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//������������ ��string��������������
        public System.Int32 DId { get { return this._DId; } set { this._DId = value; } }

        private System.String _Developers_Name;
        /// <summary>
        /// ����������
        /// </summary>
        public System.String Developers_Name { get { return this._Developers_Name; } set { this._Developers_Name = value; } }

        private System.String _Developers_encoding;
        /// <summary>
        /// �����̱���
        /// </summary>
        public System.String Developers_encoding { get { return this._Developers_encoding; } set { this._Developers_encoding = value; } }

        private System.String _Developers_synopsis;
        /// <summary>
        /// �����̱�ע
        /// </summary>
        public System.String Developers_synopsis { get { return this._Developers_synopsis; } set { this._Developers_synopsis = value; } }

        private System.Int32? _Developers_sort;
        /// <summary>
        /// ����������
        /// </summary>
        public System.Int32? Developers_sort { get { return this._Developers_sort; } set { this._Developers_sort = value; } }

        private System.DateTime? _Developers_changetime;
        /// <summary>
        /// ����������޸�ʱ��
        /// </summary>
        public System.DateTime? Developers_changetime { get { return this._Developers_changetime; } set { this._Developers_changetime = value; } }
    }
}
