using api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Common
{
    public class StepProcessTemplate<TStepModel, TApplication, TCommand>
        : IStepProcessTemplate<TStepModel, TCommand>
    {
        private ICommandValidator<TCommand> _commandValidator;
        private ICommandSender<TCommand> _commandSender;
        private Action<IList<IError>> _onError;

        public StepProcessTemplate(ICommandValidator<TCommand> commandValidator, ICommandSender<TCommand> commandSender, Action<IList<IError>> onError)
        {
            _commandValidator = commandValidator;
            _commandSender = commandSender;
            _onError = onError;
        }

        public async Task<IStepProcessResult> Process(TStepModel step, TCommand command)
        {
            var errors = await _commandValidator.Validate(command);
            if (errors.Count == 0)
            {
                return await _commandSender.Send(command);
            }

            _onError(errors);

            return StepProcessResult.Failed("Failed");
        }
    }
}
