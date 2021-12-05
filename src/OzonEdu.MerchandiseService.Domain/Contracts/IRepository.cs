using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.Contracts
{
    /// <summary>
    /// Базовый интерфейс репозитория
    /// </summary>
    /// <typeparam name="TAggregationRoot">Объект сущности для управления</typeparam>
    public interface IRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Создать новую сущность
        /// </summary>
        /// <param name="ticketToCreate">Объект для создания</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Созданная сущность</returns>
        Task<TEntity> CreateAsync(TEntity ticketToCreate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновить существующую сущность
        /// </summary>
        /// <param name="ticketToUpdate">Объект для создания</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Обновленная сущность сущность</returns>
        Task<TEntity> UpdateAsync(TEntity ticketToUpdate, CancellationToken cancellationToken = default);
    }
}