using System;
using System.Collections.Generic;

namespace HuongViet.Models
{
    public class PagedResult<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
        public bool HasNextPage => PageNumber < TotalPages;
        public bool HasPreviousPage => PageNumber > 1;
    }

    public class SearchCriteria
    {
        public string SearchTerm { get; set; } = "";
        public string SortBy { get; set; } = "";
        public string SortDirection { get; set; } = "ASC"; // ASC or DESC
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
