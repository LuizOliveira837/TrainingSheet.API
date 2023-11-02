using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.SheetCommands.DisableSheet
{
    public class DisableSheetCommandHandler : IRequestHandler<DisableSheetCommand, Unit>
    {
        private readonly TrainingSheetDbContext _dbContext;

        public DisableSheetCommandHandler(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DisableSheetCommand request, CancellationToken cancellationToken)
        {
            var sheet = await _dbContext
                 .Sheets
                 .SingleOrDefaultAsync(s => s.Id == request.Id);

            sheet.Disable();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
