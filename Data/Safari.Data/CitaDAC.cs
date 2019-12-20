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
    public partial class CitaDAC : DataAccessComponent, IRepository<Cita>
    {
        public Cita Create(Cita cita)
        {
            const string SQL_STATEMENT = "INSERT INTO [dbo].[Cita] ([Fecha], [MedicoId], [PacienteId], [SalaId], [TipoServicioId], [Estado], [CreatedBy], [CreatedDate]) VALUES (@Fecha, @MedicoId, @PacienteId, @SalaId, @TipoServicioId, @Estado, @CreatedBy, @CreatedDate); SELECT SCOPE_IDENTITY();";

            try
            {
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Fecha", DbType.DateTime, cita.Fecha);
                    db.AddInParameter(cmd, "@MedicoId", DbType.Int32, cita.MedicoId);
                    db.AddInParameter(cmd, "@PacienteId", DbType.Int32, cita.PacienteId);
                    db.AddInParameter(cmd, "@SalaId", DbType.Int32, cita.SalaId);
                    db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, cita.TipoServicioId);
                    db.AddInParameter(cmd, "@Estado", DbType.AnsiString, cita.Estado);

                    db.AddInParameter(cmd, "@CreatedBy", DbType.AnsiString, cita.CreatedBy);
                    db.AddInParameter(cmd, "@CreatedDate", DbType.DateTime, cita.CreatedDate);

                    //db.AddInParameter(cmd, "@ChangedBy", DbType.AnsiString, cita.ChangedBy);
                    //db.AddInParameter(cmd, "@ChangedDate", DbType.DateTime, cita.ChangedDate);

                    //db.AddInParameter(cmd, "@DeletedBy", DbType.AnsiString, cita.DeletedBy);
                    //db.AddInParameter(cmd, "@DeletedDate", DbType.DateTime, cita.DeletedDate);

                    //db.AddInParameter(cmd, "@Deleted", DbType.Boolean, cita.Deleted);
                    cita.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
            }
            catch (Exception ex)
            {
                var log = ServiceFactory.Get<ILoggingService>();
                log.Error(ex);
                var wrapper = new Exception("Error personalizado por el Usuario.", ex);
                throw wrapper;
            }
            return cita;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Cita WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void DeleteCita (Cita cita)
        {
            const string SQL_STATEMENT = "UPDATE Cita SET [DeletedBy]=@DeletedBy, [DeletedDate]=@DeletedDate, [Deleted]=@Deleted  WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                
                db.AddInParameter(cmd, "@DeletedBy", DbType.AnsiString, cita.DeletedBy);
                db.AddInParameter(cmd, "@DeletedDate", DbType.DateTime, cita.DeletedDate);
                db.AddInParameter(cmd, "@Deleted", DbType.Boolean, cita.Deleted);

                db.AddInParameter(cmd, "@Id", DbType.Int32, cita.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Cita> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Fecha], [MedicoId], [PacienteId], [SalaId], [TipoServicioId], [Estado], [CreatedBy], [CreatedDate], [ChangedBy], [ChangedDate], [DeletedBy], [DeletedDate], [Deleted] FROM [dbo].[Cita]";

            List<Cita> result = new List<Cita>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Cita cita = LoadCita(dr);
                        result.Add(cita);
                    }
                }
            }
            return result;
        }

        public Cita ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT * FROM Cita WHERE [Id]=@Id ";
            Cita cita = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        cita = LoadCita(dr);
                    }
                }
            }
            return cita;
        }


        public void Update(Cita cita)
        {
            const string SQL_STATEMENT = "UPDATE Cita SET [Fecha]=@Fecha, [MedicoId]=@MedicoId, [PacienteId]=@PacienteId, [SalaId]=@SalaId, [TipoServicioId]=@TipoServicioId, [Estado]=@Estado, [ChangedBy]=@ChangedBy, [ChangedDate]=@ChangedDate  WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Fecha", DbType.DateTime, cita.Fecha);
                db.AddInParameter(cmd, "@MedicoId", DbType.Int32, cita.MedicoId);
                db.AddInParameter(cmd, "@PacienteId", DbType.Int32, cita.PacienteId);
                db.AddInParameter(cmd, "@SalaId", DbType.Int32, cita.SalaId);
                db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, cita.TipoServicioId);
                db.AddInParameter(cmd, "@Estado", DbType.AnsiString, cita.Estado);

                //db.AddInParameter(cmd, "@CreatedBy", DbType.AnsiString, cita.CreatedBy);
                //db.AddInParameter(cmd, "@CreatedDate", DbType.DateTime, cita.CreatedDate);

                db.AddInParameter(cmd, "@ChangedBy", DbType.AnsiString, cita.ChangedBy);
                db.AddInParameter(cmd, "@ChangedDate", DbType.DateTime, cita.ChangedDate);

                //db.AddInParameter(cmd, "@DeletedBy", DbType.AnsiString, cita.DeletedBy);
                //db.AddInParameter(cmd, "@DeletedDate", DbType.DateTime, cita.DeletedDate);

                //db.AddInParameter(cmd, "@Deleted", DbType.Boolean, cita.Deleted);
                db.AddInParameter(cmd, "@Id", DbType.Int32, cita.Id);
                db.ExecuteNonQuery(cmd);
            }
        }



        public void Facturar(Cita cita)
        {
            const string SQL_STATEMENT = "UPDATE Cita SET [Estado] = @Estado WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                
                db.AddInParameter(cmd, "@Estado", DbType.AnsiString, "Realizado");
                
                db.AddInParameter(cmd, "@Id", DbType.Int32, cita.Id);
                db.ExecuteNonQuery(cmd);
            }
        }


        private Cita LoadCita(IDataReader dr)
        {
            Cita cita = new Cita();
            cita.Id = GetDataValue<int>(dr, "Id");
            cita.Fecha = GetDataValue<DateTime>(dr, "Fecha");
            cita.MedicoId = GetDataValue<int>(dr, "MedicoId");
            cita.PacienteId = GetDataValue<int>(dr, "PacienteId");
            cita.SalaId = GetDataValue<int>(dr, "SalaId");
            cita.TipoServicioId = GetDataValue<int>(dr, "TipoServicioId");
            cita.Estado = GetDataValue<string>(dr, "Estado");

            cita.CreatedBy = GetDataValue<string>(dr, "CreatedBy");
            cita.CreatedDate = GetDataValue<DateTime>(dr, "CreatedDate");

            cita.ChangedBy = GetDataValue<string>(dr, "ChangedBy");
            cita.ChangedDate = GetDataValue<DateTime>(dr, "ChangedDate");

            cita.DeletedBy = GetDataValue<string>(dr, "DeletedBy");
            cita.DeletedDate = GetDataValue<DateTime>(dr, "DeletedDate");

            cita.Deleted = GetDataValue<bool>(dr, "Deleted");

            return cita;
        }

    }
}
