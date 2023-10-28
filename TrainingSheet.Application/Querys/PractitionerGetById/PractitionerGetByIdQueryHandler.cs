using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.Practitioner;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Querys.PractitionerGetById
{
    public class PractitionerGetByIdQueryHandler : IRequestHandler<PractitionerGetByIdQuery, PractitionerViewModel>
    {
        private readonly TrainingSheetDbContext _dbContext;

        public PractitionerGetByIdQueryHandler(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PractitionerViewModel> Handle(PractitionerGetByIdQuery request, CancellationToken cancellationToken)
        {
            var practitioner = await _dbContext.Practitioners.FirstOrDefaultAsync(p=> p.Id == request.Id);

            return new PractitionerViewModel(practitioner.FullName, practitioner.BirthDate, practitioner.Email);
        }
    }
}
