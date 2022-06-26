using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.DataAccess;
using REST_API.Extras;
using REST_API.Models;
using REST_API.Models.Invoices;

namespace REST_API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class InvoicesController : ControllerBase
	{
		private readonly ICRUDBase<Invoice> _repo;

		public InvoicesController(ICRUDBase<Invoice> repo)
		{
			_repo = repo;
		}

		// GET: api/invoices
		[HttpGet]
		public async Task<ActionResult<IList<InvoiceResponseModel>>> GetAll()
		{
			try
			{
				IList<Invoice> invoices = await _repo.ReadAll();
				IEnumerable<InvoiceResponseModel> response = invoices.Select(i => new InvoiceResponseModel(i));
				return Ok(response);
			}
			catch (NullReferenceException)
			{
				return NotFound();
			}
		}

		// GET: api/invoices/jhds-ytrf-...
		[HttpGet("{id}")]
		public async Task<ActionResult<Invoice>> GetInvoice(string id)
		{
			try
			{
				if (string.IsNullOrEmpty(id)) return NotFound();

				Invoice invoice = await _repo.ReadById(new Guid(id));

				InvoiceResponseModel response = new InvoiceResponseModel(invoice);

				return Ok(response);
			}
			catch (NullReferenceException)
			{
				return NotFound();
			}
		}

		// POST: api/invoices
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Invoice>> Create(CreateInvoiceRequestModel model)
		{
			try
			{
				if (!model.Secret.ToGuid().IsValid()) return BadRequest();

				Invoice invoice = model.ToDomainModel();

				await _repo.Create(invoice);

				// return CreatedAtAction("GetToDoItem", new { id = toDoItem.Id }, toDoItem);
				return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, invoice);
			}
			catch (NullReferenceException)
			{
				return NotFound();
			}
			catch (FormatException)
			{
				return BadRequest();
			}
		}

		// PUT: api/invoices/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(string id, UpdateInvoiceRequestModel model)
		{
			try
			{
				if (id != model.Id) return BadRequest();

				if (model.Secret.ToGuid().IsValid()) return BadRequest();

				Invoice invoice = model.ToDomainModel();

				await _repo.Update(invoice);

				return NoContent();
			}
			catch (NullReferenceException)
			{
				return NotFound();
			}
		}

		// DELETE: api/invoices/5
		// [HttpDelete("{id}")]
		// public async Task<IActionResult> Delete(string id)
		// {
		// 	try
		// 	{
		// 		if (string.IsNullOrEmpty(id)) return NotFound();

		// 		await _repo.Delete(new Guid(id));

		// 		return NoContent();
		// 	}
		// 	catch (NullReferenceException)
		// 	{
		// 		return NotFound();
		// 	}
		// }
	}
}