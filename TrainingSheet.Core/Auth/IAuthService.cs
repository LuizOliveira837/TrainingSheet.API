using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Core.Auth
{
    public interface IAuthService
    {
        public string GenerationToken(string email);
        public string EncryptPassword(string password);
    }
}
