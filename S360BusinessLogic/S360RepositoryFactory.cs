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
                case "STANDARD":
                    return new StandardRepository(uow);
                case "LANGUAGE":
                    return new LanguageRepository(uow);
                case "STUDENTCATEGORY":
                    return new StudentCategoryRepository(uow);
                case "RELIGION":
                    return new ReligionRepository(uow);
                case "STUDENTACADEMIC":
                    return new StudentAcademicRepository(uow);
                case "DETAINORPROMOTION":
                    return new StudentDetainPromotionRepository(uow);
                case "STUDENTTC":
                    return new StudentTCRepository(uow);
                case "CHEQUEMASTER":
                    return new ChequeMasterRepository(uow);
                case "CHEQUEMASTERTEMP":
                    return new ChequeMasterTempRepository(uow);
                default:
                    return null;
            }
        }

    }
}
