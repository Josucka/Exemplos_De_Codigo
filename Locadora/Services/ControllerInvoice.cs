using Locadora.Dados;
using Locadora.Services.Models;
using System;
using System.Collections.Generic;

namespace Locadora.Services
{
    public class ControllerInvoice
    {
        private InvoiceDados _invoice;

        private static readonly ControllerInvoice instance = new ControllerInvoice();

        static ControllerInvoice()
        {

        }
        public ControllerInvoice()
        {
            _invoice = InvoiceDados.Instance;
        }

        public static ControllerInvoice Instance
        {
            get { return instance; }
        }

        public Boolean Salvar(Invoice invoice)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _invoice.Salvar(invoice);
                return true;
            }
        }

        public Invoice Buscar(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return _invoice.Buscar(id);
            }
        }

        public List<Invoice> Listar()
        {
            return _invoice.Listar();
        }

        public void Remove(Invoice invoice)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _invoice.Remover(invoice);
            }
        }

        public void Editar(Invoice invoice, int nDias, string formPagamento)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _invoice.Editar(invoice, nDias, formPagamento);
            }
        }
    }
}
