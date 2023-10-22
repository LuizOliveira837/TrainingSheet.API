using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Core.Enums;

namespace TrainingSheet.Core.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            Status = StatusEntity.Active;
        }

        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public StatusEntity Status { get; set; }

    }
}
