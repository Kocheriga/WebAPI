﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.RequestFeatures;

namespace Entities.RequestFeatures
{
    public class ProdajaParameters : RequestParameters
    {
        public ProdajaParameters()
        {
            OrderBy = "tovar";
        }
        public uint MinCost { get; set; }
        public uint MaxCost { get; set; } = int.MaxValue;
        public bool ValidCostRange => MaxCost > MinCost;
        public string SearchTerm { get; set; }
    }
}
