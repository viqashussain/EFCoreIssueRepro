using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreIssueRepro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly GetTagsQuery getTagsQuery;

        public ValuesController(GetTagsQuery getTagsQuery)
        {
            this.getTagsQuery = getTagsQuery;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Tag>> Get()
        {
            return await getTagsQuery.Execute();
        }
    }
}
