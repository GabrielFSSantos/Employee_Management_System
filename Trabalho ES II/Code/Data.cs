using System.Data.SQLite;
using System.Reflection;
using System.IO;
using System;
using System.Data;
using System.Windows.Forms;

namespace Trabalho_ESII.Code
{
    class Data
    {
        private string installLocation;
        private static SQLiteConnection connection;

        public Data()
        {
            installLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        private SQLiteConnection DBConnection()
        {
            SQLiteConnection con;
            con = new SQLiteConnection("Data Source=" + installLocation + "\\Treinamentos.sqlite");
            con.Open();
            return con;
        }
        public void Setup()
        {
            var createSQL = installLocation + "\\Scripts\\create.sql";
            try
            {
                SQLiteConnection.CreateFile(installLocation + "\\Treinamentos.sqlite");
                connection = DBConnection();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = File.ReadAllText(createSQL);
                    cmd.ExecuteNonQuery();          
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getAll(string table)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM " + table;
                    da = new SQLiteDataAdapter(cmd.CommandText, connection);
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getMatricula()
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT CódigoE as codEmpregado, CódigoT as codTurma, Frequência FROM MATRÍCULA";
                    da = new SQLiteDataAdapter(cmd.CommandText, connection);
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void insertEmpregado(string nome, string endereco, string telefone, string cargo,int codigog)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO EMPREGADO(nome,endereço,telefone,cargo,códigog) VALUES(" + '"' + nome + '"' + "," + '"' + endereco + '"' + "," + '"' + telefone + '"' + "," + '"' + cargo + '"' + "," + codigog + ");";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool canMatricula(int codigot)
        {
            string sql = "SELECT COUNT(*) FROM TURMA WHERE CódigoT = " + codigot;
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    da = new SQLiteDataAdapter(cmd.CommandText, connection);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        int count = int.Parse(dt.Rows[0][0].ToString());
                        return  count < 10;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } //Restrição #1

        public void insertMatricula(int idEmpregado, int idTurma)
        {
            if (canMatricula(idTurma))
            {
                try
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO MATRÍCULA(códigoe,códigot) VALUES(" + idEmpregado + "," + idTurma + ");";
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public DataTable runSQL(string sql)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    da = new SQLiteDataAdapter(cmd.CommandText, connection);
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable deleteRow(int row, string table)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM EMPREGADO WHERE CódigoE=" + row;
                    da = new SQLiteDataAdapter(cmd.CommandText, connection);
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getTurma(int turma)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT CódigoT as codTurma, CURSO.Nome, INSTRUTOR.Nome as nomeInstrutor, HORÁRIOS.horário FROM TURMA INNER JOIN CURSO on TURMA.CódigoC = CURSO.CódigoC INNER JOIN INSTRUTOR on TURMA.CódigoI = INSTRUTOR.CódigoI inner join HORÁRIOS on TURMA.códigoh = HORÁRIOS.códigoh WHERE CódigoT = " + turma;
                    da = new SQLiteDataAdapter(cmd.CommandText, connection);
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable getAlunos(int turma)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT EMPREGADO.nome, EMPREGADO.Cargo, CURSO.Nome as Curso FROM MATRÍCULA inner join EMPREGADO on MATRÍCULA.códigoe = EMPREGADO.CódigoE INNer join TURMA on MATRÍCULA.CódigoT = TURMA.CódigoT inner join CURSO ON TURMA.CódigoC = CURSO.CódigoC WHERE TURMA.CódigoT = " + turma;
                    da = new SQLiteDataAdapter(cmd.CommandText, connection);
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public DataTable getEmpregado(string nome)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT EMPREGADO.nome, EMPREGADO.Cargo, CURSO.Nome as Curso FROM MATRÍCULA inner join EMPREGADO on MATRÍCULA.códigoe = EMPREGADO.CódigoE INNer join TURMA on MATRÍCULA.CódigoT = TURMA.CódigoT inner join CURSO ON TURMA.CódigoC = CURSO.CódigoC WHERE EMPREGADO.Nome = '" + nome +"'";
                    da = new SQLiteDataAdapter(cmd.CommandText, connection);
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

