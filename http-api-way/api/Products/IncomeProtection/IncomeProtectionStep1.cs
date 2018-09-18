using api.Common;
using api.Interfaces;
using System;
using System.Collections.Generic;

namespace api.Products.IncomeProtection
{
    public class IncomeProtectionStep1
        : IIncomeProductionStep<IApplicationStep1Model, IStep1Command>
    {
        private ICommandValidator<IStep1Command> _commandValidator_step1;
        private ICommandSender<IStep1Command> _commandSender_step1;
        private Action<IList<IError>> _onError;

        public IncomeProtectionStep1(ICommandValidator<IStep1Command> commandValidator, ICommandSender<IStep1Command> commandSender)
        {
            _commandValidator_step1 = commandValidator;
            _commandSender_step1 = commandSender;
        }

        public IStepProcessTemplate<IApplicationStep1Model, IStep1Command> GetTemplate()
        {
            return new StepProcessTemplate<IApplicationStep1Model, IIncomeProductionApplication, IStep1Command>(
                _commandValidator_step1, _commandSender_step1, _onError);
        }

        public IIncomeProductionStep<IApplicationStep1Model, IStep1Command> OnError(Action<IList<IError>> onError)
        {
            return new IncomeProtectionStep1(_commandValidator_step1, _commandSender_step1)
            {
                _onError = onError
            };
        }

        public IIncomeProductionApplication GetFullApplicationObject(IApplicationStep1Model stepData)
        {
            throw new NotImplementedException();
        }
    }
}
