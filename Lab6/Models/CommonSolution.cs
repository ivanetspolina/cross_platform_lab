﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class CommonSolution
    {
        public int Solution_Id { get; set; }
        public string SolutionDescription { get; set; }
        public string OtherSolutionDetails { get; set; }
    }
}
