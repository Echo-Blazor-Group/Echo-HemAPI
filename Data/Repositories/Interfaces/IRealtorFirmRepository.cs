<<<<<<<< HEAD:Data/Repositories/IRealtorFirmRepository.cs
﻿using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Models
{
    /// <summary>
    /// Author: Samed Salman
    /// </summary>
========
﻿using Echo_HemAPI.Data.Models;

namespace Echo_HemAPI.Data.Repositories.Interfaces
{
    // Author: Samed Salman
>>>>>>>> 9f8a995f08b8baf94aa692b4944a031647db96f1:Data/Repositories/Interfaces/IRealtorFirmRepository.cs
    public interface IRealtorFirmRepository
    {
        Task<RealtorFirm> AddRealtorFirmAsync(RealtorFirm realtorFirm);
        Task<IEnumerable<RealtorFirm>> GetAllRealtorFirmsAsync();
        Task<RealtorFirm> GetRealtorFirmByIdAsync(int id);
        Task<RealtorFirm> RemoveRealtorFirmAsync(RealtorFirm realtorFirm);
        Task<RealtorFirm> UpdateRealtorFirmAsync(RealtorFirm realtorFirm);
        Task<IQueryable<RealtorFirm>> FindAsync(Expression<Func<RealtorFirm, bool>> predicate);
        void SaveChanges();
    }
}