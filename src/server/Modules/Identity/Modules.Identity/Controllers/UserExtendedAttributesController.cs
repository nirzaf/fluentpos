﻿using System;
using System.Threading.Tasks;
using FluentPOS.Modules.Identity.Core.Entities;
using FluentPOS.Shared.Core.Constants;
using FluentPOS.Shared.Core.Features.ExtendedAttributes.Commands;
using FluentPOS.Shared.DTOs.ExtendedAttributes;
using FluentPOS.Shared.Infrastructure.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace FluentPOS.Modules.Identity.Controllers
{
    [Route(BaseController.BasePath + "/user/attributes")]
    public class UserExtendedAttributesController : ExtendedAttributesController<string, FluentUser>
    {
        private IMediator _mediatorInstance;
        protected override IMediator Mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();

        [Authorize(Policy = Permissions.UsersExtendedAttributes.ViewAll)]
        public override Task<IActionResult> GetAllAsync(PaginatedExtendedAttributeFilter<string> filter)
        {
            return base.GetAllAsync(filter);
        }

        [Authorize(Policy = Permissions.UsersExtendedAttributes.View)]
        public override Task<IActionResult> GetByIdAsync(Guid id, bool bypassCache)
        {
            return base.GetByIdAsync(id, bypassCache);
        }

        [Authorize(Policy = Permissions.UsersExtendedAttributes.Add)]
        public override Task<IActionResult> CreateAsync(AddExtendedAttributeCommand<string, FluentUser> command)
        {
            return base.CreateAsync(command);
        }

        [Authorize(Policy = Permissions.UsersExtendedAttributes.Update)]
        public override Task<IActionResult> UpdateAsync(UpdateExtendedAttributeCommand<string, FluentUser> command)
        {
            return base.UpdateAsync(command);
        }

        [Authorize(Policy = Permissions.UsersExtendedAttributes.Remove)]
        public override Task<IActionResult> RemoveAsync(Guid id)
        {
            return base.RemoveAsync(id);
        }
    }
}