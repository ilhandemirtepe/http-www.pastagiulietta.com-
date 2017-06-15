using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PastaMVC.Models;
namespace PastaMVC.Repository
{
    public class TarifRepository:InterfaceTarifRepository
    {
        PastaDBEntities db = new PastaDBEntities();
        public List<Tarifim> findAll()
        {
            return db.Tarifim.ToList();
        }
    }
}