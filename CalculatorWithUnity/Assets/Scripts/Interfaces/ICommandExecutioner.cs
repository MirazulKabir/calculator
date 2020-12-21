using System;

namespace Calculator
{
    public interface ICommandExecutioner
    {  
        void CommandExecutioner(Func<string> sign);
        void CommandExecutioner(Func<string> sign, Func<double, double> execute);
        void CommandExecutioner(Func<string> sign, Func<double, double, double> execute);
    }
}