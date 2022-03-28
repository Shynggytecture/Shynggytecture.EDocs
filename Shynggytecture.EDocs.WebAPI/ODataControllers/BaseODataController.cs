using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.WebAPI.ODataControllers
{
    public abstract class BaseODataController<TEntity> : ODataController
        where TEntity : class
    {
        protected readonly DbContext BaseDbContext;

        public BaseODataController(DbContext dbContext)
        {
            BaseDbContext = dbContext;
        }

        [HttpGet]
        [EnableQuery]
        public virtual IActionResult Get() 
        {
            return Ok(this.BaseDbContext.Set<TEntity>().AsQueryable());
        }
    }
}
