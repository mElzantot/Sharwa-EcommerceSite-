using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data.Repositories.Managers
{
    public class ImageManager:Reposiotry<ApplicationDbContext,Image>,IImageManager
    {
        public ImageManager(ApplicationDbContext context):base(context)
        {

        }
    }
}
