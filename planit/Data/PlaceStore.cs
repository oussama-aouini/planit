using planit.Models.Dto;

namespace planit.Data
{
    public static class PlaceStore
    {
        public static List<PlaceDTO> placeList = new List<PlaceDTO>
        {
            new PlaceDTO{Id=1, Name="Gormet", Category="food"},
            new PlaceDTO{Id=2, Name="Najib kharrat", Category="Health"}
        };
    }
}
