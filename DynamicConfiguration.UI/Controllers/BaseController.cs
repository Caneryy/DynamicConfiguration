using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicConfiguration.DAL;
using DynamicConfiguration.Model;
using Microsoft.AspNetCore.Mvc;

namespace DynamicConfiguration.UI.Controllers
{
    public abstract class BaseController<TModel> : Controller where TModel : BaseModel
    {
        public BaseRepository<TModel> BaseRepository { get; set; }
        public BaseController(BaseRepository<TModel> baseRepository)
        {
            this.BaseRepository = baseRepository;
        }
        public virtual IActionResult Index()
        {
            var list = this.BaseRepository.GetList();
            return View(list);
        }

        public virtual IActionResult Edit(string id)
        {
            var model = this.BaseRepository.GetById(id);
            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Edit(string id, [Bind("Name,IsActive,Value,Type,ApplicationName,Id")] TModel model)
        {
            try
            {
                this.BaseRepository.Update(id, model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,IsActive,Value,Type,ApplicationName")]TModel model)
        {
            this.BaseRepository.Create(model);
            return RedirectToAction(nameof(Index));
        }
    }
}