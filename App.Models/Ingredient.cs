namespace App.Models
{
    public class Ingredient : BaseModel<int>
    {
        public string Name { get; set; }

        public string Quantity { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
