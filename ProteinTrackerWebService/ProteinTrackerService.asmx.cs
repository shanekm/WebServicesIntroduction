namespace ProteinTrackerWebService
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    using ProteinTrackerWebService.Models;


    // TAKE FIVE - converting to WCF
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public interface IProteinTrackerService
    {
        [WebMethod(EnableSession = true)]
        int AddUser(string name, int goal);

        [WebMethod(EnableSession = true)]
        [SoapHeader("Authentication")]
        List<User> ListUsers();

        [WebMethod(Description = "Adds amount")]
        int AddProtein(int amount, int userId);
    }


    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]

    // WebService base class provides Session object and others
    // TAKE FIVE - WCF convertion, implementing interface
    public class ProteinTrackerService : WebService, IProteinTrackerService
    {
        // TAKE TWO -using repository

        // for SOAP Header
        #region Fields

        public AuthenticationHeader Authentication;

        private UserRepository repo = new UserRepository();

        #endregion

        // Web method lets us expose public method as service method

        // TAKE ONE - USING SESSION object
        // [WebMethod(Description = "Adds amount")]
        // public int AddProtein(int amount, int userId)
        // {
        // if (Session["user" + userId] == null)
        // {
        // return -1;
        // }
        // var user = (User)Session["user" + userId];
        // user.Total += amount;
        // Session["user" + userId] = user;
        // return user.Total;
        // }

        //// Enable session when using Session object
        // [WebMethod(EnableSession = true)]
        // public int AddUser(string name, int goal)
        // {
        // var userId = 0;
        // if (this.Session["userId"] != null)
        // {
        // userId = (int)this.Session["userId"];
        // }

        // this.Session["user" + userId] = new User { Goal = goal, Name = name, Total = 0, UserId = userId };
        // this.Session["userId"] = userId + 1;

        // return userId;
        // }

        // [WebMethod(EnableSession = true)]
        // public List<User> ListUsers()
        // {
        // var users = new List<User>();
        // var userId = 0;
        // if (this.Session["userId"] != null)
        // {
        // userId = (int)this.Session["userId"];
        // }
        // for (var i = 0; i < userId; i++)
        // {
        // users.Add((User)this.Session["user" + i]);
        // }

        // return users;
        // }

        // TAKE TWO - using repository
        #region Public Methods and Operators

        // Converting to interface, taking out Attributes
        //[WebMethod(Description = "Adds amount")]
        public int AddProtein(int amount, int userId)
        {
            throw new Exception("test exception here");

            // TAKE THREE - ASYNChRONOUS calls
            Thread.Sleep(3000); // added delay to do asynch test

            var user = this.repo.GetById(userId);
            if (user == null)
            {
                return -1;
            }

            user.Total += amount;
            this.repo.Save(user);
            return user.Total;
        }

        // Enable session when using Session object
        //[WebMethod(EnableSession = true)]
        public int AddUser(string name, int goal)
        {
            var user = new User { Goal = goal, Name = name, UserId = 0 };
            this.repo.Add(user);

            return user.UserId;
        }

        // Adding SOAP Header
        //[WebMethod(EnableSession = true)]
        //[SoapHeader("Authentication")]
        public List<User> ListUsers()
        {
            if (this.Authentication == null || this.Authentication.UserName != "Bob"
                || this.Authentication.Password != "Pass")
            {
                throw new Exception("Bad credentials");
            }

            return new List<User>(this.repo.GetAll());
        }

        #endregion

        public class AuthenticationHeader : SoapHeader
        {
            #region Fields

            public string Password;

            public string UserName;

            #endregion
        }
    }
}