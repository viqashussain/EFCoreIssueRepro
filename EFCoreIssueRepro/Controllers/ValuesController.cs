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
        readonly DataContext dataContext;

        public ValuesController(GetTagsQuery getTagsQuery, DataContext dataContext)
        {
            this.getTagsQuery = getTagsQuery;
            this.dataContext = dataContext;

            if (!dataContext.Assets.Any())
            {
                var tag = new Tag { TagID = 1, Name = "Tag 1" };
                var asset = new Asset { AssetID = 2, Name = "Asset 1", Tags = new List<Tag> { tag } };
                tag.Asset = asset;
                dataContext.Database.EnsureCreated();
                dataContext.Assets.Add(asset);
                dataContext.SaveChanges();
            }
        }

        // GET api/values
        [HttpGet]
        public async Task Get()
        {
            await getTagsQuery.Execute();
        }
    }
}
