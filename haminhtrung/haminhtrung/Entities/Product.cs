using System;
using System.Collections.Generic;

namespace haminhtrung.Entities;

public partial class Product
{
    /// <summary>
    /// 1: SẢN PHẨM MỚI, 2: SẢN PHẨM HOT, 3: SẢN PHẨM KHUYẾN MÃI, 4: PHỤ KIỆN
    /// </summary>
    public int Id { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public int? TypeId { get; set; }

    public int? BrandId { get; set; }
}
