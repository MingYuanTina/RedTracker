using System;
using Twilio;
class Example
{
    static void Main(string[] args)
    {
        // Find your Account Sid and Auth Token at twilio.com/user/account

        string AccountSid = "AC5f83bdb45f9177d65f3e57b3d6eb9316";
        string AuthToken = "870f844dc7f0bf00a4da78a41c110fd7";
        var twilio = new TwilioRestClient(AccountSid, AuthToken);

        var message = twilio.SendMessage("+12268940606", "+12269724002",
            "We have notified a community health worker. She will be in touch with you shortly. ");
        Console.WriteLine(message.Sid);
    }
}