﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDAL.Models
{
    public partial class inventory
    {
        [NotMapped]
        public string MakeColor => $"{Make} + ({Color})";
        // Поскольку столбец PetName может быть пустым,
        // предоставить стандартное имя **No Name**.
        public override String ToString()
        {
            return $"{this.PetName ?? "**No Name**"} is a {this.Color} {this.Make} with ID {this.CarId}.";
        }
    }
}
