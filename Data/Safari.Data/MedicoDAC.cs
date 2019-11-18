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
    public partial class MedicoDAC : DataAccessComponent, IRepository<Medico>
    {
        public Medico Create(Medico medico)
        {
            const string SQL_STATEMENT = "INSERT INTO [dbo].[Medico] ([TipoMatricula], [NumeroMatricula], [Apellido], [Nombre], [Especialidad], [FechaNacimiento], [Email], [Telefono]) VALUES (@TipoMatricula, @NumeroMatricula, @Apellido, @Nombre, @Especialidad, @FechaNacimiento, @Email, @Telefono); SELECT SCOPE_IDENTITY();";

            try
            {
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@TipoMatricula", DbType.AnsiString, medico.TipoMatricula);
                    db.AddInParameter(cmd, "@NumeroMatricula", DbType.Int32, medico.NumeroMatricula);
                    db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, medico.Apellido);
                    db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, medico.Nombre);
                    db.AddInParameter(cmd, "@Especialidad", DbType.AnsiString, medico.Especialidad);
                    db.AddInParameter(cmd, "@FechaNacimiento", DbType.DateTime, medico.FechaNacimiento);
                    db.AddInParameter(cmd, "@Email", DbType.AnsiString, medico.Email);
                    db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, medico.Telefono);
                    medico.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
            }
            catch (Exception ex)
            {
                var log = ServiceFactory.Get<ILoggingService>();
                log.Error(ex); 
                var wrapper = new Exception("Error personalizado por el Usuario.", ex);
                throw wrapper;
            }
            return medico;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Medico WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Medico> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [TipoMatricula], [NumeroMatricula], [Apellido], [Nombre], [Especialidad], [FechaNacimiento], [Email], [Telefono] FROM [dbo].[Medico]";

            List<Medico> result = new List<Medico>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Medico medico = LoadMedico(dr);
                        result.Add(medico);
                    }
                }
            }
            return result;
        }

        public Medico ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT * FROM Medico WHERE [Id]=@Id ";
            Medico medico = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        medico = LoadMedico(dr);
                    }
                }
            }
            return medico;
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

        public void Update(Medico entity)
        {
            const string SQL_STATEMENT = "UPDATE Medico SET [TipoMatricula]= @TipoMatricula, [NumeroMatricula]= @NumeroMatricula, [Apellido]= @Apellido, [Nombre]= @Nombre, [Especialidad]= @Especialidad, [FechaNacimiento]= @FechaNacimiento, [Email]= @Email, [Telefono]= @Telefono  WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@TipoMatricula", DbType.AnsiString, entity.TipoMatricula);
                db.AddInParameter(cmd, "@NumeroMatricula", DbType.Int32, entity.NumeroMatricula);
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, entity.Apellido);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@Especialidad", DbType.AnsiString, entity.Especialidad);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.DateTime, entity.FechaNacimiento);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, entity.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, entity.Telefono);
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Medico LoadMedico(IDataReader dr)
        {
            Medico medico = new Medico();
            medico.Id = GetDataValue<int>(dr, "Id");
            medico.TipoMatricula = GetDataValue<string>(dr, "TipoMatricula");
            medico.NumeroMatricula = GetDataValue<int>(dr, "NumeroMatricula");
            medico.Apellido = GetDataValue<string>(dr, "Apellido");
            medico.Nombre = GetDataValue<string>(dr, "Nombre");
            medico.Especialidad = GetDataValue<string>(dr, "Especialidad");
            medico.FechaNacimiento = GetDataValue<DateTime>(dr, "FechaNacimiento");
            medico.Email = GetDataValue<string>(dr, "Email");
            medico.Telefono = GetDataValue<string>(dr, "Telefono");
            return medico;
        }
    }
}
