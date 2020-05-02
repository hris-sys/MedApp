using AutoMapper;
using ToDo.Data;

namespace ToDo.Services
{
    public abstract class BaseService
    {
        protected BaseService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }

        protected ApplicationDbContext DbContext { get; }

        protected IMapper Mapper { get; }

        //ToDo: GetAll, GetAllByFilter
    }
}
