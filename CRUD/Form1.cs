using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace CRUD
{
    public partial class Form1 : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter Da;
        SqlDataReader Dr;

        string strSQL;



        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                //Para este crud funcionar ensira o endereço do seu servidor local, sua base de dados e usuario do seu sql;
                //E crie uma tabela com os campos id e nome;
                conexao = new SqlConnection(@"Server ;Database=USUARIO; User Id=; Password=;");
                strSQL = "INSERT INTO CLIENTE (NOME) VALUES (@NOME)";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@NOME", txt_Nome.Text);

                conexao.Open(); 
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            try
            {
                //Para este crud funcionar ensira o endereço do seu servidor local, sua base de dados e usuario do seu sql;
                //E crie uma tabela com os campos id e nome;
                 conexao = new SqlConnection(@"Server= ;Database=; User Id=sa; Password=;");
                strSQL = "DELETE CLIENTE WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txt_Id.Text);

                conexao.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {

            try
            {
                //Para este crud funcionar ensira o endereço do seu servidor local, sua base de dados e usuario do seu sql;
                //E crie uma tabela com os campos id e nome;
                conexao = new SqlConnection(@"Server= ;Database=; User Id=sa; Password=;");
                strSQL = "SELECT * FROM CLIENTE";

                DataSet ds = new DataSet();

                Da = new SqlDataAdapter(strSQL, conexao);

                conexao.Open();

                Da.Fill(ds);

                dgvDados.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }

        }

        private void btnConsult_Click(object sender, EventArgs e)
        {

            try
            {
                //Para este crud funcionar ensira o endereço do seu servidor local, sua base de dados e usuario do seu sql;
                //E crie uma tabela com os campos id e nome;
                conexao = new SqlConnection(@"Server= ;Database=; User Id=sa; Password= ;");
                strSQL = "SELECT * FROM CLIENTE WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txt_Id.Text);

                conexao.Open();
                Dr = comando.ExecuteReader();

                while (Dr.Read()) 
                {
                    txt_Nome.Text = (string)Dr["NOME"];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {
                //Para este crud funcionar ensira o endereço do seu servidor local, sua base de dados e usuario do seu sql;
                //E crie uma tabela com os campos id e nome;
                conexao = new SqlConnection(@"Server=;Database=USUARIO; User Id=; Password=;");
                strSQL = "UPDATE CLIENTE SET NOME = @NOME WHERE ID = @ID  ";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@NOME", txt_Nome.Text);
                comando.Parameters.AddWithValue("@ID", txt_Id.Text);

                conexao.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }


        }

        private void txt_Id_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
