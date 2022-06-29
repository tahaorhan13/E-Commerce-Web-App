using Beu.Eticaret.Db.PostgreSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Beu.Eticaret.Dal.PostgreSQL
{
    public static class Extensions
    {
        public static decimal addEntity<TEntity>(this TEntity ent, PostgreSQLContextCore db, object args) where TEntity : class
        {
            if (args != null)
            {
                args.trimValues();

                if (args.hasValidationError())
                    throw new SystemException("Messages.Codes._100, Messages.Titles.Error, Messages.Descriptions.INCORRECT_OR_MISSING_PARAMETER_VALUE");

                args.transferValues(ent);
            }
            db.Set<TEntity>().Add(ent);
            db.SaveChanges();
            return 0;
        }
        // Güncelleme Metodu
        public static decimal updateEntity(this object ent, PostgreSQLContextCore db, object args)
        {
            if (args != null)
            {
                args.trimValues();

                if (args.hasValidationError())
                    throw new SystemException("Messages.Codes._100, Messages.Titles.Error, Messages.Descriptions.INCORRECT_OR_MISSING_PARAMETER_VALUE");

                args.transferValues(ent);
            }

            db.SaveChanges();

            return 0;
        }
        // Silme Metodu
        public static void removeEntity<TEntity>(this TEntity ent, PostgreSQLContextCore db, object args) where TEntity : class
        {
            if (args != null)
                args.transferValues(ent);

            db.Set<TEntity>().Remove(ent);
            db.SaveChanges();
        }

        public static IEnumerable<ValidationResult> getValidationErrors(this object obj)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, context, validationResults, true);
            return validationResults;
        }
        public static bool hasValidationError(this object obj)
        {
            return obj.getValidationErrors().Any();
        }

        public static void validateValues(this object args, bool updateFunc)
        {
            decimal? id = args.getPropertyValue("Id").toDecimal();

            if (args.hasValidationError())
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.INCORRECT_OR_MISSING_PARAMETER_VALUE");
            if (updateFunc && id.isEqualOrLessThanZero())
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.INCORRECT_OR_MISSING_PARAMETER_VALUE");
        }
    }
}
