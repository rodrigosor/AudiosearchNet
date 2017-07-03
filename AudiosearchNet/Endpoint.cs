namespace AudiosearchNet
{
    internal class Endpoint
    {
        /// <summary>
        /// This endpoint returns search results for Shows
        /// </summary>
        public const string SEARCH_SHOW_BY_QUERY = @"/search/shows/";

        /// <summary>
        /// This endpoint returns search results for Shows by Id
        /// </summary>
        public const string SHOW_BY_ID = @"/shows/";

		/// <summary>
		/// This endpoint returns search results for Shows by Id
		/// </summary>
		public const string CATEGORIES = @"/categories/";
		public const string TRENDING_SHOW = @"/chart_daily?limit=10&country=us";
	}
}
