using AutoMapper;
using BLL.Interfaces;
using BLL.Repository;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using MVC_E_Learning.ViewModels;

namespace MVC_E_Learning.Controllers
{
    public class TopicController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITopicRepository _topicRepository;

        public TopicController(IMapper mapper, ITopicRepository topicRepository)
        {
            _mapper = mapper;
            _topicRepository = topicRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var Topics = await _topicRepository.GetTopics();
            var mappedTopics = _mapper.Map<List<Topic>, List<TopicVM>>(Topics);
            return View(mappedTopics);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var topic = await _topicRepository.GetTopicById(id);
            var mappedTopic = _mapper.Map<Topic,TopicVM>(topic);

            return View(mappedTopic);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TopicVM TopicVM)
        {
            if (ModelState.IsValid)
            {

                var topic = _mapper.Map<TopicVM, Topic>(TopicVM);
                await _topicRepository.AddTopic(topic);

                return RedirectToAction(nameof(Index));
            }

            return View(TopicVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var topic = await _topicRepository.GetTopicById(id);
            var mappedTopic = _mapper.Map<Topic, TopicVM>(topic);
            return View(mappedTopic);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TopicVM topicVM)
        {
            try
            {
                var mappedData = _mapper.Map<TopicVM, Topic>(topicVM);
                _topicRepository.EditTopic(mappedData);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(topicVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var topic = await _topicRepository.GetTopicById(id);
            if (topic != null)
            {
                var mapped = _mapper.Map<Topic, TopicVM>(topic);
                return View(mapped);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(TopicVM topicVM)
        {
            try
            {
                _topicRepository.GetTopicById(topicVM.Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction(nameof(Index));
            }

        }
    }
}
