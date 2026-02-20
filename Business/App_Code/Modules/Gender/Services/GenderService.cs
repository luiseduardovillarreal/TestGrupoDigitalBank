using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class GenderService : IGenderService
{
    private readonly IUnitOfWork _unitOfWork;

    public GenderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GenderDTO>> GetActivesAsync()
	{
        try
        {
            string resultQueryStr = await _unitOfWork.GenderRepository.GetActivesAsync();

            if (string.IsNullOrWhiteSpace(resultQueryStr))
                throw new FaultException("El repositorio no devolvió datos.");

            var resultGendersActives = JsonConvert.DeserializeObject<DTOQuerie<GenderDTO>>(resultQueryStr);

            if (resultGendersActives == null)
                throw new FaultException("Error al deserializar la respuesta.");

            if (!resultGendersActives.State)
                throw new FaultException("El servicio reportó un estado fallido.");

            if (resultGendersActives.Result.Data == null || resultGendersActives.Result.Data.Count == 0)
                return new List<GenderDTO>();

            return resultGendersActives.Result.Data;
        }
        catch (FaultException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new FaultException("Error interno en GenderService: " + ex.Message);
        }
    }
}