using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Echo_HemAPI.Data.Models.DTOs.RealtorDTOs
{
    //Author: Seb
    public class NewUserShowClaimsDTO
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public int RealtorFirmId { get; set; }
        public string? Role {  get; set; }
        public string? Token {  get; set; }
    }
}
