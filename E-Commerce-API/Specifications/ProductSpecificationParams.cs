﻿namespace E_Commerce_API.Specifications
{
    public class ProductSpecificationParams
    {
        private const int MaxPageSize = 40;
        public int PageIndex { get; set; } = 1;
       
        private int _pageSize = 6;  
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MaxPageSize)?MaxPageSize : value; }

        }

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }
    }
}
