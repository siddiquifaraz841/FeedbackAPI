using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackAPI.Services
{
    public interface ISubmitFeedback
    {
        void PostFeedback(string username, string feedback);
    }
}
