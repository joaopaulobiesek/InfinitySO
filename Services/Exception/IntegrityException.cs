using System;

namespace InfinitySO.Services.Exception
{
    public class IntegrityException : ApplicationException
    { //Configurar https://www.udemy.com/course/programacao-orientada-a-objetos-csharp/learn/lecture/11643008#questions
        public IntegrityException(string message) : base(message)
        {
        }
    }
}