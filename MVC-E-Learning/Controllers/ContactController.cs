using AutoMapper;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using MVC_E_Learning.ViewModels;

namespace MVC_E_Learning.Controllers
{
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        //public async Task<IActionResult> Index()
        //{

        //    var contacts = await _unitOfWork.Contacts.GetAllAsync();
        //    var mapped = _mapper.Map<IEnumerable<ContactVM>>(contacts);
        //    return View(mapped);
        //}

        //public async Task<IActionResult> Details(int id)
        //{
        //    return await ReturnViewWithContacts(id, nameof(Details));
        //}

        //public async Task<IActionResult> Create()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(ContactVM contactVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var contact = _mapper.Map<ContactVM, Contact>(contactVM);
        //        await _unitOfWork.Contacts.AddAsync(contact);
        //        await _unitOfWork.CompleteAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(contactVM);
        //}


        //public async Task<IActionResult> Edit(int id)
        // => await ReturnViewWithContacts(id, nameof(Edit));


        //[HttpPost]
        //public async Task<IActionResult> Edit(ContactVM contactVM, [FromRoute] int id)
        //{
        //    if (id != contactVM.Id)
        //        return BadRequest();
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _unitOfWork.Contacts.Update(_mapper.Map<ContactVM, Contact>(contactVM));
        //            await _unitOfWork.CompleteAsync();

        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("", ex.Message);
        //        }
        //    }
        //    return View(contactVM);
        //}

        //public async Task<IActionResult> Delete(int id)
        // => await ReturnViewWithContacts(id, nameof(Delete));


        //[HttpPost]
        //public IActionResult Delete(ContactVM contactVM, [FromRoute] int id)
        //{
        //    if (id != contactVM.Id)
        //        return BadRequest();
        //    try
        //    {
        //        _unitOfWork.Contacts.Delete(_mapper.Map<ContactVM, Contact>(contactVM));
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //    }
        //    return View(contactVM);

        //}



        //private async Task<IActionResult> ReturnViewWithContacts(int? id, string viewname)
        //{
        //    if (!id.HasValue)
        //        return BadRequest();
        //    var contact = await _unitOfWork.Contacts.GetAsync(id.Value);
        //    if (contact is null)
        //        return NotFound();
        //    return View(viewname, _mapper.Map<ContactVM>(contact));

        //}
    }
}
