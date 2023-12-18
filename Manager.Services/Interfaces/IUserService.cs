using Manager.Services.DTO;

namespace Manager.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
        Task Delete(long id);
        Task<UserDTO> Get(long id);
        Task<List<UserDTO>> GetAll();
        Task<List<UserDTO>> SearchByEmail(string email);
        Task<List<UserDTO>> SearchByName(string name);
        Task<UserDTO> GetByEmail(string email);
    }
}
