using System;

namespace INDSA_Sem_A.Exceptions
{
    public class InvalidKeyException : SystemException
    {
         public InvalidKeyException(string message) : base(message)
         {
             
         }
    }
}