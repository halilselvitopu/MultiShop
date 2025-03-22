﻿namespace MultiShop.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailName { get; set; }
        public string ProductImageName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
