using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceInformation : IServiceInformation
    {
        public void CreateInformation(Information information)
        {
            IRepositoryInformation repository = new RepositoryInformation();
            repository.CreateInformation(information);
        }

        public Information GetInformationById(int id)
        {
            IRepositoryInformation repository = new RepositoryInformation();
            return repository.GetInformationById(id);
        }

        public List<Information> GetInformationByResidentId(int residentId)
        {
            IRepositoryInformation repository = new RepositoryInformation();
            return repository.GetInformationByResidentId(residentId);
        }

        public List<Information> GetInformationByTypeId(int id)
        {
            IRepositoryInformation repository = new RepositoryInformation();
            return repository.GetInformationByTypeId(id);
        }

        public List<InformationType> GetInformationTypes()
        {
            IRepositoryInformation repository = new RepositoryInformation();
            return repository.GetInformationTypes();
        }

        public void UpdateInformation(Information information)
        {
            IRepositoryInformation repository = new RepositoryInformation();
            repository.UpdateInformation(information);
        }
    }
}
