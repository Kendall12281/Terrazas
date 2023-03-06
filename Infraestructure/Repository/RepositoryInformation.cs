using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryInformation : IRepositoryInformation
    {
        public void CreateInformation(Information information)
        {
            try
            {
                using (MyContext db = new MyContext())
                {
                    db.Information.Add(information);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Information GetInformationById(int id)
        {
            try
            {

                using (MyContext db = new MyContext())
                {
                    return db.Information.Include("InformationType").Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Information> GetInformationByResidentId(int residentId)
        {
            try
            {
                using(MyContext db = new MyContext())
                {
                    return db.Information.Include("InformationType").Include("Resident").Where(x => x.Resident.Id == residentId).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Information> GetInformationByTypeId(int id)
        {
            try
            {

                using (MyContext db = new MyContext())
                {
                    return db.Information.Include("InformationType").Include("Resident").Where(x => x.InformationType.Id == id).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<InformationType> GetInformationTypes()
        {
            try
            {
                using (MyContext db = new MyContext())
                {
                    return db.InformationType.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateInformation(Information information)
        {
            try
            {
                using (MyContext db = new MyContext())
                {
                    db.Information.AddOrUpdate(information);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
