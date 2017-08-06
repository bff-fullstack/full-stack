using System;
using System.Collections.Generic;
using REST.models;
using REST.Intefaces;
namespace REST.models
{
    public partial class Creds 
    {
        public int? Id { get; set; }
        public string Client { get ; set; }
        public string Key { get ; set; }
        public int Privilege { get ; set; }
    }
}
