using LojaVirtual.Dominio.ObjetoDeValor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }

        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

        /// <summary>
        /// Pedido deve ter pelo menos um item de pedido ou muitos itens de pedido
        /// </summary>
        public ICollection<ItemPedido> ItensPedido { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (ItensPedido.Any())
                AdicionarCritica("Pedido não pode ficar sem item");
            if (string.IsNullOrEmpty(Cep))
                AdicionarCritica("Cep deve estar preenchido");
            if (FormaPagamentoId == 0)
                AdicionarCritica("Não foi informada a forma de pagamento");

        }
    }
}
