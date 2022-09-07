using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02
{
    class Program
    {
        [System.Serializable]
        //criação dos tipos de dados - cliente
        struct Cliente
        {
            public string nome;
            public string email;
            public string cpf;
        }

        //criando var global para salvar todos os clientes nesta lista
        static List<Cliente> clientes = new List<Cliente>();



        //criação do menu
        enum Menu { Listagem = 1, Adicionar = 2, Remover = 3, Sair = 4}

        static void Main(string[] args)
        {
            //vai carregar a lista dos clientes no inicio do programa
            Carregar();

            bool escolheuSair = false;

            
            while (!escolheuSair)
            {
                Console.WriteLine("Sistema de clientes - Seja bem vindo!!\n");
                Console.WriteLine("1-Listagem\n2-Adicionar\n3-Remover\n4-Sair");

                //capturando a entrada do usuario
                int entradaUser = int.Parse(Console.ReadLine());
                //fazendo conversao do tipo menu pra variavel entradaUser
                Menu opcao = (Menu)entradaUser;

                switch (opcao)
                {
                    case Menu.Adicionar:
                        Adicionar();
                        break;
                    case Menu.Listagem:
                        Listagem();
                        break;
                    case Menu.Remover:
                        Remover();
                        break;
                    case Menu.Sair:
                        escolheuSair = true;
                        break;
                }
                Console.Clear();

            }
        }

        //criando funcao 
        static void Adicionar()
        {

            Cliente cliente = new Cliente();

            //capturando entrada do USER
            Console.WriteLine("Cadastro de clientes");

            Console.WriteLine("Nome:");
            cliente.nome = Console.ReadLine();

            Console.WriteLine("Email:");
            cliente.email = Console.ReadLine();

            Console.WriteLine("CPF:");
            cliente.cpf = Console.ReadLine();

            //adicionando o cliente na lista de clientes
            clientes.Add(cliente);
            //chamando a função salvar
            Salvar();

            Console.WriteLine("Aperte ENTER para sair.");
            Console.ReadLine();

        }

        //listagem
        static void Listagem()
        {

            //IF para fazer a ação de listagem somente se tiver +=1 cliente já cadastrado
            if(clientes.Count >=1)
            {

                Console.WriteLine("Lista de Clientes: ");

                //Var criada para mostrar a posição do cliente
                int i = 0;

                //foreach para percorrer a lista de clientes 
                foreach (Cliente cliente in clientes)
                {
                    //para cada CLIENTE na lista clientes, uma ação
                    Console.WriteLine($"ID: {i}");
                    Console.WriteLine($"Nome: {cliente.nome}");
                    Console.WriteLine($"Nome: {cliente.email}");
                    Console.WriteLine($"Nome: {cliente.cpf}");
                    Console.WriteLine("----------------------------");
                    i++;
                }


            }
            else
            {
                Console.WriteLine("Olá, ainda não há nenhum cliente cadastrado!");
            }

            Console.WriteLine("Aperte ENTER para sair.");
            Console.ReadLine();

        }


        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID que deseja remover");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < clientes.Count)
            {
                clientes.RemoveAt(id);
                Salvar();
            }
            else
            {
                Console.WriteLine("O ID digitado é invalido, tente novamente");
                Console.ReadLine();
            }

        }



        //criação de STREAM para salvar os dados no arquivo quando encerrar o programa
        //funções SALVAR E CARREGAR
        static void Salvar()
        {
            //vai criar uma stream e se nao tiver, cria um novo
            FileStream stream = new FileStream("clients.dat", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();

            enconder.Serialize(stream, clientes);

            stream.Close();
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("clients.dat", FileMode.OpenOrCreate);


            //estrutura try/catch: ele tenta executar o try mas senao rolar, executa o catch
            try
            {
                //vai criar uma stream e se nao tiver, cria um novo
                BinaryFormatter enconder = new BinaryFormatter();

                clientes = (List<Cliente>)enconder.Deserialize(stream);


                //se tentar ler o arquivo e estiver vazio, crie uma nova lista
                if (clientes == null)
                {
                    clientes = new List<Cliente>();
                }
            }
            catch(Exception e)
            {
                clientes = new List<Cliente>();
            }

            stream.Close();

        }


    }
}
