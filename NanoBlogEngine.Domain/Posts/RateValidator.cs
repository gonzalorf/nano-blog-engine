﻿using FluentValidation;

namespace NanoBlogEngine.Domain.Posts;

public class RateValidator : AbstractValidator<Rate>
{
    public RateValidator()
    {
        _ = RuleFor(p => p.Value).ExclusiveBetween(1, 5);
    }

    public static void ValidateRate(Rate Rate)
    {
        var validator = new RateValidator();
        var validationResult = validator.Validate(Rate);

        if (!validationResult.IsValid)
        {
            throw new RateInvalidValueException(validationResult.ToString());
        }
    }
}