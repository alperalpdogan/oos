﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.OOS.Models
{
    public record OosModel : BaseNopModel
    {
        public bool OutOfStock { get; set; }
    }
}
