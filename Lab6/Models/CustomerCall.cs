﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class CustomerCall
    {
        public int Call_Id { get; set; }
        public int Customer_Id { get; set; }
        public int CallCenter_Id { get; set; }
        public int CallOutcomeCode { get; set; }
        public int CallStatusCode { get; set; }
        public int RecommendedSolution_Id { get; set; }
        public int Staff_Id { get; set; }
        public DateTime CallDateTime { get; set; }
        public string CallDescription { get; set; }
        public string TailoredSolutionDescription { get; set; }
        public string CallOtherDetails { get; set; }

        public Customer Customer { get; set; }
        public CallCenter CallCenter { get; set; }
        public RefCallOutcome RefCallOutcome { get; set; }
        public RefCallStatusCode RefCallStatusCode { get; set; }
        public Staff Staff { get; set; }
        public CommonSolution CommonSolution { get; set; }
    }
}
