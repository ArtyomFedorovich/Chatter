using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatterCore
{
  public class DataValidation
  {
    #region Validation Rule Declaration
    public enum ValidationTarget
    {
      Login,
      Password,
    }
    internal class ValidationRule
    {
      public ValidationTarget TargetName { get; private set; }

      public delegate bool ValidationMethod(object target);
      public List<ValidationMethod> ValidationMethods { get; private set; }

      public ValidationRule(ValidationTarget targetName, ValidationMethod validationMethod)
      {
        TargetName = targetName;
        ValidationMethods.Add(validationMethod);
      }
      public ValidationRule(ValidationTarget targetName, List<ValidationMethod> validationMethods)
      {
        TargetName = targetName;
        ValidationMethods = validationMethods;
      }
      public bool InvokeValidation(object target)
      {
        bool valid = true;
        foreach (var method in ValidationMethods)
        {
          valid = method.Invoke(method);
          if (!valid)
          {
            return !valid;
          }
        }
        return valid;
      }
    }
    #endregion
    private Dictionary<ValidationTarget, List<ValidationRule>> validationRulesMap;
    internal DataValidation(List<ValidationRule> validationRules)
    {
      validationRulesMap = new Dictionary<ValidationTarget, List<ValidationRule>>();
      List<ValidationRule> targetValidationRules;
      foreach (var rule in validationRules)
      {
        targetValidationRules = validationRulesMap[rule.TargetName];
        if (targetValidationRules is null)
        {
          validationRulesMap.Add(rule.TargetName, new List<ValidationRule>() { rule });
        }
        else
        {
          targetValidationRules.Add(rule);
        }
      }
    }

    public bool Validate(ValidationTarget targetName, object targetValue)
    {
      List<ValidationRule> targetValidationRules = validationRulesMap[targetName];
      bool valid = true;
      foreach (var rule in targetValidationRules)
      {
        valid = rule.InvokeValidation(targetValue);
        if (!valid)
        {
          return !valid;
        }
      }
      return valid;
    }
  }
}
