﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S360Entity;
using S360Logging;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;

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
        private StudentAcademicRepository _StudentAcademicRepository;
        private StudentDetainPromotionRepository _studentDetainPromotionRepository;

        public StudentBusinessLogic()
        {
            _StudentRepository = S360RepositoryFactory.GetRepository("STUDENT") as StudentRepository;
            _SectionRepository = S360RepositoryFactory.GetRepository("SECTION") as SectionRepository;
            _Standardpository = S360RepositoryFactory.GetRepository("STANDARD") as StandardRepository;
            _LanguageRepository = S360RepositoryFactory.GetRepository("LANGUAGE") as LanguageRepository;
            _StudentCategoryRepository = S360RepositoryFactory.GetRepository("STUDENTCATEGORY") as StudentCategoryRepository;
            _ReligionRepository = S360RepositoryFactory.GetRepository("RELIGION") as ReligionRepository;
            _StudentAcademicRepository = S360RepositoryFactory.GetRepository("STUDENTACADEMIC") as StudentAcademicRepository;
            _studentDetainPromotionRepository = S360RepositoryFactory.GetRepository("DETAINORPROMOTION") as StudentDetainPromotionRepository;
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

        public IEnumerable<STUD_StudentAcademic_Details> GetAllStudentsAccademicDetails()
        {
            return this._StudentAcademicRepository.GetAll();
        }

        public ObservableCollection<STUD_Students_Master> GetAllStudents()
        {
            return new ObservableCollection<STUD_Students_Master>(_StudentRepository.GetAll());
        }

        public IEnumerable<STUD_Students_Master> GetStudentsBySearchStringAndSection(string SearchString, short SectionId)
        {
            return (from st in this._StudentRepository.GetAll()
                    join ac in this._StudentAcademicRepository.GetAll() on st.CurrentAcaDetail_ID equals ac.AcademicDet_ID
                    where st.Name.Contains(SearchString) && ac.Section_ID == SectionId && st.IsActive == true
                    select st).Distinct<STUD_Students_Master>();
        }

        public STUD_Students_Master SaveStudent(STUD_Students_Master studentDetails)
        {
            STUD_Students_Master studentResult = new STUD_Students_Master();
            if (studentDetails != null)
            {
                studentResult = _StudentRepository.Insert(studentDetails) as STUD_Students_Master;
            }

            return studentResult;
        }

        public STUD_StudentAcademic_Details SaveStudentAcademicDetails(STUD_Students_Master studentDetails, STUD_StudentAcademic_Details studentAcademicDetails)
        {
            STUD_StudentAcademic_Details AcademicDetails = new STUD_StudentAcademic_Details();
            AcademicDetails.RegNo = studentDetails.RegNo;
            AcademicDetails.Student_ID = studentDetails.Student_ID;
            AcademicDetails.AcademicDet_ID = (decimal)studentDetails.CurrentAcaDetail_ID;
            AcademicDetails.Remarks = studentDetails.Remarks;
            AcademicDetails.Standard_ID = (short)studentDetails.CurrentStd_ID;
            AcademicDetails.Section_ID = studentAcademicDetails.Section_ID;
            AcademicDetails.AcademicYearStart = studentAcademicDetails.AcademicYearStart;
            AcademicDetails.AcademicYearEnd = studentAcademicDetails.AcademicYearEnd;
            AcademicDetails.IsActive = true;

            STUD_StudentAcademic_Details academicdetails = _StudentAcademicRepository.Insert(AcademicDetails);
            studentDetails.CurrentAcaDetail_ID = academicdetails.AcademicDet_ID;
            _StudentRepository.Update(studentDetails);

            return AcademicDetails;
        }

        /// <summary>
        /// Method to save Student Promotion detail
        /// </summary>
        /// <param name="studentAcademicDetails"></param>
        public void SavePromotion(STUD_StudentAcademic_Details studentsaccademicdetails)
        {
            //insert into STUD_StudentAcademic_Details table
            Decimal LastAccDetId = studentsaccademicdetails.AcademicDet_ID;
            if (studentsaccademicdetails != null)
            {
                try
                {
                    _StudentAcademicRepository.Insert(studentsaccademicdetails);

                    STUD_DetainingOrPromotions_Details promotion = new STUD_DetainingOrPromotions_Details()
                    {
                        CurrentAcadDetail_ID = studentsaccademicdetails.AcademicDet_ID,
                        LastAcadDetail_ID = LastAccDetId,
                        Status_ID = 1,
                        Student_ID = studentsaccademicdetails.Student_ID,
                        EnteredBy = S360Model.S360Configuration.Instance.UserID,
                        Login_ID = S360Model.S360Configuration.Instance.LoginID
                    };

                    //Insert into STUD_DetainingOrPromotions_Details table
                    _studentDetainPromotionRepository.Insert(promotion);
                }
                catch(Exception Ex)
                {
                    throw new S360Exceptions.S360Exception(Ex.Message, Ex.InnerException);
                }
            }
        }

        /// <summary>
        /// Method to update Student master table after Promotion or detain
        /// </summary>
        /// <param name="students"></param>
        public void UpdateStudentAcademics(IEnumerable<STUD_Students_Master> students)
        {
            foreach(STUD_Students_Master student in students)
            {
                _StudentRepository.Update(student); 
            }
        }
    }
}
