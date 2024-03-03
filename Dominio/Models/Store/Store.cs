using Domain.Models.Shared;
using Domain.Primitives;

namespace Domain.Models.Store
{
    public class Store : AggregateRoot
    {
        public Guid Id { get; }
        public FiscalTypeEnum FiscalTypeEnum { get; private set; }
        public FiscalNumber FiscalNumber { get; private set; }
        public Name StoreName { get; private set; }
        public Address StoreAddress { get; private set; }
        public PhoneNumber StorePhone { get; private set; }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public Store() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.

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
