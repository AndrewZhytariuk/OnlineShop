using AutoMapper;
using Calabonga.AspNetCore.Controllers.Handlers;
using Calabonga.AspNetCore.Controllers.Queries;
using Calabonga.UnitOfWork;
using Microservise.Entities;
using Microservise.Web.ViewModels.LogViewModels;
using System;

namespace Microservise.Web.Mediator.LogsReadonly
{
    /// <summary>
    /// Request for Log by Identifier
    /// </summary>
    public class LogGetByIdRequest : GetByIdQuery<LogViewModel>
    {
        public LogGetByIdRequest(Guid id) : base(id)
        {
        }
    }

    /// <summary>
    /// Response for  Request for Log by Identifier
    /// </summary>
    public class LogGetByIdRequestHandler : GetByIdHandlerBase<LogGetByIdRequest, Log, LogViewModel>
    {
        public LogGetByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
