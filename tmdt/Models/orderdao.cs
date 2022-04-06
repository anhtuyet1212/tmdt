using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using tmdt.Models;

namespace tmdt.Models
{
    public class orderdao
    {
        csdlbh db = new csdlbh();
        public long Insert(donhang order)
        {
            db.donhangs.Add(order);
            db.SaveChanges();
            return order.ma;
        }
    }
}