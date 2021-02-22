namespace dc_common_view_model
{
    internal interface IPagedResponse
    {
        public int TotalRecords { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public int Skipped { get; set; }
    }
}
