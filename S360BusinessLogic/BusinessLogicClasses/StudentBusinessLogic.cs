using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S360Entity;
using S360Logging;
using System.Collections.ObjectModel;

namespace S360BusinessLogic
{
    public class StudentBusinessLogic
    {
        private StudentRepository _StudentRepository;
        private SectionRepository _SectionRepository;

        public StudentBusinessLogic()
        {
            _StudentRepository = S360RepositoryFactory.GetRepository("STUDENT") as StudentRepository;
            _SectionRepository = S360RepositoryFactory.GetRepository("SECTION") as SectionRepository;
        }

        /// <summary>
        /// Get All Sections
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<GEN_Sections_Lookup> GetAllSections()
        {
            return new ObservableCollection<GEN_Sections_Lookup>(_SectionRepository.GetAll()); 
        }
    }
}
