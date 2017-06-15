using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PastaMVC.Models;
namespace PastaMVC.Repository
{
    public class SertifikaRepository:InterfaceSertifiaRepository
    {
        private PastaDBEntities db = new PastaDBEntities();
        public List<Sertifikalar> findAll()
        {
            return db.Sertifikalar.ToList();
        }
    }
}