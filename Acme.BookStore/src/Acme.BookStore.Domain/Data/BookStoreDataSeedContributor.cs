using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Acme.BookStore.Models;
namespace Acme.BookStore.Data
{
    internal class BookStoreDataSeedContributor : IDataSeedContributor, ITransientDependency
    {

        private readonly IRepository<Category, Guid> categoryRepository;
        private readonly IRepository<Book, Guid> bookRepository;
        private readonly IRepository<Author, Guid> authorsRepository;

        public BookStoreDataSeedContributor(IRepository<Author, Guid> authorsRepository, IRepository<Category, Guid> categoryRepository, IRepository<Book, Guid> bookRepository)
        {
            this.authorsRepository = authorsRepository;
            this.categoryRepository = categoryRepository;
            this.bookRepository = bookRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await categoryRepository.CountAsync() > 0)
            {
                return;
            }

            var pCategory = Category.Create(Guid.NewGuid(), "文学类", null, "文学类");
            var Category1 = Category.Create(Guid.NewGuid(), "小说", pCategory.CreatorId, "文学类-小说");
            var Category2 = Category.Create(Guid.NewGuid(), "散文", pCategory.CreatorId, "文学类-散文");
            var Category3 = Category.Create(Guid.NewGuid(), "诗歌", pCategory.CreatorId, "文学类-诗歌");
            var Category4 = Category.Create(Guid.NewGuid(), "戏剧", pCategory.CreatorId, "文学类-戏剧");
            var Category5 = Category.Create(Guid.NewGuid(), "纪实文学", pCategory.CreatorId, "文学类-纪实文学");

            var p2Category = Category.Create(Guid.NewGuid(), "专业类", null, "专业类");
            var Cate1 = Category.Create(Guid.NewGuid(), "教材", p2Category.CreatorId, "专业类-大学教科书");
            var Cate2 = Category.Create(Guid.NewGuid(), "技术手册", p2Category.CreatorId, "专业类-编程、医学指南");
            var Cate3 = Category.Create(Guid.NewGuid(), "著作", p2Category.CreatorId, "专业类-论文、研究报告");

            await categoryRepository.InsertManyAsync(new[] { pCategory, Category1, Category2, Category3, Category4, Category5,
                p2Category,Cate1,Cate2,Cate3
            });


            var author1 = Author.Create(Guid.NewGuid(), "施耐庵", new DateOnly(1993, 12, 15), "", "");
            var author2 = Author.Create(Guid.NewGuid(), "吴承恩", new DateOnly(1993, 12, 15), "", "");
            var author3 = Author.Create(Guid.NewGuid(), "罗贯中", new DateOnly(1993, 12, 15), "", "");
            var author4 = Author.Create(Guid.NewGuid(), "曹雪芹", new DateOnly(1993, 12, 15), "", "");

            var authorS1 = Author.Create(Guid.NewGuid(), "埃里克·马瑟斯", new DateOnly(1993, 12, 15), "", "");
            var authorS2 = Author.Create(Guid.NewGuid(), "布鲁斯·埃克尔", new DateOnly(1993, 12, 15), "", "");
            var authorS3 = Author.Create(Guid.NewGuid(), "Robert Sedgewick", new DateOnly(1993, 12, 15), "", "");
            var authorS4 = Author.Create(Guid.NewGuid(), "Robert C. Martin", new DateOnly(1993, 12, 15), "", "");

            await authorsRepository.InsertManyAsync(new[] { author1, author2, author3, author4, authorS1, authorS2, authorS3, authorS4 });

            var book1 = Book.Create(Guid.NewGuid(), "西游记", author2.Id, "", 159.6m, Category1.Id, 100);
            var book2 = Book.Create(Guid.NewGuid(), "水浒传", author1.Id, "", 159.6m, Category1.Id, 100);
            var book3 = Book.Create(Guid.NewGuid(), "红楼梦", author4.Id, "", 159.6m, Category1.Id, 100);
            var book4 = Book.Create(Guid.NewGuid(), "三国演义", author3.Id, "", 159.6m, Category1.Id, 100);

            var bookS1 = Book.Create(Guid.NewGuid(), "Python编程：从入门到实践（第3版）", authorS1.Id, "", 189m, Cate2.Id, 100);
            var bookS2 = Book.Create(Guid.NewGuid(), "On Java 中文版", authorS2.Id, "", 178m, Cate1.Id, 100);
            var bookS3 = Book.Create(Guid.NewGuid(), "算法（第4版）", authorS3.Id, "", 299.6m, Cate1.Id, 100);
            var bookS4 = Book.Create(Guid.NewGuid(), "代码整洁之道", authorS4.Id, "", 99.6m, Cate1.Id, 100);

            await bookRepository.InsertManyAsync(new[] { book1, book2, book3, book4, bookS1, bookS2, bookS3, bookS4 });
        }
    }

}