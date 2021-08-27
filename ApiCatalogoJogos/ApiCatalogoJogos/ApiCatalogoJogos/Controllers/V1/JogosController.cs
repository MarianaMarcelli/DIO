﻿using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.Services;
using ApiCatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> ListarJogos([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1,50)] int quantidade = 5)
        {
            var jogos = await _jogoService.ListarJogos(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }

        [HttpGet("{idJogo: guid}")]
        public async Task<ActionResult<JogoViewModel>> SelecionarJogoId([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoService.SelecionarJogoId(idJogo);

            if (jogo == null)
                return NoContent();
            
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);

                return Ok(jogo);
            }
            catch (Exception)
            {
                return UnprocessableEntity("Já existe um jogo cadastrado com esses dados");
            }
          
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.AtualizarJogo(idJogo, jogoInputModel);

                return Ok();
            }
            catch (Exception)
            {
                return NotFound("Jogo não encontrado");
            }
        }

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarPrecoJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.AtualizarPrecoJogo(idJogo, preco);

                return Ok();
            }
            catch (Exception)
            {
                return NotFound("Jogo não encontrado");
            }
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ExcluirJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.ExcluirJogo(idJogo);

                return Ok();
            }
            catch (Exception)
            {
                return NotFound("Jogo não encontrado");
            }
        }



    }
}