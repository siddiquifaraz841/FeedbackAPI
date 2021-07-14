using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackAPI.Models
{
    public class FeedbackEntity : TableEntity
    {
        public FeedbackEntity() { }

        public string username { get; set; }
        public string feedback { get; set; }
        public string feedbackTime { get; set; }
    }
}
