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
    public partial class SalaDAC : DataAccessComponent, IRepository<Sala>
    {
        public Sala Create(Sala sala)
        {
            const string SQL_STATEMENT = "INSERT INTO Sala([Nombre],[TipoSala]) VALUES(@Nombre, @TipoSala); SELECT SCOPE_IDENTITY();";

            try
            {
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, sala.Nombre);
                    db.AddInParameter(cmd, "@TipoSala", DbType.AnsiString, sala.TipoSala);
                    sala.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
            }
            catch (Exception ex)
            {
                var log = ServiceFactory.Get<ILoggingService>();
                log.Error(ex); //Trace
                var wrapper = new Exception("Error personalizado por el Usuario.", ex);
                throw wrapper;
            }
            return sala;
        }

        public List<Sala> Read()
        {
            const string SQL_STATEMENT = "SELECT * FROM Sala ";

            List<Sala> result = new List<Sala>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Sala sala = LoadSala(dr);
                        result.Add(sala);
                    }
                }
            }
            return result;
        }

        public Sala ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT * FROM Sala WHERE [Id]=@Id ";
            Sala sala = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        sala = LoadSala(dr);
                    }
                }
            }
            return sala;
        }

        public void Update(Sala sala)
        {
            const string SQL_STATEMENT = "UPDATE Sala SET [Nombre]= @Nombre, [TipoSala]= @TipoSala  WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, sala.Nombre);
                db.AddInParameter(cmd, "@TipoSala", DbType.AnsiString, sala.TipoSala);
                db.AddInParameter(cmd, "@Id", DbType.Int32, sala.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Sala WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        //public List<Sala> SelectPage(int currentPage)
        //{
        //    const string SQL_STATEMENT =
        //        "WITH SortedSala AS " +
        //        "(SELECT ROW_NUMBER() OVER (ORDER BY [Id]) AS RowNumber, " +
        //            "[Id] " +
        //            "FROM dbo.Sala " +
        //        ") SELECT * FROM SortedSala " +
        //        "WHERE RowNumber BETWEEN @StartIndex AND @EndIndex";

        //    long startIndex = (currentPage * base.PageSize);
        //    long endIndex = startIndex + base.PageSize;

        //    startIndex += 1;
        //    List<Sala> result = new List<Sala>();

        //    var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
        //    using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
        //    {
        //        db.AddInParameter(cmd, "@StartIndex", DbType.Int64, startIndex);
        //        db.AddInParameter(cmd, "@EndIndex", DbType.Int64, endIndex);

        //        using (IDataReader dr = db.ExecuteReader(cmd))
        //        {
        //            while (dr.Read())
        //            {
        //                Sala sala = new Sala();
        //                sala.Id = GetDataValue<int>(dr, "Id");
        //                result.Add(sala);
        //            }
        //        }
        //    }

        //    return result;
        //}

        private Sala LoadSala(IDataReader dr)
        {
            Sala sala = new Sala();
            sala.Id = GetDataValue<int>(dr, "Id");
            sala.Nombre = GetDataValue<string>(dr, "Nombre");
            sala.TipoSala = GetDataValue<string>(dr, "TipoSala");
            return sala;
        }
    }
}
