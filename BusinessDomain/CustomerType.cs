using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDomain
{
    public class CustomerType
    {
        #region Constructors
        public CustomerType(CustomerTypes type)
        {
            if (type == CustomerTypes.Premium)
            {
                Type = type;
                Price = 150;
                Discount = 2.45;
            }
            else if (type == CustomerTypes.Gold)
            {
                Type = type;
                Price = 350;
                Discount = 6.25;
            }
            else
            {
                Type = CustomerTypes.Basis;
                Price = 0;
                Discount = 0;
            }
        }

        public CustomerType()
        {
            Type = CustomerTypes.Basis;
            Price = 0;
            Discount = 0;
        }
        #endregion

        #region Fields
        private double discount;
        private double price;
        #endregion

        #region Properties
        public CustomerTypes Type { get; set; }
        public double Discount
        {
            get => discount;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Tilbudsprocenten skal være inden for intervallet 1:100");
                }
                discount = value;
            }
        }
        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Prisen kan ikke være i minus");
                }
                price = value;
            }
        } 
        #endregion
    }
}
