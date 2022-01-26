namespace CookiesAndMilk
{
    public class ShoppingCart
    {

        public List<Product> Products { get; set; }

        public ShoppingCart(List<Product> products)
        {
            Products = products;
        }
    }
}
