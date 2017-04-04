namespace AudiosearchNet.Models
{
    /// <summary>
    /// Limit a search by any field value.This example uses network but any field name could be used. 
    /// (Note: the filter uses a 'term' match, so it returns a result if the field contains the term.It is most reliably 
    /// used with integer values.) E.g.filters[network_name]=NPR or filters[categories.name]=Talk%20Show.
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Filter field name. E.g. categories.name.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Filter value for field name. E.g. Talk%20Show.
        /// </summary>
        public string Value { get; set; }
    }
}
