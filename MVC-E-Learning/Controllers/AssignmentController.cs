using AutoMapper;
using BL.ViewModels;
using BLL.Helpers;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using MVC_E_Learning.Utility;
using MVC_E_Learning.ViewModels;

namespace MVC_E_Learning.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAssignmentRepository _assignment;

        public AssignmentController(IUnitOfWork unitOfWork, IMapper mapper, IAssignmentRepository assignment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _assignment = assignment;
        }


        public async Task<IActionResult> Index()
        {

            var Assignments = await _assignment.GetAssignments();
            var mappedAssignments = _mapper.Map<List<Assignment>, List<AssignmentVM>>(Assignments);
            return View(mappedAssignments);
        }

        public async Task<IActionResult> Show(int id)
        {
            var Assignment = await _assignment.GetAssignmentById(id);
            var mappedAssignment = _mapper.Map<Assignment, AssignmentVM>(Assignment);
            return View(mappedAssignment);
        }

        public async Task<IActionResult> Create(int courseId)
        {
            ViewBag.CourseId = courseId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AssignmentVM model,int courseId)
        {
            try
            {
                var assignmentName = FileHelper.UploadFile("/wwwroot/Files/Assignment", model.Assignment);
                model.Name = assignmentName;
                model.CourseId = courseId;
                var assignment = _mapper.Map<AssignmentVM, Assignment>(model);
                _assignment.AddAssignment(assignment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }

        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(AssignmentVM AssignmentVM, [FromRoute] int id)
        //{
        //    if (id != AssignmentVM.Id)
        //        return BadRequest();
        //    try
        //    {
        //        _unitOfWork.Assignments.Delete(_mapper.Map<AssignmentVM, Assignment>(AssignmentVM));
        //        await _unitOfWork.CompleteAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //    }
        //    return View(AssignmentVM);

        //}

    }
}
