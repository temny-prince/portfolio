using TestingPlatform.Application.DTOs;
using TestingPlatform.Domain.Models;
using TestingPlatform.Application.DTOs;

namespace TestingPlatform.Application.Interfaces
{
    public interface IGroupRepository
    {
        List<GroupDTO> GetAll();

        Group GetById(int id);

        int Create(GroupDTO group);
        
        void Update(GroupDTO group);

        void Delete(int id);
    }
}
