namespace BLL;
using BOL;
using DAL;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class CatlogManager
{
     
//   public  List<Product> GetAllProducts()
//         {
//               List<Product> allProducts = new List<Product>();
//               allProducts=DBManager.GetAllProducts();
//               var opt = new JsonSerializerOptions {IncludeFields=true};
//               var prodJson = JsonSerializer.Serialize<List<Product>>(allProducts,opt);
//               string filename = @"D:\CDAC All subjects\.Net\practice\EcommerceApplication2\product.json";
//               File.WriteAllText(filename,prodJson);
//               return allProducts;
//         }


  public List<Product> GetProductsFromFile(string path){
            List<Product> allProducts = new List<Product>();
              allProducts=DBManager.GetAllProductsFromFile(path);
              return allProducts;
  }
  public Product GetProductById(int id){

      List<Product> allProducts = new List<Product>();

           allProducts=DBManager.GetAllProducts();

           Product p = allProducts.Find((product)=> product.ProductId == id);
           return p;

  } 

  public void AddProduct(Product p){
        DBManager.AddProduct(p);     
    
  }     

  public void DeleteProduct(int id){
      DBManager.DeleteProductById(id);
  }


}
