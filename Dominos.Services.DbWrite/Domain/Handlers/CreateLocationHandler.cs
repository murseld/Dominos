using System;
using System.Threading.Tasks;
using AutoMapper;
using Dominos.Core.Bus;
using Dominos.Core.Domain.MessagesHandlers;
using Dominos.Services.DbWrite.Data.UnitOfWorks;
using Dominos.Services.DbWrite.Domain.Commands;
using Dominos.Services.DbWrite.Domain.Events;
using Dominos.Services.DbWrite.Entities;
using Dominos.Services.DbWrite.Repositories;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Dominos.Services.DbWrite.Domain.Handlers
{
    public class CreateLocationHandler : ICommandHandler<CreateLocationCommand>
    {
        private readonly IBusPublisher _busPublisher;
        private readonly ILocationRepository _locationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly ILogger<IBusPublisher> _logger;
        public CreateLocationHandler(
            ILocationRepository locationRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IBusPublisher busPublisher, ILogger<IBusPublisher> logger)
        {
            _locationRepository = locationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _busPublisher = busPublisher;
            _logger = logger;
        }
        public async Task HandleAsync(CreateLocationCommand command, ICorrelationContext context)
        {
            _logger.Log(LogLevel.Information, JsonConvert.SerializeObject(command));
            var location = new Location()
            {
                src_lat = command.src_lat,
                src_long = command.src_long,
                des_lat = command.des_lat,
                des_long = command.des_long,
            };
            await _locationRepository.CreateProductAsync(location);
            var result = _unitOfWork.SaveChanges();
            if (result > 0)
            {
                await _busPublisher.PublishAsync(new LocationCreatedEvent(
                    command.src_long,
                    command.src_lat,
                    command.des_long,
                    command.des_lat
                ), context);

            }
        }
    }
}
