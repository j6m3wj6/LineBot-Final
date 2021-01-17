using System;
namespace LineBot.App
{
    public class ExceptionManager : Exception
    {
        public string module;
        public ExceptionManager(string mes) : base(mes)
        {
        }
        public ExceptionManager(string module, string mes) : base(mes)
        {
            this.module = module;
        }
    }
}
