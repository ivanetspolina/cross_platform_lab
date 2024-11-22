﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class SolutionsForCommonProblem
    {
        public int Problem_Id { get; set; }
        public int Solution_Id { get; set; }
        public CommonProblem CommonProblem { get; set; }
        public CommonSolution CommonSolution { get; set; }
    }
}
