﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class RefCallOutcome
    {
        public int CallOutcomeCode { get; set; }
        public string CallOutcomeDescription { get; set; }
        public string OtherCallOutcomeDetails { get; set; }
    }
}
