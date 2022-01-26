using Microsoft.AspNetCore.Mvc;

namespace CookiesAndMilk.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShoppingcartController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> Get(string productName, int price)
        {
            //Try to find the shoppingcart in session
            ShoppingCart shoppingCart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("ShoppingCart");
            //If shoppingcart exists we can just add the product to the cart and save it again
            if (shoppingCart != null)
            {
                //Update the object with new product and save it to session
                shoppingCart.Products.Add(new Product(productName, price));
                HttpContext.Session.SetObjectAsJson("ShoppingCart", shoppingCart);
                return shoppingCart.Products;
            }
            else
            {
                //Add the product to the shoppingcart
                List<Product> products = new List<Product>();
                products.Add(new Product(productName, price));
                //Lets add a shoppingcart with the first product
                HttpContext.Session.SetObjectAsJson("ShoppingCart", new ShoppingCart(products));
                return products;
            }
        }

        //Making a delete instead of new controller since swagger makes it easy to call delete
        [HttpDelete]
        //We get the product name and price since we dont have an id on the product
        public IEnumerable<Product> Delete(string productName, int price)
        {
            //Try to find the shoppingcart in session
            ShoppingCart shoppingCart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("ShoppingCart");
            //If shoppingcart exists we can just add the product to the cart and save it again
            if (shoppingCart != null)
            {
                //Find 1 product that matches the product name an price (because we have no id)
                Product foundProduct = shoppingCart.Products.Find(x => x.Name == productName && x.Price == price);
                if (foundProduct != null)
                {
                    //Remove the matching product
                    shoppingCart.Products.Remove(foundProduct);
                    //Save the updated cart to session
                    HttpContext.Session.SetObjectAsJson("ShoppingCart", shoppingCart);
                    return shoppingCart.Products;
                }
            }

            return new List<Product>();
        }


    }
}
