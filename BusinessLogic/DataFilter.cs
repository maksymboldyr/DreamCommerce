﻿namespace BusinessLogic
{
    public class DataFilter
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public string? SortBy { get; set; }
        public string? SortOrder { get; set; }
    }
}
