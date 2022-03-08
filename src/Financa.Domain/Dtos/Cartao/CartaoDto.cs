using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Financa.Domain.Dtos.Cartao
{
    public record AdicionaCartaoDto
    {
        public string Titulo { get; set; }
        public decimal Limite { get; set; }
        public int DiaVencimento { get; set; }
        public int DiaFechamento { get; set; }
    }


    public record ListaCartaoDto : AdicionaCartaoDto
    {
        [JsonPropertyOrder(1)]
        public Guid Id { get; set; }
    }

    public record DetalhaCartaoDto : ListaCartaoDto
    {
        public DateTime DataCadastro { get; protected set; }
        public DateTime? DataAtualizacao { get; protected set; }
    }
}
