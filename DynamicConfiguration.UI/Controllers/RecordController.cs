using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicConfiguration.DAL;
using DynamicConfiguration.Model;
using Microsoft.AspNetCore.Mvc;

namespace DynamicConfiguration.UI.Controllers
{
    public class RecordController : BaseController<Record>
    {
        public RecordController(RecordRepository recordRepository) : base(recordRepository)
        {
        }
    }
}