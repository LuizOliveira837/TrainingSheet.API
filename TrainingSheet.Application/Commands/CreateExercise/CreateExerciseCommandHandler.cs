﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.Services.Interface;
using TrainingSheet.Core.Models;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.CreateExercise
{
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, int>
    {
        public readonly TrainingSheetDbContext _dbContext;
        public CreateExerciseCommandHandler(IExerciseService service, TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exerise = new Exercise(request.ExerciseName);
            await _dbContext.Exercises.AddAsync(exerise);
            await _dbContext.SaveChangesAsync();

            return exerise.Id;
        }
    }
}
