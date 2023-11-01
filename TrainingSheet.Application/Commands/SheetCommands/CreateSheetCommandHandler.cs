using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.TrainingSheetCommands
{
    public class CreateSheetCommandHandler : IRequestHandler<CreateSheetCommand, int>
    {
        private readonly TrainingSheetDbContext _dbContext;

        public CreateSheetCommandHandler(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateSheetCommand request, CancellationToken cancellationToken)
        {
            var trainingSheet = new Sheet(request.SheetName, request.PractitionerId, request.StartedIn, request.FinishIn);

            await _dbContext.Sheets.AddAsync(trainingSheet);

            await _dbContext.SaveChangesAsync();

            return trainingSheet.Id;
        }
    }
}
