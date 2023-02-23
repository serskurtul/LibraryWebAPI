using System;
using LibraryWebAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebAPI.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            if (!(Books?.Any() ?? true))
            {
                Seed();
            }
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Raitings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        private void Seed()
        {
            Books.AddRange(
                new Book()
                {
                    Id = 1,
                    Author = "Роберт Мартін",
                    Title = "Чиста архітектура",
                    Cover = "image",
                    Content = "Користуючись універсальними правилами архітектури програмного забезпечення, можна" +
                        " значно підвищити продуктивність праці розробників протягом усього життєвого циклу будь-якої" +
                        " програмної системи. Легендарний майстер програмного забезпечення Роберт К. Мартін («Дядечко Боб»)" +
                        " розкриває ці правила у своїй книжці «Чиста архітектура» і допомагає їх застосувати.",
                    Genre = "Наукова"
                },
                new Book()
                {
                    Id = 2,
                    Author = "Роберт Мартін",
                    Title = "Чистий код",
                    Cover = "image",
                    Content = "Навіть поганий програмний код може працювати. Однак якщо код не є «чистим»," +
                        " це завжди буде заважати розвитку проекту і компанії-розробника, віднімаючи значні ресурси на " +
                        "його підтримку і «приборкання». Ця книга присвячена хорошому програмуванню. У ній повно реальних " +
                        "прикладів коду. Прочитавши книгу, ви дізнаєтеся багато нового про коди. Більш того, ви навчитеся " +
                        "відрізняти хороший код від поганого. Ви дізнаєтеся, як писати хороший код і як перетворити поганий " +
                        "код у хороший.",
                    Genre = "Наукова"
                },
                new Book()
                {
                    Id = 3,
                    Author = "Емі Вебб",
                    Title = "Велика дев'ятка",
                    Cover = "image",
                    Content = "У цьому виданні Емі Вебб пояснює, що таке ШІ та яку роль" +
                        " відіграла Велика дев’ятка (Google, Amazon, Apple, IBM, Microsoft," +
                        " Facebook, Baidu, Alibaba, Tencent) у його розвитку; пропонує сценарії" +
                        " перебігу подій упродовж наступних 50 років; окреслює ризики переходу від" +
                        " штучного вузького інтелекту до сильного штучного інтелекту та штучного " +
                        "надрозуму; пропонує тактичні та стратегічні рішення проблем, які виникнуть" +
                        " за наведеними сценаріями, а також конкретний план перезавантаження сьогодення.",
                    Genre = "Наукова"
                },
                new Book()
                {
                    Id = 4,
                    Author = "Емі Вебб",
                    Title = "Досконала зброя",
                    Cover = "image",
                    Content = "Вражаюча оповідь про початки та перебіг застосувань кіберзброї, які " +
                        "кидають виклик балансу сил, що встановився у світі з часу винайдення атомної бомби. " +
                        "Побудована на великому обсязі інсайдерській інформації, вона посвячує читача у малопомітне," +
                        " але загрозливе для самих основ техногенної цивілізації протистояння у кіберпросторі. Автор " +
                        "веде нас через наради в Ситуаційній кімнаті Білого дому та дискусії в офісах підприємств " +
                        "Кремнієвої долини, через осідки російських, китайських чи північнокорейських хакерів, " +
                        "висвітлює діяльність спецслужб та підрозділів збройних сил. Ми знайдемо опис кібератак " +
                        "проти ядерних програм Ірану та Північної Кореї, енергетичної мережі України, нафтової " +
                        "компанії Saudi Aramco, корпорації Sony, банківських установ, компанії медичного страхування" +
                        " Anthem тощо, і усвідомимо, наскільки вразливі перед цим новим і дуже ефективним видом зброї.",
                    Genre = "Наукова"

                },
                new Book()
                {
                    Id = 5,
                    Author = "Рей Бредбері",
                    Title = "451° за Фаренгейтом",
                    Cover = "image",
                    Content = "Рей Бредбері – науковий фантаст, який окрім того ще й написав кілька томів " +
                        "зворушливих оповідань. Його роман «451 градус за Фаренгейтом» належить до одного з " +
                        "найвідоміших творів у доробку автора. Жанром твору «451 градус за Фаренгейтом» є " +
                        "роман-антиутопія. Книга Бредбері у майстерності написання не поступається визначним " +
                        "антиутопіям ХХ століття, як от «1984» Джорджа Орвелла та «О дивний світ новий» Олдоса " +
                        "Гакслі.\nРоман оповідає про світ, у якому існують спеціальні загони пожежників, які " +
                        "спалюють книги. Назва «451 градус за Фаренгейтом» теж не випадкова. 451 градус за " +
                        "Фаренгейтом – це температура спалювання паперу.",
                    Genre = "Художня"
                },
                new Book()
                {
                    Id = 6,
                    Author = "Бернар Вербер",
                    Title = "Імперія Ангелів",
                    Cover = "image",
                    Content = "У другому романі циклу \"Ангели\" один з найпопулярніших сучасних" +
                        " французьких письменників зі світовим ім'ям захопливо і з легким гумором," +
                        " перемежовуючи сюжетні перипетії з езотеричними знаннями та науковими даними," +
                        " описує світ ангелів. Тут Мікаелю Пенсону, знайомому читачам з першого роману" +
                        " циклу - \"Танатонавти\", доведеться випробувати на собі роль ангела-охоронця, " +
                        "що, втім, не завадить йому продовжити справу дослідника духовних світів, розпочату " +
                        "ще в земному житті.",
                    Genre = "Художня"
                });
            Raitings.AddRange(
                new Rating
                {
                    BookId = 1,
                    Id = 1,
                    Score = 3.6m
                },
                new Rating
                {
                    BookId = 2,
                    Id = 2,
                    Score = 3m
                },
                new Rating
                {
                    BookId = 3,
                    Id = 3,
                    Score = 4.81m
                },
                new Rating
                {
                    BookId = 4,
                    Id = 4,
                    Score = 2.68m
                },
                new Rating
                {
                    BookId = 5,
                    Id = 5,
                    Score = 3.01m
                },
                new Rating
                {
                    BookId = 6,
                    Id = 6,
                    Score = 4.83m
                }
            );
            Reviews.AddRange(
                new Review
                {
                    Id = 1,
                    BookId = 1,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 2,
                    BookId = 1,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 3,
                    BookId = 1,
                    Message = "",
                    Reviewer = ""
                },
                 new Review
                 {
                     Id = 4,
                     BookId = 1,
                     Message = "",
                     Reviewer = ""
                 },
                new Review
                {
                    Id = 5,
                    BookId = 1,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 6,
                    BookId = 1,
                    Message = "",
                    Reviewer = ""
                },
                 new Review
                 {
                     Id = 7,
                     BookId = 1,
                     Message = "",
                     Reviewer = ""
                 },
                new Review
                {
                    Id = 8,
                    BookId = 1,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 9,
                    BookId = 1,
                    Message = "",
                    Reviewer = ""
                },
                 new Review
                 {
                     Id = 10,
                     BookId = 1,
                     Message = "",
                     Reviewer = ""
                 },
                new Review
                {
                    Id = 11,
                    BookId = 1,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 12,
                    BookId = 2,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 13,
                    BookId = 2,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 14,
                    BookId = 2,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 15,
                    BookId = 2,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 16,
                    BookId = 2,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 17,
                    BookId = 2,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 18,
                    BookId = 2,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 19,
                    BookId = 2,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 20,
                    BookId = 2,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 21,
                    BookId = 2,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 22,
                    BookId = 2,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 23,
                    BookId = 2,
                    Message = "",
                    Reviewer = ""
                },
                new Review
                {
                    Id = 24,
                    BookId = 2,
                    Message = "",
                    Reviewer = ""
                }
            );
            SaveChanges();
        }
    }
}

