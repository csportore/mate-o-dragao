using System;
using System.Collections.Generic;
using MateODragao.Enums;
using MateODragao.Models;

namespace MateODragao {
    class Program {
        static void Main (string[] args) {

            bool jogadorNaoDesistiu = true;

            do {
                /* INICIO - Menu Principal */
                // Temos que trocar para int aqui porque agora o código não é mais digitado pelo usuário, mas sim decidido
                // por nós no método
                int opcaoJogador = MontarMenuPrincipal ();

                /* FIM - Menu Principal */
                switch (opcaoJogador) {
                    case 1:
                        Console.Clear ();

                        /* INICIO - Criando os personagens (objetos) */
                        Guerreiro guerreiro = CriarGuerreiro ();
                        Dragao dragao = CriarDragao ();
                        /* FIM - Criando os personagens (objetos) */

                        /* INICIO - Primeiro Diálogo */
                        /**
                         * ! Mostrar aos alunos como uma alteração no jeito de imprimir os diálogos seria muito penosa do jeito anterior pois teria que ser repetida 
                         * ! manualmente, já com o método, basta fazer a alteração nele.
                         */
                        CriarDialogo (guerreiro.Nome, $"{dragao.Nome}, seu louco! Vim-lhe derrotar-lhe!");
                        CriarDialogo (dragao.Nome, "Humano tolinho. Quem pensas que és?");

                        FinalizarDialogo ();
                        /* FIM - Primeiro Diálogo */

                        /* INICIO - Segundo Diálogo */
                        CriarDialogo (guerreiro.Nome, $"Eu sou {guerreiro.Nome}! Da casa {guerreiro.Sobrenome}, ó criatura morfética!");
                        CriarDialogo (guerreiro.Nome, $"Vim de {guerreiro.CidadeNatal} para derrotar-te e mostrar meu valor!");
                        CriarDialogo (dragao.Nome, $"QUEM? DE ONDE? Bom, que seja...fritar-te-ei e devorar-te-ei, primata insolente!");

                        FinalizarDialogo ();
                        /* FIM - Segundo Diálogo */

                        bool jogadorAtacaPrimeiro = guerreiro.Destreza > dragao.Destreza ? true : false;
                        bool jogadorNaoCorreu = true;

                        #region Quando o jogador ataca primeiro
                        if (jogadorAtacaPrimeiro) {

                            GerarMenuTurnos (guerreiro.Nome);
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
                                        CriarDialogo (guerreiro.Nome, $"Toma essa lagarto MALDJEETO! BIRLLLL!");
                                        dragao.Vida -= poderAtaqueGuerreiro + 5;
                                        System.Console.WriteLine ($"HP Dragão: {dragao.Vida}");
                                        System.Console.WriteLine ($"HP Jogador: {guerreiro.Vida}");
                                    } else {
                                        CriarDialogo (dragao.Nome.ToUpper(), $"Errrrrou, humanóide tosco!");
                                        System.Console.WriteLine ($"HP Dragão: {dragao.Vida}");
                                        System.Console.WriteLine ($"HP Jogador: {guerreiro.Vida}");
                                    }
                                    break;
                                case "2":
                                    CriarDialogo (guerreiro.Nome, $"Simbora fii! FLW VLW!");
                                    jogadorNaoCorreu = false;
                                    break;
                            }
                            System.Console.WriteLine ();
                            System.Console.WriteLine ("Aperte ENTER para prosseguir");
                            Console.ReadLine ();
                        }
                        #endregion

                        /** INICIO - Turnos Oficiais */
                        while (dragao.Vida > 0 && guerreiro.Vida > 0 && jogadorNaoCorreu) {

                            GerarMenuTurnos (dragao.Nome);

                            Random geradorNumeroAleatorio = new Random ();
                            int numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
                            int numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
                            int guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                            int dragaoDestrezaTotal = guerreiro.Destreza + numeroAleatorioDragao;

                            if (guerreiroDestrezaTotal < dragaoDestrezaTotal) {
                                CriarDialogo (dragao.Nome, $"HA! Estúpido ser!");
                                guerreiro.Vida -= dragao.Forca;
                                MostrarHP (guerreiro.Vida, dragao.Vida);

                            } else {
                                CriarDialogo (guerreiro.Nome, $"Eita lasquera que essa passou perto!");
                                MostrarHP (guerreiro.Vida, dragao.Vida);
                            }

                            FinalizarDialogo ();

                            if (guerreiro.Vida <= 0) {
                                System.Console.WriteLine ("JOGADOR Murreeeeeu!");
                                System.Console.WriteLine ();
                                System.Console.WriteLine ("Aperte ENTER para prosseguir");
                                Console.ReadLine ();
                                break;
                            }

                            GerarMenuTurnos (guerreiro.Nome);

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
                                        CriarDialogo (guerreiro.Nome, $"Toma essa lagarto MALDJEETO!");
                                        dragao.Vida -= poderAtaqueGuerreiro + 5;

                                    } else {
                                        CriarDialogo (dragao.Nome, $"Errrrrou, humanóide tosssssco!");
                                    }
                                    break;
                                case "2":
                                    CriarDialogo (guerreiro.Nome, $"Simbora fii! FLW VLW!");
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
                    // Opção adicionada para deixar o menu gamer mais interessante
                    case 2:
                        System.Console.WriteLine("Esse joguinho vai ficar massa!");
                        System.Console.WriteLine ();
                        System.Console.WriteLine ("Aperte ENTER para voltar");
                        Console.ReadLine ();
                        break;
                    case 3:
                        jogadorNaoDesistiu = false;
                        break;
                    default:
                        System.Console.WriteLine ("Comando desconhecido");
                        break;
                }
            } while (jogadorNaoDesistiu);
            System.Console.WriteLine ("GAME OVER!");
        }

        #region Criação de Personagens
        /*
        =========================================================
                                PERSONAGENS
        =========================================================
        */
        private static Guerreiro CriarGuerreiro () {
            Guerreiro guerreiro = null;

            bool terminouDeMontar = false;
            do {
                System.Console.WriteLine ("Deseja começar com um personagem pronto? Responda com S ou N.");
                string respostaUsuario = Console.ReadLine ();

                switch (respostaUsuario.ToUpper ()) {
                    case "S":
                        guerreiro = new Guerreiro ("Asdrúbal", "Silvius", "Brasilidis", DateTime.Parse ("01/01/1450"), "Espada", "Armadura de ferro", 2, 1, 1, 1, 2);
                        terminouDeMontar = true;
                        break;
                    case "N":

                        System.Console.Write ("Digite o nome do personagem: ");
                        string nome = Console.ReadLine ();

                        System.Console.Write ("Digite o sobrenome do personagem: ");
                        string sobrenome = Console.ReadLine ();

                        System.Console.Write ("Escolha o gênero do personagem: ");

                        string genero = Console.ReadLine ();

                        System.Console.Write ("Digite a cidade natal do personagem: ");
                        string cidadeNatal = Console.ReadLine ();

                        System.Console.Write ("Digite a data de nascimento do personagem: ");
                        DateTime dataNascimento = DateTime.Parse (Console.ReadLine ());

                        System.Console.Write ("Digite a ferramenta de ataque do personagem: ");
                        string ferramentaAtaque = Console.ReadLine ();

                        System.Console.Write ("Digite a ferramenta de proteção do personagem: ");
                        string ferramentaProtecao = Console.ReadLine ();

                        int pontosIniciais = 7;

                        string[] listaNomesAtributos = { "Força", "Destreza", "Agilidade", "Inteligência", "Vigor" };
                        int[] listaValoresAtributos = { 1, 1, 1, 1, 1 };

                        while (pontosIniciais != 0) {
                            Console.Clear ();
                            System.Console.WriteLine ($"Você possui {pontosIniciais} pontos a serem distribuídos");
                            System.Console.WriteLine ("Seu status atual:");
                            for (int i = 0; i < listaNomesAtributos.Length; i++) {
                                System.Console.WriteLine ($"{listaNomesAtributos[i]}: {listaValoresAtributos[i]}");
                            }

                            System.Console.WriteLine ();

                            for (int i = 0; i < listaNomesAtributos.Length; i++) {
                                if (pontosIniciais > 0) {
                                    System.Console.WriteLine ($"Digite a {listaNomesAtributos[i]} do personagem: ");
                                    int valor = int.Parse (Console.ReadLine ());

                                    /* Se o atributo da vez for maior ou igual a 5, não podemos mais aumentá-lo, então mandamos o loop prosseguir */
                                    if (listaValoresAtributos[i] >= 5) {
                                        MostrarMensagem ("Atributo já possui pelo menos 5 pontos. Passando para o próximo", TipoMensagemEnum.ALERTA);
                                        continue;
                                    }

                                    /* Se o atributo da vez for maior ou igual a 5, não podemos mais aumentá-lo, então mandamos o loop prosseguir */
                                    if (pontosIniciais >= valor && (valor + listaValoresAtributos[i]) <= 5) {
                                        listaValoresAtributos[i] += valor;
                                        pontosIniciais -= valor;
                                        System.Console.WriteLine ($"Sobraram {pontosIniciais} pontos");
                                    } else {
                                        MostrarMensagem ("Você não possui tantos pontos assim. Tente novamente.", TipoMensagemEnum.ALERTA);
                                    }
                                } else {
                                    MostrarMensagem ("Pontos já distribuídos", TipoMensagemEnum.SUCESSO);
                                    break;
                                }
                            }
                        }
                        guerreiro = new Guerreiro (nome, sobrenome, cidadeNatal, dataNascimento, ferramentaAtaque, ferramentaProtecao, listaValoresAtributos);
                        terminouDeMontar = true;
                        break;
                    default:
                        System.Console.WriteLine ("Comando inexistente. Aperte ENTER e tente novamente.");
                        Console.ReadLine ();

                        break;
                }
            } while (!terminouDeMontar);

            Console.Clear();
            
            return guerreiro;

        }

        /*
            Abrindo a possibilidade de criar mais dragões!
        */
        public static Dragao CriarDragao () {
            Dragao dragao = new Dragao ("Dragonildo", 5, 3, 2, 3, 5);
            return dragao;
        }
        #endregion
        #region Criação de Menus
        /*
        =========================================================
                                MENUS

        Caso tenhamos que alterar algum aspecto desses menus,
        Esse tipo de abordagem nos pouparia trabalho extra e 
        ainda manteria a consistência no visual deles
        =========================================================
        */
        private static int MontarMenuPrincipal () {
            /* MONTAGEM

                Nesta fase o alinhamento será manual
                Devemos deixar claro os seguintes aspectos dessa abordagem
                Vantagem: é muito simples e funciona
                Desvantagem: o texto pode transbordar
            */
            bool jogadorEscolheu = false;
            int opcaoSelecionada = 1;

            do {
                Console.Clear ();

                System.Console.WriteLine ("===========================");
                System.Console.WriteLine ("       Mate o Dragão!");
                System.Console.WriteLine ("===========================");

                if (opcaoSelecionada == 1) {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine ("  Iniciar jogo  ");
                    Console.ResetColor ();
                } else {
                    System.Console.WriteLine ("  Iniciar jogo  ");
                }

                if (opcaoSelecionada == 2) {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine ("  Sobre o jogo  ");
                    Console.ResetColor ();
                } else {
                    System.Console.WriteLine ("  Sobre o jogo  ");
                }

                if (opcaoSelecionada == 3) {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine ("  Sair do jogo  ");
                    Console.ResetColor ();
                } else {
                    System.Console.WriteLine ("  Sair do jogo  ");
                }

                var key = Console.ReadKey (true).Key;

                // Exemplo de operador ternário
                switch (key) {
                    case ConsoleKey.UpArrow:
                    // Exemplo de porque usar o decremento/incremento antes
                    // Faça um teste com ele depois da variável também!
                        opcaoSelecionada = opcaoSelecionada == 1 ? opcaoSelecionada = 1 : --opcaoSelecionada;
                        break;
                    case ConsoleKey.DownArrow:
                        opcaoSelecionada = opcaoSelecionada == 3 ? opcaoSelecionada = 3 : ++opcaoSelecionada;
                        break;
                    case ConsoleKey.Enter:
                        jogadorEscolheu = true;
                        break;
                }

            } while (!jogadorEscolheu);

            return opcaoSelecionada;
        }

        public static void GerarMenuTurnos (string quemEstaAgindo) {
            Console.Clear ();
            System.Console.WriteLine ("------------------------------");
            System.Console.WriteLine ($"       Turno de {quemEstaAgindo}:");
            System.Console.WriteLine ("------------------------------");
        }

        public static void MostrarHP (int guerreiroHP, int dragaoHP) {
            System.Console.WriteLine ($"HP Dragão: {dragaoHP}");
            System.Console.WriteLine ($"HP Jogador: {guerreiroHP}");
        }

        #endregion
        #region Criação de Diálogos
        /*
        =========================================================
                                DIÁLOGOS

        Caso tenhamos que alterar algum aspecto desses diálogos,
        Esse tipo de abordagem nos pouparia trabalho extra e 
        ainda manteria a consistência no visual deles
        =========================================================
        */

        public static void CriarDialogo (string emissor, string frase) {
            System.Console.WriteLine ($"{emissor.ToUpper()}: {frase}");
        }

        public static void FinalizarDialogo () {
            System.Console.WriteLine ();
            System.Console.WriteLine ("Aperte ENTER para prosseguir");
            Console.ReadLine ();
            Console.Clear ();
        }

        public static void MostrarMensagem (string mensagem, TipoMensagemEnum tipoMensagem) {

            switch (tipoMensagem) {
                case TipoMensagemEnum.ERRO:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case TipoMensagemEnum.SUCESSO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case TipoMensagemEnum.ALERTA:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case TipoMensagemEnum.MENSAGEM:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    break;
            }

            System.Console.WriteLine (mensagem);
            Console.ResetColor ();

            System.Console.WriteLine ("\nAperte ENTER para voltar ao menu principal");
            Console.ReadLine ();
        }
    #endregion
    }
    
}