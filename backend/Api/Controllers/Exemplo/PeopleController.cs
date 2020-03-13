using Domain.Dto;
using Domain.Dto.Models.Exemplo;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.CustomException;
using System;
using System.Threading.Tasks;

namespace Api.Controllers.Exemplo
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private readonly PeopleService _service;

        public PeopleController(PeopleService service)
        {
            _service = service;
        }

        #region Get

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetById(id);

                return StatusCode(200, result);
            }
            catch (ValidationException e)
            {
                return StatusCode(400, new ErrorDto(e.Message));
            }
            catch (Exception)
            {
                // Erro desconhecido
                return StatusCode(500, new ErrorDto("Ocorreu um erro desconhecido na operação"));
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll( )
        {
            try
            {
                var result = await _service.GetAll();
                return StatusCode(200, result);
            }
            catch (ValidationException e)
            {
                return StatusCode(400, new ErrorDto(e.Message));
            }
            catch (Exception)
            {
                // Erro desconhecido
                return StatusCode(500, new ErrorDto("Ocorreu um erro desconhecido na operação"));
            }
        }

        #endregion

        #region Insert, update, delete

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]PeopleUpsertDto dto)
        {
            try
            {
                var id = await _service.Insert(dto);
                return StatusCode(201, new InsertedDto(id));
            }
            catch (ValidationException e)
            {
                return StatusCode(400, new ErrorDto(e.Message));
            }
            catch (Exception)
            {
                // Erro desconhecido
                return StatusCode(500, new ErrorDto("Ocorreu um erro desconhecido na operação"));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody]PeopleUpsertDto dto)
        {
            try
            {
                await _service.Update(dto);
                return StatusCode(204);
            }
            catch (ValidationException e)
            {
                return StatusCode(400, new ErrorDto(e.Message));
            }
            catch (Exception)
            {
                // Erro desconhecido
                return StatusCode(500, new ErrorDto("Ocorreu um erro desconhecido na operação"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _service.Delete(id);
                return StatusCode(204);
            }
            catch (ValidationException e)
            {
                return StatusCode(400, new ErrorDto(e.Message));
            }
            catch (Exception)
            {
                // Erro desconhecido
                return StatusCode(500, new ErrorDto("Ocorreu um erro desconhecido na operação"));
            }
        }

        #endregion
    }
}