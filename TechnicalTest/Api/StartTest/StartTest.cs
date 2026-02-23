
using Microsoft.Extensions.Logging;
using TechnicalTest.Aplication.DTO_s;
using TechnicalTest.Aplication.Interface;
using TechnicalTest.Domain.Entities;

namespace TechnicalTest.Api.StartTest

{
    public class StartTest :IHostedService
    {
        private readonly IRegionListClient _client;
        private readonly ICrudRegionService _service;
        private readonly ILogger<StartTest> _logger;

        public StartTest(IRegionListClient client, ICrudRegionService service, ILogger<StartTest> logger)
        {
           _client = client;
            _service = service;
           _logger = logger;
        }

        public async Task StartAsync (CancellationToken ct)
        {
            try
            {
                _logger.LogInformation("Probando conexión con API externa...");

                var sortBy = "";
                var sortDirection = "";

                var listRegion = await _client.GetRegionListAsync(sortBy, sortDirection, ct);
                //_logger.LogInformation("resultado api {count}", listRegion.Count);

                
                //crea todos los registros obtenidos en la bd
                foreach (var item in listRegion) 
                {
                    

                    var existsId = await _service.GetByExternalIdAsync(item.Id,ct);
                    if (existsId is null)
                    {
                        var entity = new CreateRegionDTO
                        {
                            RecordId = item.Id,
                            Name = item.Name,
                            Description = item.Description
                        };

                        await _service.CreateRecordAsync(entity, ct);
                        _logger.LogInformation("REgistro guardado en BD: {id} {name}", item.Id, item.Name);
                    }
                    else
                    {
                        //modifica los existentes
                        var updateDto = new RegionUpdateDTO
                        {
                            Name = item.Name,
                            Description = item.Description
                        };

                        await _service.UpdateAsync(existsId.Id, updateDto, ct);
                        _logger.LogInformation("Registro actualizado en BD: {id} {name}", item.Id, item.Name);

                    }
                }

                var id = 1;
                var region = await _client.GetRegionByIdAsync(id, ct);
                if (region == null)
                {
                    _logger.LogInformation("Registro no encontrado");
                }
                else
                {
                    _logger.LogInformation("Registro encontrado: {id} {name}", region.Id, region.Name);
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "ERROR probando conexión con API externa....");
                //throw;
            }

        }

        public Task StopAsync(CancellationToken ct) => Task.CompletedTask;
    }
}
