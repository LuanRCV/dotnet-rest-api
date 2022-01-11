using rest_api.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace rest_api.Hypermedia.Utils
{
    public class PagedSearchVO<T> where T : ISupportsHyperMedia
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public string SortFields { get; set; }
        public string SortDirections { get; set; }
        public Dictionary<string, Object> Filters { get; set; }
        public List<T> List { get; set; }

        public PagedSearchVO() { }

        public PagedSearchVO(int currentPage, int pageSize, string sortFields, string sortDirections)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            SortFields = sortFields;
            SortDirections = sortDirections;
        }

        public PagedSearchVO(int currentPage, int pageSize, string sortFields, string sortDirections, Dictionary<string, object> filters)
            : this (currentPage, pageSize, sortFields, sortDirections)
        {
            Filters = filters;
        }

        // Set default page size 10
        public PagedSearchVO(int currentPage, string sortFields, string sortDirections) 
            : this (currentPage, 10, sortFields, sortDirections) { }

        public int GetCurrentPage()
        {
            if (CurrentPage == 0) return 1;

            return CurrentPage;
        }

        public int GetPageSize()
        {
            if (PageSize == 0) return 10;

            return PageSize;
        }
    }
}
