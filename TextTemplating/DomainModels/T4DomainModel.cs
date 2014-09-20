using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.Repositories;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class T4DomainModel<TContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public  T4DomainModel(TContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        public TContext Context
        {
            get {return this._context; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected T4ProviderFactory Factory
        {
            get { return T4ProviderFactory.Instance; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected SqlSchemaRepository SqlSchema
        {
            get { return SqlSchemaRepository.Instance; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<SqlTableSchemaEntity> GetTablesSchema()
        {
            var connection = default(DbConnection);

            try
            {
                connection = this.Factory.CreateConnection();
                connection.Open();

                var tables = this.SqlSchema.GetTablesSchema(connection);

                return tables;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        protected IEnumerable<SqlColumnSchemaEntity> GetColumnsSchema(string tableName)
        {
            var connection = default(DbConnection);

            try
            {
                connection = this.Factory.CreateConnection();
                connection.Open();

                var columns = this.SqlSchema.GetColumnsSchema(tableName, connection);

                return columns;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        /// <param name="encoding"></param>
        protected void WrtieToFile(string path, string text, Encoding encoding)
        {
            var stream = default(TextWriter);

            try
            {
                stream = new StreamWriter(path, false, encoding);
                stream.Write(text);
                stream.Flush();
            }
            finally
            {
                if (stream != null) { stream.Close(); }
            }
        }

        /// <summary>
        /// 何もしません。
        /// </summary>
        [DebuggerStepThrough()]
        protected void DoNothing()
        {
            // 何もしない
        }

        #region Private memberes...

        /// <summary></summary>
        private readonly TContext _context;

        #endregion
    }
}
