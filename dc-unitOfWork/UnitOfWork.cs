using dc_data_context;
using dc_datamodels.account;
using dc_generic_repository;
using System;

namespace dc_unitOfWork
{
    public class UnitOfWork
    {
        private readonly MySQLDBContext _context;

        public UnitOfWork(MySQLDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        //LoggerDataModel Rpository
        #region
        //private GenericRepository<LoggerDataModel> loggerRepository;
        //public GenericRepository<LoggerDataModel> LoggerRepository
        //{
        //    get
        //    {
        //        if (this.loggerRepository == null)
        //            this.loggerRepository = new GenericRepository<LoggerDataModel>(_context);
        //        return loggerRepository;
        //    }
        //}
        private GenericRepository<UserDataModel> userRepository;
        public GenericRepository<UserDataModel> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new GenericRepository<UserDataModel>(_context);
                return userRepository;
            }
        }
       

        #endregion

       
        //public async void Save()
        //{
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}
