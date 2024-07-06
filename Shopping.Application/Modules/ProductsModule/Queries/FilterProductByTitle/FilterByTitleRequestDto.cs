
namespace Shopping.Application.Modules.ProductsModule.Queries.FilterProductByTitle
{
    public class FilterByTitleRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public short Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
