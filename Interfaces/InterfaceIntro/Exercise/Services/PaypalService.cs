﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Services
{
    class PaypalService : IOnlinePaymentService
    {
        private const double FeePercentage = 0.02;
        private const double MonthlyInterest = 0.01;

        public double Interest(double amount, int month)
        {
            return amount * MonthlyInterest * month;
        }

        public double PaymentFee(double amount)
        {
            return amount * FeePercentage;
        }
    }
}
