﻿using ConversionsDal.Entities.Units;
using ConversionsDb;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ConversionsDal.Dals.Units
{
    public interface IConversionDal
    {
        List<ConversionEntity> GetConversions(int unitTypeId);
    }

    public class ConversionDal : BaseDal, IConversionDal
    {
        private readonly ConversionsContext _db;

        public ConversionDal(ConversionsContext db)
        {
            _db = db;
        }

        public List<ConversionEntity> GetConversions(int unitTypeId)
        {
            var result = (from c in _db.Conversions
                          join utm in _db.UnitTypeMaps on c.FromUnit.Id equals utm.Unit.Id
                          join utm2 in _db.UnitTypeMaps on c.ToUnit.Id equals utm2.Unit.Id
                          where utm.UnitType.Id == unitTypeId && utm2.UnitType.Id == unitTypeId
                          select c)
                .Include(rv => rv.FromUnit)
                .Include(rv => rv.ToUnit);

            return result.Select(conversion => new ConversionEntity(conversion)).ToList();
        }
    }
}
