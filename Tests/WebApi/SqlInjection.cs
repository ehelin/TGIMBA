using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimulatedCyberAttacks.attacks.web.rest
{
    public class WebApiTests
    {
        private Connect c = null;

        public WebApiTests(string pUrl)
        {
            //c = new Connect(pUrl);
        }

        //[TestMethod]
        //public async void TestProcessUser()
        //{
        //    string token = await ProcessUser("erichelin", "ILoveSilvia9");
        //    ReportResultString("", token, attackString, "ProcessUser(string, string)");
        //}


        //protected void ReportResultStringArray(string[] expected, string[] actual, string injectionValue, string method)
        //{
        //    if (actual != null && actual.Length >= 1 && !expected[0].Equals(actual[0]))
        //        Console.WriteLine("--Attack Succeeded! (Expected/Actual) (" + expected.ToString() + "/" + actual.ToString() + ")");
        //}
        //protected void ReportResultBool(bool expected, bool actual, string injectionValue, string method)
        //{
        //    if (!expected.Equals(actual))
        //        Console.WriteLine("--Attack Succeeded! (Expected/Actual) (" + expected.ToString() + "/" + actual.ToString() + ")");
        //}
        //protected void ReportResultString(string expected, string actual, string injectionValue, string method)
        //{
        //    if (!expected.Equals(actual))
        //        Console.WriteLine("--Attack Succeeded! (Expected/Actual) (" + expected + "/" + actual + ")");
        //}

        //private async Task<Object> RunInjectionAttack()
        //{
        //    Connect c = new Connect(this.Url);
        //    object result = null;

        //    foreach(string attackString in attackStrings)
        //    {
        //        System.Console.WriteLine("Running simulated attack for character '" + attackString + "'");

        //        string token = await ProcessUser(c, attackString);
        //        ReportResultString("", token, attackString, "ProcessUser(string, string)");

        //        System.Threading.Thread.Sleep(this._testStepInterval);   //Make output readable and not a blur :)

        //        bool registered = await ProcessRegistration(c, attackString);
        //        ReportResultBool(false, registered, attackString, "ProcessUserRegistration(string, string, string)");

        //        System.Threading.Thread.Sleep(this._testStepInterval);   //Make output readable and not a blur :)

        //        string[] bucketListItems = await GetBucketListItems(c, attackString);
        //        string[] expected = new string[]{"ERR_000002-Token Expired"};
        //        ReportResultStringArray(expected, bucketListItems, attackString, "GetBucketListItems(string, string, string)");

        //        System.Threading.Thread.Sleep(this._testStepInterval);   //Make output readable and not a blur :)

        //        string[] upsertResults = await Upsert(c, attackString);
        //        ReportResultStringArray(expected, upsertResults, attackString, "UpsertBucketListItem(string, string, string)");

        //        System.Threading.Thread.Sleep(this._testStepInterval);   //Make output readable and not a blur :)

        //        string[] deleteResults = await Delete(c, attackString);
        //        ReportResultStringArray(expected, deleteResults, attackString, "DeleteBucketListItem(int, string, string)");

        //        System.Threading.Thread.Sleep(this._testStepInterval);   //Make output readable and not a blur :)
        //    }

        //    Program.SimulatedInjectionAttackesComplete = true;

        //    return result;
        //}

        //private async Task<string> ProcessUser(Connect c, string attackString)
        //{
        //    string token = await c.ProcessUser(Utilities.EncodeClientBase64String(attackString), 
        //                                         Utilities.EncodeClientBase64String(attackString));

        //    return token;
        //}
        //private async Task<bool> ProcessRegistration(Connect c, string attackString)
        //{
        //    bool registered = await c.ProcessRegistration(Utilities.EncodeClientBase64String(attackString), 
        //                                                  Utilities.EncodeClientBase64String(attackString),
        //                                                  Utilities.EncodeClientBase64String(attackString));

        //    return registered;
        //}
        //private async Task<string[]> GetBucketListItems(Connect c, string attackString)
        //{
        //    string[] bucketListitems = await c.GetBucketListItems(Utilities.EncodeClientBase64String(attackString), 
        //                                                          Utilities.EncodeClientBase64String(attackString),
        //                                                          Utilities.EncodeClientBase64String(attackString));

        //    return bucketListitems;
        //}
        //private async Task<string[]> Upsert(Connect c, string attackString)
        //{
        //    string[] result = await c.Upsert(Utilities.EncodeClientBase64String(attackString), 
        //                                     Utilities.EncodeClientBase64String(attackString),
        //                                     Utilities.EncodeClientBase64String(attackString));

        //    return result;
        //}
        //private async Task<string[]> Delete(Connect c, string attackString)
        //{
        //    string[] result = await c.Delete(Utilities.EncodeClientBase64String(attackString), 
        //                                     Utilities.EncodeClientBase64String(attackString),
        //                                     Utilities.EncodeClientBase64String(attackString));

        //    return result;
        //}
    }
}
