
using Microsoft.Practices.EnterpriseLibrary.Data;
using Safari.Data;
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
    public partial class PacienteDAC : DataAccessComponent, IRepository<Paciente>
    {

        public Paciente Create(Paciente paciente)
        {
            const string SQL_STATEMENT = "INSERT INTO Paciente ([ClienteId],[Nombre],[FechaNacimiento],[EspecieId],[Observacion]) VALUES(@ClienteId, @Nombre, @FechaNacimiento, @EspecieId, @Observacion ); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase("DefaultConnection");
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@ClienteId", DbType.AnsiString, paciente.ClienteId);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, paciente.Nombre);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, paciente.FechaNacimiento);
                db.AddInParameter(cmd, "@EspecieId", DbType.AnsiString, paciente.EspecieId);
                db.AddInParameter(cmd, "@Observacion", DbType.AnsiString, paciente.Observacion);
                paciente.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return paciente;
        }

        public List<Paciente> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [ClienteId], [Nombre], [FechaNacimiento], [EspecieId], [Observacion] FROM Paciente ";

            List<Paciente> result = new List<Paciente>();
            var db = DatabaseFactory.CreateDatabase("DefaultConnection");
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Paciente paciente = LoadPaciente(dr);
                        result.Add(paciente);
                    }
                }
            }
            return result;
        }

        public Paciente ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT * FROM Paciente WHERE [Id]=@Id ";
            Paciente paciente = null;

            var db = DatabaseFactory.CreateDatabase("DefaultConnection");
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        paciente = LoadPaciente(dr);
                    }
                }
            }
            return paciente;
        }

        public void Update(Paciente paciente)
        {
            const string SQL_STATEMENT = "UPDATE Paciente SET [ClienteId]= @ClienteId, [Nombre]= @Nombre, [FechaNacimiento]= @FechaNacimiento,[EspecieId]= @EspecieId,[Observacion]= @Observacion WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase("DefaultConnection");
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@ClienteId", DbType.AnsiString, paciente.ClienteId);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, paciente.Nombre);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, paciente.FechaNacimiento);
                db.AddInParameter(cmd, "@EspecieId", DbType.AnsiString, paciente.EspecieId);
                db.AddInParameter(cmd, "@Observacion", DbType.AnsiString, paciente.Observacion);
                db.AddInParameter(cmd, "@Id", DbType.Int32, paciente.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Paciente WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase("DefaultConnection");
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Paciente LoadPaciente(IDataReader dr)
        {
            Paciente paciente = new Paciente();
            paciente.Id = GetDataValue<int>(dr, "Id");
            paciente.ClienteId = GetDataValue<int>(dr, "ClienteId");
            paciente.Nombre = GetDataValue<string>(dr, "Nombre");
            paciente.FechaNacimiento = GetDataValue<DateTime>(dr, "FechaNacimiento");
            paciente.EspecieId = GetDataValue<int>(dr, "EspecieId");
            paciente.Observacion = GetDataValue<string>(dr, "Observacion");
            return paciente;
        }



    }
}
