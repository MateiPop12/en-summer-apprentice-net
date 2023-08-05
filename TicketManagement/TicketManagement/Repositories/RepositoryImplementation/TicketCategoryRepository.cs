using Microsoft.EntityFrameworkCore;
using TicketManagement.Models;
using TicketManagement.Repositories.RepositoryInterface;

namespace TicketManagement.Repositories.RepositoryImplementation;

public class TicketCategoryRepository : ITicketCategoryRepository
{
    private readonly TicketManagementContext _ticketManagementContext;

    public TicketCategoryRepository()
    {
        _ticketManagementContext = new TicketManagementContext();
    }
    public async Task<TicketCategory> GetById(long id)
    {
        var ticketCategory = await _ticketManagementContext.TicketCategories
            .Where(e => e.TicketCategoryId == id).FirstOrDefaultAsync();

        return @ticketCategory;
    }
}