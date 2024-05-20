using CloudGame.Features.DtoModels.Owner;
using CloudGame.Features.Interfaces.Manager;
using CloudGame.Logic.DtoModels.Filtres;
using CloudGame.Logic.Interfaces.Repositories;
using CloudGame.Logic.Interfaces.Service;
using CloudGame.Storage.Database;
using AutoMapper;
using CloudGame.Storage.Models;
using CloudGame.Features.DtoModels.Server;
using Microsoft.AspNetCore.Mvc.Rendering;
using CloudGame.Logic.Service;

namespace CloudGame.Features.Manager
{
    public class OwnerManager : IOwnerManager
    {
        private readonly IMapper _mapper;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IOwnerService _ownerService;
        private readonly DataContext _dataContext;

        public OwnerManager(IMapper mapper, IOwnerRepository ownerRepository, IOwnerService ownerService, DataContext dataContext)
        {
            _mapper = mapper;
            _ownerRepository = ownerRepository;
            _ownerService = ownerService;
            _dataContext = dataContext;
        }
        
        public async Task Create(EditOwner editOwner, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Owner>(editOwner);

            _ownerRepository.Create(_dataContext, model);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(EditOwner editOwner, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Owner>(editOwner);

            _ownerRepository.Update(_dataContext, model);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Guid isnNode, CancellationToken cancellationToken)
        {

            _ownerRepository.Delete(_dataContext, isnNode);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<EditOwner> GetOwner(Guid isnNode)
        {
            var model = _ownerRepository.GetById(_dataContext, isnNode);

            return _mapper.Map<EditOwner>(model);
        }

        public async Task<InfoOwnerDto> GetInfoOwner(Guid isnOwner)
        {
            var owner = _ownerService.GetInfoOwner(_dataContext, isnOwner);

            return new InfoOwnerDto
            {
                IsnNode = owner.IsnNode,
                NameOwn = owner.NameOwn,
                DataRegistration = owner.DataRegistration,
                Servers = owner.Servers
                    .Select(servers => new ServerDto
                    {
                         IsnNode = servers.IsnNode,
                         IsnOwner = servers.IsnOwner,
                         NameServer = servers.NameServer,
                         Games = servers.Games,
                         Сharacteristic = servers.Сharacteristic
                    })
                    .ToArray()
            };
        }
        public async Task<OwnerDto[]> GetListOwner(OwnerFilter filter)
        {
            var owners = _ownerService
                .GetOwnerQueryble(_dataContext, filter, false)
                .Select(x => new OwnerDto
                {
                    IsnNode = x.IsnNode,
                    NameOwn = x.NameOwn,
                    DataRegistration = x.DataRegistration,
                })
                .ToArray();

            return owners;
        }

        public async Task<SelectListItem[]> GetListOwnersDropDown()
        {
            var owners = _ownerService.GetListOwnersDropDown(_dataContext)
                .Select(center => new SelectListItem
                {
                    Text = center.Label,
                    Value = center.Value,
                })
                .ToArray();

            return owners;
        }
    }
}
