namespace ShopTARge23.Models.Drinks
{
    public class DrinkIndexViewModel
    {
        public string DrinkName { get; set; } 

        
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Alcoholic { get; set; }
        public string Glass { get; set; }
        public string Instructions { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();

     
    }
}
