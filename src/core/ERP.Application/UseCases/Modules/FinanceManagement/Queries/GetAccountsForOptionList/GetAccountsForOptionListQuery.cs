using ERP.Application.Common.ResponseModels;

namespace ERP.Application.UseCases.Modules.FinanceManagement.Queries.GetAccountsForOptionList
{
    public record GetAccountsForOptionListQuery : IRequest<Result<IReadOnlyList<GetResponseForOptionListDto>, Error>>
    {
        public string? Search { get; init; }
    }
}
