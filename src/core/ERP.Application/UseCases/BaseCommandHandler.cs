namespace ERP.Application.UseCases
{
    public abstract class BaseCommandHandler(IMainDbContext context)
    {
        protected readonly IMainDbContext _context = context;
    }
}
