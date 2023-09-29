using FluentValidation;
using Loja_Games.Model;
using Loja_Games.Service;
using Microsoft.AspNetCore.Mvc;

namespace Loja_Games.Controller
{
    [Route("~/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IValidator<Produto> _produtoValidator;

        public ProdutoController(
            IProdutoService produtoService,
            IValidator<Produto> produtoValidator)
        {
            _produtoService = produtoService;
            _produtoValidator = produtoValidator;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _produtoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _produtoService.GetById(id);

            if (Resposta is null)
                return NotFound();

            return Ok(Resposta);
        }

        [HttpGet("console/{console}")]
        public async Task<ActionResult> GetByconsole(string console)
        {
            return Ok(await _produtoService.GetByConsole(console));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Produto produto)
        {
            var validarProduto = await _produtoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);
            }

            await _produtoService.Create(produto);
            var Resposta = await _produtoService.Create(produto);

            if (Resposta is null)
            {
                return BadRequest("Tipo não encontrado!");
            }

            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Produto produto)
        {
            if (produto.Id == 0)
            {
                return BadRequest("Id da produto é inválido");
            }

            var validarproduto = await _produtoValidator.ValidateAsync(produto);

            if (!validarproduto.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarproduto);
            }

            var Resposta = await _produtoService.Update(produto);

            if (Resposta is null)
            {
                return NotFound("Produto e/ou Tipo não encontrado!");
            }
            return Ok(Resposta);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var Buscaproduto = await _produtoService.GetById(id);

            if (Buscaproduto is null)
            {
                return NotFound("Produto não foi encontrado!");
            }

            await _produtoService.Delete(Buscaproduto);

            return NoContent();

        }
    }

 }
