using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PastaMVC.Models;
namespace PastaMVC.Repository
{
    public interface InterfaceKategoriRepository
    {
        List<Kategori> findAll();

        Kategori find(int id);

    }
}
