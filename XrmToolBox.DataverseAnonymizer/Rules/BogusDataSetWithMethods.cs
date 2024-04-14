using System;
using System.Reflection;

namespace XrmToolBox.DataverseAnonymizer.Rules
{
    public class BogusDataSetWithMethods
    {
        public class MethodWithFriendlyName
        {
            public MethodInfo Method { get; set; }
            public string FriendlyName { get; set; }
        }

        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public Type DataSetType { get; set; }
        public MethodWithFriendlyName[] Methods { get; set; }
    }
}
