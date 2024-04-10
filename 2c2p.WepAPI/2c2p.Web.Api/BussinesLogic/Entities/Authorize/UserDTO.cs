using System.ComponentModel.DataAnnotations;

namespace BussinesLogic.Entities.Authorize
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
