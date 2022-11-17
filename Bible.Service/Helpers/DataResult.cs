namespace Bible.Service.Helpers
{
    public class DataResult<TEntity>
    {
        public TEntity? Data { get; set; }
        public Boolean Success { get; set; }
        public String? Message { get; set; }
        public Int32 Total { get; set; }
    }
}
