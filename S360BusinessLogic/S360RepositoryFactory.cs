using System;
using System.Linq;
using S360Entity;

namespace S360BusinessLogic
{
    public static class S360RepositoryFactory
    {
        public static object GetRepository(string repositoryName)
        {
            IUnitOfWork uow = new UnitOfWork();
            switch (repositoryName)
            {
                case "STUDENT":
                    return new StudentRepository(uow);
                case "USERCREDENTIAL":
                    return new UserCredentialRepository(uow);
                case "SECTION":
                    return new SectionRepository(uow);
                case "USERLOGINDETAIL":
                    return new UserLoginDetailRepository(uow);
                default:
                    return null;
            }
        }

    }
}
