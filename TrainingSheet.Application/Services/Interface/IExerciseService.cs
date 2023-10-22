using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Application.InputModels.Exercise;
using TrainingSheet.Application.ViewModels.Exercise;

namespace TrainingSheet.Application.Services.Interface
{
    public interface IExerciseService
    {

        public IList<ExerciseViewModel> GetAll();
        public ExerciseViewModel GetById(int id);
        public int Create(InputCreateModel input);
        public void Delete(int id);
        public void Update(int id, InputUpdateModel input);
    }
}
