using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.Querys.ExerciseGetAll;
using TrainingSheet.Application.ViewModels.ExerciseView;
using TrainingSheet.Core.Models;
using TrainingSheet.Core.Repositories;
using Xunit;

namespace TrainingSheet.UnitTests.Application
{
    public class ExerciseGetAllQueryHandlerTests
    {
        [Fact]
        public async Task When_Executed_ReturnExercises()
        {
            //AAA

            //ARRANGE
            var exercises = new List<Exercise>()
            {
                new Exercise("PullOver"),
                new Exercise("CrossOver"),
                new Exercise("Pull Down")
            };

            var exerciseGetAllQuery = new ExerciseGetAllQuery();


            var repository = new Mock<IExerciseRepository>();
            repository.Setup(repo => repo.GetAllAsync().Result).Returns(exercises);

            var exerciseGetAllQueryHandler = new ExerciseGetAllQueryHandler(repository.Object);


            //ACT

            var exercisesResult = await exerciseGetAllQueryHandler.Handle(exerciseGetAllQuery, new CancellationToken());

            //ASSERT
            Assert.IsType<List<ExerciseViewModel>>(exercisesResult);
            repository.Verify(repo=> repo.GetAllAsync(), Times.Once()); 
        }
    }
}
