using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using GW2OIC.GW2APIJSONDomain;

namespace GW2OIC.BLL
{
    public class GW2ObtainJSONItem
    {
        async public Task<GW2Item> GetItem(int id)
        {
            GW2Item item = new GW2Item();
            await item.CreateItem(id);
            return item;
        }
    }
}
