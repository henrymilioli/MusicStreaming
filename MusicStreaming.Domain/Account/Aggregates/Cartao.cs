﻿using MusicStreaming.Domain.Account.Exception;
using MusicStreaming.Domain.Billing.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.Domain.Account.Aggregates
{
    public class Cartao
    {

        private const int TRANSACTION_TIME_INTERVAL = -2;
        private const int TRANSACTION_MERCHANT_REPEAT = 1;
       

        public Guid Id { get; set; }
        public Boolean Ativo { get; set; }
        public Decimal Limite { get; set; }
        public String Numero { get; set; }
        public List<Billing.Aggregates.Transacao> Transacoes { get; set; }

        public Cartao()
        {
            this.Transacoes = new List<Billing.Aggregates.Transacao>();
        }

        public void CriarTransacao(string merchant, Decimal valor, string descricao)
        {
            CartaoException validationErrors = new CartaoException();

            //Verificar se o cartao está ativo
            this.IsCartaoAtivo(validationErrors);

            Billing.Aggregates.Transacao transacao = new Billing.Aggregates.Transacao();
            transacao.Merchant = new Billing.ValueObject.Merchant() {  Nome = merchant } ;
            transacao.Valor = valor ;
            transacao.Descricao = descricao ;
            transacao.DtTransacao = DateTime.Now;

            //Verificar o Limite
            this.VerificaLimiteDisponivel(transacao, validationErrors);
            
            //Validar a transação
            this.ValidarTransacao(transacao, validationErrors);

            //Verifica senão ocorreu erros de validação
            validationErrors.ValidateAndThrow();

            //Criar numero de Autorização
            transacao.Id = Guid.NewGuid();

            //Diminui o limite com o valor da transação
            this.Limite = this.Limite - transacao.Valor;

            //Adicionar uma nova transação
            this.Transacoes.Add(transacao);

            
        }

        private void IsCartaoAtivo(CartaoException validationErrors)
        {
            if (this.Ativo == false)
            {
                validationErrors.AddError(new Core.Exception.BusinessValidation()
                {
                    ErrorMessage = "Cartão não está ativo",
                    ErrorName = nameof(CartaoException)
                });

            }

        }

        private void VerificaLimiteDisponivel(Billing.Aggregates.Transacao transacao, CartaoException validationErrors)
        {
            if (transacao.Valor > this.Limite)
            {
                validationErrors.AddError(new Core.Exception.BusinessValidation() { ErrorMessage = "Cartão não possui limite para esta transação",
                                                                                    ErrorName = nameof(CartaoException) });
            }
        }

        private void ValidarTransacao(Billing.Aggregates.Transacao transacao, CartaoException validationErrors)
        {
            var ultimasTransacoes = this.Transacoes.Where(x => x.DtTransacao >= DateTime.Now.AddMinutes(TRANSACTION_TIME_INTERVAL));

            if (ultimasTransacoes?.Count() >= 3)
            {
                validationErrors.AddError(new Core.Exception.BusinessValidation()
                {
                    ErrorMessage = "Cartão utilizado muitas vezes em um período curto",
                    ErrorName = nameof(CartaoException)
                });
            }

            if (ultimasTransacoes?.Where(x => x.Merchant.Nome.ToUpper() == transacao.Merchant.Nome.ToUpper() 
                                         &&   x.Valor == transacao.Valor).Count() == TRANSACTION_MERCHANT_REPEAT)
            {
                validationErrors.AddError(new Core.Exception.BusinessValidation()
                {
                    ErrorMessage = "Transação duplicada para o mesmo cartão e mesmo merchant",
                    ErrorName = nameof(CartaoException)
                });
            }
        }
    }
}
