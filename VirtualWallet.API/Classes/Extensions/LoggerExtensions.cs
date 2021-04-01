using Microsoft.Extensions.Logging;
using VirtualWallet.Common.Extensions;
using VirtualWallet.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualWallet.API.Classes.Extensions
{
    public static class LoggerExtensions
    {
        //public static void QuickLog<C>(this ILogger<C> logger, LogReport logReport) => logger.Log(logReport.LogLevel, logReport.Message);

        public static void QuickLog<C>(this ILogger<C> logger, DbOperationType dbOperationType, Type type)
            => logger.LogInformation(string.Format(dbOperationType.Description(), type.Name));

        public static void QuickLog<C>(this ILogger<C> logger, DbOperationType dbOperationType, Type type, int id)
            => logger.LogInformation(string.Format(dbOperationType.Description(), type.Name, id));

        public static void QuickLog<C>(this ILogger<C> logger, DbOperationType dbOperationType, Entity entity)
            => logger.LogInformation(string.Format(dbOperationType.Description(), entity.GetType().Name));

        public static void QuickLog<C>(this ILogger<C> logger, DbOperationType dbOperationType, Entity entity, int id)
            => logger.LogInformation(string.Format(dbOperationType.Description(), entity.GetType().Name, id));

        public static void LogIfNotFound<C>(this ILogger<C> logger, Type type, IEnumerable<object> enumerable)
        {
            if (!enumerable.Any())
            {
                logger.LogWarning($"Nie znaleziono elementów typu {type.Name}");
            }
        }

        public static void LogIfNotFound<C>(this ILogger<C> logger, Type type, object ob)
        {
            if (ob == null)
            {
                logger.LogWarning($"Nie znaleziono elementu typu {type.Name}");
            }
        }

        public static void LogIfNotFound<C>(this ILogger<C> logger, Type type, int id, object ob)
        {
            if (ob == null)
            {
                logger.LogWarning($"Nie znaleziono elementu typu {type.Name} o ID = {id}");
            }
        }

        public static void LogError<C>(this ILogger<C> logger, Exception exception) => logger.LogError(exception, "Błąd");
        public static void LogSuccess<C>(this ILogger<C> logger) => logger.LogInformation("Operacja zakończona sukcesem !");
        public static void LogSuccess<C>(this ILogger<C> logger, Func<bool> succesCondition)
        {
            if (succesCondition())
            {
                LogSuccess(logger);
            }
            else
            {
                logger.LogWarning("Operacja mogła zostać niepoprawnie wykonana.");
            }
        }

    }
}
