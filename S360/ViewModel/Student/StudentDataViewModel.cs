using S360Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S360BusinessLogic;
using S360Model;

namespace S360.ViewModel.Student
{
    public class StudentDataViewModel : ViewModelBase
    {
        #region [ Private Variables ]

        /// <summary>
        /// Variable to store all students to display
        /// </summary>
        private System.Collections.ObjectModel.ObservableCollection<StudentDataModel> _students;

        /// <summary>
        /// Variable to store current page title
        /// </summary>
        private string _title;

        #endregion

        #region [ Constructor ]

        public StudentDataViewModel()
        {
            StudentBusinessLogic business = new StudentBusinessLogic();
            Students = new System.Collections.ObjectModel.ObservableCollection<StudentDataModel>((from st in business.GetAllStudents()
                                             join acc in business.GetAllStudentsAccademicDetails()
                                             on st.CurrentAcaDetail_ID equals acc.AcademicDet_ID
                                             where acc.Section_ID == SectionID && st.IsActive == true
                                             select new StudentDataModel()
                                             {
                                                 Student_ID = st.Student_ID,
                                                 RegNo = st.RegNo,
                                                 Gender = st.Gender,
                                                 Surname = st.Surname,
                                                 Name = st.Name,
                                                 FatherName = st.FatherName,
                                                 MotherName = st.MotherName,
                                                 CurrentStd_ID = st.CurrentStd_ID,
                                                 Standard = business.GetAllStandards().Where(S=>S.Standard_Id == st.CurrentStd_ID).FirstOrDefault().Name,
                                                 CurrentDiv = st.CurrentDiv,
                                                 Address = st.Address,
                                                 DOB = st.DOB,
                                                 AadharNo = st.Address,
                                                 Caste = st.Caste,
                                                 Category_ID = st.Category_ID,
                                                 CurrentAcaDetail_ID = st.CurrentAcaDetail_ID,
                                                 Email = st.Email,
                                                 HomePh = st.HomePh,
                                                 Mobile1 = st.Mobile1,
                                                 Mobile2 = st.Mobile2,
                                                 Mobile3 = st.Mobile3,
                                                 MotherTongue = st.MotherTongue,
                                                 PrimaryContact = st.PrimaryContact,
                                                 WorkPh = st.WorkPh,
                                                 Religion = st.Religion
                                             }).Distinct());
        }

        #endregion

        #region [ Public Properties ]

        /// <summary>
        /// Gets or sets Title of page
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged("Title"); }
        }

        /// <summary>
        /// Gets or sets SectionID
        /// </summary>
        public short SectionID { get; set; }

        /// <summary>
        /// Gets or sets all students
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<StudentDataModel> Students
        {
            get
            {
                if (_students == null)
                    _students = new System.Collections.ObjectModel.ObservableCollection<StudentDataModel>();
                return _students;
            }
            set
            {
                _students = value;
                RaisePropertyChanged("Students");
            }
        }

        #endregion
    }
}
