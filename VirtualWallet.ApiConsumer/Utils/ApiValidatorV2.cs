using VirtualWallet.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualWallet.ApiConsumer.Utils
{
    public class ApiValidatorV2<R>
    {
        public R InputData { get; set; }
        public IDictionary<string, string> ErrorCodes { get; set; }
        public Action<ApiValidatorV2<R>> FindErrors { get; set; } = (validator) => { };
        public string ErrorMessagesConnector { get; set; } = ApiError.DefaultErrorConnector;
        public bool TechnicalErrorOccured { get; private set; } = false;
        public IList<ApiError> ErrorList { get; private set; }
        public string SuccessText { get; set; }

        public void AddError(string message, string additionalMessage = "")
        {
            ErrorList?.AddError($"{message} {additionalMessage}");
        }

        public void AddErrorByCode(string code, string additionalMessage = "")
        {
            ErrorList?.AddError(code, $"{ErrorCodes?.PickErrorMessage(code)} {additionalMessage}".Trim());
        }

        public void AddErrorByCodeOrText(string code, string text, string additionalMessage = "")
        {
            ErrorList?.AddError(code, $"{ErrorCodes?.PickErrorMessage(code, text)} {additionalMessage}");
        }

        public void Run()
        {
            try
            {
                ErrorList = new List<ApiError>();
                FindErrors(this);
            }
            catch (Exception ex)
            {
                TechnicalErrorOccured = true;
            }
        }


        public bool IsSuccess => SuccessText.HasValue();
    }
}
