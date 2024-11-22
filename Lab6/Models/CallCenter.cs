﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class CallCenter
    {
        public int CallCenter_Id { get; set; }
        public string CallCenterAddress { get; set; }
        public string CallCenterOtherDetails { get; set; }
    }
}
