using Beu.Eticaret.Dal.PostgreSQL;
using Beu.Eticaret.Db.System;
using Beu.Eticaret.Entity;
using Beu.Eticaret.Entity.System;
using System;
using System.Linq;

namespace Beu.Eticaret.Dal.System
{
    public class dRole : dCore
    {
        public dRole(DbEntities db) : base(db)
        {
            //
        }
        private bool Has(pRole args)
        {
            args.validateValues(false);

            try
            {
                return db.sys_Role.Where(w => w.RoleName == args.RoleName).Any();
            }
            catch (Exception)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }
        }
        private bool HasDifferent(pRole args)
        {
            args.validateValues(true);

            try
            {
                return db.sys_Role.Where(w => w.Id != args.Id && w.RoleName == args.RoleName).Any();
            }
            catch (Exception)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }
        }
        private IQueryable<eRole> GenerateQuery()
        {
            return (from role in db.sys_Role
                    select new eRole()
                    {
                        Id = role.Id,
                        Name = role.RoleName,
                        Value = role.AccessLevel
                    });
        }
        private sys_Role GetEntity(pId args)
        {
            if (args.Id <= 0)
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.INCORRECT_OR_MISSING_PARAMETER_VALUE");

            try
            {
                return db.sys_Role.Where(w => w.Id == args.Id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }
        }
        public rRole Get(pRole args)
        {
            if (args.Id <= 0)
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.INCORRECT_OR_MISSING_PARAMETER_VALUE");

            var q = GenerateQuery();

            if (args.Id > 0)
                q = q.Where(w => w.Id == args.Id);

            try
            {
                return new rRole() { Value = q.SingleOrDefault() };
            }
            catch (Exception)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }
        }
        public rRole Add(pRole args)
        {
            if (Has(args))
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.HAS_RECORD");

            var ent = new sys_Role();

            try
            {
                ent.addEntity(db, args);
            }
            catch (Exception)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }

            var r = Get(new pRole() { Id = ent.Id });

            return r;
        }
        public rRole Update(pRole args)
        {
            if (HasDifferent(args))
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.HAS_RECORD");

            var ent = GetEntity(new pId() { Id = args.Id });

            try
            {
                ent.updateEntity(db, args);
            }
            catch (Exception)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }

            var r = Get(new pRole() { Id = ent.Id });

            return r;
        }
        public rRole Save(pRole args)
        {
            return args.Id > 0 ? Update(args) : Add(args);
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
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }

            return new rCore()
            {
                Message = "Hata"
            };
        }
        //public rListRole List(pListRole args)
        //{
        //    var q = GenerateQuery().Where(w => w.AccessLevel >= 0);

        //    if (args.State.isEqualOrGreaterThanZero())
        //        q = q.Where(w => w.State == args.State);

        //    if (args.hasNotSort())
        //        q = q.OrderBy(o => o.Name);

        //    q = q.addFilterQuery(args).addSortQuery(args);

        //    try
        //    {
        //        return new rListRole() { Value = q.addSkipTakeQuery(args).ToList(), Total = q.Count() };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new SystemException(Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex);
        //    }
        //}
    }
}
