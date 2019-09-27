
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
    //public partial class PacienteDac : DataAccessComponent, IRepository<Paciente>
    //{

    //    public Paciente Create(Paciente paciente)
    //    {
    //        const string SQL_STATEMENT = "INSERT INTO Pciente ([ClienteId],[Nombre],[FechaNacimiento],[EspecieId],[Observacion]) VALUES(@ClienteId, @Nombre, @FechaNacimiento, @EspecieId, @Observacion ); SELECT SCOPE_IDENTITY();";

    //        var db = DatabaseFactory.CreateDatabase("DefaultConnection");
    //        using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
    //        { 
    //            db.AddInParameter(cmd, "Nombre", DbType.AnsiString, paciente.Nombre);
    //            db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, paciente.FechaNacimiento);
    //            db.AddInParameter(cmd, "@EspecieId", DbType.AnsiString, paciente.EspecieId);
    //            db.AddInParameter(cmd, "@Observacion", DbType.AnsiString, paciente.Observacion);
    //            paciente.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
    //        }
    //        return paciente;
    //    }

    //    public List<Paciente> Read()
    //    {
    //        const string SQL_STATEMENT = "SELECT [Id], [Nombre], [FechaNacimiento], [EspecieId], [Observacion] FROM Paciente ";

    //        List<Paciente> result = new List<Paciente>();
    //        var db = DatabaseFactory.CreateDatabase("DefaultConnection");
    //        using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
    //        {
    //            using (IDataReader dr = db.ExecuteReader(cmd))
    //            {
    //                while (dr.Read())
    //                {
    //                    Paciente paciente = LoadPaciente(dr);
    //                    result.Add(paciente);
    //                }
    //            }
    //        }
    //        return result;
    //    }

    //    public Especie ReadBy(int id)
    //    {
    //        const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM Especie WHERE [Id]=@Id ";
    //        Especie especie = null;

    //        var db = DatabaseFactory.CreateDatabase("DefaultConnection");
    //        using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
    //        {
    //            db.AddInParameter(cmd, "@Id", DbType.Int32, id);
    //            using (IDataReader dr = db.ExecuteReader(cmd))
    //            {
    //                if (dr.Read())
    //                {
    //                    especie = LoadEspecie(dr);
    //                }
    //            }
    //        }
    //        return especie;
    //    }

    //    public void Update(Especie especie)
    //    {
    //        const string SQL_STATEMENT = "UPDATE Especie SET [Nombre]= @Nombre WHERE [Id]= @Id ";

    //        var db = DatabaseFactory.CreateDatabase("DefaultConnection");
    //        using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
    //        {
    //            db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, especie.Nombre);
    //            db.AddInParameter(cmd, "@Id", DbType.Int32, especie.Id);
    //            db.ExecuteNonQuery(cmd);
    //        }
    //    }

    //    public void Delete(int id)
    //    {
    //        const string SQL_STATEMENT = "DELETE Especie WHERE [Id]= @Id ";
    //        var db = DatabaseFactory.CreateDatabase("DefaultConnection");
    //        using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
    //        {
    //            db.AddInParameter(cmd, "@Id", DbType.Int32, id);
    //            db.ExecuteNonQuery(cmd);
    //        }
    //    }

    //    private Paciente LoadPaciente(IDataReader dr)
    //    {
    //        Paciente paciente = new Paciente();
    //        paciente.Id = GetDataValue<int>(dr, "Id");
    //        paciente.Nombre = GetDataValue<string>(dr, "Nombre");
    //        return paciente;
    //    }



    //}
}
