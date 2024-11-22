﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Contract
    {
        public int Contract_Id { get; set; }
        public int Customer_Id { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string OtherDetails { get; set; }
        public Customer Customer { get; set; }
    }
}
