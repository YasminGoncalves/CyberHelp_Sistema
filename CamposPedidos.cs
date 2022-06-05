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
    public partial class CamposPedidos : Form
    {
        public CamposPedidos()
        {
            InitializeComponent();
        }

        public string Empresa { get; set; }
        public string Adm { get; set; }
        public string Pedido { get; set; }
        public string acao { get; set; }

        private void Buscar()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");
            string sql = $"select * from pedido where idPedido={this.Pedido}";
            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                if (linhas.Read())
                {
                    textBoxId.Text = linhas["idPedido"].ToString();
                    textBoxData.Text = linhas["data"].ToString();
                    richTextBoxDesc.Text = linhas["descricao"].ToString();
                    textBoxStatus.Text = linhas["status"].ToString();
                    textBoxValor.Text = linhas["valor"].ToString();
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

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string comandoSql = $"delete from pedido where idPedido={this.Pedido}";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Pedido excluído com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao tentar excluir o pedido, tente novamente!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + erro);
            }
            finally
            {
                comando.Dispose();
                conexao.Close();
                Finalizar();
            }
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string comandoSql = $"updade pedido set descricao = '{richTextBoxDesc.Text}', status = '{textBoxStatus.Text}', valor = {textBoxValor.Text} WHERE idPedido = {this.Pedido}";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Produto atualizado com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao atualizar o pedido, tente novamente!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + erro);
            }
            finally
            {
                comando.Dispose();
                conexao.Close();
                Finalizar();
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string comandoSql = $"insert into pedido (idPedido, data, descricao, status, valor, idEmpresa, idAdm) values " +
               $"(NULL, '{textBoxData.Text}', '{richTextBoxDesc.Text}', '{textBoxStatus.Text}', '{textBoxValor.Text}', {Convert.ToInt32(this.Empresa)}, {Convert.ToInt32(this.Adm)})";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Pedido cadastrado com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao adicionar o pedido, tente novamente!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + erro);
            }
            finally
            {
                comando.Dispose();
                conexao.Close();
                Finalizar();
            }
        }

        private void CamposPedidos_Load(object sender, EventArgs e)
        {
            if (!this.acao.Equals("Incluir")) Buscar();

            if (this.acao.Equals("Incluir"))
            {
                labelAcao.Text = "Incluir Pedido";
                buttonAdicionar.Visible = true;
            }
            else if (this.acao.Equals("Excluir"))
            {
                labelAcao.Text = "Excluir Pedido";
                buttonExcluir.Visible = true;
            }
            else if (this.acao.Equals("Alterar"))
            {
                labelAcao.Text = "Alterar Pedido";
                buttonAlterar.Visible = true;
            }
        }

        private void Finalizar()
        {
            Pedidos pedidos  = new Pedidos();
            pedidos.Administrador = this.Adm;
            pedidos.Empresa = this.Empresa;
            pedidos.Show();
            this.Close();
        }
    }
}
