using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShop.CategoryData.Interfaces;
using OnlineShop.CategoryData.Repository.Base.Interfaces;
using OnlineShop.CategoryData.Repository.Constants;
using OnlineShop.Lib.Logging;
using OnlineShop.Lib.Common.Converters;
using OnlineShop.Lib.Repositories;

namespace OnlineShop.CategoryData.Repository.Base
{
    public abstract class RepoControllerBase<T> : ControllerBase where T : class, IIdentifiable
    {
        protected readonly IRepos<T> EntitiesRepo;
        protected readonly ILogger<T> _logger;

        protected abstract void UpdateProperties(T scope, T destination);

        public RepoControllerBase(IRepos<T> entitiesRepo, ILogger<T> logger)
        {
            EntitiesRepo = entitiesRepo;
            _logger = logger;
        }

        [HttpPost(RepoActions.Add)]
        public async Task<IActionResult> Add([FromBody] T entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values);
                }

                var articleId = await EntitiesRepo.AddAsync(entity);
                return Ok(articleId);
            }
            catch (Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(T))
                    .WithMethod(nameof(RepoActions.Add))
                    .WithComment(ex.ToString())
                    .WithParameters($"{nameof(entity.Id)}: {entity.Id}")
                    .ToString()
                    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpPost(RepoActions.AddRange)]
        public async Task<IActionResult> Add([FromBody] IEnumerable<T> entitis)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values);
                }

                var articleIds = await EntitiesRepo.AddRangeAsync(entitis);

                return Ok(articleIds);
            }
            catch (Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(T))
                    .WithMethod(nameof(RepoActions.AddRange))
                    .WithComment(ex.ToString())
                    .WithParameters($"A collections of entities with ids: {ConverterToString<T>.IdsToString(entitis)} not added")
                    .ToString()
                    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOne(Guid id)
        {
            try
            {
                var article = await EntitiesRepo.GetOneAsync(id);

                return Ok(article);
            }
            catch (Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(T))
                    .WithMethod(nameof(GetOne))
                    .WithComment(ex.ToString())
                    .WithParameters($"{nameof(id)}: {id}")
                    .ToString()
                    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpGet(RepoActions.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var article = await EntitiesRepo.GetAllAsync();

                return Ok(article);
            }
            catch (Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(T))
                    .WithMethod(nameof(RepoActions.GetAll))
                    .WithComment(ex.ToString())
                    .WithParameters(LoggingConstants.NoParameters)
                    .ToString()
                    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpPost(RepoActions.Update)]
        public async Task<IActionResult> Update([FromBody] T entry)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values);
                }

                var entityToBeUpdated = await EntitiesRepo.GetOneAsync(entry.Id);

                if (entityToBeUpdated == null)
                    return BadRequest($"Entity with id = {entry.Id} was not found");

                UpdateProperties(entry, entityToBeUpdated);
                await EntitiesRepo.SaveAsync(entityToBeUpdated);

                return Ok(entityToBeUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(T))
                    .WithMethod(nameof(RepoActions.Update))
                    .WithComment(ex.ToString())
                    .WithParameters($"{nameof(entry.Id)}: {entry.Id}")
                    .ToString()
                    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpPost(RepoActions.Remove)]
        public async Task<IActionResult> Remove([FromBody] Guid id)
        {
            try
            {
                await EntitiesRepo.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(T))
                    .WithMethod(nameof(RepoActions.Remove))
                    .WithComment(ex.ToString())
                    .WithParameters($"{nameof(id)}: {id}")
                    .ToString()
                    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpPost(RepoActions.RemoveRange)]
        public async Task<IActionResult> Remove([FromBody] IEnumerable<Guid> ids)
        {
            try
            {
                await EntitiesRepo.DeleteRangeAsync(ids);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(T))
                    .WithMethod(nameof(RepoActions.RemoveRange))
                    .WithComment(ex.ToString())
                    .WithParameters($"A collections of entities with ids: {ConverterToString<Guid>.IdsToString(ids)} not added")
                    .ToString()
    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

    }
}
