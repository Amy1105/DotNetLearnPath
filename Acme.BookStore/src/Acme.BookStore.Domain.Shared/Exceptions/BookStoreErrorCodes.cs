using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BookStore.Exceptions
{
    public static class BookStoreErrorCodes
    {
        public const string Prefix = "BookStore";

        public static class Books
        {
            public const string NotFound = Prefix + ":0001";
            public const string InsufficientStock = Prefix + ":0002";
            public const string ISBNAlreadyExists = Prefix + ":0003";
        }

        public static class Orders
        {
            public const string InvalidStatus = Prefix + ":0101";
            public const string AlreadyPaid = Prefix + ":0102";
        }
    }
}
