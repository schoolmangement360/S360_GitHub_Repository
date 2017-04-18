
namespace S360Entity
{
    public class StudentRepository : BaseRepository<Student>
    {

        public StudentRepository(IUnitOfWork unit) : base(unit)
        {

        }

    }
}
