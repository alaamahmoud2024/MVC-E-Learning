using AutoMapper;
using BLL.Interfaces;
using BLL.ViewModels;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_E_Learning.ViewModels;

namespace MVC_E_Learning.Controllers
{
    public class CourseController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITopicRepository _topicRepository;

        public CourseController(IMapper mapper, 
            ICourseRepository courseRepository,
            IUserRepository userRepository,
            ITopicRepository topicRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _topicRepository = topicRepository;
        }


        public async Task<IActionResult> Index()
        {

            var Courses = await _courseRepository.GetCourses();
            if (Courses != null)
            {
                var mapped = _mapper.Map<List<Course>,List<CourseVM>>(Courses);
                return View(mapped);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var Course = await _courseRepository.GetCourseById(id);
            var topics = await _topicRepository.GetTopics();
            var mappedTopics = _mapper.Map<List<Topic>, List<TopicVM>>(topics);
            ViewBag.Topics = mappedTopics;

            if (Course != null)
            {
                var mapped = _mapper.Map<Course, CourseVM>(Course);
                return View(mapped);
            }
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var topics = await _topicRepository.GetTopics();
            var mappedTopics = _mapper.Map<List<Topic>, List<TopicVM>>(topics);
            ViewBag.Topics = mappedTopics;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseVM courseVM)
        {
            try
            {
                var course = _mapper.Map<CourseVM, Course>(courseVM);
                await _courseRepository.AddCourse(course);
                return RedirectToAction(nameof(Index));

            }
            catch
            {

                return View(courseVM);
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            var Course = await _courseRepository.GetCourseById(id);
            var topics = await _topicRepository.GetTopics();
            var mappedTopics = _mapper.Map<List<Topic>, List<TopicVM>>(topics);
            ViewBag.Topics = mappedTopics;

            if (Course != null)
            {
                var mapped = _mapper.Map<Course, CourseVM>(Course);
                return View(mapped);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseVM courseVM)
        {   
            try
            {
                var mappedData =_mapper.Map<CourseVM, Course>(courseVM);
                _courseRepository.EditCourse(mappedData);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(courseVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Course = await _courseRepository.GetCourseById(id);
            if (Course != null)
            {
                var mapped = _mapper.Map<Course, CourseVM>(Course);
                return View(mapped);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(CourseVM model)
        {
            try
            {
                _courseRepository.DeleteCourse(model.Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction(nameof(Index));
            }

        }
        [HttpGet]
        public async Task<IActionResult> AssignToInstructor()
        {
            var instructors = await _userRepository.GetInstructors();
            var courses = await _courseRepository.GetCourses();
            var assignedCoursesAndInstructors = await _courseRepository.GetAssignedCoursesAndInstructor();
            if(assignedCoursesAndInstructors != null)
            {                
                ViewBag.instructors = instructors;
			    ViewBag.courses = courses;
			    ViewBag.assignedCoursesAndInstructors = assignedCoursesAndInstructors;
                return View();

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AssignToInstructor(InstructorCourseVM model)
        {
            await _courseRepository.AssignCourseToInstructor(model);
            return RedirectToAction("AssignToInstructor");

        }

        public IActionResult DeleteAssigned(InstructorCourseVM model)
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteAssigned(int id)
        {
            try
            {
                _courseRepository.DeleteAssignedCourse(id);
                return RedirectToAction("AssignToInstructor");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("AssignToInstructor");
            }

        }

    }
}
