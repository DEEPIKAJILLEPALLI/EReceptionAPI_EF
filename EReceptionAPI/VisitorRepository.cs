using EReceptionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EReceptionAPI
{
    public class VisitorRepository
    {
        public List<Visitor> GetAllVisitors()
        {
            VisitorDbContext visitorDbContext = new VisitorDbContext();
            return visitorDbContext.Visitors.ToList();
        }
    }
}