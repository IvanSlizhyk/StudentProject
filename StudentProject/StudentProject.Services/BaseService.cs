using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.BLInterfaces.BLLInterfaces;
using StudentProject.DALInterfaces;

namespace StudentProject.Services
{
    public abstract class BaseService : IService
    {
        protected IUnitOfWork UnitOfWork { get; set; }
        protected IRepositoryFactory RepositoryFactory { get; set; }

        protected BaseService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
        {
            UnitOfWork = unitOfWork;
            RepositoryFactory = repositoryFactory;
        }
    }
}
