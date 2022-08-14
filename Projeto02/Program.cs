using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02
{
    class Program
    {

        enum Menu { Listagem = 1, Adicionar = 2, Remover = 3, Sair = 4}

        static void Main(string[] args)
        {

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
                        break;
                    case Menu.Listagem:
                        break;
                    case Menu.Remover:
                        break;
                    case Menu.Sair:
                        escolheuSair = true;
                        break;
                }
                Console.Clear();







            }






        }
    }
}
