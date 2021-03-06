﻿using System;

namespace CSharp.PrimitveRefAndValTypes.Entities
{
    public struct ChangeablePoint : IChangable
    {
        public Int32 m_x, m_y;
        
        public ChangeablePoint(Int32 x, Int32 y) 
        {
            m_x = x;
            m_y = y;
        }
        
        
        public void Change(Int32 x, Int32 y) 
        {
            m_x = x; m_y = y;
        }
        
        public override String ToString() 
        {
            return $"({m_x.ToString()}, {m_y.ToString()})";
        }
    }
}