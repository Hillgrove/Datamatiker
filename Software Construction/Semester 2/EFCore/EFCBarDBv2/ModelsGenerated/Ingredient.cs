﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCBarDBv2.ModelsGenerated;

[Table("Ingredient")]
public partial class Ingredient
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public int PricePerCl { get; set; }

    public double AlcoholPercent { get; set; }

    [InverseProperty("AlcoholicPart")]
    public virtual ICollection<Drink> DrinkAlcoholicParts { get; set; } = new List<Drink>();

    [InverseProperty("NonAlcoholicPart")]
    public virtual ICollection<Drink> DrinkNonAlcoholicParts { get; set; } = new List<Drink>();
}