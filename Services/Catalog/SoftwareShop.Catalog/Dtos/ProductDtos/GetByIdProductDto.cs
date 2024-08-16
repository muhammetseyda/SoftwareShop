﻿using SoftwareShop.Catalog.Entities;

namespace SoftwareShop.Catalog.Dtos.ProductDtos
{
    public class GetByIdProductDto
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SalePrice { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}