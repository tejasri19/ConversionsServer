﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace ConversionsClientModels.Models.Units
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class UnitTypeClientModel
    {
        public string DisplayName;

        public UnitClientModel BaseUnit;

        public List<UnitClientModel> Units;
    }
}
