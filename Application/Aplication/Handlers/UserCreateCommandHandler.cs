using Application.Aplication.CommandsDTOS;
using Application.Interfaces;
using Domain.Models.Shared;
using Domain.Models.User;
using Domain.Primitives;
using MediatR;

namespace Application.Aplication.Handlers
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, Unit>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private FiscalTypeEnum _facilityTypeEnum;

        public UserCreateCommandHandler(IMediator mediator, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Unit> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.Phone == null || request.FiscalType == null || request.FiscalNumber == null)
                throw new NotImplementedException("Parte de la request viene vacia");

            // TODO : if (request.FiscalType.CompareTo(FiscalTypeEnum))  ** hacer la comparacion con los elementos del enum
            if (request.FiscalType == "NIF")
                _facilityTypeEnum = FiscalTypeEnum.NIF;

            if (request.FiscalType == "CIF")
                _facilityTypeEnum = FiscalTypeEnum.CIF;

            if (request.FiscalType == "NIE")
                _facilityTypeEnum = FiscalTypeEnum.NIE;


            if (FiscalNumber.Create(request.FiscalNumber) is not FiscalNumber fiscalNumber)
                throw new NotImplementedException("El nombre no es correcto");

            if (Name.Create(request.Name) is not Name name)
                throw new NotImplementedException("El nombre no es correcto");

            if (PhoneNumber.Create(request.Phone) is not PhoneNumber phoneNumber)
                throw new NotImplementedException("Address no es correcta");

            if (Address.Create(request.Street, request.Number, request.ZipCode, request.Floor, request.Letter, request.City, request.CountryCode) is not Address address)
                throw new NotImplementedException("Address no es correcta");

            var user = User.Create(
                _facilityTypeEnum,
                fiscalNumber,
                name,
                address,
                phoneNumber
                );

            await _userRepository.RecordUser(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }

    }
}
