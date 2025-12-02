using ERP.Application.Common.Interfaces.DbContext;
using ERP.Domain.Entities.Modules.HumanResourcesManagement;
using ERP.Domain.Repositories.Modules.HumanResourcesManagement;
using ERP.Domain.Repositories.Users;

namespace ERP.Application.UseCases.Modules.HumanResourcesManagement.Commands.CreateNewHuman
{
    public class CreateNewHumanCommandHandler(IMainDbContext context, IUserRepository userRepository, IHumanRepository humanRepository)
        : IRequestHandler<CreateNewHumanCommand, Result<string, Error>>
    {
        private readonly IMainDbContext _context = context;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IHumanRepository _humanRepository = humanRepository;

        public async Task<Result<string, Error>> Handle(CreateNewHumanCommand request, CancellationToken cancellationToken)
        {
            var isExistenceNationalId = await _humanRepository.IsExistenceByNatioanlIdAsync(request.NationalId, cancellationToken);
            if (isExistenceNationalId)
            {
                return Result.Failure<string, Error>(Errors.Human.NationalIdIsUsed(request.NationalId));
            }
            if (request.PassportId is not null)
            {
                var isExistencePassportId = await _humanRepository.IsExistenceByPassportIdAsync(request.PassportId, cancellationToken);
                if (isExistencePassportId)
                {
                    return Result.Failure<string, Error>(Errors.Human.PassportIdIsUsed(request.PassportId));
                }
            }
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (user is null)
            {
                return Result.Failure<string, Error>(Errors.User.UserNotFound());
            }
            var human = new Human(user, request.NationalId, request.Name, request.Family, request.Gender, request.BirthDate, request.MaritalStatus, request.PassportId);
            await _humanRepository.CreateAsync(human, cancellationToken);
            var resultSave = await _context.SaveChanges(cancellationToken);
            if (resultSave <= 0)
            {
                return Result.Failure<string, Error>(Errors.General.NotSavedChanges());
            }
            return Result.Success<string, Error>($"{human.Name} {human.Family}");
        }
    }
}
