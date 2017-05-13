using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360Entity
{
    public class StudentDetainPromotionRepository : BaseRepository<STUD_DetainingOrPromotions_Details>
    {
        public StudentDetainPromotionRepository(IUnitOfWork unit) : base(unit)
        {

        }
    }
}
