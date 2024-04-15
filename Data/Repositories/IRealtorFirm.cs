namespace Echo_HemAPI.Data.Models
{
    // Author: Samed Salman
    public interface IRealtorFirm
    {
        Task<IEnumerable<RealtorFirm>> GetAllRealtorFirmsAsync();
        Task<RealtorFirm> GetRealtorFirmByIdAsync(int id);
        Task<RealtorFirm> GetRealtorFirmByNameAsync(string name);

        // TODO: Hur använder vi returen i de här metoderna? 
        Task<RealtorFirm> AddRealtorFirmAsync(RealtorFirm realtorFirm);
        Task<RealtorFirm> UpdateRealtorFirmAsync(RealtorFirm realtorFirm);
        Task<RealtorFirm> RemoveRealtorFirmAsync(RealtorFirm realtorFirm);
        Task SaveChangesAsync();
    }
}