using BasketCase.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCase.Infrastructure.Contexts
{
    public class BasketContextSeed
    {
        public static async Task SeedAsync(IMongoCollection<Product> mongoCollection)
        {
            bool exist = mongoCollection.Find(p => true).Any();
            if (!exist)
                await mongoCollection.InsertManyAsync(ProductData());
        }

        private static IEnumerable<Product> ProductData()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = new ObjectId("613ce8077d9b46580f8a5a3f"),
                    Name = "11'li Kırmızı Gül Çiçek Buketi",
                    Description = "Çiçeklerle birini şaşırtmak ya da sevindirmek çok keyifli değil midir? Herkes çiçek almayı sever, herkes onlarla mutlu olur. Güller de çiçek dünyasında romantikliği ile ve aşkı anlatmasıyla tanınan en şık çiçeklerden biridir. Kırmızı gül buketi; aşkı, tutkuyu ve romantizmi simgelerken sevdiklerinizi şımartmanızı sağlayacak!",
                    Code = "at4273",
                    Price = (decimal)79.99,
                    StockQuantity = 100,
                    MinimumStockQuantity = 10
                },
                new Product()
                {
                    Id = new ObjectId("613ce87aa4fd2ce91c7feadd"),
                    Name = "925 Ayar Gümüş Kanatlı Kalp Kolye",
                    Description = "Sevginin saflığını sembolize eden melek motifi, zarif ve ışıltılı taşlarla süslenen şık bir takıya dönüştü! Kişiselleştirilebilir kalp ve melek kolye, hem sevdikleriniz hem de kendiniz için göz dolduran bir hediye seçeneği.",
                    Code = "kc8955280",
                    Price = (decimal)99.99,
                    StockQuantity = 20,
                    MinimumStockQuantity = 5
                },
                new Product()
                {
                    Id = new ObjectId("613ce94c6ff6b192e174baee"),
                    Name = "Huawei MateBook D15 i3-10110U 8 GB 256 GB 15\" W10H Dizüstü Bilgisaya",
                    Description = "15.6 inçlik güzel IPS TamGörüş Ekranında kaybolun. %87 ekran / gövde oranıyla ve sadece 5.3 mm dar çerçevesiyle film izlemek, yaratıcı olmak ya da iş yapmak için birebir.",
                    Code = "kcm14209836",
                    Price = (decimal)4219.04,
                    StockQuantity = 10,
                    MinimumStockQuantity = 0
                },
                new Product()
                {
                    Id = new ObjectId("613ce9c9f7f973d7e605fcd1"),
                    Name = "Bubble Mum Kahve Kokulu 2 Li Set",
                    Description = "6x6 Ebatlarındadır. Kahve kokusu eklenmiştir. El yapımıdır 2 li set halinde satılmaktadır.",
                    Code = "kcm72635642",
                    Price = (decimal)49.99,
                    StockQuantity = 5,
                    MinimumStockQuantity = 5
                },
                new Product()
                {
                    Id = new ObjectId("613ce9d0324bf1e8e7da18e6"),
                    Name = "PROCSIN Güneş Kremi 50 ML İkili Paket",
                    Description = "ConnectProf © tarafından yayınlanmıştır.",
                    Code = "kcm45394365",
                    Price = (decimal)29.90,
                    StockQuantity = 0,
                    MinimumStockQuantity = 0
                }
            };
        }
    }
}