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
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Querys.SheetGetById
{
    public class SheetGetByIdQueryHandler : IRequestHandler<SheetGetByIdQuery, SheetViewModel>
    {
        private readonly ISheetRepository _repository;

        public SheetGetByIdQueryHandler(ISheetRepository repository)
        {
            _repository = repository;
        }
        public async Task<SheetViewModel> Handle(SheetGetByIdQuery request, CancellationToken cancellationToken)
        {
            var sheet = await _repository.GetByIdAsync(request.Id);

            return new SheetViewModel(
                sheet.SheetName
                , sheet.Practitioner
                , sheet.StartedIn
                , sheet.FinishIn
                );


        }
    }
}
