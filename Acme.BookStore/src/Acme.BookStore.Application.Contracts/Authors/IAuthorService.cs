using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Author
{
    public  interface IAuthorService:IApplicationService
    {
       
        //public static Author Create(
        //    Guid id,
        //    string name,
        //    DateTime birthDate,
        //    string biography = null,
        //    string photoUrl = null)
        //{
        //    Check.NotNullOrWhiteSpace(name, nameof(name));

        //    var author = new Author
        //    {
        //        Id = id,
        //        Name = name,
        //        BirthDate = birthDate,
        //        Biography = biography,
        //        PhotoUrl = photoUrl,
        //        Books = new List<Book>()
        //    };

        //    return author;
        //}

        //public void UpdateInfo(
        //    string name,
        //    DateTime birthDate,
        //    string biography = null,
        //    string photoUrl = null)
        //{
        //    Check.NotNullOrWhiteSpace(name, nameof(name));

        //    Name = name;
        //    BirthDate = birthDate;
        //    Biography = biography;
        //    PhotoUrl = photoUrl;
        //}
    }
}
