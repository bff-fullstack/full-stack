using System;
using System.Collections.Generic;
using REST.models;

namespace REST.Intefaces
{
    public class IUser
    {
        public string Client { get; set; }
        public string Key { get; set; }
        public int Privilege { get ; set; }
        public IUser(){

        }
    }
}
