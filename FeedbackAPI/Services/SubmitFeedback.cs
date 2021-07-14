using FeedbackAPI.Models;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackAPI.Services
{
    public class SubmitFeedback : ISubmitFeedback
    {
        public void PostFeedback(string username, string feedback)
        {

            var table = AuthTable();

            var feedbackTime = DateTime.Now.ToString();

            var success = CreateEntity(username, feedback, feedbackTime, table);

            if (success)
            {

            }
            else
            {

            }
        }

        public static CloudTable AuthTable()
        {
            string accountName = "unique841";
            string accountKey = "FaONSll3bRGGmeUGrmuXdSKYPbQqxQf8SmUFcGoFI6yh4NiM85+q5WGi+jgPYLp3ZSUbopEj1jWTp6K4Us3Czg==";
            try
            {
                StorageCredentials creds = new StorageCredentials(accountName, accountKey);
                CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);

                CloudTableClient client = account.CreateCloudTableClient();

                CloudTable table = client.GetTableReference("tblfeedback");

                return table;
            }
            catch
            {
                return null;
            }
        }

        private static bool CreateEntity(string username, string feedback, string feedbackTime, CloudTable table)
        {
            var newEntity = new FeedbackEntity()
            {
                PartitionKey = username,
                RowKey = Guid.NewGuid().ToString(),
                feedback = feedback,
                feedbackTime = feedbackTime
            };

            TableOperation insert = TableOperation.Insert(newEntity);

            try
            {
                table.Execute(insert);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
