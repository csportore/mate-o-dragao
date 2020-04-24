using System;
using MateODragao.Models;

namespace MateODragao {
    class Program {
        static void Main (string[] args) {

            bool jogadorNaoDesistiu = true;

            do {
                /* INICIO - Menu Principal */
                Console.Clear ();
                System.Console.WriteLine ("===========================");
                System.Console.WriteLine ("       Mate o Dragão!");
                System.Console.WriteLine ("===========================");

                System.Console.WriteLine (" 1 - Iniciar jogo");
                System.Console.WriteLine (" 0 - Sair do jogo");
                System.Console.Write (" Digite o código da opção:");
                string opcaoJogador = Console.ReadLine ();

                /* FIM - Menu Principal */
                switch (opcaoJogador) {
                    case "1":
                        Console.Clear ();

                        /* INICIO - Criando os personagens (objetos) */
                        Guerreiro guerreiro = new Guerreiro ();
                        guerreiro.Nome = "Asdrúbal";
                        guerreiro.Sobrenome = "Silvius";
                        guerreiro.CidadeNatal = "Brasilidis";
                        guerreiro.DataDeNascimento = DateTime.Parse ("01/01/1450");
                        guerreiro.FerramentaAtaque = "Espada";
                        guerreiro.FerramentaProtecao = "Armadura de ferro";
                        guerreiro.Forca = 3;
                        guerreiro.Destreza = 3;
                        guerreiro.Inteligencia = 2;
                        guerreiro.Vida = 20;

                        Dragao dragao = new Dragao ();
                        dragao.Nome = "Dragonildo";
                        dragao.Forca = 5;
                        dragao.Destreza = 1;
                        dragao.Inteligencia = 3;
                        dragao.Vida = 300;
                        /* FIM - Criando os personagens (objetos) */

                        /* INICIO - Primeiro Diálogo */
                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: {dragao.Nome}, seu louco! Vim-lhe derrotar-lhe!");
                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Humano tolinho. Quem pensas que és?");

                        System.Console.WriteLine ();
                        System.Console.WriteLine ("Aperte ENTER para prosseguir");
                        Console.ReadLine ();
                        Console.Clear ();
                        /* FIM - Primeiro Diálogo */

                        /* INICIO - Segundo Diálogo */
                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Eu sou {guerreiro.Nome}! Da casa {guerreiro.Sobrenome}, ó criatura morfética!");
                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Vim de {guerreiro.CidadeNatal} para derrotar-te e mostrar meu valor!");
                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: QUEM? DE ONDE? Bom, que seja...fritar-te-ei e devorar-te-ei, primata insolente!");

                        System.Console.WriteLine ();
                        System.Console.WriteLine ("Aperte ENTER para prosseguir");
                        Console.ReadLine ();
                        Console.Clear ();
                        /* FIM - Segundo Diálogo */

                        bool jogadorAtacaPrimeiro = guerreiro.Destreza > dragao.Destreza ? true : false;
                        bool jogadorNaoCorreu = true;

                        /** INICIO - Quando o jogador ataca primeiro */
                        if (jogadorAtacaPrimeiro) {
                            Console.Clear ();

                            System.Console.WriteLine ("------------------------------");
                            System.Console.WriteLine ("        Turno do jogador:");
                            System.Console.WriteLine ("------------------------------");
                            System.Console.WriteLine ("Escolha sua ação");
                            System.Console.WriteLine (" 1 - Atacar");
                            System.Console.WriteLine (" 2 - Fugir");
                            System.Console.Write (" Digite o código da opção:");
                            string opcaoBatalhaJogador = Console.ReadLine ();

                            switch (opcaoBatalhaJogador) {
                                case "1":
                                    Random geradorNumeroAleatorio = new Random ();
                                    int numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
                                    int numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
                                    int guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                                    int dragaoDestrezaTotal = guerreiro.Destreza + numeroAleatorioDragao;
                                    int poderAtaqueGuerreiro = guerreiro.Forca > guerreiro.Inteligencia ? guerreiro.Forca + guerreiro.Destreza : guerreiro.Inteligencia + guerreiro.Destreza;

                                    if (guerreiroDestrezaTotal > dragaoDestrezaTotal) {
                                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Toma essa lagarto MALDJEETO! BIRLLLL!");
                                        dragao.Vida -= poderAtaqueGuerreiro + 5;
                                        System.Console.WriteLine ($"HP Dragão: {dragao.Vida}");
                                        System.Console.WriteLine ($"HP Jogador: {guerreiro.Vida}");
                                    } else {
                                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Errrrrou, humanóide tosco!");
                                        System.Console.WriteLine ($"HP Dragão: {dragao.Vida}");
                                        System.Console.WriteLine ($"HP Jogador: {guerreiro.Vida}");
                                    }
                                    break;
                                case "2":
                                    System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Simbora fii! FLW VLW!");
                                    jogadorNaoCorreu = false;
                                    break;
                            }
                            System.Console.WriteLine ();
                            System.Console.WriteLine ("Aperte ENTER para prosseguir");
                            Console.ReadLine ();
                        }

                        /** FIM - Quando o jogador ataca primeiro */

                        /** INICIO - Turnos Oficiais */
                        while (dragao.Vida > 0 && guerreiro.Vida > 0 && jogadorNaoCorreu) {

                            Console.Clear ();
                            System.Console.WriteLine ("------------------------------");
                            System.Console.WriteLine ("       Turno do dragão:");
                            System.Console.WriteLine ("------------------------------");
                            Random geradorNumeroAleatorio = new Random ();
                            int numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
                            int numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
                            int guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                            int dragaoDestrezaTotal = guerreiro.Destreza + numeroAleatorioDragao;

                            if (guerreiroDestrezaTotal < dragaoDestrezaTotal) {
                                System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: HA! Estúpido ser!");
                                guerreiro.Vida -= dragao.Forca;
                                System.Console.WriteLine ($"HP Dragão: {dragao.Vida}");
                                System.Console.WriteLine ($"HP Jogador: {guerreiro.Vida}");
                            } else {
                                System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Eita lasquera que essa passou perto!");
                                System.Console.WriteLine ($"HP Dragão: {dragao.Vida}");
                                System.Console.WriteLine ($"HP Jogador: {guerreiro.Vida}");
                            }

                            System.Console.WriteLine ();
                            System.Console.WriteLine ("Aperte ENTER para prosseguir");
                            Console.ReadLine ();

                            Console.Clear ();

                            if (guerreiro.Vida <= 0) {
                                System.Console.WriteLine ("JOGADOR Murreeeeeu!");
                                System.Console.WriteLine ();
                                System.Console.WriteLine ("Aperte ENTER para prosseguir");
                                Console.ReadLine ();
                                break;
                            }
                            System.Console.WriteLine ("------------------------------");
                            System.Console.WriteLine ("       Turno do jogador:");
                            System.Console.WriteLine ("------------------------------");
                            System.Console.WriteLine ("Escolha sua ação");
                            System.Console.WriteLine (" 1 - Atacar");
                            System.Console.WriteLine (" 2 - Fugir");
                            System.Console.Write (" Digite o código da opção:");
                            string opcaoBatalhaJogador = Console.ReadLine ();

                            switch (opcaoBatalhaJogador) {
                                case "1":
                                    geradorNumeroAleatorio = new Random ();
                                    numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
                                    numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
                                    guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                                    dragaoDestrezaTotal = guerreiro.Destreza + numeroAleatorioDragao;
                                    int poderAtaqueGuerreiro = guerreiro.Forca > guerreiro.Inteligencia ? guerreiro.Forca + guerreiro.Destreza : guerreiro.Inteligencia + guerreiro.Destreza;

                                    if (guerreiroDestrezaTotal > dragaoDestrezaTotal) {
                                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Toma essa lagarto MALDJEETO!");
                                        dragao.Vida -= poderAtaqueGuerreiro + 5;
                                        System.Console.WriteLine ($"HP Dragão: {dragao.Vida}");
                                        System.Console.WriteLine ($"HP Jogador: {guerreiro.Vida}");
                                    } else {
                                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Errrrrou, humanóide tosssssco!");
                                    }
                                    break;
                                case "2":
                                    System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Simbora fii! FLW VLW!");
                                    jogadorNaoCorreu = false;
                                    break;
                            }

                            if (dragao.Vida <= 0) {
                                System.Console.WriteLine ("DRAGÃO Murreeeeeu!");
                                System.Console.WriteLine ();
                                System.Console.WriteLine ("Aperte ENTER para prosseguir");
                                Console.ReadLine ();
                                break;
                            }

                            System.Console.WriteLine ();
                            System.Console.WriteLine ("Aperte ENTER para prosseguir");
                            Console.ReadLine ();
                        }
                        /** FIM - Turnos Oficiais */

                        break;
                    case "0":
                        jogadorNaoDesistiu = false;
                        break;
                    default:
                        System.Console.WriteLine ("Comando desconhecido");
                        break;

                }

            } while (jogadorNaoDesistiu);

            System.Console.WriteLine ("GAME OVER!");

        }
    }
}