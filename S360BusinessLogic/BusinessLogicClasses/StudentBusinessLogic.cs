using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S360Entity;
using S360Logging;

namespace S360BusinessLogic
{
    public class StudentBusinessLogic
    {
        private StudentRepository _StudentRepository;

        public StudentBusinessLogic()
        {
            _StudentRepository = S360RepositoryFactory.GetRepository("STUDENT") as StudentRepository;
        }

        public Student FirstStudent()
        {
            return _StudentRepository.Single(7); 
        }
    }
}
