using System;

namespace MateODragao.Models
{
    public class Guerreiro
    {
        public string Nome {get;set;}
        public string Sobrenome{get;set;}
        public string CidadeNatal{get;set;}
        public DateTime DataDeNascimento{get;set;}
        public string FerramentaProtecao {get;set;}
        public string FerramentaAtaque {get;set;}
        public int Forca {get;set;}
        public int Destreza {get;set;}
        public int Inteligencia {get;set;}
        public int Vida {get;set;}

    }
}