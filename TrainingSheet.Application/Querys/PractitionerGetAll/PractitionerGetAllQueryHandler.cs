using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.Practitioner;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Querys.PractitionerGetAll
{
    public class PractitionerGetAllQueryHandler : IRequestHandler<PractitionerGetAllQuery, IList<PractitionerViewModel>>
    {
        public readonly TrainingSheetDbContext _dbContext;

        public PractitionerGetAllQueryHandler(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<PractitionerViewModel>> Handle(PractitionerGetAllQuery request, CancellationToken cancellationToken)
        {
            var practitioners = _dbContext.Practitioners
                 .Where(p => p.Status == Core.Enums.StatusEntity.Active)
                 .Select(P => new PractitionerViewModel(P.FullName, P.BirthDate, P.Email))
                 .ToList();

            return practitioners;
        }
    }
}
