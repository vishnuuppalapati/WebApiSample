using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
//using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;

namespace WebApplication1.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        static readonly IProductRepository repository = new ProductRepository();
        //Getting All Products
        [HttpGet]
        //public IActionResult GetAllProducts()
        //{
        //    try
        //    {
        //        var items = repository.GetAll();
        //        if (items == null)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound);
        //        }
        //        return StatusCode(StatusCodes.Status200OK, items);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
        //    }
        //}
        //Getting the Single Product by id
        // GET api/values
        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            //Product item = repository.Get(id);

            try
            {
                Product item = repository.Get(id);
                if (item == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                
                return StatusCode(StatusCodes.Status200OK, item);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
 
        [HttpPost]
        public IActionResult PostProduct(Product item) 
        {           
                repository.Add(item);
                return StatusCode(StatusCodes.Status201Created);
        }
      
         //updating the Product in list
        [HttpPut]
        public IActionResult PutProduct(int id, Product product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                return StatusCode(StatusCodes.Status404NotFound, id);               
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, id);
            }
        }

        //Deleting the Product from the list
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, item);
            }
            else
            {
                repository.Remove(id);
                return StatusCode(StatusCodes.Status200OK, item);
            }
        }



    }
}