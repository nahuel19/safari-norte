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
    public partial class PrecioDAC : DataAccessComponent, IRepository<Precio>
    {
        public Precio Create(Precio precio)
        {
            const string SQL_STATEMENT = "INSERT INTO Precio([TipoServicioId],[FechaDesde],[FechaHasta],[Valor]) VALUES(@TipoServicioId,@FechaDesde,@FechaHasta,@Valor); SELECT SCOPE_IDENTITY();";

            try
            {
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, precio.TipoServicioId);
                    db.AddInParameter(cmd, "@FechaDesde", DbType.DateTime, precio.FechaDesde);
                    db.AddInParameter(cmd, "@FechaHasta", DbType.DateTime, precio.FechaHasta);
                    db.AddInParameter(cmd, "@Valor", DbType.Double, precio.Valor);
                    precio.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
            }
            catch (Exception ex)
            {
                var log = ServiceFactory.Get<ILoggingService>();
                log.Error(ex); //Trace
                var wrapper = new Exception("Error personalizado por el Usuario.", ex);
                throw wrapper;
            }
            return precio;
        }

        public List<Precio> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id],[TipoServicioId],[FechaDesde],[FechaHasta],[Valor] FROM Precio ";

            List<Precio> result = new List<Precio>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Precio precio = LoadPrecio(dr);
                        result.Add(precio);
                    }
                }
            }
            return result;
        }

        public Precio ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id],[TipoServicioId],[FechaDesde],[FechaHasta],[Valor] FROM Precio WHERE [Id]=@Id ";
            Precio precio = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        precio = LoadPrecio(dr);
                    }
                }
            }
            return precio;
        }

        public void Update(Precio precio)
        {
            const string SQL_STATEMENT = "UPDATE Precio SET [TipoServicioId]=@TipoServicioId,[FechaDesde]=@FechaDesde,[FechaHasta]=@FechaHasta,[Valor]=@Valor WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, precio.TipoServicioId);
                db.AddInParameter(cmd, "@FechaDesde", DbType.DateTime, precio.FechaDesde);
                db.AddInParameter(cmd, "@FechaHasta", DbType.DateTime, precio.FechaHasta);
                db.AddInParameter(cmd, "@Valor", DbType.Double, precio.Valor);
                db.AddInParameter(cmd, "@Id", DbType.Int32, precio.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Precio WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        

        private Precio LoadPrecio(IDataReader dr)
        {
            Precio precio = new Precio();
            precio.Id = GetDataValue<int>(dr, "Id");
            precio.TipoServicioId = GetDataValue<int>(dr, "TipoServicioId");
            precio.FechaDesde = GetDataValue<DateTime>(dr, "FechaDesde");
            precio.FechaHasta = GetDataValue<DateTime >(dr, "FechaHasta");
            precio.Valor = GetDataValue<double>(dr, "Valor");
            return precio;
        }
    }
}
