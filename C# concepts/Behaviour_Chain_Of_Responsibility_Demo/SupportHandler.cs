using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behaviour_Chain_Of_Responsibility_Demo
{
    public abstract class SupportHandler
    {
        protected SupportHandler nextHandler;

        public void SetNext (SupportHandler next)
        {
            nextHandler = next;
        }

        public abstract void HandleRequest(string issueType);
    }

    public class Level1Support : SupportHandler
    {
        public override void HandleRequest(string issuType)
        {
            if (issuType == "password reset")
            {
                Console.WriteLine("level 1 support handled to reset the password");
            }
            else if(nextHandler!=null)
            {
                nextHandler.HandleRequest(issuType);
            }
        }
    }

    public class Level2Support : SupportHandler
    {
        public override void HandleRequest(string issueType)
        {
            if (issueType =="software issue")
            {
                Console.WriteLine("level 2 support working on fixing the bug");
            }
            else if (nextHandler !=null)
            {
                nextHandler.HandleRequest(issueType);
            }
        }
    }

    public class ManagerSupport : SupportHandler
    {

    }
}
