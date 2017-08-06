using System;
using System.Collections.Generic;
using REST.models;
using REST.Intefaces;
namespace REST.models
{
    public partial class Creds : IUser
    {
        public int? Id { get; set; }
        public string Client { get ; set; }
        public string Key { get ; set; }
        
    }
}
