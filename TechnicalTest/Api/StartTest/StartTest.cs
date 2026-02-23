
using Microsoft.Extensions.Logging;
using TechnicalTest.Aplication.DTO_s;
using TechnicalTest.Aplication.Interface;
using TechnicalTest.Domain.Entities;

namespace TechnicalTest.Api.StartTest

{
    public class StartTest :IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        
        private readonly ILogger<StartTest> _logger;

        public StartTest(IServiceScopeFactory scopeFactory, ILogger<StartTest> logger)
        {
           _scopeFactory = scopeFactory;
           _logger = logger;
        }

        public async Task StartAsync (CancellationToken ct)
        {
            

            try
            {

                using var scope = _scopeFactory.CreateScope();

                var client = scope.ServiceProvider.GetRequiredService<IRegionListClient>();
                var service = scope.ServiceProvider.GetRequiredService<ICrudRegionService>();
                _logger.LogInformation("Probando conexión con API externa...");


                var sortBy = "";
                var sortDirection = "";

                //consume endpoint /api/v1/Region
                _logger.LogInformation("consumiendo endpoint /api/v1/Region");
                var listRegion = await client.GetRegionListAsync(sortBy, sortDirection, ct);
                //_logger.LogInformation("resultado api {count}", listRegion.Count);


                //crea todos los registros obtenidos en la bd
                _logger.LogInformation("Creando en DB los registros encontrados...");
                foreach (var item in listRegion) 
                {
                    

                    var existsId = await service.GetByExternalIdAsync(item.Id,ct);
                    if (existsId is null)
                    {
                        var entity = new CreateRegionDTO
                        {
                            RecordId = item.Id,
                            Name = item.Name,
                            Description = item.Description
                        };

                        await service.CreateRecordAsync(entity, ct);
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

                        await service.UpdateAsync(existsId.Id, updateDto, ct);
                        _logger.LogInformation("Registro actualizado en BD: {id} {name}", item.Id, item.Name);

                        

                    }
                }


                //consume endpoint /api/v1/Region/{id}
                _logger.LogInformation("consumiendo endpoint /api/v1/Region/{id}");
                var id = 1;
                _logger.LogInformation("id = 1");
                var region = await client.GetRegionByIdAsync(id, ct);
                if (region == null)
                {
                    _logger.LogInformation("Registro no encontrado");
                }
                else
                {
                    _logger.LogInformation("Respuesta Servicio: {id} {name}", region.Id, region.Name);
                }

                //lista todos los endpoints de la base de datos 
                _logger.LogInformation("Listando registros creados en DB sql server");
                var recordList  = await service.GetAllAsync(ct);
                foreach (var record in recordList)
                {
                    _logger.LogInformation("id: {id}, Id Servicio: {servicio}, nombre: {name}",record.Id, record.RecordId, record.Name);
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
