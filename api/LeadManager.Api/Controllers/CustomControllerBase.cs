﻿using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace LeadManager.Api.Controllers;

public class CustomControllerBase : ControllerBase
{
    private readonly ICollection<string> _errors = new List<string>();

    protected ActionResult CustomResponse(object? result = null)
    {
        if (IsOperationValid())
        {
            return Ok(result);
        }

        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
        {
            { "Messages", _errors.ToArray() }
        }));
    }

    protected ActionResult CustomResponse(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            AddError(error.ErrorMessage);
        }

        return CustomResponse();
    }

    protected bool IsOperationValid()
    {
        return !_errors.Any();
    }

    protected void AddError(string erro)
    {
        _errors.Add(erro);
    }
}
