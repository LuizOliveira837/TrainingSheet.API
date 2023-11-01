using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.SheetView;

namespace TrainingSheet.Application.Querys.SheetGetById
{
    public class SheetGetByIdQuery : IRequest<SheetViewModel>
    {
        public SheetGetByIdQuery(int id)
        {
            Id = id;
        }


        public int Id { get; set; }
    }
}
