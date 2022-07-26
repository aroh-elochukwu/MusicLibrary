using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicLibrary.Models.ViewModels
{
    public class ArtistSelectViewModel
    {      
        public List<SelectListItem> ArtistSelectItems { get; set;}

        public ArtistSelectViewModel(List<Artist> artists )
        {
            ArtistSelectItems = new List<SelectListItem>();           

            foreach (Artist artist in artists)
            {
                ArtistSelectItems.Add(new SelectListItem(artist.Name, artist.Id.ToString()));
            }

        }
        
    }
}
