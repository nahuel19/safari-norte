using Microsoft.Practices.EnterpriseLibrary.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Data
{
    public class TipoMovimientoDAC : DataAccessComponent, IRepository<TipoMovimiento>
    {
        public TipoMovimiento Create(TipoMovimiento tipomovimiento)
        {
            const string SQL_STATEMENT = "INSERT INTO TipoMovimiento ([Nombre],[Multiplicador]) VALUES(@Nombre,@Multiplicador); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, tipomovimiento.Nombre);
                db.AddInParameter(cmd, "@Multiplicador", DbType.Int16, tipomovimiento.Multiplicador);
                tipomovimiento.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return tipomovimiento;
        }

        public List<TipoMovimiento> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id],[Nombre],[Multiplicador] FROM TipoMovimiento ";

            List<TipoMovimiento> result = new List<TipoMovimiento>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoMovimiento tipomovimiento = LoadTipoMovimiento(dr);
                        result.Add(tipomovimiento);
                    }
                }
            }
            return result;
        }

        public TipoMovimiento ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id],[Nombre],[Multiplicador] FROM TipoMovimiento WHERE [Id]=@Id ";
            TipoMovimiento tipomovimiento = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        tipomovimiento = LoadTipoMovimiento(dr);
                    }
                }
            }
            return tipomovimiento;
        }

        public void Update(TipoMovimiento tipomovimiento)
        {
            const string SQL_STATEMENT = "UPDATE TipoMovimiento SET [Nombre]=@Nombre, [Multiplicador]=@Multiplicador WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, tipomovimiento.Nombre);
                db.AddInParameter(cmd, "@Multiplicador", DbType.Int16, tipomovimiento.Multiplicador);
                db.AddInParameter(cmd, "@Id", DbType.Int32, tipomovimiento.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE TipoMovimiento WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private TipoMovimiento LoadTipoMovimiento(IDataReader dr)
        {
            TipoMovimiento tipomovimiento = new TipoMovimiento();
            tipomovimiento.Id = GetDataValue<int>(dr, "Id");
            tipomovimiento.Nombre = GetDataValue<string>(dr, "Nombre");
            tipomovimiento.Multiplicador = GetDataValue<Int16>(dr, "Multiplicador");
            return tipomovimiento;
        }

    }
}
