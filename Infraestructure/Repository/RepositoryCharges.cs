using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryCharges : IRepositoryCharges
    {
        public void SaveCharges(List<Charge> charges)
        {
            try
            {
                using (MyContext db = new MyContext())
                {
                    foreach (Charge item in charges)
                    {
                        db.Charge.Add(item);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public List<Resident> SelectDate(DateTime date)
        {
            List<Resident> list1 = new List<Resident>();
            try
            {
                using (MyContext db = new MyContext())
                {
                    List<Resident> list = db.Resident.Include("Charge").ToList();

                    foreach (Resident item in list)
                    {
                        
                        if(item.Charge.Where(x => x.Year == date.Year && x.Month == date.Month).ToList().Count() == 0){
                            list1.Add(item);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            return list1;
        }
    }
}
