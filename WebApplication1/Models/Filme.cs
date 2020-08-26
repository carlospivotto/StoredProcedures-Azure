using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Filme
    {
        public int FilmeId { get; set; }
        public string Titulo { get; set; }
        public string TituloOriginal { get; set; }
        public int AnoLancamento { get; set; }
        public string ClassificacaoEtaria { get; set; }
        public int Duracao { get; set; }
    }
}
