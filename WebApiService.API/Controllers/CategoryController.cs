using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiService.Application.Common.DTO.CategoryDto;
using WebApiService.Application.Common.Interfaces;
using WebApiService.Application.Mediator.Commands.CategoryCommands.CreateCategory;
using WebApiService.Application.Mediator.Commands.CategoryCommands.DeleteCategory;
using WebApiService.Application.Mediator.Commands.CategoryCommands.UpdateCategory;
using WebApiService.Application.Mediator.Queries.CategoryQueries.GetAllCategory;
using WebApiService.Application.Mediator.Queries.CategoryQueries.GetCategoryById;

namespace WebApiService.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        public CategoryController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Возвращает список всех категорий
        /// </summary>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IServiceResponse>> GetAllCategory()
        {
            return Ok(await _mediator.Send(new GetAllCategoryQuery()));
        }

        /// <summary>
        /// Возвращает одну запись по указанному идентификатору
        /// </summary>
        /// <param name="categoryId">Идентификатор записи в таблице Category</param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="404">Запись не найдена</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IServiceResponse>> GetCategoryById(int categoryId)
        {
            return Ok(await _mediator.Send(new GetCategoryByIdQuery()
            {
                CategoryId = categoryId
            }));
        }

        /// <summary>
        /// Добавляет запись в таблицу Category
        /// </summary>
        /// <param name="addCategoryDto"></param>
        /// <returns></returns>
        /// <response code="201"></response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IServiceResponse>> CreateCategory([FromBody] AddCategoryDto addCategoryDto)
        {
            var command = _mapper.Map<CreateCategoryCommand>(addCategoryDto);

            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Удаляет запись из таблицы Category
        /// </summary>
        /// <param name="categoryId">Идентификатор записи в таблице Category</param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="404">Запись не найдена</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IServiceResponse>> DeleteCategory(int categoryId)
        {
            return Ok(await _mediator.Send(new DeleteCategoryCommand()
            {
                CategoryId = categoryId
            }));
        }

        /// <summary>
        /// Обновляет запись в таблице Category
        /// </summary>
        /// <param name="updateCategoryDto"></param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="404">Запись не найдена</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IServiceResponse>> UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(updateCategoryDto);

            return Ok(await _mediator.Send(command));
        }
    }
}
