using AutoMapper;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_E_Learning.Utility;
using MVC_E_Learning.ViewModels;

namespace MVC_E_Learning.Controllers
{
    public class InstructorController : Controller
    {
    
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _usermanager;
		private readonly IUserRepository _userRep;

		public InstructorController(IUnitOfWork unitOfWork, IMapper mapper , 
            UserManager<AppUser> usermanager,
            IUserRepository userRep)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _usermanager = usermanager;
			_userRep = userRep;
		}



    //    public async Task<IActionResult> Index()
    //    {

    //        var AllInstructor = await _userRep.GetInstructors();
    //        var AllInstructorvm = _mapper.Map<IEnumerable<Instructor>, IEnumerable<InstructorVM>>(AllInstructor);
    //        return View(AllInstructorvm);
    //    }


    //    public async Task<IActionResult> Details(int id)
    //    {
    //        return await ReturnViewWithTopics(id, nameof(Details));
    //    }

    //    public async Task<IActionResult> Create()
    //    {

    //        return View();
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Create(InstructorVM modelVm)
    //    {
    //        if (ModelState.IsValid)
    //        {

    //            var model = _mapper.Map<InstructorVM, AppUser>(modelVm);

    //            model.ImageName = DocumentSettings.UploadFile(modelVm.Image, "Images");
    //            model.Id = Guid.NewGuid().ToString();

    //            model.UserName = modelVm.Email.Split("@")[0];
    //        var Resulte=   await _usermanager.CreateAsync(model, modelVm.Password);
    //            if(Resulte.Succeeded)
    //            {
    //                _usermanager.AddToRoleAsync(model, "Instructor");
    //                return RedirectToAction(nameof(Index));
    //            }

    //            return View(model);


    //        }

    //        return View(modelVm);
    //    }


    //    public async Task<IActionResult> Edite(string id)
    //    {
    //        var Date = await _usermanager.FindByIdAsync(id);
            
    //        var Datavm = _mapper.Map<InstructorVM>(Date);



    //        return View(Datavm);
    //    }



    //    [HttpPost]
    //    public async Task<IActionResult> Edite(InstructorVM Datavm, [FromRoute] string id)
    //    {
    //        if (id != Datavm.Id)
    //            return BadRequest();
    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                Datavm.UserName = Datavm.Email.Split("@")[0];
    //                if (Datavm.ImageName!=null)
    //                {
    //                    DocumentSettings.DeleteFile(Datavm.ImageName, "Images");
    //                    DocumentSettings.UploadFile(Datavm.Image, "Images");

    //                }
    //                var Data = await _usermanager.FindByIdAsync(id);

    //                //Data.Email = Datavm.Email;
    //                //Data.Youtube = Datavm.Youtube;
    //                //Data.Facebook = Datavm.Facebook;
    //                //Data.Linkedin = Datavm.Linkedin;
    //                //Data.UserName = Datavm.UserName;
    //                //Data.JobTitle = Datavm.JobTitle;

    //                //var model= _mapper.Map<InstructorVM, AppUser>(Datavm);

    //                var resulte=     await _usermanager.UpdateAsync(Data);

    //                return RedirectToAction(nameof(Index));
    //            }
    //            catch (Exception ex)
    //            {
    //                ModelState.AddModelError("", ex.Message);
    //            }
    //        }
    //        return View(Datavm);
    //    }


    //    [HttpPost]
    //    public async Task<IActionResult> Delete(string id)
    //    {
    //        var Instructor = await _userRep.DeleteInstructorAsync(id);
    //        if (Instructor == null)
    //        {
    //            return NotFound();
    //        }
    //        return RedirectToAction("Index", "Instructor"); // Return the deleted item as JSON
    //    }


    //    //[HttpPost]
    //    //public async Task<IActionResult> Delete(TopicVM TopicVM, [FromRoute] int id)
    //    //{
    //    //    if (id != TopicVM.Id)
    //    //        return BadRequest();
    //    //    try
    //    //    {
    //    //        _unitOfWork.Topics.Delete(_mapper.Map<TopicVM, Topic>(TopicVM));
    //    //        await _unitOfWork.CompleteAsync();
    //    //        return RedirectToAction(nameof(Index));
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        ModelState.AddModelError("", ex.Message);
    //    //    }
    //    //    return View(TopicVM);

    //    //}

    }
}
