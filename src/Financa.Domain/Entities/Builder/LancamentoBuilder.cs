using Financa.Domain.Dtos.Lancamento;

namespace Financa.Domain.Entities
{

    public partial class Lancamento
    {
        public class LancamentoBuilder
        {
            private Lancamento _lancamento;

            public LancamentoBuilder()
            {
                _lancamento = new Lancamento();
            }

            public Lancamento Build()
            {
                return _lancamento;
            }

            public LancamentoBuilder FromDto(AdicionaDespesaDto despesaDto)
            {
                return this.SetValor(despesaDto.Valor)
                    .SetTitulo(despesaDto.Titulo)
                    .SetDescricao(despesaDto.Descricao)
                    .SetTipoLancamento(TipoLancamento.Despesa);
                    //.SetParcelas(despesaDto.QuantidadeParcelas ?? 1);
            }

            public LancamentoBuilder SetUsuario(Usuario? usuario)
            {
                if(usuario is not null)
                    _lancamento.AdicionaUsuario(usuario);
                return this;
            }

            public LancamentoBuilder SetCategoria(Categoria categoria)
            {
                _lancamento.AdicionaCategoria(categoria);
                return this;
            }
            
            public LancamentoBuilder SetCartao(Cartao? cartao)
            {
                if(cartao is not null)
                    _lancamento.AdicionaCartao(cartao);
                return this;
            }

            public LancamentoBuilder SetValor(decimal valor)
            {
                _lancamento.Valor = valor;
                return this;
            }

            public LancamentoBuilder SetTitulo(string titulo)
            {
                _lancamento.Titulo = titulo;
                return this;
            }
            
            public LancamentoBuilder SetDescricao(string descricao)
            {
                _lancamento.Descricao = descricao;
                return this;
            }
            
            public LancamentoBuilder SetTipoLancamento(TipoLancamento tipoLancamento)
            {
                _lancamento.TipoLancamento = tipoLancamento;
                return this;
            }
            
            public LancamentoBuilder SetParcelas(int quantidadeParcela)
            {
                _lancamento.AdicionaParcelas(quantidadeParcela);
                return this;
            }
        }
    }
}
