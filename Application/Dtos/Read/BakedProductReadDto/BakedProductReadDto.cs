namespace PadariaTech.Application.Dtos.Read
{
    public class BakedProductReadDto : ProductReadDto 
    {
        public BakedProductRecipeReadDto Recipe { get; set; }
    }
}   