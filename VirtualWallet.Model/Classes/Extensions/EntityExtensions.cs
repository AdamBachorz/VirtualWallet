using VirtualWallet.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace VirtualWallet.Model.Classes.Extensions
{
    public static class EntityExtensions
    {
        public static bool Equals(this Entity myEntity, Entity otherEntity, bool excludeId)
        {
            var myValues = myEntity.GetType().GetProperties()
                .Where(p => p.MemberType == MemberTypes.Property && excludeId ? !p.Name.Equals("Id") : true)
                .Select(p => p.GetValue(myEntity)?.ToString() ?? string.Empty).ToList();

            var otherEntityValues = otherEntity.GetType().GetProperties()
                .Where(p => p.MemberType == MemberTypes.Property && excludeId ? !p.Name.Equals("Id") : true)
                .Select(p => p.GetValue(otherEntity)?.ToString() ?? string.Empty).ToList();

            if (myValues.Count() != otherEntityValues.Count() || myEntity.GetType() != otherEntity.GetType())
            {
                return false;
            }

            for (int i = 0; i < myValues.Count(); i++)
            {
                if (!myValues[i].Equals(otherEntityValues[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
