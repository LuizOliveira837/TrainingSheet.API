using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.SheetView;
using TrainingSheet.Core.Models;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Querys.SheetGetById
{
    public class SheetGetByIdQueryHandler : IRequestHandler<SheetGetByIdQuery, SheetViewModel>
    {
        private readonly TrainingSheetDbContext _dbContext;

        public SheetGetByIdQueryHandler(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<SheetViewModel> Handle(SheetGetByIdQuery request, CancellationToken cancellationToken)
        {
            var sheet = await _dbContext
                .Sheets
                .Where(s => s.Id == request.Id  && s.Status == Core.Enums.StatusEntity.Active)
                .Include(a => a.Practitioner)
                .SingleOrDefaultAsync();

            return new SheetViewModel(
                sheet.SheetName
                , sheet.Practitioner
                , sheet.StartedIn
                , sheet.FinishIn
                );


        }
    }
}
