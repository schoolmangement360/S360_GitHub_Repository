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
        private StandardRepository _Standardpository;
        private LanguageRepository _LanguageRepository;
        private StudentCategoryRepository _StudentCategoryRepository;
        private ReligionRepository _ReligionRepository;

        public StudentBusinessLogic()
        {
            _StudentRepository = S360RepositoryFactory.GetRepository("STUDENT") as StudentRepository;
            _SectionRepository = S360RepositoryFactory.GetRepository("SECTION") as SectionRepository;
            _Standardpository = S360RepositoryFactory.GetRepository("STANDARD") as StandardRepository;
            _LanguageRepository = S360RepositoryFactory.GetRepository("LANGUAGE") as LanguageRepository;
            _StudentCategoryRepository = S360RepositoryFactory.GetRepository("STUDENTCATEGORY") as StudentCategoryRepository;
            _ReligionRepository = S360RepositoryFactory.GetRepository("RELIGION") as ReligionRepository;
        }

        /// <summary>
        /// Get All Sections
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<GEN_Sections_Lookup> GetAllSections()
        {
            return new ObservableCollection<GEN_Sections_Lookup>(_SectionRepository.GetAll()); 
        }

        /// <summary>
        /// Get All Standards
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<GEN_Standards_Lookup> GetAllStandards()
        {
            return new ObservableCollection<GEN_Standards_Lookup>(_Standardpository.GetAll());
        }

        /// <summary>
        /// Get All Languages
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<GEN_Languages_Lookup> GetAllLanguages()
        {
            return new ObservableCollection<GEN_Languages_Lookup>(_LanguageRepository.GetAll());
        }

        /// <summary>
        /// Get All Category
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<GEN_StudentCategory_Lookup> GetAllStudentCategory()
        {
            return new ObservableCollection<GEN_StudentCategory_Lookup>(_StudentCategoryRepository.GetAll());
        }

        /// <summary>
        /// Get All Religion
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<GEN_Religions_Lookup> GetAllStudentReligion()
        {
            return new ObservableCollection<GEN_Religions_Lookup>(_ReligionRepository.GetAll());
        }

        public STUD_Students_Master SaveStudent(STUD_Students_Master studentDetails)
        {
            STUD_Students_Master result = new STUD_Students_Master();
            if (studentDetails != null)
            {
                result = _StudentRepository.Insert(studentDetails) as STUD_Students_Master;
            }

            return result;          
        }
    }
}
