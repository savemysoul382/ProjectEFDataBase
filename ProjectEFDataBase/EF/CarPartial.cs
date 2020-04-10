﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEFDataBase.EF
{
    public partial class Car
    {
        // Поскольку столбец PetName может быть пустым,
        // предоставить стандартное имя **No Name**.
        public override String ToString()
        {
            return $"{this.CarNickName ?? "**No Name**"} is a {this.Color} {this.Make} with ID {this.CarId}.";
        }
    }
}
