using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShop.Application.Common.Validators
{
    public interface IValidationService
    {
        //Task<ValidationResult> ValidateAsync<T>(T request);

        Task<bool> ValidateAsync<T>(T request);
    }
}
