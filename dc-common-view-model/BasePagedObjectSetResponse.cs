namespace dc_common_view_model
{
    public class BasePagedObjectSetResponse<T> : BaseObjectSetResponse<T>, IPagedResponse
    {
        public int TotalRecords { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public int Skipped { get; set; }
    }
}
