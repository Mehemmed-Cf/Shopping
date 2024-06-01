using MediatR;

namespace Shopping.Application.Modules.MaterialsModule.Queries.MaterialGetAllQuery
{
    public class MaterialGetAllRequest : IRequest<IEnumerable<MaterialRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
