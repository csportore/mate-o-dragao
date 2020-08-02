using System;
using System.Collections.Generic;
using MateODragao.Models;
using MateODragao.Repositories;
using System.Linq;
using System.IO;

namespace MateODragao
{
    class Program
    {
        static void Main(string[] args)
        {

            bool jogadorNaoDesistiu = true;

            Guerreiro guerreiro = null;
            GuerreiroRepository guerreiroRepository = new GuerreiroRepository();

            do
            {
                /* INICIO - Menu Principal */
                Console.Clear();
                System.Console.WriteLine("===========================");
                System.Console.WriteLine("       Mate o Dragão!");
                System.Console.WriteLine("===========================");

                System.Console.WriteLine(" 1 - Iniciar jogo");
                System.Console.WriteLine(" 2 - Criar personagem");
                System.Console.WriteLine(" 3 - Carregar personagem salvo");
                System.Console.WriteLine(" 0 - Sair do jogo");
                System.Console.Write(" Digite o código da opção:");
                string opcaoJogador = Console.ReadLine();

                /* FIM - Menu Principal */
                switch (opcaoJogador)
                {
                    case "1":
                        Console.Clear();

                        /* INICIO - Criando o dragão */
                        if(guerreiro == null)
                            guerreiro = guerreiroRepository.CriarPersonagemPadrao();

                        Dragao dragao = new Dragao();
                        dragao.Nome = "Dragonildo";
                        dragao.Forca = 5;
                        dragao.Destreza = 1;
                        dragao.Inteligencia = 3;
                        dragao.Vida = 300;
                        /* FIM - Criando o dragão */

                        /* INICIO - Primeiro Diálogo */
                        System.Console.WriteLine($"{guerreiro.Nome.ToUpper()}: {dragao.Nome}, seu louco! Vim-lhe derrotar-lhe!");
                        System.Console.WriteLine($"{dragao.Nome.ToUpper()}: Humano tolinho. Quem pensas que és?");

                        System.Console.WriteLine();
                        System.Console.WriteLine("Aperte ENTER para prosseguir");
                        Console.ReadLine();
                        Console.Clear();
                        /* FIM - Primeiro Diálogo */

                        /* INICIO - Segundo Diálogo */
                        System.Console.WriteLine($"{guerreiro.Nome.ToUpper()}: Eu sou {guerreiro.Nome}! Da casa {guerreiro.Sobrenome}, ó criatura morfética!");
                        System.Console.WriteLine($"{guerreiro.Nome.ToUpper()}: Vim de {guerreiro.CidadeNatal} para derrotar-te e mostrar meu valor!");
                        System.Console.WriteLine($"{dragao.Nome.ToUpper()}: QUEM? DE ONDE? Bom, que seja...fritar-te-ei e devorar-te-ei, primata insolente!");

                        System.Console.WriteLine();
                        System.Console.WriteLine("Aperte ENTER para prosseguir");
                        Console.ReadLine();
                        Console.Clear();
                        /* FIM - Segundo Diálogo */

                        bool jogadorAtacaPrimeiro = guerreiro.Destreza > dragao.Destreza ? true : false;
                        bool jogadorNaoCorreu = true;

                        /** INICIO - Quando o jogador ataca primeiro */
                        if (jogadorAtacaPrimeiro)
                        {
                            Console.Clear();

                            System.Console.WriteLine("------------------------------");
                            System.Console.WriteLine("        Turno do jogador:");
                            System.Console.WriteLine("------------------------------");
                            System.Console.WriteLine("Escolha sua ação");
                            System.Console.WriteLine(" 1 - Atacar");
                            System.Console.WriteLine(" 2 - Fugir");
                            System.Console.Write(" Digite o código da opção:");
                            string opcaoBatalhaJogador = Console.ReadLine();

                            switch (opcaoBatalhaJogador)
                            {
                                case "1":
                                    Random geradorNumeroAleatorio = new Random();
                                    int numeroAleatorioJogador = geradorNumeroAleatorio.Next(0, 5);
                                    int numeroAleatorioDragao = geradorNumeroAleatorio.Next(0, 5);
                                    int guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                                    int dragaoDestrezaTotal = guerreiro.Destreza + numeroAleatorioDragao;
                                    int poderAtaqueGuerreiro = guerreiro.Forca > guerreiro.Inteligencia ? guerreiro.Forca + guerreiro.Destreza : guerreiro.Inteligencia + guerreiro.Destreza;

                                    if (guerreiroDestrezaTotal > dragaoDestrezaTotal)
                                    {
                                        System.Console.WriteLine($"{guerreiro.Nome.ToUpper()}: Toma essa lagarto MALDJEETO! BIRLLLL!");
                                        dragao.Vida -= poderAtaqueGuerreiro + 5;
                                        System.Console.WriteLine($"HP Dragão: {dragao.Vida}");
                                        System.Console.WriteLine($"HP Jogador: {guerreiro.Vida}");
                                    }
                                    else
                                    {
                                        System.Console.WriteLine($"{dragao.Nome.ToUpper()}: Errrrrou, humanóide tosco!");
                                        System.Console.WriteLine($"HP Dragão: {dragao.Vida}");
                                        System.Console.WriteLine($"HP Jogador: {guerreiro.Vida}");
                                    }
                                    break;
                                case "2":
                                    System.Console.WriteLine($"{guerreiro.Nome.ToUpper()}: Simbora fii! FLW VLW!");
                                    jogadorNaoCorreu = false;
                                    break;
                            }
                            System.Console.WriteLine();
                            System.Console.WriteLine("Aperte ENTER para prosseguir");
                            Console.ReadLine();
                        }

                        /** FIM - Quando o jogador ataca primeiro */

                        /** INICIO - Turnos Oficiais */
                        while (dragao.Vida > 0 && guerreiro.Vida > 0 && jogadorNaoCorreu)
                        {

                            Console.Clear();
                            System.Console.WriteLine("------------------------------");
                            System.Console.WriteLine("       Turno do dragão:");
                            System.Console.WriteLine("------------------------------");
                            Random geradorNumeroAleatorio = new Random();
                            int numeroAleatorioJogador = geradorNumeroAleatorio.Next(0, 5);
                            int numeroAleatorioDragao = geradorNumeroAleatorio.Next(0, 5);
                            int guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                            int dragaoDestrezaTotal = guerreiro.Destreza + numeroAleatorioDragao;

                            if (guerreiroDestrezaTotal < dragaoDestrezaTotal)
                            {
                                System.Console.WriteLine($"{dragao.Nome.ToUpper()}: HA! Estúpido ser!");
                                guerreiro.Vida -= dragao.Forca;
                                System.Console.WriteLine($"HP Dragão: {dragao.Vida}");
                                System.Console.WriteLine($"HP Jogador: {guerreiro.Vida}");
                            }
                            else
                            {
                                System.Console.WriteLine($"{guerreiro.Nome.ToUpper()}: Eita lasquera que essa passou perto!");
                                System.Console.WriteLine($"HP Dragão: {dragao.Vida}");
                                System.Console.WriteLine($"HP Jogador: {guerreiro.Vida}");
                            }

                            System.Console.WriteLine();
                            System.Console.WriteLine("Aperte ENTER para prosseguir");
                            Console.ReadLine();

                            Console.Clear();

                            if (guerreiro.Vida <= 0)
                            {
                                System.Console.WriteLine("JOGADOR Murreeeeeu!");
                                System.Console.WriteLine();
                                System.Console.WriteLine("Aperte ENTER para prosseguir");
                                Console.ReadLine();
                                break;
                            }
                            System.Console.WriteLine("------------------------------");
                            System.Console.WriteLine("       Turno do jogador:");
                            System.Console.WriteLine("------------------------------");
                            System.Console.WriteLine("Escolha sua ação");
                            System.Console.WriteLine(" 1 - Atacar");
                            System.Console.WriteLine(" 2 - Fugir");
                            System.Console.Write(" Digite o código da opção:");
                            string opcaoBatalhaJogador = Console.ReadLine();

                            switch (opcaoBatalhaJogador)
                            {
                                case "1":
                                    geradorNumeroAleatorio = new Random();
                                    numeroAleatorioJogador = geradorNumeroAleatorio.Next(0, 5);
                                    numeroAleatorioDragao = geradorNumeroAleatorio.Next(0, 5);
                                    guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                                    dragaoDestrezaTotal = guerreiro.Destreza + numeroAleatorioDragao;
                                    int poderAtaqueGuerreiro = guerreiro.Forca > guerreiro.Inteligencia ? guerreiro.Forca + guerreiro.Destreza : guerreiro.Inteligencia + guerreiro.Destreza;

                                    if (guerreiroDestrezaTotal > dragaoDestrezaTotal)
                                    {
                                        System.Console.WriteLine($"{guerreiro.Nome.ToUpper()}: Toma essa lagarto MALDJEETO!");
                                        dragao.Vida -= poderAtaqueGuerreiro + 5;
                                        System.Console.WriteLine($"HP Dragão: {dragao.Vida}");
                                        System.Console.WriteLine($"HP Jogador: {guerreiro.Vida}");
                                    }
                                    else
                                    {
                                        System.Console.WriteLine($"{dragao.Nome.ToUpper()}: Errrrrou, humanóide tosssssco!");
                                    }
                                    break;
                                case "2":
                                    System.Console.WriteLine($"{guerreiro.Nome.ToUpper()}: Simbora fii! FLW VLW!");
                                    jogadorNaoCorreu = false;
                                    break;
                            }

                            if (dragao.Vida <= 0)
                            {
                                System.Console.WriteLine("DRAGÃO Murreeeeeu!");
                                System.Console.WriteLine();
                                System.Console.WriteLine("Aperte ENTER para prosseguir");
                                Console.ReadLine();
                                break;
                            }

                            System.Console.WriteLine();
                            System.Console.WriteLine("Aperte ENTER para prosseguir");
                            Console.ReadLine();
                        }
                        /** FIM - Turnos Oficiais */

                        break;
                    case "2":
                        bool nomeExiste = true;
                        int pontosDisponiveis = 8;
                        Guerreiro guerreiroBebe = new Guerreiro();

                        while (nomeExiste)
                        {
                            System.Console.WriteLine("Digite o nome do seu guerreiro:");
                            guerreiroBebe.Nome = Console.ReadLine();

                            System.Console.WriteLine("Digite o sobrenome do seu guerreiro:");
                            guerreiroBebe.Sobrenome = Console.ReadLine();

                            nomeExiste = guerreiroRepository.NomeESobrenomeExistem(guerreiroBebe.Nome, guerreiroBebe.Sobrenome);

                            // Caso existir, retorna um erro e volta para o inicio da criação de personagem
                            if (nomeExiste)
                            {
                                System.Console.WriteLine("Este nome e sobrenome de guerreiro já existe, tente novamente com outro.");
                                Console.ReadLine();
                            }
                        }

                        System.Console.WriteLine("Digite a cidade natal do seu guerreiro:");
                        guerreiroBebe.CidadeNatal = Console.ReadLine();

                        System.Console.WriteLine("Digite a data de nascimento do seu guerreiro: (xx/xx/xxxx)");
                        guerreiroBebe.DataDeNascimento = Convert.ToDateTime(Console.ReadLine());

                        System.Console.WriteLine("Digite a ferramenta de proteção do seu guerreiro:");
                        guerreiroBebe.FerramentaProtecao = Console.ReadLine();

                        System.Console.WriteLine("Digite a ferramenta de ataque do seu guerreiro:");
                        guerreiroBebe.FerramentaAtaque = Console.ReadLine();

                        Console.Clear();
                        System.Console.WriteLine("ETAPA 2: Pontue as 3 habilidades de seu guerreiro: Força, Destreza e Inteligência. Máximo de 8 pontos.");
                        Console.ReadLine();

                        /*
                            ------------------------------------------------------------------------------------------------------------------------
                            FORÇA
                            ------------------------------------------------------------------------------------------------------------------------
                        */

                        bool pontosInvalidos = true;
                        while (pontosInvalidos)
                        {
                            Console.Clear();
                            System.Console.WriteLine($"AVISO: Você tem {pontosDisponiveis} pontos disponíveis para usar");
                            System.Console.WriteLine("Pontue a FORÇA do seu guerreiro: (0-8)");
                            guerreiroBebe.Forca = Convert.ToInt32(Console.ReadLine());

                            if (guerreiroBebe.Forca > pontosDisponiveis)
                            {
                                System.Console.WriteLine("Você não tem essa quantidade de pontos disponíveis.");
                                Console.ReadLine();
                                pontosInvalidos = true;
                            }
                            else
                            {
                                pontosInvalidos = false;
                            }
                        }

                        // Substrai pontosDisponiveis da pontuação aplicada
                        pontosDisponiveis -= guerreiroBebe.Forca;

                        // Verifica se pontos atingiram o limite
                        if (pontosDisponiveis <= 0)
                        {
                            System.Console.WriteLine("Limite de pontuação atingida, seu guerreiro será criado e salvo!");
                            guerreiroBebe.Vida = 20;

                            if (!guerreiroRepository.ExportarGuerreiro(guerreiroBebe))
                            {
                                System.Console.WriteLine("Ocorreu um erro no salvamento do guerreiro na base de dados.");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                System.Console.WriteLine("Guerreiro criado e salvo com sucesso!");
                                Console.ReadLine();
                                break;
                            }
                        }

                        /*
                            ------------------------------------------------------------------------------------------------------------------------
                            DESTREZA
                            ------------------------------------------------------------------------------------------------------------------------
                        */

                        pontosInvalidos = true;
                        while (pontosInvalidos)
                        {
                            Console.Clear();
                            System.Console.WriteLine($"AVISO: Você tem {pontosDisponiveis} pontos disponíveis para usar");
                            System.Console.WriteLine("Pontue a DESTREZA do seu guerreiro: (0-8)");
                            guerreiroBebe.Destreza = Convert.ToInt32(Console.ReadLine());

                            if (guerreiroBebe.Destreza > pontosDisponiveis)
                            {
                                System.Console.WriteLine("Você não tem essa quantidade de pontos disponíveis.");
                                Console.ReadLine();
                                pontosInvalidos = true;
                            }
                            else
                            {
                                pontosInvalidos = false;
                            }
                        }

                        // Substrai pontosDisponiveis da pontuação aplicada
                        pontosDisponiveis -= guerreiroBebe.Destreza;

                        // Verifica se pontos atingiram o limite
                        if (pontosDisponiveis <= 0)
                        {
                            System.Console.WriteLine("Limite de pontuação atingida, seu guerreiro será criado e salvo!");
                            guerreiroBebe.Vida = 20;

                            if (!guerreiroRepository.ExportarGuerreiro(guerreiroBebe))
                            {
                                System.Console.WriteLine("Ocorreu um erro no salvamento do guerreiro na base de dados.");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                System.Console.WriteLine("Guerreiro criado e salvo com sucesso!");
                                Console.ReadLine();
                                break;
                            }
                        }

                        /*
                            ------------------------------------------------------------------------------------------------------------------------
                            INTELIGÊNCIA
                            ------------------------------------------------------------------------------------------------------------------------
                        */

                        pontosInvalidos = true;
                        while (pontosInvalidos)
                        {
                            Console.Clear();
                            System.Console.WriteLine($"AVISO: Você tem {pontosDisponiveis} pontos disponíveis para usar");
                            System.Console.WriteLine("Pontue a INTELIGÊNCIA do seu guerreiro: (0-8)");
                            guerreiroBebe.Inteligencia = Convert.ToInt32(Console.ReadLine());

                            if (guerreiroBebe.Inteligencia > pontosDisponiveis)
                            {
                                System.Console.WriteLine("Você não tem essa quantidade de pontos disponíveis.");
                                Console.ReadLine();
                                pontosInvalidos = true;
                            }
                            else
                            {
                                pontosInvalidos = false;
                            }
                        }

                        // Substrai pontosDisponiveis da pontuação aplicada
                        pontosDisponiveis -= guerreiroBebe.Destreza;

                        // Verifica se pontos atingiram o limite
                        if (pontosDisponiveis <= 0)
                        {
                            System.Console.WriteLine("Limite de pontuação atingida, seu guerreiro será criado e salvo!");
                            guerreiroBebe.Vida = 20;

                            if (!guerreiroRepository.ExportarGuerreiro(guerreiroBebe))
                            {
                                System.Console.WriteLine("Ocorreu um erro no salvamento do guerreiro na base de dados.");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                System.Console.WriteLine("Guerreiro criado e salvo com sucesso!");
                                Console.ReadLine();
                                break;
                            }
                        }

                        break;
                    case "3":
                        System.Console.WriteLine("Digite o NOME do guerreiro:");
                        string nomeGuerreiro = Console.ReadLine();

                        System.Console.WriteLine("Digite o SOBRENOME do guerreiro para usa-lo em batalha!");
                        string sobrenomeGuerreiro = Console.ReadLine();

                        Guerreiro g = guerreiroRepository.ImportarGuerreiroPorNome(nomeGuerreiro, sobrenomeGuerreiro);

                        if (g == null){

                            System.Console.WriteLine("Não foi encontrado um guerreiro com este nome :(");
                            Console.ReadLine();
                        }
                        else{
                            System.Console.WriteLine($"Personagem {g.Nome} Carregado!");
                            Console.ReadLine();
                            guerreiro = g;
                        }
                        break;
                    case "0":
                        jogadorNaoDesistiu = false;
                        break;
                    default:
                        System.Console.WriteLine("Comando desconhecido");
                        break;

                }

            } while (jogadorNaoDesistiu);

            System.Console.WriteLine("GAME OVER!");

        }
    }
}