using Microsoft.Practices.EnterpriseLibrary.Data;
using Safari.Entities;
using Safari.Framework.Common;
using Safari.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Data
{
    public partial class TipoServicioDAC : DataAccessComponent, IRepository<TipoServicio>
    {
        public TipoServicio Create(TipoServicio tipoServicio)
        {
            const string SQL_STATEMENT = "INSERT INTO TipoServicio([Nombre]) VALUES(@Nombre); SELECT SCOPE_IDENTITY();";

            try
            {
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, tipoServicio.Nombre);
                    tipoServicio.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
            }
            catch (Exception ex)
            {
                var log = ServiceFactory.Get<ILoggingService>();
                log.Error(ex); //Trace
                var wrapper = new Exception("Error personalizado por el Usuario.", ex);
                throw wrapper;
            }
            return tipoServicio;
        }

        public List<TipoServicio> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM TipoServicio ";

            List<TipoServicio> result = new List<TipoServicio>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoServicio tipoServicio = LoadTipoServicio(dr);
                        result.Add(tipoServicio);
                    }
                }
            }
            return result;
        }

        public TipoServicio ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM TipoServicio WHERE [Id]=@Id ";
            TipoServicio tipoServicio = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        tipoServicio = LoadTipoServicio(dr);
                    }
                }
            }
            return tipoServicio;
        }

        public void Update(TipoServicio tipoServicio)
        {
            const string SQL_STATEMENT = "UPDATE TipoServicio SET [Nombre]= @Nombre WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, tipoServicio.Nombre);
                db.AddInParameter(cmd, "@Id", DbType.Int32, tipoServicio.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE TipoServicio WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        //public List<Especie> SelectPage(int currentPage)
        //{
        //    const string SQL_STATEMENT =
        //        "WITH SortedEspecie AS " +
        //        "(SELECT ROW_NUMBER() OVER (ORDER BY [Id]) AS RowNumber, " +
        //            "[Id] " +
        //            "FROM dbo.Especie " +
        //        ") SELECT * FROM SortedEspecie " +
        //        "WHERE RowNumber BETWEEN @StartIndex AND @EndIndex";

        //    long startIndex = (currentPage * base.PageSize);
        //    long endIndex = startIndex + base.PageSize;

        //    startIndex += 1;
        //    List<Especie> result = new List<Especie>();

        //    var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
        //    using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
        //    {
        //        db.AddInParameter(cmd, "@StartIndex", DbType.Int64, startIndex);
        //        db.AddInParameter(cmd, "@EndIndex", DbType.Int64, endIndex);

        //        using (IDataReader dr = db.ExecuteReader(cmd))
        //        {
        //            while (dr.Read())
        //            {
        //                Especie especie = new Especie();
        //                especie.Id = GetDataValue<int>(dr, "Id");
        //                result.Add(especie);
        //            }
        //        }
        //    }

        //    return result;
        //}

        private TipoServicio LoadTipoServicio(IDataReader dr)
        {
            TipoServicio tipoServicio = new TipoServicio();
            tipoServicio.Id = GetDataValue<int>(dr, "Id");
            tipoServicio.Nombre = GetDataValue<string>(dr, "Nombre");
            return tipoServicio;
        }
    }
}
