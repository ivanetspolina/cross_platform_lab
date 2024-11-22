﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class RefCallStatusCode
    {
        public int CallStatusCode { get; set; }
        public string CallStatusDescription { get; set; }
        public string CallStatusComments { get; set; }
    }
}
