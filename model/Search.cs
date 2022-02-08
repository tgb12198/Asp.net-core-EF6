namespace model
{
    public class Search
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        /// <summary>
        /// if ordered（ordered:1,no ordered:0,all:-1）
        /// </summary>
        public int IsOrdered { get; set; }
    }
}