using Dominio.Models.Shared;


namespace Dominio.Models.Store
{
    public class Store
    {
        public Guid Id { get; private set; }
        public FiscalTypeEnum FiscalTypeEnum { get; private set; }
        public FiscalNumber FiscalNumber { get; private set; }
        public Name StoreName { get; private set; }
        public Address StoreAddress { get; private set; }
        public PhoneNumber StorePhone { get; private set; }

        private Store(FiscalTypeEnum fiscalTypeEnum, FiscalNumber fiscalNumber, Name storeName, Address storeAddress, PhoneNumber storePhone)
        {
            Id = Guid.NewGuid();
            FiscalTypeEnum = fiscalTypeEnum;
            FiscalNumber = fiscalNumber;
            StoreName = storeName;
            StoreAddress = storeAddress;
            StorePhone = storePhone;
        }

        public Store Create(FiscalTypeEnum fiscalTypeEnum, FiscalNumber fiscalNumber, Name storeName, Address storeAddress, PhoneNumber storePhone)
        {
            return new Store(fiscalTypeEnum, fiscalNumber, storeName, storeAddress, storePhone);
        }


    }
}
