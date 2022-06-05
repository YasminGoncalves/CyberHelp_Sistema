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
    public partial class Pedidos : Form
    {
        public Pedidos()
        {
            InitializeComponent();
        }
        public string Empresa { get; set; }
        public string Administrador { get; set; }

        private void atualizar()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string sql = $"select * from pedido where idEmpresa={Convert.ToInt32(this.Empresa)}";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
  
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();
                DataTable tabelaPedido = new DataTable();

                tabelaPedido.Columns.Add("Código").ReadOnly = true;
                tabelaPedido.Columns.Add("Data");
                tabelaPedido.Columns.Add("Descrição");
                tabelaPedido.Columns.Add("Status");
                tabelaPedido.Columns.Add("Valor");

                while (linhas.Read())
                {
                    DataRow linha = tabelaPedido.NewRow();
                    linha[0] = linhas["idPedido"];
                    linha[1] = linhas["data"];
                    linha[2] = linhas["descricao"];
                    linha[3] = linhas["status"];
                    linha[4] = linhas["valor"];

                    tabelaPedido.Rows.Add(linha);
                }

                dataGridViewPedidos.DataSource = tabelaPedido;
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

        private void BuscarEmpresa()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string sql = $"select empresa from usuario where idEmpresa={Convert.ToInt32(this.Empresa)}";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                if (linhas.Read())
                {
                    labelEmpresa.Text = linhas["empresa"].ToString();
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

        private void BuscarAdm()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string sql = $"select nome from administrador where idAdm={Convert.ToInt32(this.Administrador)}";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                if (linhas.Read())
                {
                    labelAdm.Text = linhas["nome"].ToString();
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

        private void Pedidos_Load(object sender, EventArgs e)
        {
            atualizar();
            BuscarAdm();
            BuscarEmpresa();
        }

        private void labelVoltar_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            menu.Administrador = this.Administrador;
            menu.Empresa = this.Empresa;
            menu.Show();
            this.Close();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            CamposPedidos cp = new CamposPedidos();
            cp.acao = "Incluir";
            cp.Adm = this.Administrador;
            cp.Empresa = this.Empresa;
            cp.Show();
            this.Close();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            CamposPedidos cp = new CamposPedidos();
            cp.acao = "Excluir";
            cp.Adm = this.Administrador;
            cp.Empresa = this.Empresa;
            cp.Pedido = dataGridViewPedidos.CurrentRow.Cells[0].Value.ToString();
            cp.Show();
            this.Close();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text.Equals(""))
            {
                atualizar();
            }
            else
            {
                MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

                string sql = $"select * from pedido where idEmpresa={Convert.ToInt32(this.Empresa)} and idPedido={Convert.ToInt32(textBoxID.Text)}";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                try
                {

                    conexao.Open();
                    MySqlDataReader linhas = comando.ExecuteReader();
                    DataTable tabelaPedido = new DataTable();

                    tabelaPedido.Columns.Add("Código").ReadOnly = true;
                    tabelaPedido.Columns.Add("Data");
                    tabelaPedido.Columns.Add("Descrição");
                    tabelaPedido.Columns.Add("Status");
                    tabelaPedido.Columns.Add("Valor");

                    while (linhas.Read())
                    {
                        DataRow linha = tabelaPedido.NewRow();
                        linha[0] = linhas["idPedido"];
                        linha[1] = linhas["data"];
                        linha[2] = linhas["descricao"];
                        linha[3] = linhas["status"];
                        linha[4] = linhas["valor"];

                        tabelaPedido.Rows.Add(linha);
                    }

                    dataGridViewPedidos.DataSource = tabelaPedido;
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
