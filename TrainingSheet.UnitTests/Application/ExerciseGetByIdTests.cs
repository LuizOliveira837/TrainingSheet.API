using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.Querys.ExerciseGetById;
using TrainingSheet.Core.Models;
using TrainingSheet.Core.Repositories;
using Xunit;

namespace TrainingSheet.UnitTests.Application
{
    public class ExerciseGetByIdTests
    {

        [Fact]
        public async Task  EnteredAnID_Executed_ReturnExercise()
        {
            //AAA
            //ARRANGE

            var exerciseGetByIdQuery = new ExerciseGetByIdQuery(1);
            var exercise = new Exercise("PullOver");

            var repository = new Mock<IExerciseRepository>();
            var exerciseGetByIdQueryHandler = new ExerciseGetByIdQueryHandler(repository.Object);

            repository.Setup(r => r.GetById(It.IsAny<int>()).Result).Returns(exercise);



            //ACT

            var exerciseResult = await exerciseGetByIdQueryHandler.Handle(exerciseGetByIdQuery, new CancellationToken());




            //ASSERT

            Assert.NotNull(exerciseResult);
            Assert.NotEmpty(exerciseResult.ExerciseName);
            Assert.Equal(It.IsAny<int>(),exerciseResult.Id);
            repository.Verify(repo=> repo.GetById(It.IsAny<int>()), Times.Once);

        }

    }
}
