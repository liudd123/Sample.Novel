using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Sample.Novel.HttpApi.Host.Controllers
{
    public class BookController: AbpController
    {
        [HttpGet]
        public string Index()
        {
            return "123";
        }
    }
}
