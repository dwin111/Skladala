﻿using System;
namespace Skladala.Core.Models
{
    public class NonfoodProducts : Product
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override void ValueValidation()
        {
            throw new NotImplementedException();
        }
    }
}