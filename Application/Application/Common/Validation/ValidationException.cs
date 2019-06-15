﻿namespace Application.Common.Validation
{
    using System;
    using System.Collections.Generic;

    public class ValidationException : Exception
    {
        public IList<ValidationError> Errors { get; private set; }
        public ValidationException():base()
        {
            this.Errors = new List<ValidationError>();
        }
    }
}