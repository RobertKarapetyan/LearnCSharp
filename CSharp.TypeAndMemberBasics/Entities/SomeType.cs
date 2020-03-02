using System;

namespace CSharp.TypeAndMemberBasics.Entities
{
    public sealed class SomeType { // 1
        // Nested class
        private class SomeNestedType { } // 2
        
        // Constant, read­only, and static read/write field
        private const Int32 c_SomeConstant = 1; // 3
        private readonly String m_SomeReadOnlyField = "2"; // 4
        private static Int32 s_SomeReadWriteField = 3; // 5
        
        // Type constructor
        static SomeType() { } // 6
        
        // Instance constructors
        public SomeType(Int32 x) { } // 7
        public SomeType() { } // 8
        
        // Instance and static methods
        private String InstanceMethod() { return null; } // 9

        // Instance property
        public Int32 SomeProp { // 11
            get { return 0; } // 12
            set { } // 13
        }
        
        // Instance parameterful property (indexer)
        public Int32 this[String s] { // 14
            get { return 0; } // 15
            set { } // 16
        }
        
        // Instance event
        public event EventHandler SomeEvent; // 17
    }
}