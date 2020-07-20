using Application.Common.Interfaces;
using AutoMapper;

namespace Application.Common.Handlers
{
    public abstract class CommandBaseHandler
    {
        protected readonly IApplicationContext context;
        protected readonly IMapper mapper;

        protected CommandBaseHandler(IApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    }
}
