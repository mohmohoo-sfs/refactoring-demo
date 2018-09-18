using api.Common;
using api.Interfaces;
using System;
using System.Collections.Generic;

namespace api.Products.IncomeProtection
{
    public class IncomeProtectionStep2
        : IIncomeProductionStep<IApplicationStep2Model, IStep2Command>
    {
        private ICommandValidator<IStep2Command> _commandValidator_step2;
        private ICommandSender<IStep2Command> _commandSender_step2;
        private Action<IList<IError>> _onError;

        public IncomeProtectionStep2(ICommandValidator<IStep2Command> commandValidator, ICommandSender<IStep2Command> commandSender)
        {
            _commandValidator_step2 = commandValidator;
            _commandSender_step2 = commandSender;
        }


        public IIncomeProductionStep<IApplicationStep2Model, IStep2Command> OnError(Action<IList<IError>> onError)
        {
            return new IncomeProtectionStep2(_commandValidator_step2, _commandSender_step2)
            {
                _onError = onError
            };
        }

        public IIncomeProductionApplication GetFullApplicationObject(IApplicationStep2Model stepData)
        {
            // create new application object with updated step 1 data
            throw new NotImplementedException();
        }

        public IStepProcessTemplate<IApplicationStep2Model, IStep2Command> GetTemplate()
        {
            return new StepProcessTemplate<IApplicationStep2Model, IIncomeProductionApplication, IStep2Command>(
                _commandValidator_step2, _commandSender_step2, _onError);
        }
    }
}
