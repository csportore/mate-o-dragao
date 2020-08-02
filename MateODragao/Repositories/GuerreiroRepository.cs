using System;
using System.Collections.Generic;
using System.IO;
using MateODragao.Models;
using System.Linq;
using System.Globalization;

namespace MateODragao.Repositories
{
    public class GuerreiroRepository
    {
        private const string Path = "Databases/Guerreiro.csv";

        public GuerreiroRepository()
        {
            if (!File.Exists(Path))
            {
                File.Create(Path).Close();

                string[] primeiraLinha = { "\"" + "Nome" + "\"" + "," + "\"" + "Sobrenome" + "\"" + "," + "\"" + "CidadeNatal" + "\"" + "," + "\"" + "DataDeNascimento" + "\"" + "," + "\"" + "FerramentaProtecao" + "\"" + "," + "\"" + "FerramentaAtaque" + "\"" + "," + "\"" + "Forca" + "\"" + "," + "\"" + "Destreza" + "\"" + "," + "\"" + "Inteligencia" + "\"" + "," + "\"" + "Vida" + "\"" };

                File.AppendAllLines(Path, primeiraLinha);
            }
        }

        public bool ExportarGuerreiro(Guerreiro guerreiro)
        {
            try
            {
                string[] dadosGuerreiro = { PrepararGuerreiro(guerreiro) };

                File.AppendAllLines(Path, dadosGuerreiro);

                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }

        public Guerreiro ImportarGuerreiroPorNome(string nome, string sobrenome)
        {
            try
            {
                List<Guerreiro> guerreiros = ObterTodosGuerreiros();

                // Usando System.Linq para pesquisar dentro da lista de guerreiros, utilizando de expressão Lambda (lambida!)
                // DICA: Melhor e mais fácil que usar forEach :)

                // Explicação: Da lista de "guerreiros", obtêm o guerreiro que tem o nome igual à variavel "nomeGuerreiro"
                Guerreiro guerreiro = guerreiros.FirstOrDefault(x => x.Nome == nome && x.Sobrenome == sobrenome);

                // Com apenas uma linha, não é preciso do "corpo" (chaves)
                if (guerreiro == null)
                    return null;
                else
                    return guerreiro;
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        public bool NomeESobrenomeExistem(string nome, string sobrenome)
        {

            // Utilizando propriedades anonimas (var)
            var guerreiros = ObterTodosGuerreiros();

            // NOTA PARA PROF: Importante ensinar ao menos o básico sobre LINQ pois ao mexer com banco de dados, irá ser utilizado bastante!

            // Explicação: Da lista de "guerreiros", obtêm o guerreiro que contem o nome E sobrenome iguais às variaveis de mesmo nome, que irão vir pelo parâmetro do método atual
            var guerreiro = guerreiros.FirstOrDefault(x => x.Nome == nome && x.Sobrenome == sobrenome);

            if (guerreiro != null)
                // Retorna true caso nome e sobrenome de guerreiro EXISTIR na base de dados
                return true;
            else
                // Retorna false caso NÃO existir
                return false;
        }

        public List<Guerreiro> ObterTodosGuerreiros()
        {
            try
            {
                List<Guerreiro> guerreiros = new List<Guerreiro>();

                string[] guerreirosCSV = File.ReadAllLines(Path);

                // Inicia com 1 para pular primeira linha do .csv
                for (int i = 1; i < guerreirosCSV.Length; i++)
                {
                    Guerreiro guerreiro = new Guerreiro();

                    if (guerreirosCSV.Length > 1)
                    {
                        string[] guerreiroLinha = guerreirosCSV[i].Split(",");

                        guerreiro.Nome = guerreiroLinha[0].Replace("\"", "");
                        guerreiro.Sobrenome = guerreiroLinha[1].Replace("\"", "");
                        guerreiro.CidadeNatal = guerreiroLinha[2].Replace("\"", "");
                        guerreiro.DataDeNascimento = DateTime.Parse(guerreiroLinha[3].Replace("\"", ""));
                        guerreiro.FerramentaProtecao = guerreiroLinha[4].Replace("\"", "");
                        guerreiro.FerramentaAtaque = guerreiroLinha[5].Replace("\"", "");
                        guerreiro.Forca = Convert.ToInt32(guerreiroLinha[6].Replace("\"", ""));
                        guerreiro.Destreza = Convert.ToInt32(guerreiroLinha[7].Replace("\"", ""));
                        guerreiro.Inteligencia = Convert.ToInt32(guerreiroLinha[8].Replace("\"", ""));
                        guerreiro.Vida = Convert.ToInt32(guerreiroLinha[9].Replace("\"", ""));

                        guerreiros.Add(guerreiro);
                    }
                }

                return guerreiros;
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        public Guerreiro CriarPersonagemPadrao()
        {
            /* INICIO - Criando os personagens (objetos) */
            Guerreiro guerreiro = new Guerreiro();
            guerreiro.Nome = "Asdrúbal";
            guerreiro.Sobrenome = "Silvius";
            guerreiro.CidadeNatal = "Brasilidis";
            guerreiro.DataDeNascimento = DateTime.Parse("01/01/1450");
            guerreiro.FerramentaAtaque = "Espada";
            guerreiro.FerramentaProtecao = "Armadura de ferro";
            guerreiro.Forca = 3;
            guerreiro.Destreza = 3;
            guerreiro.Inteligencia = 2;
            guerreiro.Vida = 20;
            /* FIM - Criando os personagens (objetos) */

            return guerreiro;
        }

        private string PrepararGuerreiro(Guerreiro guerreiro)
        {
            return "\"" + $"{guerreiro.Nome}" + "\"" + "," + "\"" + $"{guerreiro.Sobrenome}" + "\"" + "," + "\"" + $"{guerreiro.CidadeNatal}" + "\"" + "," + "\"" + $"{guerreiro.DataDeNascimento}" + "\"" + "," + "\"" + $"{guerreiro.FerramentaProtecao}" + "\"" + "," + "\"" + $"{guerreiro.FerramentaAtaque}" + "\"" + "," + "\"" + $"{guerreiro.Forca}" + "\"" + "," + "\"" + $"{guerreiro.Destreza}" + "\"" + "," + "\"" + $"{guerreiro.Inteligencia}" + "\"" + "," + "\"" + $"{guerreiro.Vida}" + "\"";
        }
    }
}