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
    }
}