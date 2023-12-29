using FinancialApp.Application.Queries.Commands;
using FinancialApp.Application.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet(nameof(GetAll))]
    public async Task<List<TransactionDto>> GetAll()
    {
        return await _mediator.Send(new GetTransactionsCommand());
    }


    [HttpGet(nameof(Get) + "/{id}")]
    public async Task<TransactionDto> Get([FromRoute] int id)
    {
        return await _mediator.Send(new GetTransactionCommand(id));
    }

    [HttpPost(nameof(Add))]
    public async Task Add([FromBody] TransactionToAddDto transactionToAddDto)
    {
        await _mediator.Send(new AddTransactionCommand(transactionToAddDto));
    }

    [HttpDelete(nameof(Delete) + "/{id}")]
    public async Task Delete([FromRoute] int id)
    {
        await _mediator.Send(new DeleteTransactionCommand(id));
    }

    [HttpGet(nameof(GetTotalAmount))]
    public async Task<double> GetTotalAmount()
    {
        return await _mediator.Send(new GetTotalAmountCommand());
    }
}
