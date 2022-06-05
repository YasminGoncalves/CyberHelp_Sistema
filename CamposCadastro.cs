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
    public partial class CamposCadastro : Form
    {
        public CamposCadastro()
        {
            InitializeComponent();
            
        }

        public string idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }
        public string idAdministrador { get; set; }
        public string nomeAdministrador { get; set; }
        public string cliente { get; set; }
        public string acao { get; set; }

        private void Buscar(int p)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");
            string sql;
            if (p.Equals(1)) sql = $"select * from administrador where idAdm={Convert.ToInt32(this.idAdministrador)}";
            else sql = $"select * from cliente where idCliente={Convert.ToInt32(this.cliente)}";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                if (linhas.Read())
                {
                    if (p.Equals(1))
                    {
                        textBoxId.Text = linhas["idAdm"].ToString();
                        textBoxNome.Text = linhas["nome"].ToString();
                        textBoxFE.Text = linhas["email"].ToString();
                        textBoxEndSenha.Text = linhas["senha"].ToString();
                    }
                    else
                    {
                        textBoxId.Text = linhas["idCliente"].ToString();
                        textBoxNome.Text = linhas["nome"].ToString();
                        textBoxFE.Text = linhas["telefone"].ToString();
                        textBoxEndSenha.Text = linhas["endereco"].ToString();
                    }
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
        private void CamposCadastro_Load(object sender, EventArgs e)
        {
            if (this.acao.Equals("Adicionar 1"))
            {
                buttonAdicionarAdm.Visible = true;
                labelSenha.Visible = true;
                labelEmail.Visible = true;
                labelAcao.Text = "Adicionar administrador";
            }
            else if (this.acao.Equals("Excluir 1"))
            {
                buttonExcluirAdm.Visible = true;
                labelSenha.Visible = true;
                labelEmail.Visible = true;
                labelAcao.Text = "Excluir administrador";
                Buscar(1);
            }
            else if (this.acao.Equals("Adicionar 2"))
            {
                buttonAdicionarC.Visible = true;
                labelEndereco.Visible = true;
                labelFone.Visible = true;
                labelAcao.Text = "Adicionar cliente";
            }
            else if(this.acao.Equals("Alterar 2"))
            {
                buttonAlterarC.Visible = true;
                labelEndereco.Visible = true;
                labelFone.Visible = true;
                labelAcao.Text = "Alterar cliente";
                Buscar(2);
            }
            else
            {
                buttonExcluirC.Visible = true;
                labelEndereco.Visible = true;
                labelFone.Visible = true;
                labelAcao.Text = "Excluir cliente";
                Buscar(2);
            }
        }


        private void buttonExcluirC_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string comandoSql = $"delete from cliente where idCliente={Convert.ToInt32(this.cliente)}";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Cliente excluído com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao tentar excluir o cliente, tente novamente!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + erro);
            }
            finally
            {
                comando.Dispose();
                conexao.Close();
                CadastroCliente cadastro = new CadastroCliente();
                cadastro.idEmpresa = this.idEmpresa;
                cadastro.nomeEmpresa = this.nomeEmpresa;
                cadastro.idAdministrador = this.idAdministrador;
                cadastro.nomeAdministrador = this.nomeAdministrador;
                cadastro.Show();
                this.Close();
            }
        }

        private void buttonExcluirAdm_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");
            
            string comandoSql = $"delete from administrador where idAdm={Convert.ToInt32(this.idAdministrador)}";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Administrador excluído com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao tentar excluir o administrador, tente novamente!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + erro);
            }
            finally
            {
                comando.Dispose();
                conexao.Close();

                Administradores adm = new Administradores(this.nomeEmpresa);
                adm.Empresa = this.idEmpresa;
                adm.Administrador = this.idAdministrador;
                adm.Show();
                this.Close();
            }
        }

        private void buttonAdicionarC_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string comandoSql = $"insert into cliente (idCliente, nome, telefone, endereco, empresa, admCadastro) values " +
               $"(NULL, '{textBoxNome.Text}', '{textBoxFE.Text}', '{textBoxEndSenha.Text}', {Convert.ToInt32(this.idEmpresa)}, {Convert.ToInt32(this.idAdministrador)})";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Cliente cadastrado com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao adicionar o cliente, tente novamente!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + erro);
            }
            finally
            {
                comando.Dispose();
                conexao.Close();

                CadastroCliente cadastro = new CadastroCliente();
                cadastro.idEmpresa = this.idEmpresa;
                cadastro.nomeEmpresa = this.nomeEmpresa;
                cadastro.idAdministrador = this.idAdministrador;
                cadastro.nomeAdministrador = this.nomeAdministrador;
                cadastro.Show();
                this.Close();
            }

        }

        private void buttonAdicionarAdm_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string comandoSql = $"insert into administrador (idAdm, nome, email, senha, idEmpresa) values " +
               $"(NULL, '{textBoxNome.Text}', '{textBoxFE.Text}', '{textBoxEndSenha.Text}', {Convert.ToInt32(this.idEmpresa)})";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Administrador cadastrado com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao adicionar o Administrador, tente novamente!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + erro);
            }
            finally
            {
                comando.Dispose();
                conexao.Close();

                Administradores adm = new Administradores(this.nomeEmpresa);
                adm.Empresa = this.idEmpresa;
                adm.Administrador = this.idAdministrador;
                adm.Show();
                this.Close();
            }
        }

        private void buttonAlterarC_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string comandoSql = $"UPDATE cliente SET nome= '{textBoxNome.Text}', telefone = {textBoxFE.Text}, endereco = {textBoxEndSenha.Text} WHERE idCliente = {Convert.ToInt32(this.cliente)}";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Cliente atualizado com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao atualizar o cliente, tente novamente!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + erro);
            }
            finally
            {
                comando.Dispose();
                conexao.Close();

                CadastroCliente cadastro = new CadastroCliente();
                cadastro.idEmpresa = this.idEmpresa;
                cadastro.nomeEmpresa = this.nomeEmpresa;
                cadastro.idAdministrador = this.idAdministrador;
                cadastro.nomeAdministrador = this.nomeAdministrador;
                cadastro.Show();
                this.Close();
            }
        }
    }
}
