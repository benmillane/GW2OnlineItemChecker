using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GW2OIC.BLL;
using GW2OIC.GW2APIJSONDomain;

namespace GW2OIC.MVC.Controllers
{
    public class JSONController : Controller
    {
        //
        // GET: /JSON/
        async public Task<JsonResult> GetItem(int id)
        {
            GW2ObtainJSONItem obtain = new GW2ObtainJSONItem();
            GW2Item item = await obtain.GetItem(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
	}
}