using System;

namespace MvcDesignPattern.Core
{
    public class UserManager
    {
        public INotifier Notifier { get; set; }

        public UserManager(INotifier notifier)
        {
            Notifier = notifier;
        }

        public void ChangePassword(string username, string oldPwd, string newPwd)
        {
            // change password here

            // notify the user
            Notifier.Notify("Password was changed on " + DateTime.Now);
        }
    }
}
