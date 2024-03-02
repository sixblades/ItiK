using Dominio.Models.Shared;
using Dominio.Models.Store.ValueObjects;

namespace Dominio.Models.Store
{
    public class Store
    {
        public Guid Id { get; private set; }
        public Cif Cif { get; set; }
        public Name StoreName { get; set; }
        public Address StoreAddress { get; set; }
        public PhoneNumber StorePhone { get; set; }

        public Store(Cif cif, Name storeName, Address storeAddress, PhoneNumber storePhone)
        {
            Id = Guid.NewGuid();
            Cif = cif;
            StoreName = storeName;
            StoreAddress = storeAddress;
            StorePhone = storePhone;
        }
    }
}
