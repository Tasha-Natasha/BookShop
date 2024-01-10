﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class OrderPayment // паттерн value object объект значение не может изменяться после создания и нет своего идентификатора  
    {
        public string UniqueCode { get; }

        public string Description { get; }

        public decimal Amount { get; }

        public IReadOnlyDictionary<string, string> Parameters { get; }

        public OrderPayment(string uniqueCode, string description,
            IReadOnlyDictionary<string, string> parameters)
        {
            if (string.IsNullOrWhiteSpace(uniqueCode))
            {
                throw new ArgumentException(nameof(uniqueCode));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException(nameof(description));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }
            
            UniqueCode = uniqueCode;
            Description = description;
            Parameters = parameters;



        }

    }
}
