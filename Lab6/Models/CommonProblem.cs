﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class CommonProblem
    {
        public int Problem_Id { get; set; }
        public string ProblemDescription { get; set; }
        public string OtherProblemDetails { get; set; }
    }
}
