
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
    public partial class PacienteDac : DataAccessComponent, IRepository<Paciente>
    {

        public Paciente Create(Paciente paciente)
        {
            const string SQL_STATEMENT = "INSERT INTO Especie ([ClienteId],[Nombre],[FechaNacimiento],[EspecieId],[Observacion]) VALUES(@ClienteId, @Nombre, @FechaNacimiento, @EspecieId, @Observacion ); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase("DefaultConnection");
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@ClienteId", "@Nombre", "@FechaNacimiento", "@EspecieId", "@Observacion", DbType.AnsiString, paciente.Nombre);
                paciente.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return especie;
        }

        public List<Especie> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM Especie ";

            List<Especie> result = new List<Especie>();
            var db = DatabaseFactory.CreateDatabase("DefaultConnection");
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Especie especie = LoadEspecie(dr);
                        result.Add(especie);
                    }
                }
            }
            return result;
        }

        public Especie ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM Especie WHERE [Id]=@Id ";
            Especie especie = null;

            var db = DatabaseFactory.CreateDatabase("DefaultConnection");
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        especie = LoadEspecie(dr);
                    }
                }
            }
            return especie;
        }

        public void Update(Especie especie)
        {
            const string SQL_STATEMENT = "UPDATE Especie SET [Nombre]= @Nombre WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase("DefaultConnection");
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, especie.Nombre);
                db.AddInParameter(cmd, "@Id", DbType.Int32, especie.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Especie WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase("DefaultConnection");
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Especie LoadEspecie(IDataReader dr)
        {
            Especie especie = new Especie();
            especie.Id = GetDataValue<int>(dr, "Id");
            especie.Nombre = GetDataValue<string>(dr, "Nombre");
            return especie;
        }



    }
}
