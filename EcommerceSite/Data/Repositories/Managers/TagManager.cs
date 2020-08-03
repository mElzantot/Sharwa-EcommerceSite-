using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EcommerceSite.Data.Repositories.Managers
{
    public class TagManager:Reposiotry<ApplicationDbContext,Tag>,ITagManager
    {
        public TagManager(ApplicationDbContext context) : base(context)
        {

        }
        public IEnumerable<ProductsTags> GetProductsTags(string tag)
        {
            var tags = set.Where(t => t.Name.ToLower() == tag.ToLower() || ","+t.Name.ToLower()==tag.ToLower());
            if (tags!=null&& tags.Count()>0)
            {
                return set.Where(t => t.Name.ToLower() == tag.ToLower()).Include(t => t.ProductsTags).ThenInclude(prodTag=>prodTag.Product).FirstOrDefault().ProductsTags;
            }
            return null;
        }
    }
}
