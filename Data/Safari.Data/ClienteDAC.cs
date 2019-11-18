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
    public partial class ClienteDAC : DataAccessComponent, IRepository<Cliente>
    {
        public Cliente Create(Cliente cliente)
        {
            const string SQL_STATEMENT = "INSERT INTO [dbo].[Cliente] ([Apellido], [Nombre], [Email], [Telefono], [Url], [FechaNacimiento], [Domicilio]) VALUES (@Apellido, @Nombre, @Email, @Telefono, @Url, @FechaNacimiento, @Domicilio); SELECT SCOPE_IDENTITY();";

            try
            {
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, cliente.Apellido);
                    db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, cliente.Nombre);
                    db.AddInParameter(cmd, "@Email", DbType.AnsiString, cliente.Email);
                    db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, cliente.Telefono);
                    db.AddInParameter(cmd, "@Url", DbType.AnsiString, cliente.Url);
                    db.AddInParameter(cmd, "@FechaNacimiento", DbType.DateTime, cliente.FechaNacimiento);
                    db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, cliente.Domicilio);
                    cliente.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
            }
            catch (Exception ex)
            {
                var log = ServiceFactory.Get<ILoggingService>();
                log.Error(ex);
                var wrapper = new Exception("Error personalizado por el Usuario.", ex);
                throw wrapper;
            }
            return cliente;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Cliente WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Cliente> Read()
        {
            const string SQL_STATEMENT = "SELECT * FROM [dbo].[Cliente]";

            List<Cliente> result = new List<Cliente>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Cliente cliente = LoadCliente(dr);
                        result.Add(cliente);
                    }
                }
            }
            return result;
        }

        public Cliente ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT * FROM Cliente WHERE [Id]=@Id ";
            Cliente cliente = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        cliente = LoadCliente(dr);
                    }
                }
            }
            return cliente;
        }

        //public List<Medico> SelectPage(int currentPage)
        //{
        //    const string SQL_STATEMENT =
        //        "WITH SortedMedico AS " +
        //        "(SELECT ROW_NUMBER() OVER (ORDER BY [Id]) AS RowNumber, " +
        //            "[Id] " +
        //            "FROM dbo.Medico " +
        //        ") SELECT * FROM SortedEspecie " +
        //        "WHERE RowNumber BETWEEN @StartIndex AND @EndIndex";

        //    long startIndex = (currentPage * base.PageSize);
        //    long endIndex = startIndex + base.PageSize;

        //    startIndex += 1;
        //    List<Medico> result = new List<Medico>();

        //    var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
        //    using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
        //    {
        //        db.AddInParameter(cmd, "@StartIndex", DbType.Int64, startIndex);
        //        db.AddInParameter(cmd, "@EndIndex", DbType.Int64, endIndex);

        //        using (IDataReader dr = db.ExecuteReader(cmd))
        //        {
        //            while (dr.Read())
        //            {
        //                Medico medico = new Medico();
        //                medico = LoadMedico(dr);
        //                result.Add(medico);
        //            }
        //        }
        //    }

        //    return result;
        //}

        public void Update(Cliente entity)
        {
            const string SQL_STATEMENT = "UPDATE Cliente SET [Apellido]= @Apellido, [Nombre]= @Nombre, [Email]= @Email, [Telefono]= @Telefono, [Url]= @Url, [FechaNacimiento]= @FechaNacimiento, [Domicilio]= @Domicilio  WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, entity.Apellido);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, entity.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, entity.Telefono);
                db.AddInParameter(cmd, "@Url", DbType.AnsiString, entity.Url);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.DateTime, entity.FechaNacimiento);
                db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, entity.Domicilio);
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Cliente LoadCliente(IDataReader dr)
        {
            Cliente cliente = new Cliente();
            cliente.Id = GetDataValue<int>(dr, "Id");
            cliente.Apellido = GetDataValue<string>(dr, "Apellido");
            cliente.Nombre = GetDataValue<string>(dr, "Nombre");
            cliente.Email = GetDataValue<string>(dr, "Email");
            cliente.Telefono = GetDataValue<string>(dr, "Telefono");
            cliente.Url = GetDataValue<string>(dr, "Url");
            cliente.FechaNacimiento = GetDataValue<DateTime>(dr, "FechaNacimiento");
            cliente.Domicilio = GetDataValue<string>(dr, "Domicilio");
            return cliente;
        }


    }
}
