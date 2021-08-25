using System;
using CadastroSeries.Classes;
using CadastroSeries.Enum;

namespace CadastroSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static Serie serie = new Serie();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    ListarSeries();
                    break;
                    case "2":
                    InserirSerie();
                    break;
                    case "3":
                    AtualizarSerie();
                    break;
                    case "4":
                    ExcluirSerie();
                    break;
                    case "5":
                    VisualizarSerie();
                    break;
                    case "C":
                    Console.Clear();
                    break;
                    
                    default:
                    throw new ArgumentOutOfRangeException("Opção inválida! Escolha uma das opções apresentadas.");
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por nos visitar");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            
            var listaseries = repositorio.Listar();
            var excluido = serie.FoiExcluido();
            if (listaseries.Count == 0)
            {
                Console.WriteLine("Não há nenhuma série cadastrada!");
                return;
            }
            foreach (var serie in listaseries)
            {
                if (excluido == true)
                {
                    continue;
                }
                Console.WriteLine("#ID {0}: - {1}", serie.RetornaId(), serie.RetornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Série");

            foreach (int i in Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Genero.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o número para um dos gêneros acima: ");
            var entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            var entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento da série: ");
            var entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            var entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(genero: (Genero)entradaGenero, descricao : entradaDescricao, titulo: entradaTitulo, ano: entradaAno, id: repositorio.ProximoId());

            repositorio.Inserir(novaSerie);

        }

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			var indiceSerie = int.Parse(Console.ReadLine());

				foreach (int i in Genero.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Genero.GetName(typeof(Genero), i));
			}
			Console.WriteLine("Digite o número para um dos gêneros acima: ");
            var entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            var entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento da série: ");
            var entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            var entradaDescricao = Console.ReadLine();

            Serie serieAtualizada = new Serie(genero: (Genero)entradaGenero, descricao : entradaDescricao, titulo: entradaTitulo, ano: entradaAno, id: indiceSerie);

          	repositorio.Atualizar(indiceSerie, serieAtualizada);
		}

         private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			var indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Excluir(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			var indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaId(indiceSerie);

			Console.WriteLine(serie);
		}


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo(a)!");
            Console.WriteLine("Escolha a opção desejada:");
            Console.WriteLine("1- Listar Séries:");
            Console.WriteLine("2- Inserir Nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            
            return opcaoUsuario;
        }
    }
}
