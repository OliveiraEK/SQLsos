using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sos_Vicios
{
    public partial class frmOngs : Form
    {
        public void limparCampos()
        {
            mkbCodigo.Clear();
            txtNome.Clear();
            mktTelefone.Clear();
            mktCnpj.Clear();
            txtEndereco.Clear();
            txtWebsite.Clear();
        }

        public frmOngs()
        {
            InitializeComponent();

        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            if ((mkbCodigo.Text == String.Empty) && (txtNome.Text == String.Empty) && (mktTelefone.Text == String.Empty) && (mktCnpj.Text == String.Empty) && (txtEndereco.Text == String.Empty) && (txtWebsite.Text == String.Empty))
            {
                MessageBox.Show("Campos obrigatórios!!!",
                   "Mensagem do sistema",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1);
                limparCampos();
            }

            else
            {
                cadastrarUsuario();
            }
        }

        public void buscarCodigo()
        {
            
        }



        public void cadastrarUsuario()
        {
            Conexao.conectar();

            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "insert into tbONGs(nome,tel,cnpj,endereco,website)values(@nome, @tel, @cnpj, @endereco, @website);";
            comm.CommandType = CommandType.Text;
            //limpando os parâmetros de registro
            comm.Parameters.Clear();
            //ligando os campos do SQL ao c#
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = txtNome.Text;
            comm.Parameters.Add("@tel", MySqlDbType.VarChar, 50).Value = mktTelefone.Text;
            comm.Parameters.Add("@cnpj", MySqlDbType.VarChar, 50).Value = mktCnpj.Text;
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar, 50).Value = txtEndereco.Text;
            comm.Parameters.Add("@website", MySqlDbType.VarChar, 50).Value = txtWebsite.Text;


            comm.Connection = Conexao.conectar();

            try
            {
                comm.ExecuteNonQuery();

                MessageBox.Show("Cadastrado com sucesso!!!",
                        "Mensagem do sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                limparCampos();
            }
            catch (Exception)
            {

                MessageBox.Show("Usuário já existe no banco de dados!!!",
                   "Mensagem do sistema",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1);
            }


            Conexao.desconectar();
        }
    }
}
