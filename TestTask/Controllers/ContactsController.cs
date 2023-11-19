using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Implementations;
using TestTask.Services.Interfaces;

namespace TestTask.Controllers;

[Route("Contacts/")]
[Route("")]
public class ContactsController : Controller
{

    private readonly IContactService _contactService;

    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }
    
    [Route("")]
    public  IActionResult Index()
    {
        try
        {
            ContactsModel model = new ContactsModel(_contactService.GetContacts(), new Contact());
            return View(model);
        }
        catch (Exception e)
        {
            ErrorViewModel model = new ErrorViewModel(e);
            return View("Error", model);
        }
    }

    [HttpPost]
    [Route("Create")]
    public IActionResult Create(Contact contact)
    {
        try
        {
            _contactService.CreateContact(contact);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            ErrorViewModel model = new ErrorViewModel(e);
            return View("Error", model);
        }
    }

    [HttpPost]
    [Route("Update")]
    public IActionResult Update(Contact contact)
    {
        try
        {
            _contactService.UpdateContact(contact);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            ErrorViewModel model = new ErrorViewModel(e);
            return View("Error", model);
        }
        
    }
    
    [Route("GetContact")]
    public IActionResult GetContact(Contact contact)
    {
        try
        {
            return Json( _contactService.GetContact(contact.ContactId));
        }
        catch (Exception e)
        {
            ErrorViewModel model = new ErrorViewModel(e);
            return View("Error", model);
        }
    }
    
    [Route("Delete")]
    public IActionResult Delete(Contact contact)
    {
        try
        {
            _contactService.DeleteContact(contact.ContactId);
            return RedirectToAction("Index");        
        }
        catch (Exception e)
        {
            ErrorViewModel model = new ErrorViewModel(e);
            return View("Error", model);
        }
    }
    
    [Route("Error")]
    public IActionResult Error(Exception e)
    {
        ErrorViewModel model = new ErrorViewModel(e);
        return View(model);
    }
}