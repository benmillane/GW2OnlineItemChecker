using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using GW2OIC.GW2APIJSONDomain;

namespace GW2OIC.BLL
{
    /// <summary>
    /// Class used to call all API calling code and return an object for each type of API response.
    /// </summary>
    public class GW2ObtainAPIJSON
    {
        //Gets an item from the GW2 based on its id.
        async public Task<GW2Item> GetItem(int id)
        {
            GW2Item item = new GW2Item();
            await item.CreateItem(id);
            return item;
        }
    }
}
