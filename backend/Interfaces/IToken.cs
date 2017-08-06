using System;
using System.Collections.Generic;
using REST.models;

namespace REST.Intefaces
{
    public class IToken
    {
        public string Client { get; set; }
        public string Key { get; set; }
        public IToken(){

        }
    }
}
