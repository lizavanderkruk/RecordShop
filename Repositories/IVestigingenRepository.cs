using System.Collections.Generic;
using RecordShop.Models;

namespace RecordShop.Repositories
{
    public interface IVestigingenRepository
    {
        List<VestigingenModel> GetAllVestigingen(int productID);
        VestigingenModel GetOneVestiging(int vestigingID, int productID);
        void UpdateVoorraadvestiging(VestigingenModel vestigingenModel);
    }
}