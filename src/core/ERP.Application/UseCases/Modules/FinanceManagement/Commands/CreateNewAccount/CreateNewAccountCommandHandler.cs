using ERP.Domain.Entities.Modules.FinanceManagement;
using ERP.Domain.Repositories.Modules.FinanceManagement;

namespace ERP.Application.UseCases.Modules.FinanceManagement.Commands.CreateNewAccount
{
    public class CreateNewAccountCommandHandler(IMainDbContext context, IAccountRepository accountRepository)
        : IRequestHandler<CreateNewAccountCommand, Result<string, Error>>
    {
        private readonly IMainDbContext _context = context;
        private readonly IAccountRepository _accountRepository = accountRepository;

        public async Task<Result<string, Error>> Handle(CreateNewAccountCommand request, CancellationToken cancellationToken)
        {
            var isExistenceName = await _accountRepository.IsExistenceByNameAsync(request.Name, cancellationToken);
            if (isExistenceName)
            {
                return Result.Failure<string, Error>(Errors.Account.NameIsUsed(request.Name));
            }
            string code;
            Account? parentAccount = null;
            if (request.Group == AccountGroup.LevelOne)
            {
                var getCountAccountsByAccountType = await _accountRepository.GetCountAccountsByAccountTypeAndAccountGroupAsync(request.Type, request.Group, cancellationToken);
                switch (request.Type)
                {
                    case AccountType.AssetCurrent:
                        getCountAccountsByAccountType += 100;
                        break;
                    case AccountType.AssetNonCurrentTangible:
                        getCountAccountsByAccountType += 140;
                        break;
                    case AccountType.AssetNonCurrentIntangible:
                        getCountAccountsByAccountType += 170;
                        break;
                    case AccountType.LiabilityCurrent:
                        getCountAccountsByAccountType += 200;
                        break;
                    case AccountType.LiabilityNonCurrent:
                        getCountAccountsByAccountType += 250;
                        break;
                    case AccountType.Equity:
                        getCountAccountsByAccountType += 300;
                        break;
                    case AccountType.RevenueOperating:
                        getCountAccountsByAccountType += 400;
                        break;
                    case AccountType.RevenueNonOperating:
                        getCountAccountsByAccountType += 450;
                        break;
                    case AccountType.ExpenseOperating:
                        getCountAccountsByAccountType += 500;
                        break;
                    case AccountType.ExpenseNonOperating:
                        getCountAccountsByAccountType += 550;
                        break;
                    case AccountType.AssetDecrease:
                        getCountAccountsByAccountType += 600;
                        break;
                    case AccountType.LiabilityDecrease:
                        getCountAccountsByAccountType += 700;
                        break;
                    case AccountType.CostPriceProductSold:
                        getCountAccountsByAccountType += 800;
                        break;
                    case AccountType.Other:
                        getCountAccountsByAccountType += 900;
                        break;
                    default:
                        throw new ArgumentException("Invalid account type.");
                }
                code = (getCountAccountsByAccountType + 1).ToString();
            }
            else
            {
                if (request.ParentAccountId is null)
                {
                    return Result.Failure<string, Error>(Errors.Account.ParentAccountIdIsEmpty());
                }
                parentAccount = await _accountRepository.GetByIdAsync(request.ParentAccountId, cancellationToken);
                if (parentAccount is null)
                {
                    return Result.Failure<string, Error>(Errors.Account.ParentAccountNotFound());
                }
                if (parentAccount.IsFinal)
                {
                    return Result.Failure<string, Error>(Errors.Account.ParentAccountIsFinal());
                }
                if (parentAccount.Group == request.Group)
                {
                    return Result.Failure<string, Error>(Errors.Account.ParentAccountGroupIsEqualToAccountGroup());
                }
                var getCountChildAccountsByAccountId = await _accountRepository.GetCountChildAccountsByAccountIdAsync(parentAccount.Id, cancellationToken);
                string d = "0";
                string dd = "";
                for (int i = 0; i < 4 - getCountChildAccountsByAccountId.ToString().Length; i++)
                {
                    dd += d;
                }
                code = parentAccount.Code + dd + (getCountChildAccountsByAccountId + 1).ToString();
            }
            if (request.ParentAccountId is not null)
            {
                parentAccount = await _accountRepository.GetByIdAsync(request.ParentAccountId, cancellationToken);
            }
            var account = new Account(code, request.Name, request.Type, request.Group, request.Balance, request.FinancialStatement, request.IsFinal, parentAccount);
            account.SetConcurrencyStamp();
            await _accountRepository.CreateAsync(account, cancellationToken);
            var resultSave = await _context.SaveChanges(cancellationToken);
            if (resultSave <= 0)
            {
                return Result.Failure<string, Error>(Errors.General.NotSavedChanges());
            }
            return Result.Success<string, Error>(account.Code);
        }
    }
}
