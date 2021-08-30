using Exercise.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Services
{
    class ContractService
    {
        private IOnlinePaymentService _onlinePayment;

        public ContractService(IOnlinePaymentService onlinePayment)
        {
            _onlinePayment = onlinePayment;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;

            for (int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updateQuota = basicQuota + _onlinePayment.Interest(basicQuota,i);
                double fullQuota = updateQuota + _onlinePayment.PaymentFee(updateQuota);
                contract.AddInstallments(new Installment(date, fullQuota));
            }
        }
    }
}
