﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Bot.Builder.Dialogs.Flow.Loader.Types
{
    public class Binder : DefaultSerializationBinder
    {
        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = Factory.NameFromType(serializedType).ToString();

            if (string.IsNullOrEmpty(typeName))
            {
                base.BindToName(serializedType, out assemblyName, out typeName);
            }
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            var type = Factory.TypeFromName(typeName);

            if (type != default(Type))
            {
                return type;
            }
            return base.BindToType(assemblyName, typeName);
        }
    }
}
