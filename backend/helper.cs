using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REST.models;
using System.Security.Cryptography;
using System.Text;

namespace REST
{
    public class Helper {
        public static string OneWayHash(string value){
            SHA512 hasher  = SHA512.Create();
            byte[] hashedBytes;

            hashedBytes= hasher.ComputeHash(Encoding.UTF8.GetBytes(value)) ;
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower(); 
        }
    }
}