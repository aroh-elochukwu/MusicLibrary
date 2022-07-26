using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicLibrary.Models.ViewModels
{
    public class UserSelectViewModel
    {
        public List<SelectListItem> UserSelect { get; set; }

        public UserSelectViewModel(List<User> users)
        {
            UserSelect = new List<SelectListItem>();

            users.ForEach(u =>
            {
                UserSelect.Add(new SelectListItem(u.Name, u.Id.ToString()));
            });
        }
    }
}
