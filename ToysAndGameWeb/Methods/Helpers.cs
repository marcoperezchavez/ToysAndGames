using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToysAndGameWeb.Models;


namespace ToysAndGameWeb.Methods
{
    public static class Helpers
    {
  static ToysAndGamesContext _toysAndGamesContext = new ToysAndGamesContext();
  static List<ProductsGNL> productsToys =new List<ProductsGNL>();

        public static List<ProductsGNL> GetProductsList()
        {

         //-- var t = _toysAndGamesContext.Products.FromSql("");
            var productContext = _toysAndGamesContext.Products.ToList();
            var productsList = Mapping(productContext);
            return productsList;
        }

        private static List<ProductsGNL> Mapping(List<Products> listProd)
        {
            productsToys.Clear();
            foreach (var product in listProd)
            {
                ProductsGNL pro = new ProductsGNL();
                pro.Id = product.Id;
                pro.Name = product.Name;
                pro.AgeRestriction = product.AgeRestriction;
                pro.Price = product.Price;
                pro.DescriptionToy = product.DescriptionToy;
                pro.Company = GetCompanyName(product.CompanyId);

                productsToys.Add(pro);
            }
            return productsToys;
        }

        public static string GetCompanyName(int? id)
        {
            var name = _toysAndGamesContext.Company.Find(id).Company1;
            return name;

        }

        public static List<ProductsGNL> GetProduct(int Id)
        {
            var product = _toysAndGamesContext.Products.Where(x => Id== x.Id).ToList();

            if (product.Count is 0)
                return null;
            var productsList = Mapping(product);
            return productsList;
        }
        private static Products mappingProductDB(ProductsGNL Products)
        {
            Products Pd = new Products();
            Pd.Name = Products.Name;
            Pd.AgeRestriction = Products.AgeRestriction;
            Pd.DescriptionToy = Products.DescriptionToy;
            Pd.Price = Products.Price;
            Pd.CompanyId = GetCompanyNameDB(Products.Company);

            return Pd;
        }
        public static int GetCompanyNameDB(string Company)
        {
            var Id = _toysAndGamesContext.Company.Where(x => x.Company1 == Company).Select(x => x.CompanyId)
                .FirstOrDefault();
            return Id;

        }
        internal static bool SaveAlumno(ProductsGNL Products)
        {
            try
            {
                var ProductDB = mappingProductDB(Products);
                _toysAndGamesContext.Products.Add(ProductDB);
                _toysAndGamesContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }
        public static bool UpdateAlumno(int id, ProductsGNL Products)
        {
            try
            {
                var ProductDB = mappingProductDB(Products);
                // ProductDB.Id = id;
                //_toysAndGamesContext.Update(ProductDB);
                //_toysAndGamesContext.SaveChanges();
                //_toysAndGamesContext.Products.Attach(ProductDB);
                // _toysAndGamesContext.Entry(ProductDB).Property(x => x.Id).IsModified = true;
                //_toysAndGamesContext.SaveChanges();
                //_toysAndGamesContext.Update<Products>(ProductDB);
                //_toysAndGamesContext.SaveChanges();
                _toysAndGamesContext.Entry(ProductDB).Property(p => p.Name).IsModified = true;
                _toysAndGamesContext.Entry(ProductDB).Property(p => p.AgeRestriction).IsModified = true;
                _toysAndGamesContext.Entry(ProductDB).Property(p => p.DescriptionToy).IsModified = true;
                _toysAndGamesContext.Entry(ProductDB).Property(p => p.Price).IsModified = true;
                _toysAndGamesContext.Entry(ProductDB).Property(p => p.CompanyId).IsModified = true;
                _toysAndGamesContext.Entry(ProductDB).Property(p => p.Id).IsModified = false;

                // _toysAndGamesContext.Entry(ProductDB).State = EntityState.Modified;
                _toysAndGamesContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }

        public static bool DeleteId(int id)
        {
            var product = _toysAndGamesContext.Products.Where(x => x.Id == id).FirstOrDefault();
            if (product is null)
                return false;
            _toysAndGamesContext.Entry(product).State = EntityState.Deleted;
            _toysAndGamesContext.SaveChanges();
            return true;
        }
    }
}
