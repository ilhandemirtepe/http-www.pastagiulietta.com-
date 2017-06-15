using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PastaMVC.Models;
namespace PastaMVC.Repository
{
    public class UrunRepository :InterfaceUrunRepository
    {
        PastaDBEntities db = new PastaDBEntities();
        public List<Product> findAll()
        {
            return db.Product.ToList();
        }
    }
}