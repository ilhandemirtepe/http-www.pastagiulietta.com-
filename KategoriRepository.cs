using PastaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastaMVC.Repository
{
    public class KategoriRepository :InterfaceKategoriRepository
    {
        private PastaDBEntities db = new PastaDBEntities();
        public List<Kategori> findAll()
        {
            return db.Kategori.ToList();
           
        }



        public Kategori find(int id)
        {
            return db.Kategori.Find(id);
        }
    }
}