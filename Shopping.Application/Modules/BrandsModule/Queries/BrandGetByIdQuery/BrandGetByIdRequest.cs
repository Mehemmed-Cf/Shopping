using MediatR;

namespace Shopping.Application.Modules.BrandsModule.Queries.BrandGetByIdQuery
{
    public class BrandGetByIdRequest : IRequest<BrandRequestDto>
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } = true;
    }
}
