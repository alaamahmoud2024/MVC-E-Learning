using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MVC_E_Learning.ViewModels;

namespace MVC_E_Learning.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITopicRepository _opicRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;
        public DashBoardController(IUnitOfWork unitOfWork, IMapper mapper, ITopicRepository opicRepository,
            ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _opicRepository = opicRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var totalCourse = _courseRepository.GetCoursesCount();
            var totalTopics = _opicRepository.GetTopicsCount();
            var totalUseres = _userRepository.GetUsersCount();
            var totalInstructor = _userRepository.GetInstructorsCount();
            var totalStudent = _userRepository.GetStudentsCount();
            //var totalAssign = _unitOfWork.Assignments.GetTotal();
            var model = new DashBoardVM
            {
                TotalUseres = totalUseres,
                TotalCourses = totalCourse,
                TotalTopics = totalTopics,
                TotalInstructor = totalInstructor,
                TotalStudent = totalStudent,

            };
            return View();

        }
    }
}
