﻿using System;
using FluentPOS.Modules.Catalog.Core.Entities;
using FluentPOS.Shared.Core.Features.ExtendedAttributes.Commands.Validators;
using Microsoft.Extensions.Localization;

namespace FluentPOS.Modules.Catalog.Core.Features.ExtendedAttributes.Validators
{
    public class RemoveBrandExtendedAttributeCommandValidator : RemoveExtendedAttributeCommandValidator<Guid, Brand>
    {
        public RemoveBrandExtendedAttributeCommandValidator(IStringLocalizer<RemoveBrandExtendedAttributeCommandValidator> localizer) : base(localizer)
        {
            // you can override the validation rules here
        }
    }
}