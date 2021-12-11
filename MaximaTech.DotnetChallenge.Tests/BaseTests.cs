using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MaximaTech.DotnetChallenge.Domain.Models;

namespace MaximaTech.DotnetChallenge.Tests
{
    public class BaseTests<TModel> where TModel : BaseModel
    {
        protected IList<ValidationResult> ValidateModel(TModel model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);

            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
