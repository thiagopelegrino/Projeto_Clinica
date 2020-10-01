using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;

namespace Projeto.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        //atributo
        private readonly IPacienteApplicationService service;

        public PacienteController(IPacienteApplicationService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Post(PacienteCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.Cadastrar(model);
                    var result = new
                    {
                        message = "Paciente cadastrado com sucesso"
                    };
                    return Ok(result);
                }

                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }

            }
            else
            {
                return BadRequest(); //HTTP 400 
            }
        }

        [HttpPut]
        public IActionResult Put(PacienteEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.Atualizar(model);
                    var result = new
                    {
                        message = "Paciente atualizado com sucesso"
                    };
                    return Ok(result);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest(); //HTTP 400 
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Excluir(id);
                var result = new { message = "Paciente excluído com sucesso" };
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(service.Consultar());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(service.ObterPorId(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}