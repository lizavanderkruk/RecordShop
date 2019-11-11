using RecordShop.Models;
using RecordShopClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordShop.Repositories
{
    public class VestigingenRepository : IVestigingenRepository
    {
        private readonly RecordshopContext context;

        public VestigingenRepository(RecordshopContext context)
        {
            this.context = context;
        }

        public List<VestigingenModel> GetAllVestigingen(int productID)
        {
            var vestigingenlijst = new List<VestigingenModel>();

            foreach (var vestiging in context.Vestigingsvoorraads.Where(v => v.ProductId == productID))
            {
                vestigingenlijst.Add(new VestigingenModel
                {
                    VestigingID = vestiging.VestigingId,
                    ProductID = vestiging.ProductId,
                    Voorraad = vestiging.Voorraad.HasValue ? vestiging.Voorraad.Value : 0
                });
            }
            return vestigingenlijst;
        }

        public VestigingenModel GetOneVestiging(int vestigingID, int productID)
        {
            var entity = context.Vestigingsvoorraads.Single(v => v.ProductId == productID && v.VestigingId == vestigingID);
            return new VestigingenModel
            {
                VestigingID = entity.VestigingId,
                ProductID = entity.ProductId,
                Voorraad = entity.Voorraad.HasValue ? entity.Voorraad.Value : 0
            };
        }

        public void UpdateVoorraadvestiging(VestigingenModel vestigingenModel)
        {
            var entity = context.Vestigingsvoorraads.Single(v => v.ProductId == vestigingenModel.ProductID && v.VestigingId == vestigingenModel.VestigingID);
            entity.Voorraad = vestigingenModel.Voorraad;
            int beginVoorraad = entity.Voorraad.HasValue ? entity.Voorraad.Value : 0;
            UpdateTotaleVoorraad(vestigingenModel, beginVoorraad);
            context.SaveChanges();
        }

        public void UpdateTotaleVoorraad(VestigingenModel vestigingenModel, int beginVoorraad)
        {
            int verschilVoorraad = vestigingenModel.Voorraad - beginVoorraad;
            var entity = context.Productens.Single(p => p.ProductId == vestigingenModel.ProductID);
            entity. += verschilVoorraad;
            context.SaveChanges();
        }
    }
}
