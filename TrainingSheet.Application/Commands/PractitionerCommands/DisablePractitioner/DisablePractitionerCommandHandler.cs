using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.Commands.PractitionerCommands.DisablePractitioner;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.PractitionerCommands.DeletePractitioner
{
    public class DisablePractitionerCommandHandler : IRequestHandler<DisablePractitionerCommand, Unit>
    {
        private readonly TrainingSheetDbContext _dbContext;

        public DisablePractitionerCommandHandler(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DisablePractitionerCommand request, CancellationToken cancellationToken)
        {

            var practitioner = await _dbContext
                .Practitioners
                .SingleOrDefaultAsync(p => p.Id == request.Id);

            practitioner.Disable();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}