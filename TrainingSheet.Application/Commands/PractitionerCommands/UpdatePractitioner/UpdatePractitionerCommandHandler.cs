using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.PractitionerCommands.UpdatePractitioner
{
    public class UpdatePractitionerCommandHandler : IRequestHandler<UpdatePractitionerCommand, Unit>
    {
        public readonly TrainingSheetDbContext _dbcontext;
        public UpdatePractitionerCommandHandler(TrainingSheetDbContext context)
        {
            _dbcontext = context;
        }
        public async Task<Unit> Handle(UpdatePractitionerCommand request, CancellationToken cancellationToken)
        {
            var practitioner = await _dbcontext
                .Practitioners
                .SingleOrDefaultAsync(p => p.Id == request.Id);

            practitioner.Update(request.FullName, request.BirthDate, request.Email);

            await _dbcontext.SaveChangesAsync();
            await _dbcontext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
