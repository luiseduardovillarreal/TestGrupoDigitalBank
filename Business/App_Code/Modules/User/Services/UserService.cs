using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<StandarResponseDTO> DeleteAsync(Guid idUser)
    {
        try
        {
            string resultExecutionStr = await _unitOfWork.UserRepository.DeleteAsync(idUser);

            if (string.IsNullOrWhiteSpace(resultExecutionStr))
                throw new FaultException("El repositorio no devolvió datos.");

            var resultStandar = JsonConvert.DeserializeObject<DTOQuerie<StandarResponseDTO>>(resultExecutionStr);

            if (resultStandar == null)
                throw new FaultException("Error al deserializar la respuesta.");

            if (!resultStandar.State)
                throw new FaultException("El servicio reportó un estado fallido.");

            if (resultStandar.Result.Data == null || resultStandar.Result.Data.Count == 0)
                return new StandarResponseDTO();

            return resultStandar.Result.Data[0];
        }
        catch (FaultException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new FaultException("Error interno en UserService: " + ex.Message);
        }
    }

    public async Task<List<UserDTO>> GetAsync()
    {
        try
        {
            string resultQueryStr = await _unitOfWork.UserRepository.GetAsync();

            if (string.IsNullOrWhiteSpace(resultQueryStr))
                throw new FaultException("El repositorio no devolvió datos.");

            var resultUsers = JsonConvert.DeserializeObject<DTOQuerie<UserDTO>>(resultQueryStr);

            if (resultUsers == null)
                throw new FaultException("Error al deserializar la respuesta.");

            if (!resultUsers.State)
                throw new FaultException("El servicio reportó un estado fallido.");

            if (resultUsers.Result.Data == null || resultUsers.Result.Data.Count == 0)
                return new List<UserDTO>();

            return resultUsers.Result.Data;
        }
        catch (FaultException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new FaultException("Error interno en UserService: " + ex.Message);
        }
    }

    public async Task<StandarResponseDTO> PostAsync(UserDTO user)
    {
        try
        {
            string resultExecutionStr = await _unitOfWork.UserRepository.PostAsync(user);

            if (string.IsNullOrWhiteSpace(resultExecutionStr))
                throw new FaultException("El repositorio no devolvió datos.");

            var resultStandar = JsonConvert.DeserializeObject<DTOQuerie<StandarResponseDTO>>(resultExecutionStr);

            if (resultStandar == null)
                throw new FaultException("Error al deserializar la respuesta.");

            if (!resultStandar.State)
                throw new FaultException("El servicio reportó un estado fallido.");

            if (resultStandar.Result.Data == null || resultStandar.Result.Data.Count == 0)
               return new StandarResponseDTO();

            return resultStandar.Result.Data[0];
        }
        catch (FaultException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new FaultException("Error interno en UserService: " + ex.Message);
        }
    }

    public async Task<StandarResponseDTO> PutAsync(UserDTO user)
    {
        try
        {
            string resultExecutionStr = await _unitOfWork.UserRepository.PutAsync(user);

            if (string.IsNullOrWhiteSpace(resultExecutionStr))
                throw new FaultException("El repositorio no devolvió datos.");

            var resultStandar = JsonConvert.DeserializeObject<DTOQuerie<StandarResponseDTO>>(resultExecutionStr);

            if (resultStandar == null)
                throw new FaultException("Error al deserializar la respuesta.");

            if (!resultStandar.State)
                throw new FaultException("El servicio reportó un estado fallido.");

            if (resultStandar.Result.Data == null || resultStandar.Result.Data.Count == 0)
                return new StandarResponseDTO();

            return resultStandar.Result.Data[0];
        }
        catch (FaultException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new FaultException("Error interno en UserService: " + ex.Message);
        }
    }
}