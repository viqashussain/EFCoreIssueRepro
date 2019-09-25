using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreIssueRepro
{
    public class GetAssetsQuery
    {
        readonly DataContext dataContext;

        public GetAssetsQuery(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IEnumerable<Asset>> Execute()
        {
            var allAssets = await dataContext.Assets
                .Include(x => x.Tags)
                .ToListAsync();

            return allAssets;
        }
    }
}