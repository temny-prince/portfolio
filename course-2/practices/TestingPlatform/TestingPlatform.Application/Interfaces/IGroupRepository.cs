using TestingPlatform.Application.DTOs;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Application.Interfaces
{
    public interface IGroupRepository
    {
        /// <summary>
        /// Получить все группы.
        /// </summary>
        /// <returns>Массив групп.</returns>
        Task<List<GroupDTO>> GetAllAsync();

        /// <summary>
        /// Получить группу по id.
        /// </summary>
        /// <param name="id">Идентификатор группы</param>
        /// <returns></returns>
        Task<GroupDTO> GetByIdAsync(int id);

        /// <summary>
        /// Создать новую группу.
        /// </summary>
        /// <param name="groupDto">Модель создания новой группы.</param>
        /// <returns>Идентификатор новой группы .</returns>
        Task<int> CreateAsync(GroupDTO groupDto);

        /// <summary>
        /// Обновить информацию о группе.
        /// </summary>
        /// <param name="groupDto">Модель обновления группы.</param>
        Task UpdateAsync(GroupDTO groupDto);

        /// <summary>
        /// Удалить группу.
        /// </summary>
        /// <param name="id">Идентификатор группы.</param>
        Task DeleteAsync(int id);
    }
}
