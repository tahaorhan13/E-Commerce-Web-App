using Beu.Eticaret.Account.UserToken;
using Beu.Eticaret.Dal.PostgreSQL;
using Beu.Eticaret.Db.Account.DataAccess;
using Beu.Eticaret.Entity;
using System;
using System.Linq;

namespace Beu.Eticaret.Dal.Account
{
    public class dUserToken:dCore
    {
        public dUserToken(DbEntities db) : base(db)
        {
            //
        }
        private bool Has(pUserToken args)
        {
            args.validateValues(false);

            try
            {
                return db.acc_UserToken.Where(w => w.RefreshToken == args.RefreshToken).Any();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool HasDifferent(pUserToken args)
        {
            args.validateValues(true);

            try
            {
                return db.acc_UserToken.Where(w => w.Id != args.UserId && w.UserId == args.UserId).Any();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private IQueryable<eUserToken> GenerateQuery()
        {
            return (from userToken in db.acc_UserToken
                    select new eUserToken()
                    {
                        Id = userToken.Id,
                        UserId = userToken.UserId,
                        RefreshToken = userToken.RefreshToken,
                        RefreshTokenExpireDate = userToken.RefreshTokenExpireDate
                    });
        }
        private acc_UserToken GetEntity(pId args)
        {
            if (args.Id <= 0)
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.HAS_RECORD");

            try
            {
                return db.acc_UserToken.Where(w => w.Id == args.Id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public rUserToken Get(pbUserToken args)
        {

            var q = GenerateQuery();

            if (args.UserId > 0)
                q = q.Where(w => w.Id == args.UserId);

            if (args.UserId > 0)
                q = q.Where(w => w.UserId == args.UserId);

            if (!(args.RefreshToken == null))
                q = q.Where(w => w.RefreshToken == args.RefreshToken);

            try
            {
                return new rUserToken() { Value = q.SingleOrDefault() };
            }
            catch (Exception)
            {
                throw;
            }
        }
        public rUserToken Add(pUserToken args)
        {
            if (Has(args))
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.HAS_RECORD");

            var ent = new acc_UserToken();

            try
            {
                ent.addEntity(db, args);
            }
            catch (Exception)
            {
                throw;
            }

            var r = Get(new pbUserToken() { UserId = ent.Id });
            return r;
        }
        public rUserToken Update(pUserToken args)
        {
            if (HasDifferent(args))
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.HAS_RECORD");

            var ent = GetEntity(new pId() { Id = args.UserId });

            try
            {
                ent.updateEntity(db, args);
            }
            catch (Exception)
            {
                throw;
            }

            var r = Get(new pbUserToken() { UserId = ent.Id });
            return r;
        }
        public rUserToken Save(pUserToken args)
        {
            return args.UserId <= 0 ? Update(args) : Add(args);
        }
        public rCore Delete(pId args)
        {
            if (args.Id <= 0)
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.INCORRECT_OR_MISSING_PARAMETER_VALUE");

            var ent = GetEntity(args);

            try
            {
                ent.removeEntity(db, args);
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }
    }
}
