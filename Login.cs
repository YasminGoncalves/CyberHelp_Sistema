using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CyberHelp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
     
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");
            
            string sql = $"select * from usuario where login='{textBoxLogin.Text}' and senha='{textBoxSenha.Text}'";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                if (linhas.Read()) // Verificar se tem alguma linha com os dados fornecidos (login e senha)
                {
                    FormMenu menu = new FormMenu();
                    menu.Empresa = Convert.ToString(linhas["idEmpresa"]);
                    menu.Administrador = "Nenhum";
                    menu.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Usuário ou Senha inválidos.");
                }
            
            } 
            catch (Exception erro) {
                MessageBox.Show("Ocorreu o seguinte erro: "+ erro);
            } 
            finally {
                comando.Dispose();
                conexao.Close();
            }
        }

        private void Cadastrar(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormCadastro cadastro = new FormCadastro();
            cadastro.Show();
            this.Visible = false;
        }


   
        private void MudarLogin(object sender, EventArgs e)
        {
            if (textBoxLogin.Text.Equals("Login"))
            {
                textBoxLogin.Text = "";
                textBoxLogin.ForeColor = Color.Black;
            }
            else if (textBoxLogin.Text.Equals(""))
            {
                textBoxLogin.Text = "Login";
                textBoxLogin.ForeColor = Color.Gray;
            }
        }

        private void MudarSenha(object sender, EventArgs e)
        {
            if (textBoxSenha.Text.Equals("Senha"))
            {
                textBoxSenha.Text = "";
                textBoxSenha.ForeColor = Color.Black;
            }
            else if (textBoxSenha.Text.Equals(""))
            {
                textBoxSenha.Text = "Senha";
                textBoxSenha.ForeColor = Color.Gray;
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

    }
}
