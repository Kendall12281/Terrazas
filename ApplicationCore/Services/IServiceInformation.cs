using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceInformation
    {
        List<Information> GetInformationByTypeId(int id);
        void CreateInformation(Information information);
        void UpdateInformation(Information information);
        List<InformationType> GetInformationTypes();
        Information GetInformationById(int id);

        List<Information> GetInformationByResidentId(int residentId);
    }
}
