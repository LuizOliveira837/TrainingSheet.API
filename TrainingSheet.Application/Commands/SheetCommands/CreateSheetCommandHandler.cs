using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.TrainingSheetCommands
{
    public class CreateSheetCommandHandler : IRequestHandler<CreateSheetCommand, int>
    {
        private readonly ISheetRepository _repository;

        public CreateSheetCommandHandler(ISheetRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateSheetCommand request, CancellationToken cancellationToken)
        {
            var trainingSheet = new Sheet(request.SheetName, request.PractitionerId, request.StartedIn, request.FinishIn);

            var id = await _repository.CreateAsync(trainingSheet);

            return id;
        }
    }
}
