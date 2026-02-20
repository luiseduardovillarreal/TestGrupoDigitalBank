using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IUserService
{

    [OperationContract]
    Task<StandarResponseDTO> DeleteAsync(Guid idUser);

    [OperationContract]
    Task<List<UserDTO>> GetAsync();

    [OperationContract]
    Task<StandarResponseDTO> PostAsync(UserDTO user);

    [OperationContract]
    Task<StandarResponseDTO> PutAsync(UserDTO user);
}