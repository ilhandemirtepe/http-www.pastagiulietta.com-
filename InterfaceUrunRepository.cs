﻿using PastaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaMVC.Repository
{
    public interface InterfaceUrunRepository
    {
        List<Product> findAll();
    }
}
