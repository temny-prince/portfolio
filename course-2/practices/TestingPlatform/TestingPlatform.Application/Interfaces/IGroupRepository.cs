using TestingPlatform.Application.DTOs;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Application.Interfaces
{
    public interface IGroupRepository
    {
        List<GroupDTO> GetAll();

        GroupDTO GetById(int id);

        int Create(GroupDTO group);
        
        void Update(GroupDTO group);

        void Delete(int id);
    }
}
