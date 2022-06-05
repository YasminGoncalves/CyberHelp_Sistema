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
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
        }

        private void textBoxVoltar_Click(object sender, EventArgs e)
        {
            // Abrir o form de Login
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }
        

        public string CamposObrigatorios()
        {
            string validar = "Não";

            if (textBoxEmpresa.Text.Equals("") || textBoxEmpresa.Text.Equals("Nome da Empresa")) {
                MessageBox.Show("O preenchimento do campo empresa é obrigatório");
            }
            else if (textBoxCnpj.Text.Equals("") || textBoxCnpj.Text.Equals("CNPJ")) {
                MessageBox.Show("O preenchimento do campo CNPJ é obrigatório");
            }
            else if (textBoxEmail.Text.Equals("") || textBoxEmail.Text.Equals("E-mail")) {
                MessageBox.Show("O preenchimento do campo e-mail é obrigatório");
            }
            else if (textBoxLogin.Text.Equals("") || textBoxEmail.Text.Equals("Login")) {
                MessageBox.Show("O preenchimento do campo login é obrigatório");
            }
            else if (textBoxSenha.Text.Equals("") || textBoxSenha.Text.Equals("Senha"))
            {
                MessageBox.Show("O preenchimento do campo senha é obrigatório");
            }
            else
            {
                validar = "Sim";
            }

            return validar;
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            if (CamposObrigatorios().Equals("Sim"))
            {

                MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

                string sql = $"insert into usuario(idEmpresa, empresa, cnpj, email, telefone, login, senha) values " +
                    $"(NULL, '{textBoxEmpresa.Text}', '{textBoxCnpj.Text}', '{textBoxEmail.Text}', '{textBoxTel.Text}', '{textBoxLogin.Text}', '{textBoxSenha.Text}')";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                try
                {
                    conexao.Open();
                    int linhaAfetada = comando.ExecuteNonQuery();

                    if (linhaAfetada == 1)
                        MessageBox.Show("Cadastro realizado com sucesso!");
                    else
                        MessageBox.Show("Ocorreu um erro ao realizar o cadastro, tente novamente!");

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
        }
    }
}
