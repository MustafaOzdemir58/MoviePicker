using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Application.ValidationModels
{
    public sealed class ValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
        public ValidationError(string propertyName, string errorMessage)
        {
            this.PropertyName = propertyName;
            this.ErrorMessage = errorMessage;
        }
    }
}
