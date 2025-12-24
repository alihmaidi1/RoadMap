using Microsoft.EntityFrameworkCore;
using RoadMap.Domain.Repository;
using RoadMap.Domain.Security;

namespace RoadMap.Infrastructure.Repositories;

public class AdminRepository:BaseRepository<Admin>, IAdminRepository
{
    public AdminRepository(RoadMapDbContext context) : base(context)
    {
    }
}