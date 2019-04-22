﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.Place
{
    /// <summary>
    /// Передержка
    /// </summary>
    public class Place : PlaceInfo
    {
        /// <summary>
        /// Название передержки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес передержки
        /// </summary>
        public string Address { get; set; }
    }
}
