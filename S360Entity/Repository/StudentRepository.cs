namespace S360Entity
{
    public class StudentRepository : BaseRepository<STUD_Students_Master>
    {

        public StudentRepository(IUnitOfWork unit) : base(unit)
        {

        }

    }
}
