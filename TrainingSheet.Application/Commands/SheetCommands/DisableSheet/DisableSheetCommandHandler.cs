using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.SheetCommands.DisableSheet
{
    public class DisableSheetCommandHandler : IRequestHandler<DisableSheetCommand, Unit>
    {
        private readonly ISheetRepository _repository;

        public DisableSheetCommandHandler(ISheetRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DisableSheetCommand request, CancellationToken cancellationToken)
        {
            _repository.DisableAsync(request.Id);

            return Unit.Value;
        }
    }
}
