using Locadora.Services.Models;
using System;
using System.Collections.Generic;

namespace Locadora.Dados
{
    public class InvoiceDados

    {
        public List<Invoice> invoice;

        private static readonly InvoiceDados _instanceInvoice = new InvoiceDados();

        static InvoiceDados()
        {

        }

        public static InvoiceDados Instance
        {
            get { return _instanceInvoice; }
        }

        public InvoiceDados()
        {
            invoice = new List<Invoice>();
        }

        //Methodo salvar
        public Boolean Salvar(Invoice invoicer)
        {
            if (!invoice.Contains(invoicer))
            {
                invoice.Add(invoicer);
                return true;
            }
            return false;
        }

        //Methodo buscar
        public Invoice Buscar(int id)
        {
            foreach (Invoice invoicer in invoice)
            {
                if (invoicer.Id == id)
                    return invoicer;
            }
            return null;
        }

        //Methodo listar
        public List<Invoice> Listar()
        {
            return invoice;
        }

        //Methodo remover
        public void Remover(Invoice invoicer)
        {
            foreach (Invoice inv in invoice)
            {
                if (inv.Id == invoicer.Id)
                {
                    invoice.Remove(inv);
                }
            }
        }

        //Methodo editar
        public void Editar(Invoice invoicer, int nDias, string formPagamento)
        {
            foreach (Invoice inv in invoice)
            {
                if (inv.Id == invoicer.Id)
                {
                    inv.NumeroDias = nDias;
                    inv.FormaPagamento = formPagamento;
                    if (inv.Client.Premium)
                    {
                        inv.ValorFinal = (nDias * inv.Filme.Preco - (inv.Filme.Preco * 0.2));
                    }
                    else
                    {
                        inv.ValorFinal = (nDias * inv.Filme.Preco);
                    }
                }
            }
        }
    }
}
