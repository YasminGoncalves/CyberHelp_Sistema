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
    public partial class LogarADM : Form
    {
        public LogarADM()
        {
            InitializeComponent();
        }

        public string Empresa { get; set; }
        public string Administrador { get; set; }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string sql = $"select * from administrador where idAdm='{textBoxLogin.Text}' and senha='{textBoxSenha.Text}'";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                if (linhas.Read()) // Verificar se tem alguma linha com os dados fornecidos (login e senha)
                {
                    FormMenu formMenu = new FormMenu();
                    formMenu.Empresa =this.Empresa;
                    formMenu.Administrador = this.Administrador;
                    formMenu.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuário ou Senha inválidos. Volte ao menu de Administradores ou Tente novamente.");
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + erro);
            }
            finally
            {
                comando.Dispose();
                conexao.Close();
            }
        }

        private void LogarADM_Load(object sender, EventArgs e)
        {
            textBoxLogin.Text = this.Administrador;
        }
    }
}
