namespace AudiosearchNet.Models
{
    /// <summary>
    /// Thing you would like to search for. A wildcard character(*) can be used to substitute for any other 
    /// character or characters in a string. Submitting* will return all results.To restrict the query to a single field, 
    /// preface the query with the field name followed by :, (e.g.title: radio).
    /// </summary>
    public class Query
    {
        /// <summary>
        /// Query keyword. (e.g.title: radio).
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// Limit a search by any field value.This example uses network but any field name could be used. 
        /// (Note: the filter uses a 'term' match, so it returns a result if the field contains the term.It is most reliably 
        /// used with integer values.) E.g.filters[network_name]=NPR or filters[categories.name]=Talk%20Show.
        /// </summary>
        public Filter Filter { get; set; }

        /// <summary>
        /// Sort results by any field value, for example (buzz_score). Must be paired with sort_order.
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// Sort direction. Must be either asc or desc. Must be paired with sort_by.
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// Shortcut for specifying sort_by and sort_order in a single value. E.g. date_created desc.
        /// </summary>
        public string SortByAndOrderBy { get; set; }

        /// <summary>
        /// The number of results in a single page. Default is 10. If present, must be paired with from.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Offset when doing manual pagination. Must be paired with size.
        /// </summary>
        public int PageOffset { get; set; }

        /// <summary>
        /// The page number of results. Default is 1.
        /// </summary>
        public int Page { get; set; }
    }
}
