using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreIssueRepro
{
    public class GetTagsQuery
    {
        readonly GetAssetsQuery getAssetsQuery;

        public GetTagsQuery(GetAssetsQuery getAssetsQuery)
        {
            this.getAssetsQuery = getAssetsQuery;
        }

        public async Task<IEnumerable<Tag>> Execute()
        {
            var allAssets = await getAssetsQuery.Execute();
            var allTags = allAssets.SelectMany(x => x.Tags);
            return allTags;
        }
    }
}