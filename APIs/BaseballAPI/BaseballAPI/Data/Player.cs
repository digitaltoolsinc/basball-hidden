﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BaseballAPI.Data
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TeamId { get; set; }
        public double BattingAverage { get; set; }
        public int HomeRuns { get; set; }
        public int Rbis { get; set; }
        public string Position { get; set; }
    }
}