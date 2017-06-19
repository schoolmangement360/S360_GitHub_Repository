using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360Model
{
    public sealed class S360Configuration
    {

        #region Singelton Class implementation

        private static readonly object padlock = new object();

        S360Configuration()
        {
        }

        private static S360Configuration instance = null;
        public static S360Configuration Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new S360Configuration();
                        }
                    }
                }
                return instance;
            }
        }

        #endregion

        #region App Configuration

        /// <summary>
        /// Store Login ID
        /// </summary>
        public decimal LoginID { get; set; }

        /// <summary>
        /// Store User ID
        /// </summary>
        public decimal UserID { get; set; }

        /// <summary>
        /// Gets or sets Username
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Store UsAcademic Year Starter
        /// </summary>
        public int AcademicYearStart { get; set; }

        /// <summary>
        /// Store Academic Year End
        /// </summary>
        public int AcademicYearEnd { get; set; }


        #endregion
    }
}
