using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INDSA_Sem_A.Exceptions
{
  public  class LoopEdgeException : SystemException
    {
      public LoopEdgeException(string message) : base (message){}
    }
}
