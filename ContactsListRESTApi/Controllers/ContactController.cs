
using ContactsListRESTApi.Models;
using ContactsListRESTApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactsListRESTApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
    public ContactController() { }

    [HttpGet]
    public ActionResult<List<Contact>> GetAll() => ContactService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Contact> Get(int id)
    {
        var contact = ContactService.Get(id);
        if (contact is null) return NotFound();
        return contact;
    }

    [HttpPost]
    public IActionResult Create(Contact contact) {
        ContactService.Add(contact);
        return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
    }

    [HttpPut]
    public IActionResult Update(int id, Contact contact) {
        var c = ContactService.Get(id);
        if (c is null) return NotFound();
        ContactService.Update(contact);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        var contact = ContactService.Get(id);
        if (contact is null) return NotFound();
        
        ContactService.Delete(id);
        return NoContent();

    }
}