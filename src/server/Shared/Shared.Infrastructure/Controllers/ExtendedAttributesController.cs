﻿using System;
using System.Threading.Tasks;
using FluentPOS.Shared.Core.Contracts;
using FluentPOS.Shared.Core.Features.ExtendedAttributes.Commands;
using FluentPOS.Shared.Core.Features.ExtendedAttributes.Queries;
using FluentPOS.Shared.DTOs.ExtendedAttributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FluentPOS.Shared.Infrastructure.Controllers
{
    [ApiController]
    public abstract class ExtendedAttributesController<TEntityId, TEntity> : ControllerBase
        where TEntity : class, IEntity<TEntityId>
    {
        protected abstract IMediator Mediator { get; }

        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync([FromQuery] PaginatedExtendedAttributeFilter<TEntityId> filter)
        {
            var extendedAttributes = await Mediator.Send(new GetAllPagedExtendedAttributesQuery<TEntityId, TEntity>(filter.PageNumber, filter.PageSize, filter.SearchString, filter.EntityId, filter.Type));
            return Ok(extendedAttributes);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetByIdAsync(Guid id, bool bypassCache)
        {
            var extendedAttribute = await Mediator.Send(new GetExtendedAttributeByIdQuery<TEntityId, TEntity>(id, bypassCache));
            return Ok(extendedAttribute);
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync(AddExtendedAttributeCommand<TEntityId, TEntity> command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public virtual async Task<IActionResult> UpdateAsync(UpdateExtendedAttributeCommand<TEntityId, TEntity> command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> RemoveAsync(Guid id)
        {
            return Ok(await Mediator.Send(new RemoveExtendedAttributeCommand<TEntityId, TEntity>(id)));
        }
    }
}