using System;

namespace MateODragao.Models {
    public class Guerreiro {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string CidadeNatal { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string FerramentaProtecao { get; set; }
        public string FerramentaAtaque { get; set; }
        /**
         * TODO: Deixar os atributos privados! 
         */
        public int Forca { get; set; }
        public int Destreza { get; set; }
        public int Agilidade { get; set; }
        public int Inteligencia { get; set; }
        public int Vigor { get; set; }
        public int Vida { get; set; }

        
        /* Construtor completo */
        public Guerreiro (string nome, string sobrenome, string cidadeNatal, DateTime dataNascimento, string ferramentaAtaque, string ferramentaProtecao, int forca, int destreza, int agilidade, int inteligencia, int vigor) {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.CidadeNatal = cidadeNatal;
            this.DataNascimento = dataNascimento;
            this.FerramentaAtaque = ferramentaAtaque;
            this.FerramentaProtecao = ferramentaProtecao;
            this.Forca = 1 + forca;
            this.Destreza = 1 + destreza;
            this.Agilidade = 1 +  agilidade;
            this.Inteligencia = 1 + inteligencia;
            this.Vigor = 1 +  vigor;
            this.Vida = this.Vigor * 10;
        }

        /* Construtor otimizado */
        public Guerreiro (string nome, string sobrenome, string cidadeNatal, DateTime dataNascimento, string ferramentaAtaque, string ferramentaProtecao, int[] atributos) {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.CidadeNatal = cidadeNatal;
            this.DataNascimento = dataNascimento;
            this.FerramentaAtaque = ferramentaAtaque;
            this.FerramentaProtecao = ferramentaProtecao;
            this.Forca = 1 + atributos[0];
            this.Destreza = 1 + atributos[1];
            this.Agilidade = 1 +  atributos[2];
            this.Inteligencia = 1 + atributos[3];
            this.Vigor = 1 +  atributos[4];
            this.Vida = this.Vigor * 10;
        }

    }
}