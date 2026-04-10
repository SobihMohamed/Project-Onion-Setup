using System;

namespace SoftBridge.Domain.Exceptions.NotFoundModels;

public class CategoryNotFoundException : NotFoundExceptionCustome
{
    public CategoryNotFoundException(string message) : base(message) {}
}
