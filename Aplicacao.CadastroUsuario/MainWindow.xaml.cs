using Aplicacao.CadastroUsuario.DAL;
using Aplicacao.CadastroUsuario.Enumerations;
using Aplicacao.CadastroUsuario.Models;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Aplicacao.CadastroUsuario
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Incluir os sexos no componente ComboBox
            Sexos[] sexos = { Sexos.Masculino, Sexos.Feminino };
            sexoComboBox.ItemsSource = sexos;
            sexoComboBox.SelectedIndex = 0;
        }

        private Cliente CriarCliente()
        {
            try
            {
                //Obtendo os dados do endereço
                Endereco endereco = new Endereco()
                {
                    Logradouro = logradouroTextBox.Text,
                    Numero = int.Parse(numeroTextBox.Text),
                    Cidade = cidadeTextBox.Text,
                    Cep = cepTextBox.Text
                };

                //obtendo dados do cliente (contato)
                Cliente cliente = new Cliente();

                //Trabalhando com o documento
                var doc = documentoTextBox.Text;
                if (doc.Length == 11)
                {
                    cliente.Documento = new DocumentoCPF() { Numero = doc };
                }
                else if (doc.Length == 14)
                {
                    cliente.Documento = new DocumentoCNPJ() { Numero = doc };
                }
                else
                {
                    throw new InvalidOperationException("O documento informado não é CPF e nem CNPJ");
                }

                cliente.Nome = nomeTextBox.Text;
                cliente.DataNascimento = Convert.ToDateTime(dataTextBox.Text);
                cliente.Sexo = (Sexos)sexoComboBox.SelectedItem;
                cliente.EnderecoPermanente = endereco;

                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void IncluirButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cliente = CriarCliente();

                var dao = new ContatosDao();
                dao.Incluir(cliente);
                //apresentando os dados p/ o usuario

                MessageBox.Show(
                    "Contato incluído com sucesso",
                    "Dados do contato",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erro na aplicação",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void salvarArquivoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string caminho = @"C:\Estudo\Console\Arquivos\Arquivos\Contatos.txt";
                StreamWriter writer = new StreamWriter(caminho, true);

                var cliente = CriarCliente();
                writer.WriteLine(cliente.Mostrar());
                writer.WriteLine(new string('-', 50));

                writer.Close();

                MessageBox.Show(
                    "Cliente armazenado no arquivo com sucesso!!!",
                    "Dados do contato",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            
            catch (Exception ex)    
            {
                MessageBox.Show(
                ex.Message,
                "Erro na aplicação",
                MessageBoxButton.OK,
                MessageBoxImage.Error); ;
            }
        }

        private void abrirArquivoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Arquivos de Texto (*.txt;*.log)|*.txt;*.log|Todos os arquivos (*.*)|*.*";
            dialog.InitialDirectory = @"C:\Estudo\Console\Arquivos\Arquivos";
            if (dialog.ShowDialog() == true)
            {
                conteudoTextBox.Text = File.ReadAllText(dialog.FileName);
            }
        }

        private void listarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resultadoTextBox.Items.Clear();
                var lista = new ContatosDao().Listar();
                foreach (var item in lista)
                {
                    resultadoTextBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message,
                "Erro na aplicação",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            }
        }

        private void buscarContatoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var contato = new ContatosDao().Buscar(documentoTextBox.Text);
                if(contato == null)
                {
                    throw new Exception("Nenhum cliente encontrado com este documento");
                }
                nomeTextBox.Text = contato.Nome;
                dataTextBox.Text = contato.DataNascimento.ToString("dd/MM/yyyy");
                sexoComboBox.SelectedItem = contato.Sexo == Sexos.Masculino ? 0 : 1;

                var end = contato.EnderecoPermanente;
                logradouroTextBox.Text = end.Logradouro;
                numeroTextBox.Text = end.Numero.ToString();
                cidadeTextBox.Text = end.Cidade;
                cepTextBox.Text = end.Cep;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
