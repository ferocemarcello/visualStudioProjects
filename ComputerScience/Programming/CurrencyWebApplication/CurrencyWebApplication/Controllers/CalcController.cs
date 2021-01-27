using CurrencyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CurrencyWebApplication.Controllers
{
    public class CalcController : ApiController
    {
        [HttpGet]
        public int GetFixedNumber()
        {
            return 10;
        }
        [HttpGet]
        public int AddOne(int a)
        {
            return a + 1;
        }
        [HttpGet]
        public int AddTwo(int b)
        {
            return b + 2;
        }
        [HttpPut]
        [HttpGet]
        public User UserMaxAge(User u,User u2)
        {
            if (u2.GetAge() > u.GetAge()) return u2;
            else return u;
        }
    }
}
