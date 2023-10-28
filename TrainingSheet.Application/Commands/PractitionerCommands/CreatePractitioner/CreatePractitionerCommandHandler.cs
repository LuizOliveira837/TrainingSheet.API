using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.PractitionerCommands.CreatePractitioner
{
    public class CreatePractitionerCommandHandler : IRequestHandler<CreatePractitionerCommand, int>
    {
        private readonly TrainingSheetDbContext _dbContext;

        public CreatePractitionerCommandHandler(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
           
        }
        public async Task<int> Handle(CreatePractitionerCommand request, CancellationToken cancellationToken)
        {
            var practitioner = new Practitioner(request.FullName, request.BirthDate, request.Email, request.Password);

            await _dbContext.Practitioners.AddAsync(practitioner);

            await _dbContext.SaveChangesAsync();

            return practitioner.Id;
        }
    }
}
